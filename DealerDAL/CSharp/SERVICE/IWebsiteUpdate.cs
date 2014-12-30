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
    /// Provides the interface for data access methods to the WebsiteUpdate database table
    /// </summary>
    /// <remarks>
    public interface IWebsiteUpdateService
    {


        /// <summary>
        /// Creates a new WebsiteUpdate record
        /// </summary>
        int Create(WebsiteUpdateDO DO);
        

        /// <summary>
        /// Creates a new WebsiteUpdate record
        /// </summary>
        int Create(WebsiteUpdateDO DO, DalapiTransaction Transaction);


        /// <summary>
        /// Updates a WebsiteUpdate record and returns the number of records affected
        /// </summary>
        int Update(WebsiteUpdateDO DO);


        /// <summary>
        /// Updates a WebsiteUpdate record and returns the number of records affected
        /// </summary>
        int Update(WebsiteUpdateDO DO, DalapiTransaction Transaction);


        /// <summary>
        /// Deletes a WebsiteUpdate record
        /// </summary>
        int Delete(WebsiteUpdateDO DO);

        /// <summary>
        /// Deletes a WebsiteUpdate record
        /// </summary>
        int Delete(WebsiteUpdateDO DO, DalapiTransaction Transaction);


        /// <summary>
        /// Gets all WebsiteUpdate records
        /// </summary>
        WebsiteUpdateDO[] GetAll();


        /// <summary>
        /// Selects WebsiteUpdate records by PK
        /// </summary>
        WebsiteUpdateDO[] GetByPK(Int32 WebsiteUpdateId);




        /// <summary>
        /// Truncates the WebsiteUpdate Table
        /// </summary>
        void Truncate();
        

        /// <summary>
        /// Truncates the WebsiteUpdate Table
        /// </summary>
        void Truncate(DalapiTransaction Transaction);

    }
}