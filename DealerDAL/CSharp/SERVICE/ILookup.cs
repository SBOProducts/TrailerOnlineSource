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
    /// Provides the interface for data access methods to the Lookup database table
    /// </summary>
    /// <remarks>
    public interface ILookupService
    {


        /// <summary>
        /// Creates a new Lookup record
        /// </summary>
        int Create(LookupDO DO);
        

        /// <summary>
        /// Creates a new Lookup record
        /// </summary>
        int Create(LookupDO DO, DalapiTransaction Transaction);


        /// <summary>
        /// Updates a Lookup record and returns the number of records affected
        /// </summary>
        int Update(LookupDO DO);


        /// <summary>
        /// Updates a Lookup record and returns the number of records affected
        /// </summary>
        int Update(LookupDO DO, DalapiTransaction Transaction);


        /// <summary>
        /// Deletes a Lookup record
        /// </summary>
        int Delete(LookupDO DO);

        /// <summary>
        /// Deletes a Lookup record
        /// </summary>
        int Delete(LookupDO DO, DalapiTransaction Transaction);


        /// <summary>
        /// Gets all Lookup records
        /// </summary>
        LookupDO[] GetAll();


        /// <summary>
        /// Selects Lookup records by Lookup_Category
        /// </summary>
        LookupDO[] GetByLookup_Category(String Category);

/// <summary>
        /// Selects Lookup records by Lookup_Value
        /// </summary>
        LookupDO[] GetByLookup_Value(String Category,
 String Value);

/// <summary>
        /// Selects Lookup records by PK
        /// </summary>
        LookupDO[] GetByPK(Int32 LookupId);




        /// <summary>
        /// Truncates the Lookup Table
        /// </summary>
        void Truncate();
        

        /// <summary>
        /// Truncates the Lookup Table
        /// </summary>
        void Truncate(DalapiTransaction Transaction);

    }
}