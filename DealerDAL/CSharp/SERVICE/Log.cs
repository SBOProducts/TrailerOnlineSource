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
    /// Provides data access methods for the Log database table
    /// </summary>
    /// <remarks>
    public class LogService: ILogService
    {

        private string pid;

        /// <summary>
        /// Creates a new instance of the Log service using the named connection string
        /// </summary>
        public LogService(string ConnectionStringName)
        {
            pid = ConnectionStringName;
        }


        /// <summary>
        /// Creates a new Log record
        /// </summary>
        public int Create(LogDO DO)
        {
            return Create(null); 
        }
        

        /// <summary>
        /// Creates a new Log record
        /// </summary>
        public int Create(LogDO DO, DalapiTransaction Transaction)
        {
            SqlParameter _Date = new SqlParameter("Date", SqlDbType.DateTime);
            SqlParameter _Thread = new SqlParameter("Thread", SqlDbType.VarChar);
            SqlParameter _Level = new SqlParameter("Level", SqlDbType.VarChar);
            SqlParameter _Logger = new SqlParameter("Logger", SqlDbType.VarChar);
            SqlParameter _Message = new SqlParameter("Message", SqlDbType.VarChar);
            SqlParameter _Exception = new SqlParameter("Exception", SqlDbType.VarChar);
            
            _Date.Value = DO.Date;
            _Thread.Value = DO.Thread;
            _Level.Value = DO.Level;
            _Logger.Value = DO.Logger;
            _Message.Value = DO.Message;
            _Exception.Value = DO.Exception;
            
            SqlParameter[] _params = new SqlParameter[] {
                _Date,
                _Thread,
                _Level,
                _Logger,
                _Message,
                _Exception
            };


            return DataCommon.ExecuteScalar(String.Format("[{0}].[Log_Insert]", pid), _params, pid, Transaction);
            
        }


        /// <summary>
        /// Updates a Log record and returns the number of records affected
        /// </summary>
        public int Update(LogDO DO)
        {
             return Update(DO, null);
        }


        /// <summary>
        /// Updates a Log record and returns the number of records affected
        /// </summary>
        public int Update(LogDO DO, DalapiTransaction Transaction)
        {
            SqlParameter _Id = new SqlParameter("Id", SqlDbType.Int);
            SqlParameter _Date = new SqlParameter("Date", SqlDbType.DateTime);
            SqlParameter _Thread = new SqlParameter("Thread", SqlDbType.VarChar);
            SqlParameter _Level = new SqlParameter("Level", SqlDbType.VarChar);
            SqlParameter _Logger = new SqlParameter("Logger", SqlDbType.VarChar);
            SqlParameter _Message = new SqlParameter("Message", SqlDbType.VarChar);
            SqlParameter _Exception = new SqlParameter("Exception", SqlDbType.VarChar);
            
            _Id.Value = DO.Id;
            _Date.Value = DO.Date;
            _Thread.Value = DO.Thread;
            _Level.Value = DO.Level;
            _Logger.Value = DO.Logger;
            _Message.Value = DO.Message;
            _Exception.Value = DO.Exception;
            
            SqlParameter[] _params = new SqlParameter[] {
                _Id,
                _Date,
                _Thread,
                _Level,
                _Logger,
                _Message,
                _Exception
            };

            return DataCommon.ExecuteScalar(String.Format("[{0}].[Log_Update]", pid), _params, pid, Transaction);
        }


        /// <summary>
        /// Deletes a Log record
        /// </summary>
        public int Delete(LogDO DO)
        {
            return Delete(DO, null);
        }

        /// <summary>
        /// Deletes a Log record
        /// </summary>
        public int Delete(LogDO DO, DalapiTransaction Transaction)
        {
            SqlParameter _Id = new SqlParameter("Id", SqlDbType.Int);
            
            _Id.Value = DO.Id;
            
            SqlParameter[] _params = new SqlParameter[] {
                _Id
            };


            return DataCommon.ExecuteScalar(String.Format("[{0}].[Log_Delete]", pid), _params, pid, Transaction);
        }


        /// <summary>
        /// Gets all Log records
        /// </summary>
        public LogDO[] GetAll()
        {

            SafeReader sr = DataCommon.ExecuteSafeReader(String.Format("[{0}].[Log_GetAll]", pid), new SqlParameter[] { }, pid);
            
            List<LogDO> objs = new List<LogDO>();
            
            while(sr.Read()){

                LogDO obj = new LogDO();
                
                obj.Id = sr.GetInt32(sr.GetOrdinal("Id"));
                obj.Date = sr.GetDateTime(sr.GetOrdinal("Date"));
                obj.Thread = sr.GetString(sr.GetOrdinal("Thread"));
                obj.Level = sr.GetString(sr.GetOrdinal("Level"));
                obj.Logger = sr.GetString(sr.GetOrdinal("Logger"));
                obj.Message = sr.GetString(sr.GetOrdinal("Message"));
                if (sr.IsDBNull(sr.GetOrdinal("Exception"))) { obj.Exception = null; } else { obj.Exception = sr.GetString(sr.GetOrdinal("Exception")); }


                objs.Add(obj);
            }

            return objs.ToArray();
        }


        /// <summary>
        /// Selects Log records by PK
        /// </summary>
        public LogDO[] GetByPK(Int32 Id)
        {

            SqlParameter _Id = new SqlParameter("Id", SqlDbType.Int);
			
            _Id.Value = Id;
			
            SqlParameter[] _params = new SqlParameter[] {
                _Id
            };


            SafeReader sr = DataCommon.ExecuteSafeReader(String.Format("[{0}].[Log_GetByPK]", pid), _params, pid);


            List<LogDO> objs = new List<LogDO>();
			
            while(sr.Read())
            {
                LogDO obj = new LogDO();
				
                obj.Id = sr.GetInt32(sr.GetOrdinal("Id"));
                obj.Date = sr.GetDateTime(sr.GetOrdinal("Date"));
                obj.Thread = sr.GetString(sr.GetOrdinal("Thread"));
                obj.Level = sr.GetString(sr.GetOrdinal("Level"));
                obj.Logger = sr.GetString(sr.GetOrdinal("Logger"));
                obj.Message = sr.GetString(sr.GetOrdinal("Message"));
                if (sr.IsDBNull(sr.GetOrdinal("Exception"))) { obj.Exception = null; } else { obj.Exception = sr.GetString(sr.GetOrdinal("Exception")); }

                objs.Add(obj);
            }

            return objs.ToArray();
        }




        /// <summary>
        /// Truncates the Log Table
        /// </summary>
        public void Truncate()
        {
            Truncate(null);
        }


        /// <summary>
        /// Truncates the Log Table
        /// </summary>
        public void Truncate(DalapiTransaction Transaction)
        {
            DataCommon.TruncateTable(pid, "Log", Transaction);
        }

    }
}