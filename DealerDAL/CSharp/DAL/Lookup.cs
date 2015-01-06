// CREATED BY: Nathan Townsend
// CREATED DATE: 1/6/2015
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
    /// Provides data access methods for the Lookup database table
    /// </summary>
    /// <remarks>
    public partial class Lookup
    {

        /// <summary>
        /// Creates a new Lookup record
        /// </summary>
        public static int Create(LookupDO DO)
        {
            return Create(null); 
        }
        

        /// <summary>
        /// Creates a new Lookup record
        /// </summary>
        public static int Create(LookupDO DO, DalapiTransaction Transaction)
        {
            SqlParameter _Category = new SqlParameter("Category", SqlDbType.VarChar);
            SqlParameter _Name = new SqlParameter("Name", SqlDbType.VarChar);
            SqlParameter _Value = new SqlParameter("Value", SqlDbType.VarChar);
            SqlParameter _Description = new SqlParameter("Description", SqlDbType.VarChar);
            
            _Category.Value = DO.Category;
            _Name.Value = DO.Name;
            _Value.Value = DO.Value;
            _Description.Value = DO.Description;
            
            SqlParameter[] _params = new SqlParameter[] {
                _Category,
                _Name,
                _Value,
                _Description
            };

            string pid = ConfigurationManager.AppSettings["PID"];

            return DataCommon.ExecuteScalar(String.Format("[{0}].[Lookup_Insert]", pid), _params, pid, Transaction);
            
        }


        /// <summary>
        /// Updates a Lookup record and returns the number of records affected
        /// </summary>
        public static int Update(LookupDO DO)
        {
             return Update(DO, null);
        }


        /// <summary>
        /// Updates a Lookup record and returns the number of records affected
        /// </summary>
        public static int Update(LookupDO DO, DalapiTransaction Transaction)
        {
            SqlParameter _LookupId = new SqlParameter("LookupId", SqlDbType.Int);
            SqlParameter _Category = new SqlParameter("Category", SqlDbType.VarChar);
            SqlParameter _Name = new SqlParameter("Name", SqlDbType.VarChar);
            SqlParameter _Value = new SqlParameter("Value", SqlDbType.VarChar);
            SqlParameter _Description = new SqlParameter("Description", SqlDbType.VarChar);
            
            _LookupId.Value = DO.LookupId;
            _Category.Value = DO.Category;
            _Name.Value = DO.Name;
            _Value.Value = DO.Value;
            _Description.Value = DO.Description;
            
            SqlParameter[] _params = new SqlParameter[] {
                _LookupId,
                _Category,
                _Name,
                _Value,
                _Description
            };

            string pid = ConfigurationManager.AppSettings["PID"];

            return DataCommon.ExecuteScalar(String.Format("[{0}].[Lookup_Update]", pid), _params, pid, Transaction);
        }


        /// <summary>
        /// Deletes a Lookup record
        /// </summary>
        public static int Delete(LookupDO DO)
        {
            return Delete(DO, null);
        }

        /// <summary>
        /// Deletes a Lookup record
        /// </summary>
        public static int Delete(LookupDO DO, DalapiTransaction Transaction)
        {
            SqlParameter _LookupId = new SqlParameter("LookupId", SqlDbType.Int);
            
            _LookupId.Value = DO.LookupId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _LookupId
            };

            string pid = ConfigurationManager.AppSettings["PID"];

            return DataCommon.ExecuteScalar(String.Format("[{0}].[Lookup_Delete]", pid), _params, pid, Transaction);
        }


        /// <summary>
        /// Gets all Lookup records
        /// </summary>
        public static LookupDO[] GetAll()
        {

            string pid = ConfigurationManager.AppSettings["PID"];

            SafeReader sr = DataCommon.ExecuteSafeReader(String.Format("[{0}].[Lookup_GetAll]", pid), new SqlParameter[] { }, pid);
            
            List<LookupDO> objs = new List<LookupDO>();
            
            while(sr.Read()){

                LookupDO obj = new LookupDO();
                
                obj.LookupId = sr.GetInt32(sr.GetOrdinal("LookupId"));
                obj.Category = sr.GetString(sr.GetOrdinal("Category"));
                obj.Name = sr.GetString(sr.GetOrdinal("Name"));
                obj.Value = sr.GetString(sr.GetOrdinal("Value"));
                if (sr.IsDBNull(sr.GetOrdinal("Description"))) { obj.Description = null; } else { obj.Description = sr.GetString(sr.GetOrdinal("Description")); }


                objs.Add(obj);
            }

            return objs.ToArray();
        }


        /// <summary>
        /// Selects Lookup records by Lookup_Category
        /// </summary>
        public static LookupDO[] GetByLookup_Category(String Category)
        {

            SqlParameter _Category = new SqlParameter("Category", SqlDbType.VarChar);
			
            _Category.Value = Category;
			
            SqlParameter[] _params = new SqlParameter[] {
                _Category
            };

            string pid = ConfigurationManager.AppSettings["PID"];

            SafeReader sr = DataCommon.ExecuteSafeReader(String.Format("[{0}].[Lookup_GetByLookup_Category]", pid), _params, pid);


            List<LookupDO> objs = new List<LookupDO>();
			
            while(sr.Read())
            {
                LookupDO obj = new LookupDO();
				
                obj.LookupId = sr.GetInt32(sr.GetOrdinal("LookupId"));
                obj.Category = sr.GetString(sr.GetOrdinal("Category"));
                obj.Name = sr.GetString(sr.GetOrdinal("Name"));
                obj.Value = sr.GetString(sr.GetOrdinal("Value"));
                if (sr.IsDBNull(sr.GetOrdinal("Description"))) { obj.Description = null; } else { obj.Description = sr.GetString(sr.GetOrdinal("Description")); }

                objs.Add(obj);
            }

            return objs.ToArray();
        }

