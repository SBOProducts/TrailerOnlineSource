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
    /// Provides the interface for data access methods to the WebsiteUpdateLog database table
    /// </summary>
    /// <remarks>
    public interface IWebsiteUpdateLogService
    {


        /// <summary>
        /// Creates a new WebsiteUpdateLog record
        /// </summary>
        void Create(WebsiteUpdateLogDO DO);
        

        /// <summary>
        /// Creates a new WebsiteUpdateLog record
        /// </summary>
        void Create(WebsiteUpdateLogDO DO, DalapiTransaction Transaction);


        /// <summary>
        /// Updates a WebsiteUpdateLog record and returns the number of records affected
        /// </summary>
        int Update(WebsiteUpdateLogDO DO);


        /// <summary>
        /// Updates a WebsiteUpdateLog record and returns the number of records affected
        /// </summary>
        int Update(WebsiteUpdateLogDO DO, DalapiTransaction Transaction);


        /// <summary>
        /// Deletes a WebsiteUpdateLog record
        /// </summary>
        int Delete(WebsiteUpdateLogDO DO);

        /// <summary>
        /// Deletes a WebsiteUpdateLog record
        /// </summary>
        int Delete(WebsiteUpdateLogDO DO, DalapiTransaction Transaction);


        /// <summary>
        /// Gets all WebsiteUpdateLog records
        /// </summary>
        WebsiteUpdateLogDO[] GetAll();


        /// <summary>
        /// Selects WebsiteUpdateLog records by PK
        /// </summary>
        WebsiteUpdateLogDO[] GetByPK(Int32 WebsiteUpdateId,
 Int32 InstallSequence);




        /// <summary>
        /// Truncates the WebsiteUpdateLog Table
        /// </summary>
        void Truncate();
        

        /// <summary>
        /// Truncates the WebsiteUpdateLog Table
        /// </summary>
        void Truncate(DalapiTransaction Transaction);

    }
}