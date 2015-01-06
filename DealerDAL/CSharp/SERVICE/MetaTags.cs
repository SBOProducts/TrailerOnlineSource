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
using DealerDAL.DO;

namespace DealerDAL.Service
{


    /// <summary>
    /// Provides data access methods for the MetaTags database table
    /// </summary>
    /// <remarks>
    public class MetaTagsService: IMetaTagsService
    {

        private string pid;

        /// <summary>
        /// Creates a new instance of the MetaTags service using the named connection string
        /// </summary>
        public MetaTagsService(string ConnectionStringName)
        {
            pid = ConnectionStringName;
        }


        /// <summary>
        /// Creates a new MetaTags record
        /// </summary>
        public int Create(MetaTagsDO DO)
        {
            return Create(null); 
        }
        

        /// <summary>
        /// Creates a new MetaTags record
        /// </summary>
        public int Create(MetaTagsDO DO, DalapiTransaction Transaction)
        {
            SqlParameter _Title = new SqlParameter("Title", SqlDbType.VarChar);
            SqlParameter _Description = new SqlParameter("Description", SqlDbType.VarChar);
            SqlParameter _KeyWords = new SqlParameter("KeyWords", SqlDbType.VarChar);
            SqlParameter _Author = new SqlParameter("Author", SqlDbType.VarChar);
            SqlParameter _Robots = new SqlParameter("Robots", SqlDbType.VarChar);
            
            _Title.Value = DO.Title;
            _Description.Value = DO.Description;
            _KeyWords.Value = DO.KeyWords;
            _Author.Value = DO.Author;
            _Robots.Value = DO.Robots;
            
            SqlParameter[] _params = new SqlParameter[] {
                _Title,
                _Description,
                _KeyWords,
                _Author,
                _Robots
            };


            return DataCommon.ExecuteScalar(String.Format("[{0}].[MetaTags_Insert]", pid), _params, pid, Transaction);
            
        }


        /// <summary>
        /// Updates a MetaTags record and returns the number of records affected
        /// </summary>
        public int Update(MetaTagsDO DO)
        {
             return Update(DO, null);
        }


        /// <summary>
        /// Updates a MetaTags record and returns the number of records affected
        /// </summary>
        public int Update(MetaTagsDO DO, DalapiTransaction Transaction)
        {
            SqlParameter _MetaTagsId = new SqlParameter("MetaTagsId", SqlDbType.Int);
            SqlParameter _Title = new SqlParameter("Title", SqlDbType.VarChar);
            SqlParameter _Description = new SqlParameter("Description", SqlDbType.VarChar);
            SqlParameter _KeyWords = new SqlParameter("KeyWords", SqlDbType.VarChar);
            SqlParameter _Author = new SqlParameter("Author", SqlDbType.VarChar);
            SqlParameter _Robots = new SqlParameter("Robots", SqlDbType.VarChar);
            
            _MetaTagsId.Value = DO.MetaTagsId;
            _Title.Value = DO.Title;
            _Description.Value = DO.Description;
            _KeyWords.Value = DO.KeyWords;
            _Author.Value = DO.Author;
            _Robots.Value = DO.Robots;
            
            SqlParameter[] _params = new SqlParameter[] {
                _MetaTagsId,
                _Title,
                _Description,
                _KeyWords,
                _Author,
                _Robots
            };

            return DataCommon.ExecuteScalar(String.Format("[{0}].[MetaTags_Update]", pid), _params, pid, Transaction);
        }


        /// <summary>
        /// Deletes a MetaTags record
        /// </summary>
        public int Delete(MetaTagsDO DO)
        {
            return Delete(DO, null);
        }

        /// <summary>
        /// Deletes a MetaTags record
        /// </summary>
        public int Delete(MetaTagsDO DO, DalapiTransaction Transaction)
        {
            SqlParameter _MetaTagsId = new SqlParameter("MetaTagsId", SqlDbType.Int);
            
            _MetaTagsId.Value = DO.MetaTagsId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _MetaTagsId
            };


            return DataCommon.ExecuteScalar(String.Format("[{0}].[MetaTags_Delete]", pid), _params, pid, Transaction);
        }


        /// <summary>
        /// Gets all MetaTags records
        /// </summary>
        public MetaTagsDO[] GetAll()
        {

            SafeReader sr = DataCommon.ExecuteSafeReader(String.Format("[{0}].[MetaTags_GetAll]", pid), new SqlParameter[] { }, pid);
            
            List<MetaTagsDO> objs = new List<MetaTagsDO>();
            
            while(sr.Read()){

                MetaTagsDO obj = new MetaTagsDO();
                
                obj.MetaTagsId = sr.GetInt32(sr.GetOrdinal("MetaTagsId"));
                obj.Title = sr.GetString(sr.GetOrdinal("Title"));
                obj.Description = sr.GetString(sr.GetOrdinal("Description"));
                obj.KeyWords = sr.GetString(sr.GetOrdinal("KeyWords"));
                obj.Author = sr.GetString(sr.GetOrdinal("Author"));
                obj.Robots = sr.GetString(sr.GetOrdinal("Robots"));
                


                objs.Add(obj);
            }

            return objs.ToArray();
        }


        /// <summary>
        /// Selects MetaTags records by PK
        /// </summary>
        public MetaTagsDO[] GetByPK(Int32 MetaTagsId)
        {

            SqlParameter _MetaTagsId = new SqlParameter("MetaTagsId", SqlDbType.Int);
			
            _MetaTagsId.Value = MetaTagsId;
			
            SqlParameter[] _params = new SqlParameter[] {
                _MetaTagsId
            };


            SafeReader sr = DataCommon.ExecuteSafeReader(String.Format("[{0}].[MetaTags_GetByPK]", pid), _params, pid);


            List<MetaTagsDO> objs = new List<MetaTagsDO>();
			
            while(sr.Read())
            {
                MetaTagsDO obj = new MetaTagsDO();
				
                obj.MetaTagsId = sr.GetInt32(sr.GetOrdinal("MetaTagsId"));
                obj.Title = sr.GetString(sr.GetOrdinal("Title"));
                obj.Description = sr.GetString(sr.GetOrdinal("Description"));
                obj.KeyWords = sr.GetString(sr.GetOrdinal("KeyWords"));
                obj.Author = sr.GetString(sr.GetOrdinal("Author"));
                obj.Robots = sr.GetString(sr.GetOrdinal("Robots"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }




        /// <summary>
        /// Truncates the MetaTags Table
        /// </summary>
        public void Truncate()
        {
            Truncate(null);
        }


        /// <summary>
        /// Truncates the MetaTags Table
        /// </summary>
        public void Truncate(DalapiTransaction Transaction)
        {
            DataCommon.TruncateTable(pid, "MetaTags", Transaction);
        }

    }
}