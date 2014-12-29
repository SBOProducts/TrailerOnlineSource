using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using DealerDAL.DO;
using DealerDAL;
using DealerDAL.Service;

namespace Dealer.Core
{
    public class SelfUpdate
    {
        /// <summary>
        /// A complete list of all updates including those already run
        /// </summary>
        List<UpdatePackage> _updatePackages = new List<UpdatePackage>();
        string _userName;


        /// <summary>
        /// Creates a new instance of the self update class
        /// </summary>
        /// <param name="UserName">The user name of the person initiating this update</param>
        public SelfUpdate(string UserName)
        {
            _userName = UserName;
            LoadPackages();
        }


        /// <summary>
        /// Loads the update packages from the update folder
        /// </summary>
        void LoadPackages()
        {
            foreach (string folder in Directory.GetDirectories(UpdatePackageDirectory))
            {
                UpdatePackage package = new UpdatePackage(folder, CurrentVersion, _userName);
                _updatePackages.Add(package);
            }
        }


        /// <summary>
        /// The directory that contains the update packages
        /// </summary>
        public string UpdatePackageDirectory { get { return HttpContext.Current.Server.MapPath("~/Updates"); } }


        /// <summary>
        /// The current version of the application
        /// </summary>
        public int CurrentVersion { get { return Convert.ToInt32(ConfigurationManager.AppSettings["Version"]); } }


        /// <summary>
        /// All packages that have already been installed
        /// </summary>
        public List<UpdatePackage> InstalledPackages { get { return _updatePackages.Where(u => u.Version <= CurrentVersion).ToList(); } }


        /// <summary>
        /// All packages that have not already been installed
        /// </summary>
        public List<UpdatePackage> InstallablePackages { get { return _updatePackages.Where(u => u.Version > CurrentVersion).ToList(); } }


        
    }



    /// <summary>
    /// Contains information needed to perform a website update
    /// </summary>
    public class UpdatePackage
    {
        string _packagePath;
        int _previousVersion;
        string _installedByUser;


        /// <summary>
        /// Loads the update package at the specified folder
        /// </summary>
        /// <param name="UpdatePackagePath"></param>
        public UpdatePackage(string UpdatePackagePath, int CurrentWebsiteVersion, string InstalledByUserName)
        {
            _packagePath = UpdatePackagePath;
            _previousVersion = CurrentWebsiteVersion;
            _installedByUser = InstalledByUserName;
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


        public UpdateResults RunWebsiteUpdate()
        {
            UpdateResults results = new UpdateResults(this);

            using (DalapiTransaction transaction = new DalapiTransaction("dbo"))
            {
                try
                {
                    // create the summary object
                    results.UpdateSummary = CreateWebsiteUpdateSummaryData(transaction);

                    // add log entry for initiating the update

                    // backup and replace files including views, css, js, images, binary, etc

                    // run sql scripts

                    // update version in web.config


                    transaction.Commit();
                    results.Successful = true;
                    results.Message = "The update succeeded!";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    results.Successful = false;
                    results.Message = ex.Message;
                }
            }

            return results;
        }


        /// <summary>
        /// Crates a summary record of this update in the database
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        WebsiteUpdateDO CreateWebsiteUpdateSummaryData(DalapiTransaction transaction)
        {
            // crate the summary data object
            WebsiteUpdateDO summary = new WebsiteUpdateDO() { InstallDate = DateTime.Now, InstalledByUserName = _installedByUser, PreviousVersion = _previousVersion, UpdateDescription = Description, VersionInstalled = Version };

            // save the summary data to the database using a transaction
            WebsiteUpdateService websiteUpdate = new WebsiteUpdateService("dbo");
            summary.WebsiteUpdateId = websiteUpdate.Create(summary, transaction);

            return summary;
        }

    }



    /// <summary>
    /// Provides information about an update after it has been performed
    /// </summary>
    public class UpdateResults
    {
        public UpdateResults(UpdatePackage Package)
        {
            UpdateLog = new List<WebsiteUpdateLogDO>();
        }

        /// <summary>
        /// Whether or not the update was successful
        /// </summary>
        public bool Successful { get; set; }

        /// <summary>
        /// A message associated with the update
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The update installation package
        /// </summary>
        public UpdatePackage UpdatePackage { get; set; }

        /// <summary>
        /// The summary of the update
        /// </summary>
        public WebsiteUpdateDO UpdateSummary { get; set; }

        /// <summary>
        /// A detailed log of the update actions
        /// </summary>
        public List<WebsiteUpdateLogDO> UpdateLog { get; set; }
    }
}