// CREATED BY: Nathan Townsend
// CREATED DATE: 12/30/2014
// DO NOT MODIFY THIS CODE
// CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
// GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using DealerDAL.DAL;
using DealerDAL.DO;

namespace DealerDAL.DAL
{
    /// <summary>
    /// Provides data access methods for the WebsiteUpdate database table
    /// </summary>
    /// <remarks>
    public partial class WebsiteUpdate
    {

        /// <summary>
        /// Creates a new WebsiteUpdate record
        /// </summary>
        public static int Create(WebsiteUpdateDO DO)
        {
            return Create(null); 
        }
        

        /// <summary>
        /// Creates a new WebsiteUpdate record
        /// </summary>
        public static int Create(WebsiteUpdateDO DO, DalapiTransaction Transaction)
        {
            SqlParameter _VersionInstalled = new SqlParameter("VersionInstalled", SqlDbType.Int);
            SqlParameter _UpdateDescription = new SqlParameter("UpdateDescription", SqlDbType.VarChar);
            SqlParameter _InstallDate = new SqlParameter("InstallDate", SqlDbType.DateTime);
            
            _VersionInstalled.Value = DO.VersionInstalled;
            _UpdateDescription.Value = DO.UpdateDescription;
            _InstallDate.Value = DO.InstallDate;
            
            SqlParameter[] _params = new SqlParameter[] {
                _VersionInstalled,
                _UpdateDescription,
                _InstallDate
            };

            string pid = ConfigurationManager.AppSettings["PID"];

            return DataCommon.ExecuteScalar(String.Format("[{0}].[WebsiteUpdate_Insert]", pid), _params, pid, Transaction);
            
        }


        /// <summary>
        /// Updates a WebsiteUpdate record and returns the number of records affected
        /// </summary>
        public static int Update(WebsiteUpdateDO DO)
        {
             return Update(DO, null);
        }


        /// <summary>
        /// Updates a WebsiteUpdate record and returns the number of records affected
        /// </summary>
        public static int Update(WebsiteUpdateDO DO, DalapiTransaction Transaction)
        {
            SqlParameter _WebsiteUpdateId = new SqlParameter("WebsiteUpdateId", SqlDbType.Int);
            SqlParameter _VersionInstalled = new SqlParameter("VersionInstalled", SqlDbType.Int);
            SqlParameter _UpdateDescription = new SqlParameter("UpdateDescription", SqlDbType.VarChar);
            SqlParameter _InstallDate = new SqlParameter("InstallDate", SqlDbType.DateTime);
            
            _WebsiteUpdateId.Value = DO.WebsiteUpdateId;
            _VersionInstalled.Value = DO.VersionInstalled;
            _UpdateDescription.Value = DO.UpdateDescription;
            _InstallDate.Value = DO.InstallDate;
            
            SqlParameter[] _params = new SqlParameter[] {
                _WebsiteUpdateId,
                _VersionInstalled,
                _UpdateDescription,
                _InstallDate
            };

            string pid = ConfigurationManager.AppSettings["PID"];

            return DataCommon.ExecuteScalar(String.Format("[{0}].[WebsiteUpdate_Update]", pid), _params, pid, Transaction);
        }


        /// <summary>
        /// Deletes a WebsiteUpdate record
        /// </summary>
        public static int Delete(WebsiteUpdateDO DO)
        {
            return Delete(DO, null);
        }

        /// <summary>
        /// Deletes a WebsiteUpdate record
        /// </summary>
        public static int Delete(WebsiteUpdateDO DO, DalapiTransaction Transaction)
        {
            SqlParameter _WebsiteUpdateId = new SqlParameter("WebsiteUpdateId", SqlDbType.Int);
            
            _WebsiteUpdateId.Value = DO.WebsiteUpdateId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _WebsiteUpdateId
            };

            string pid = ConfigurationManager.AppSettings["PID"];

            return DataCommon.ExecuteScalar(String.Format("[{0}].[WebsiteUpdate_Delete]", pid), _params, pid, Transaction);
        }


        /// <summary>
        /// Gets all WebsiteUpdate records
        /// </summary>
        public static WebsiteUpdateDO[] GetAll()
        {

            string pid = ConfigurationManager.AppSettings["PID"];

            SafeReader sr = DataCommon.ExecuteSafeReader(String.Format("[{0}].[WebsiteUpdate_GetAll]", pid), new SqlParameter[] { }, pid);
            
            List<WebsiteUpdateDO> objs = new List<WebsiteUpdateDO>();
            
            while(sr.Read()){

                WebsiteUpdateDO obj = new WebsiteUpdateDO();
                
                obj.WebsiteUpdateId = sr.GetInt32(sr.GetOrdinal("WebsiteUpdateId"));
                obj.VersionInstalled = sr.GetInt32(sr.GetOrdinal("VersionInstalled"));
                obj.UpdateDescription = sr.GetString(sr.GetOrdinal("UpdateDescription"));
                obj.InstallDate = sr.GetDateTime(sr.GetOrdinal("InstallDate"));
                


                objs.Add(obj);
            }

            return objs.ToArray();
        }


        /// <summary>
        /// Selects WebsiteUpdate records by PK
        /// </summary>
        public static WebsiteUpdateDO[] GetByPK(Int32 WebsiteUpdateId)
        {

            SqlParameter _WebsiteUpdateId = new SqlParameter("WebsiteUpdateId", SqlDbType.Int);
			
            _WebsiteUpdateId.Value = WebsiteUpdateId;
			
            SqlParameter[] _params = new SqlParameter[] {
                _WebsiteUpdateId
            };

            string pid = ConfigurationManager.AppSettings["PID"];

            SafeReader sr = DataCommon.ExecuteSafeReader(String.Format("[{0}].[WebsiteUpdate_GetByPK]", pid), _params, pid);


            List<WebsiteUpdateDO> objs = new List<WebsiteUpdateDO>();
			
            while(sr.Read())
            {
                WebsiteUpdateDO obj = new WebsiteUpdateDO();
				
                obj.WebsiteUpdateId = sr.GetInt32(sr.GetOrdinal("WebsiteUpdateId"));
                obj.VersionInstalled = sr.GetInt32(sr.GetOrdinal("VersionInstalled"));
                obj.UpdateDescription = sr.GetString(sr.GetOrdinal("UpdateDescription"));
                obj.InstallDate = sr.GetDateTime(sr.GetOrdinal("InstallDate"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }




        /// <summary>
        /// Truncates the WebsiteUpdate Table
        /// </summary>
        public static void Truncate()
        {
            Truncate(null);
        }


        /// <summary>
        /// Truncates the WebsiteUpdate Table
        /// </summary>
        public static void Truncate(DalapiTransaction Transaction)
        {
            string pid = ConfigurationManager.AppSettings["PID"];            
            DataCommon.TruncateTable(pid, "WebsiteUpdate", Transaction);
        }

    }
}