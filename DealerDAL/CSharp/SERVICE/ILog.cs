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
using DealerDAL.DO;

namespace DealerDAL.Service
{



    /// <summary>
    /// Provides the interface for data access methods to the Log database table
    /// </summary>
    /// <remarks>
    public interface ILogService
    {


        /// <summary>
        /// Creates a new Log record
        /// </summary>
        int Create(LogDO DO);
        

        /// <summary>
        /// Creates a new Log record
        /// </summary>
        int Create(LogDO DO, DalapiTransaction Transaction);


        /// <summary>
        /// Updates a Log record and returns the number of records affected
        /// </summary>
        int Update(LogDO DO);


        /// <summary>
        /// Updates a Log record and returns the number of records affected
        /// </summary>
        int Update(LogDO DO, DalapiTransaction Transaction);


        /// <summary>
        /// Deletes a Log record
        /// </summary>
        int Delete(LogDO DO);

        /// <summary>
        /// Deletes a Log record
        /// </summary>
        int Delete(LogDO DO, DalapiTransaction Transaction);


        /// <summary>
        /// Gets all Log records
        /// </summary>
        LogDO[] GetAll();


        /// <summary>
        /// Selects Log records by PK
        /// </summary>
        LogDO[] GetByPK(Int32 Id);




        /// <summary>
        /// Truncates the Log Table
        /// </summary>
        void Truncate();
        

        /// <summary>
        /// Truncates the Log Table
        /// </summary>
        void Truncate(DalapiTransaction Transaction);

    }
}