/// <summary>
        /// Selects Lookup records by Lookup_Value
        /// </summary>
        public static LookupDO[] GetByLookup_Value(String Category,
 String Value)
        {

            SqlParameter _Category = new SqlParameter("Category", SqlDbType.VarChar);
            SqlParameter _Value = new SqlParameter("Value", SqlDbType.VarChar);
			
            _Category.Value = Category;
            _Value.Value = Value;
			
            SqlParameter[] _params = new SqlParameter[] {
                _Category,
                _Value
            };

            string pid = ConfigurationManager.AppSettings["PID"];

            SafeReader sr = DataCommon.ExecuteSafeReader(String.Format("[{0}].[Lookup_GetByLookup_Value]", pid), _params, pid);


            List<LookupDO> objs = new List<LookupDO>();
			
            while(sr.Read())
            {
                LookupDO obj = new LookupDO();
				
                obj.LookupId = sr.GetInt32(sr.GetOrdinal("LookupId"));
                obj.Category = sr.GetString(sr.GetOrdinal("Category"));
                obj.Name = sr.GetString(sr.GetOrdinal("Name"));
                obj.Value = sr.GetString(sr.GetOrdinal("Value"));
                if (sr.IsDBNull(sr.GetOrdinal("Description"))) { obj.Description = null; } else { obj.Description = sr.GetString(sr.GetOrdinal("Description")); }

                objs.Add(obj);
            }

            return objs.ToArray();
        }

/// <summary>
        /// Selects Lookup records by PK
        /// </summary>
        public static LookupDO[] GetByPK(Int32 LookupId)
        {

            SqlParameter _LookupId = new SqlParameter("LookupId", SqlDbType.Int);
			
            _LookupId.Value = LookupId;
			
            SqlParameter[] _params = new SqlParameter[] {
                _LookupId
            };

            string pid = ConfigurationManager.AppSettings["PID"];

            SafeReader sr = DataCommon.ExecuteSafeReader(String.Format("[{0}].[Lookup_GetByPK]", pid), _params, pid);


            List<LookupDO> objs = new List<LookupDO>();
			
            while(sr.Read())
            {
                LookupDO obj = new LookupDO();
				
                obj.LookupId = sr.GetInt32(sr.GetOrdinal("LookupId"));
                obj.Category = sr.GetString(sr.GetOrdinal("Category"));
                obj.Name = sr.GetString(sr.GetOrdinal("Name"));
                obj.Value = sr.GetString(sr.GetOrdinal("Value"));
                if (sr.IsDBNull(sr.GetOrdinal("Description"))) { obj.Description = null; } else { obj.Description = sr.GetString(sr.GetOrdinal("Description")); }

                objs.Add(obj);
            }

            return objs.ToArray();
        }




        /// <summary>
        /// Truncates the Lookup Table
        /// </summary>
        public static void Truncate()
        {
            Truncate(null);
        }


        /// <summary>
        /// Truncates the Lookup Table
        /// </summary>
        public static void Truncate(DalapiTransaction Transaction)
        {
            string pid = ConfigurationManager.AppSettings["PID"];            
            DataCommon.TruncateTable(pid, "Lookup", Transaction);
        }

    }
}