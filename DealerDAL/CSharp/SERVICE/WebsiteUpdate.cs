// CREATED BY: Nathan Townsend
// CREATED DATE: 12/29/2014
// DO NOT MODIFY THIS CODE
// CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
// GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using DealerDAL.DO;

namespace DealerDAL.Service
{


    /// <summary>
    /// Provides data access methods for the WebsiteUpdate database table
    /// </summary>
    /// <remarks>
    public class WebsiteUpdateService: IWebsiteUpdateService
    {

        private string pid;

        /// <summary>
        /// Creates a new instance of the WebsiteUpdate service using the named connection string
        /// </summary>
        public WebsiteUpdateService(string ConnectionStringName)
        {
            pid = ConnectionStringName;
        }


        /// <summary>
        /// Creates a new WebsiteUpdate record
        /// </summary>
        public int Create(WebsiteUpdateDO DO)
        {
            return Create(null); 
        }
        

        /// <summary>
        /// Creates a new WebsiteUpdate record
        /// </summary>
        public int Create(WebsiteUpdateDO DO, DalapiTransaction Transaction)
        {
            SqlParameter _VersionInstalled = new SqlParameter("VersionInstalled", SqlDbType.Int);
            SqlParameter _UpdateDescription = new SqlParameter("UpdateDescription", SqlDbType.VarChar);
            SqlParameter _PreviousVersion = new SqlParameter("PreviousVersion", SqlDbType.Int);
            SqlParameter _InstalledByUserName = new SqlParameter("InstalledByUserName", SqlDbType.VarChar);
            SqlParameter _InstallDate = new SqlParameter("InstallDate", SqlDbType.DateTime);
            
            _VersionInstalled.Value = DO.VersionInstalled;
            _UpdateDescription.Value = DO.UpdateDescription;
            _PreviousVersion.Value = DO.PreviousVersion;
            _InstalledByUserName.Value = DO.InstalledByUserName;
            _InstallDate.Value = DO.InstallDate;
            
            SqlParameter[] _params = new SqlParameter[] {
                _VersionInstalled,
                _UpdateDescription,
                _PreviousVersion,
                _InstalledByUserName,
                _InstallDate
            };


            return DataCommon.ExecuteScalar(String.Format("[{0}].[WebsiteUpdate_Insert]", pid), _params, pid, Transaction);
            
        }


        /// <summary>
        /// Updates a WebsiteUpdate record and returns the number of records affected
        /// </summary>
        public int Update(WebsiteUpdateDO DO)
        {
             return Update(DO, null);
        }


        /// <summary>
        /// Updates a WebsiteUpdate record and returns the number of records affected
        /// </summary>
        public int Update(WebsiteUpdateDO DO, DalapiTransaction Transaction)
        {
            SqlParameter _WebsiteUpdateId = new SqlParameter("WebsiteUpdateId", SqlDbType.Int);
            SqlParameter _VersionInstalled = new SqlParameter("VersionInstalled", SqlDbType.Int);
            SqlParameter _UpdateDescription = new SqlParameter("UpdateDescription", SqlDbType.VarChar);
            SqlParameter _PreviousVersion = new SqlParameter("PreviousVersion", SqlDbType.Int);
            SqlParameter _InstalledByUserName = new SqlParameter("InstalledByUserName", SqlDbType.VarChar);
            SqlParameter _InstallDate = new SqlParameter("InstallDate", SqlDbType.DateTime);
            
            _WebsiteUpdateId.Value = DO.WebsiteUpdateId;
            _VersionInstalled.Value = DO.VersionInstalled;
            _UpdateDescription.Value = DO.UpdateDescription;
            _PreviousVersion.Value = DO.PreviousVersion;
            _InstalledByUserName.Value = DO.InstalledByUserName;
            _InstallDate.Value = DO.InstallDate;
            
            SqlParameter[] _params = new SqlParameter[] {
                _WebsiteUpdateId,
                _VersionInstalled,
                _UpdateDescription,
                _PreviousVersion,
                _InstalledByUserName,
                _InstallDate
            };

            return DataCommon.ExecuteScalar(String.Format("[{0}].[WebsiteUpdate_Update]", pid), _params, pid, Transaction);
        }


