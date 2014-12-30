using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using DealerDAL.DO;
using DealerDAL;
using DealerDAL.Service;
using log4net;
using System.Xml;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Dealer.Core
{

    /// <summary>
    /// The status of an updat
    /// </summary>
    public enum UpdateStatus
    {
        Succeeded,
        Failed
    }

    /// <summary>
    /// Contains the results from an update operation
    /// </summary>
    public class UpdateResult
    {

        /// <summary>
        /// The status of the update
        /// </summary>
        public UpdateStatus Status { get; set; }


    }

    
    /// <summary>
    /// Provides the ability to update a website based on contents of the update folder
    /// </summary>
    public class WebsiteUpdater
    {

        private ILog logger = LogManager.GetLogger(typeof(WebsiteUpdater));
        List<UpdatePackage> _updatePackages = new List<UpdatePackage>();
        string _userName = HttpContext.Current.User.Identity.Name;


        /// <summary>
        /// Creates a new instance of the self update class
        /// </summary>
        /// <param name="UserName">The user name of the person initiating this update</param>
        public WebsiteUpdater()
        {
            LoadPackages();
        }


        /// <summary>
        /// Loads the update packages from the update folder
        /// </summary>
        void LoadPackages()
        {
            foreach (string folder in Directory.GetDirectories(UpdatePackageDirectory))
            {
                UpdatePackage package = new UpdatePackage(folder);
                _updatePackages.Add(package);
            }
        }


        /// <summary>
        /// The directory that contains the update packages
        /// </summary>
        public static string UpdatePackageDirectory { get { return HttpContext.Current.Server.MapPath("~/Updates"); } }


        /// <summary>
        /// The current version of the application
        /// </summary>
        public static int CurrentVersion { get { return Convert.ToInt32(ConfigurationManager.AppSettings["Version"]); } }


        /// <summary>
        /// All packages that have already been installed
        /// </summary>
        public List<UpdatePackage> InstalledPackages { get { return _updatePackages.Where(u => u.Version <= CurrentVersion).ToList(); } }


        /// <summary>
        /// All packages that have not been installed yet
        /// </summary>
        public List<UpdatePackage> AvailableUpdates { get { return _updatePackages.Where(u => u.Version > CurrentVersion).ToList(); } }


        /// <summary>
        /// If there are any updates available
        /// </summary>
        public static bool UpdatesAvailable
        {
            get
            {
                List<int> UpdatePackages = new List<int>();

                foreach (string folder in Directory.GetDirectories(UpdatePackageDirectory))
                {
                    DirectoryInfo info = new DirectoryInfo(folder);
                    int version = Convert.ToInt32(info.Name);
                    UpdatePackages.Add(version);
                }

                return UpdatePackages.Any(version => version > CurrentVersion);
            }
        }


        /// <summary>
        /// Run all available updates
        /// </summary>
        public void RunUpdates()
        {
            int installedVersion = CurrentVersion;

            foreach (UpdatePackage package in AvailableUpdates)
            {
                UpdateResult result = RunUpdate(package);

                if (result.Status == UpdateStatus.Failed)
                    break;

                installedVersion = package.Version; 
            }

            if (installedVersion != CurrentVersion)
                UpdateConfiguredVersion(installedVersion);
        }


        /// <summary>
        /// Updates the version in the web.config file
        /// </summary>
        /// <param name="newVersion"></param>
        void UpdateConfiguredVersion(int newVersion)
        {

            string webConfigPath = HttpContext.Current.Server.MapPath("~/web.config");

            try
            {
                string content = File.ReadAllText(webConfigPath);
                Regex tagRe = new Regex("<add key=\"Version\" value=\"\\d{8}\" />");
                string tag = tagRe.Match(content).Value;
                Regex versionRe = new Regex("\\d{8}");
                string currentVersion = versionRe.Match(tag).Value;

                string newTag = tag.Replace(currentVersion, newVersion.ToString());
                content = content.Replace(tag, newTag);
                File.WriteAllText(webConfigPath, content);
            }
            catch (Exception ex)
            {
                logger.Error("Could not update web.config file located at " + webConfigPath, ex);
                throw ex;
            }
        }


        /// <summary>
        /// Runs an update package
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        UpdateResult RunUpdate(UpdatePackage package)
        {
            using (DalapiTransaction transaction = new DalapiTransaction("dbo"))
            {
                try
                {
                    // record the updata operation
                    WebsiteUpdateDO updateData = CreateUpdateSummary(transaction, package);

                    // run each action
                    for(int i = 0; i<package.UpdateActions.Count; i++)
                    {
                        IWebsiteUpdateAction action = package.UpdateActions[i];
                        action.MakeUpdate(transaction);

                        // record the update action
                        LogUpdateActivity(transaction, action, updateData, i);
                    }

                    // once all updates have run commit the transaction
                    transaction.Commit();
                    return new UpdateResult() { Status = UpdateStatus.Succeeded };
                }
                catch (Exception ex)
                {
                    logger.Error("Run Update failed for version " + package.Version.ToString(), ex);
                    RollbackUpdates(package);
                    transaction.Rollback();
                    return new UpdateResult() { Status = UpdateStatus.Failed };
                }
            }
        }


        /// <summary>
        /// Creates a summary record of the update in the dababase
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        WebsiteUpdateDO CreateUpdateSummary(DalapiTransaction transaction, UpdatePackage package)
        {
            // create a record of the update
            IWebsiteUpdateService updateService = new WebsiteUpdateService("dbo");
            WebsiteUpdateDO updateData = new WebsiteUpdateDO() { InstallDate = DateTime.Now, UpdateDescription = package.Description, VersionInstalled = package.Version };
            updateData.WebsiteUpdateId = updateService.Create(updateData, transaction);
            return updateData;
        }


        /// <summary>
        /// Creates a log entry for the updata action
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="action"></param>
        /// <param name="updateData"></param>
        void LogUpdateActivity(DalapiTransaction transaction, IWebsiteUpdateAction action, WebsiteUpdateDO updateData, int Sequence)
        {
            // add a log entry for the action
            IWebsiteUpdateLogService logService = new WebsiteUpdateLogService("dbo");
            WebsiteUpdateLogDO logData = new WebsiteUpdateLogDO() { ActionType = action.GetType().ToString(), InstallSequence = Sequence, Message = action.Message, WebsiteUpdateId = updateData.WebsiteUpdateId };
            logService.Create(logData, transaction);
        }


        /// <summary>
        /// Rolls an update back to the previous condition
        /// </summary>
        /// <param name="package"></param>
        void RollbackUpdates(UpdatePackage package)
        {
            // roll back file updates first
            foreach (IWebsiteUpdateAction action in package.UpdateActions.Where(p => p.HasUpdateBeenRun == true))
            {
                if(action.GetType() == typeof(WebsiteFileUpdate))
                    action.UndoUpdate();
            }

            // roll back folder updates next (if the folder is rolled back before the file an exception will be thrown)
            foreach (IWebsiteUpdateAction action in package.UpdateActions.Where(p => p.HasUpdateBeenRun == true))
            {
                if (action.GetType() == typeof(WebsiteFolderUpdate))
                    action.UndoUpdate();
            }

            // There is no need to rollback SqlScript updates since all changes occur within a transaction that will be rolled back

            logger.Warn("Rollback completed for package " + package.Version.ToString());
            
        }

    }



    /// <summary>
    /// Contains information needed to perform a website update
    /// </summary>
    public class UpdatePackage
    {
        private ILog logger = LogManager.GetLogger(typeof(UpdatePackage));
        string _packagePath;
        List<IWebsiteUpdateAction> _updates = new List<IWebsiteUpdateAction>();


        /// <summary>
        /// Loads the update package at the specified folder
        /// </summary>
        /// <param name="UpdatePackagePath"></param>
        public UpdatePackage(string UpdatePackagePath)
        {
            _packagePath = UpdatePackagePath;
            LoadUpdates();
        }


        /// <summary>
        /// Gets the version of the update YYMMDDXX: Year, Month, Day, Version
        /// </summary>
        public int Version 
        { 
            get 
            {
                DirectoryInfo info = new DirectoryInfo(_packagePath);
                return Convert.ToInt32(info.Name);
            } 
        }


        /// <summary>
        /// Gets the html formatted description of this update
        /// </summary>
        public string Description
        {
            get
            {
                string descriptionFilePath = Path.Combine(_packagePath, "Description.txt");
                if (File.Exists(descriptionFilePath))
                    return File.ReadAllText(descriptionFilePath);
                else
                    return "We're sorry, a description of this update could not be found.";
            }
        }


        /// <summary>
        /// A list of the actions this update provides
        /// </summary>
        public List<IWebsiteUpdateAction> UpdateActions { get { return _updates; } }


        #region Load Updates

        /// <summary>
        /// Load the updates
        /// </summary>
        void LoadUpdates()
        {
            string fileFolder = Path.Combine(_packagePath, "Files");
            LoadFileUpdates(fileFolder);

            LoadSqlUpdates();
        }


        /// <summary>
        /// Loads the file updates to be performed
        /// </summary>
        /// <param name="Folder"></param>
        /// <param name="transaction"></param>
        void LoadFileUpdates(string Folder)
        {
            // create an update action for each file
            foreach (string file in Directory.GetFiles(Folder))
            {
                // do not include backup files
                if (!file.Contains(".backup."))
                {
                    IWebsiteUpdateAction FileUpdate = new WebsiteFileUpdate(file);
                    _updates.Add(FileUpdate);
                }
            }

            // repeat for every subfolder
            foreach (string folder in Directory.GetDirectories(Folder))
            {
                // add a folder update if necessary
                WebsiteFolderUpdate FolderUpdate = new WebsiteFolderUpdate(folder);
                if (FolderUpdate.IsUpdateNeeded)
                    _updates.Add(FolderUpdate as IWebsiteUpdateAction);

                LoadFileUpdates(folder);
            }
        }


        /// <summary>
        /// Loads the database updates to be performed
        /// </summary>
        void LoadSqlUpdates()
        {
            string scriptsFolder = Path.Combine(_packagePath, "Scripts");
            foreach (string file in Directory.GetFiles(scriptsFolder))
            {
                IWebsiteUpdateAction update = new SqlScriptUpdate(file);
                _updates.Add(update);
            }
        }

        #endregion

    }


    /// <summary>
    /// Performs an update to the database
    /// </summary>
    public class SqlScriptUpdate : IWebsiteUpdateAction
    {
        private ILog logger = LogManager.GetLogger(typeof(SqlScriptUpdate));
        string _scriptFilePath;

        public SqlScriptUpdate(string ScriptFilePath)
        {
            _scriptFilePath = ScriptFilePath;
        }

        /// <summary>
        /// The contents of the sql query
        /// </summary>
        public string SqlQuery { get { return File.ReadAllText(ScriptFilePath); } }


        /// <summary>
        /// Make the update to the database
        /// </summary>
        /// <param name="transaction"></param>
        public void MakeUpdate(DalapiTransaction transaction)
        {
            try
            {
                HasUpdateBeenRun = true;
                using (SqlCommand cmd = new SqlCommand(SqlQuery, transaction.Connection))
                {
                    cmd.Transaction = transaction.Transaction;
                    cmd.ExecuteNonQuery();
                    Message = "Database update succeeded";
                    Successful = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Database update failed on script file " + ScriptFilePath, ex);
                Message = "Database update failed";
                Successful = false;
                throw ex;
            }
        }


        
        public void UndoUpdate()
        {
            // this is accomplished with the sql transaction, no action needed
        }

        /// <summary>
        /// The location of the script file 
        /// </summary>
        public string ScriptFilePath { get { return _scriptFilePath; } }


        /// <summary>
        /// If the update was successful
        /// </summary>
        public bool Successful { get; set; }


        /// <summary>
        /// A message associated with the update
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        /// If the update has been run yet
        /// </summary>
        public bool HasUpdateBeenRun { get; set; }
    }
    


    /// <summary>
    /// Performs a folder update to ensure the folder exists
    /// </summary>
    public class WebsiteFolderUpdate : IWebsiteUpdateAction
    {
        private ILog logger = LogManager.GetLogger(typeof(WebsiteFolderUpdate));
        string _sourceFolderPath;
        string _root = HttpContext.Current.Server.MapPath("~/");

        public WebsiteFolderUpdate(string SourceFolderPath)
        {
            _sourceFolderPath = SourceFolderPath;
        }

        /// <summary>
        /// Create the folder
        /// </summary>
        public void MakeUpdate(DalapiTransaction transaction)
        {
            try
            {
                HasUpdateBeenRun = true;
                Directory.CreateDirectory(TargetFolderPath);
                Successful = true;
                Message = "Created the directory " + TargetFolderPath;
            }
            catch (Exception ex)
            {
                Successful = false;
                Message = "Could not create the directory " + TargetFolderPath;
                logger.Error(Message, ex);
                throw ex;
            }
            
        }


        /// <summary>
        /// Remove the folder
        /// </summary>
        public void UndoUpdate()
        {
            try
            {
                if (Directory.Exists(TargetFolderPath))
                    Directory.Delete(TargetFolderPath);
            }
            catch (Exception ex)
            {
                logger.Error("Delete failed for " + TargetFolderPath, ex);
            }
        }

        /// <summary>
        /// Is an update needed
        /// </summary>
        public bool IsUpdateNeeded
        {
            get
            {
                return !Directory.Exists(TargetFolderPath);
            }
        }


        /// <summary>
        /// The source folder
        /// </summary>
        public string SourceFolderPath { get { return _sourceFolderPath; } }


        /// <summary>
        /// The full path to the folder that is beind deployed
        /// </summary>
        public string TargetFolderPath
        {
            get
            {
                string token = @"\Files\";
                int index = SourceFolderPath.IndexOf(token);
                string suffix = SourceFolderPath.Substring(index + token.Length);
                return Path.Combine(_root, suffix);
            }
        }


        /// <summary>
        /// If the update was successful
        /// </summary>
        public bool Successful { get; set; }


        /// <summary>
        /// A message associated with the update
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        /// If the update has been run yet
        /// </summary>
        public bool HasUpdateBeenRun { get; set; }
    }


    /// <summary>
    /// Performs a file update by making a copy of the original file and replacing it with the new file
    /// </summary>
    public class WebsiteFileUpdate : IWebsiteUpdateAction
    {
        private ILog logger = LogManager.GetLogger(typeof(WebsiteFileUpdate));
        string _sourceFilePath;
        string _root = HttpContext.Current.Server.MapPath("~/");

        public WebsiteFileUpdate(string SourcePath)
        {
            _sourceFilePath = SourcePath;
            HasUpdateBeenRun = false;
        }

        /// <summary>
        /// The full path to the source file on the web server hard drive
        /// </summary>
        private string SourceFilePath { get { return _sourceFilePath; } }
        
        /// <summary>
        /// The full path to the file that is being replaced
        /// </summary>
        private string TargetFilePath
        {
            get
            {
                string token = @"\Files\";
                int index = SourceFilePath.IndexOf(token);
                string suffix = SourceFilePath.Substring(index + token.Length);
                return Path.Combine(_root, suffix);
            }
        }

        /// <summary>
        /// The full path to the backup of the target file
        /// </summary>
        private string BackupFilePath
        {
            get
            {
                string ext = Path.GetExtension(SourceFilePath);
                string newExt = ".backup" + ext;
                return SourceFilePath.Replace(ext, newExt);
            }
        }


        /// <summary>
        /// Updates the file with the new version
        /// </summary>
        public void MakeUpdate(DalapiTransaction transaction)
        {
            try
            {
                HasUpdateBeenRun = true;

                // remove the existing backup file if one exists
                if (File.Exists(BackupFilePath))
                    File.Delete(BackupFilePath);

                // make a backup of the target file and remove the current version
                if (File.Exists(TargetFilePath))
                {
                    File.Copy(TargetFilePath, BackupFilePath);
                    File.Delete(TargetFilePath);
                }

                // distribute the new file 
                File.Copy(SourceFilePath, TargetFilePath);

                Successful = true;
                Message = string.Format("Updated file {0}", TargetFilePath);

            }
            catch (Exception ex)
            {
                Successful = false;
                Message = String.Format("The file could not be updated: " + TargetFilePath);
                logger.Error(Message, ex);
                throw ex;
            }
        }


        /// <summary>
        /// Restores the original file version
        /// </summary>
        public void UndoUpdate()
        {
            try
            {
                HasUpdateBeenRun = true;

                // delete the new file
                if (File.Exists(TargetFilePath))
                    File.Delete(TargetFilePath);

                // if a backup exists then restore it and delete
                if (File.Exists(BackupFilePath))
                {
                    File.Copy(BackupFilePath, TargetFilePath);
                    File.Delete(BackupFilePath);
                }

                Successful = true;
                Message = string.Format("Restored file {0}", Path.GetFileName(SourceFilePath));
            }
            catch (Exception ex)
            {
                Successful = false;
                Message = string.Format("Could not restore file {0}", Path.GetFileName(SourceFilePath));
                logger.Error(Message, ex);
                throw ex;
            }
        }


        /// <summary>
        /// If the update was successful
        /// </summary>
        public bool Successful { get; set; }


        /// <summary>
        /// A message associated with the update
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        /// If the update has been run yet
        /// </summary>
        public bool HasUpdateBeenRun { get; set; }
    }


    /// <summary>
    /// The interface for website update activities
    /// </summary>
    public interface IWebsiteUpdateAction
    {
        void MakeUpdate(DalapiTransaction transaction);

        void UndoUpdate();

        bool Successful { get; set; }

        string Message { get; set;}

        bool HasUpdateBeenRun { get; set; }
        
    }



}