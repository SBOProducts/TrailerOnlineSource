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
    /// Provides data access methods for the WebsiteUpdateLog database table
    /// </summary>
    /// <remarks>
    public class WebsiteUpdateLogService: IWebsiteUpdateLogService
    {

        private string pid;

        /// <summary>
        /// Creates a new instance of the WebsiteUpdateLog service using the named connection string
        /// </summary>
        public WebsiteUpdateLogService(string ConnectionStringName)
        {
            pid = ConnectionStringName;
        }


        /// <summary>
        /// Creates a new WebsiteUpdateLog record
        /// </summary>
        public void Create(WebsiteUpdateLogDO DO)
        {
            Create(null); 
        }
        

        /// <summary>
        /// Creates a new WebsiteUpdateLog record
        /// </summary>
        public void Create(WebsiteUpdateLogDO DO, DalapiTransaction Transaction)
        {
            SqlParameter _WebsiteUpdateId = new SqlParameter("WebsiteUpdateId", SqlDbType.Int);
            SqlParameter _InstallSequence = new SqlParameter("InstallSequence", SqlDbType.Int);
            SqlParameter _InstallAction = new SqlParameter("InstallAction", SqlDbType.VarChar);
            SqlParameter _SourceFilePath = new SqlParameter("SourceFilePath", SqlDbType.VarChar);
            SqlParameter _DestinationFilePath = new SqlParameter("DestinationFilePath", SqlDbType.VarChar);
            
            _WebsiteUpdateId.Value = DO.WebsiteUpdateId;
            _InstallSequence.Value = DO.InstallSequence;
            _InstallAction.Value = DO.InstallAction;
            _SourceFilePath.Value = DO.SourceFilePath;
            _DestinationFilePath.Value = DO.DestinationFilePath;
            
            SqlParameter[] _params = new SqlParameter[] {
                _WebsiteUpdateId,
                _InstallSequence,
                _InstallAction,
                _SourceFilePath,
                _DestinationFilePath
            };


            DataCommon.ExecuteNonQuery(String.Format("[{0}].[WebsiteUpdateLog_Insert]", pid), _params, pid, Transaction);
            
        }


        /// <summary>
        /// Updates a WebsiteUpdateLog record and returns the number of records affected
        /// </summary>
        public int Update(WebsiteUpdateLogDO DO)
        {
             return Update(DO, null);
        }


        /// <summary>
        /// Updates a WebsiteUpdateLog record and returns the number of records affected
        /// </summary>
        public int Update(WebsiteUpdateLogDO DO, DalapiTransaction Transaction)
        {
            SqlParameter _WebsiteUpdateId = new SqlParameter("WebsiteUpdateId", SqlDbType.Int);
            SqlParameter _InstallSequence = new SqlParameter("InstallSequence", SqlDbType.Int);
            SqlParameter _InstallAction = new SqlParameter("InstallAction", SqlDbType.VarChar);
            SqlParameter _SourceFilePath = new SqlParameter("SourceFilePath", SqlDbType.VarChar);
            SqlParameter _DestinationFilePath = new SqlParameter("DestinationFilePath", SqlDbType.VarChar);
            
            _WebsiteUpdateId.Value = DO.WebsiteUpdateId;
            _InstallSequence.Value = DO.InstallSequence;
            _InstallAction.Value = DO.InstallAction;
            _SourceFilePath.Value = DO.SourceFilePath;
            _DestinationFilePath.Value = DO.DestinationFilePath;
            
            SqlParameter[] _params = new SqlParameter[] {
                _WebsiteUpdateId,
                _InstallSequence,
                _InstallAction,
                _SourceFilePath,
                _DestinationFilePath
            };

            return DataCommon.ExecuteScalar(String.Format("[{0}].[WebsiteUpdateLog_Update]", pid), _params, pid, Transaction);
        }


        /// <summary>
        /// Deletes a WebsiteUpdateLog record
        /// </summary>
        public int Delete(WebsiteUpdateLogDO DO)
        {
            return Delete(DO, null);
        }

        /// <summary>
        /// Deletes a WebsiteUpdateLog record
        /// </summary>
        public int Delete(WebsiteUpdateLogDO DO, DalapiTransaction Transaction)
        {
            SqlParameter _WebsiteUpdateId = new SqlParameter("WebsiteUpdateId", SqlDbType.Int);
            SqlParameter _InstallSequence = new SqlParameter("InstallSequence", SqlDbType.Int);
            
            _WebsiteUpdateId.Value = DO.WebsiteUpdateId;
            _InstallSequence.Value = DO.InstallSequence;
            
            SqlParameter[] _params = new SqlParameter[] {
                _WebsiteUpdateId,
                _InstallSequence
            };


            return DataCommon.ExecuteScalar(String.Format("[{0}].[WebsiteUpdateLog_Delete]", pid), _params, pid, Transaction);
        }


        /// <summary>
        /// Gets all WebsiteUpdateLog records
        /// </summary>
        public WebsiteUpdateLogDO[] GetAll()
        {

            SafeReader sr = DataCommon.ExecuteSafeReader(String.Format("[{0}].[WebsiteUpdateLog_GetAll]", pid), new SqlParameter[] { }, pid);
            
            List<WebsiteUpdateLogDO> objs = new List<WebsiteUpdateLogDO>();
            
            while(sr.Read()){

                WebsiteUpdateLogDO obj = new WebsiteUpdateLogDO();
                
                obj.WebsiteUpdateId = sr.GetInt32(sr.GetOrdinal("WebsiteUpdateId"));
                obj.InstallSequence = sr.GetInt32(sr.GetOrdinal("InstallSequence"));
                obj.InstallAction = sr.GetString(sr.GetOrdinal("InstallAction"));
                obj.SourceFilePath = sr.GetString(sr.GetOrdinal("SourceFilePath"));
                obj.DestinationFilePath = sr.GetString(sr.GetOrdinal("DestinationFilePath"));
                


                objs.Add(obj);
            }

            return objs.ToArray();
        }


        /// <summary>
        /// Selects WebsiteUpdateLog records by PK
        /// </summary>
        public WebsiteUpdateLogDO[] GetByPK(Int32 WebsiteUpdateId,
 Int32 InstallSequence)
        {

            SqlParameter _WebsiteUpdateId = new SqlParameter("WebsiteUpdateId", SqlDbType.Int);
            SqlParameter _InstallSequence = new SqlParameter("InstallSequence", SqlDbType.Int);
			
            _WebsiteUpdateId.Value = WebsiteUpdateId;
            _InstallSequence.Value = InstallSequence;
			
            SqlParameter[] _params = new SqlParameter[] {
                _WebsiteUpdateId,
                _InstallSequence
            };


            SafeReader sr = DataCommon.ExecuteSafeReader(String.Format("[{0}].[WebsiteUpdateLog_GetByPK]", pid), _params, pid);


            List<WebsiteUpdateLogDO> objs = new List<WebsiteUpdateLogDO>();
			
            while(sr.Read())
            {
                WebsiteUpdateLogDO obj = new WebsiteUpdateLogDO();
				
                obj.WebsiteUpdateId = sr.GetInt32(sr.GetOrdinal("WebsiteUpdateId"));
                obj.InstallSequence = sr.GetInt32(sr.GetOrdinal("InstallSequence"));
                obj.InstallAction = sr.GetString(sr.GetOrdinal("InstallAction"));
                obj.SourceFilePath = sr.GetString(sr.GetOrdinal("SourceFilePath"));
                obj.DestinationFilePath = sr.GetString(sr.GetOrdinal("DestinationFilePath"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }




        /// <summary>
        /// Truncates the WebsiteUpdateLog Table
        /// </summary>
        public void Truncate()
        {
            Truncate(null);
        }


        /// <summary>
        /// Truncates the WebsiteUpdateLog Table
        /// </summary>
        public void Truncate(DalapiTransaction Transaction)
        {
            DataCommon.TruncateTable(pid, "WebsiteUpdateLog", Transaction);
        }

    }
}