        /// <summary>
        /// Deletes a WebsiteUpdate record
        /// </summary>
        public int Delete(WebsiteUpdateDO DO)
        {
            return Delete(DO, null);
        }

        /// <summary>
        /// Deletes a WebsiteUpdate record
        /// </summary>
        public int Delete(WebsiteUpdateDO DO, DalapiTransaction Transaction)
        {
            SqlParameter _WebsiteUpdateId = new SqlParameter("WebsiteUpdateId", SqlDbType.Int);
            
            _WebsiteUpdateId.Value = DO.WebsiteUpdateId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _WebsiteUpdateId
            };


            return DataCommon.ExecuteScalar(String.Format("[{0}].[WebsiteUpdate_Delete]", pid), _params, pid, Transaction);
        }


        /// <summary>
        /// Gets all WebsiteUpdate records
        /// </summary>
        public WebsiteUpdateDO[] GetAll()
        {

            SafeReader sr = DataCommon.ExecuteSafeReader(String.Format("[{0}].[WebsiteUpdate_GetAll]", pid), new SqlParameter[] { }, pid);
            
            List<WebsiteUpdateDO> objs = new List<WebsiteUpdateDO>();
            
            while(sr.Read()){

                WebsiteUpdateDO obj = new WebsiteUpdateDO();
                
                obj.WebsiteUpdateId = sr.GetInt32(sr.GetOrdinal("WebsiteUpdateId"));
                obj.VersionInstalled = sr.GetInt32(sr.GetOrdinal("VersionInstalled"));
                obj.UpdateDescription = sr.GetString(sr.GetOrdinal("UpdateDescription"));
                obj.PreviousVersion = sr.GetInt32(sr.GetOrdinal("PreviousVersion"));
                obj.InstalledByUserName = sr.GetString(sr.GetOrdinal("InstalledByUserName"));
                obj.InstallDate = sr.GetDateTime(sr.GetOrdinal("InstallDate"));
                


                objs.Add(obj);
            }

            return objs.ToArray();
        }


        /// <summary>
        /// Selects WebsiteUpdate records by PK
        /// </summary>
        public WebsiteUpdateDO[] GetByPK(Int32 WebsiteUpdateId)
        {

            SqlParameter _WebsiteUpdateId = new SqlParameter("WebsiteUpdateId", SqlDbType.Int);
			
            _WebsiteUpdateId.Value = WebsiteUpdateId;
			
            SqlParameter[] _params = new SqlParameter[] {
                _WebsiteUpdateId
            };


            SafeReader sr = DataCommon.ExecuteSafeReader(String.Format("[{0}].[WebsiteUpdate_GetByPK]", pid), _params, pid);


            List<WebsiteUpdateDO> objs = new List<WebsiteUpdateDO>();
			
            while(sr.Read())
            {
                WebsiteUpdateDO obj = new WebsiteUpdateDO();
				
                obj.WebsiteUpdateId = sr.GetInt32(sr.GetOrdinal("WebsiteUpdateId"));
                obj.VersionInstalled = sr.GetInt32(sr.GetOrdinal("VersionInstalled"));
                obj.UpdateDescription = sr.GetString(sr.GetOrdinal("UpdateDescription"));
                obj.PreviousVersion = sr.GetInt32(sr.GetOrdinal("PreviousVersion"));
                obj.InstalledByUserName = sr.GetString(sr.GetOrdinal("InstalledByUserName"));
                obj.InstallDate = sr.GetDateTime(sr.GetOrdinal("InstallDate"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }




        /// <summary>
        /// Truncates the WebsiteUpdate Table
        /// </summary>
        public void Truncate()
        {
            Truncate(null);
        }


        /// <summary>
        /// Truncates the WebsiteUpdate Table
        /// </summary>
        public void Truncate(DalapiTransaction Transaction)
        {
            DataCommon.TruncateTable(pid, "WebsiteUpdate", Transaction);
        }

    }
}