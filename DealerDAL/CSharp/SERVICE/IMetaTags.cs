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
    /// Provides the interface for data access methods to the MetaTags database table
    /// </summary>
    /// <remarks>
    public interface IMetaTagsService
    {


        /// <summary>
        /// Creates a new MetaTags record
        /// </summary>
        int Create(MetaTagsDO DO);
        

        /// <summary>
        /// Creates a new MetaTags record
        /// </summary>
        int Create(MetaTagsDO DO, DalapiTransaction Transaction);


        /// <summary>
        /// Updates a MetaTags record and returns the number of records affected
        /// </summary>
        int Update(MetaTagsDO DO);


        /// <summary>
        /// Updates a MetaTags record and returns the number of records affected
        /// </summary>
        int Update(MetaTagsDO DO, DalapiTransaction Transaction);


        /// <summary>
        /// Deletes a MetaTags record
        /// </summary>
        int Delete(MetaTagsDO DO);

        /// <summary>
        /// Deletes a MetaTags record
        /// </summary>
        int Delete(MetaTagsDO DO, DalapiTransaction Transaction);


        /// <summary>
        /// Gets all MetaTags records
        /// </summary>
        MetaTagsDO[] GetAll();


        /// <summary>
        /// Selects MetaTags records by PK
        /// </summary>
        MetaTagsDO[] GetByPK(Int32 MetaTagsId);




        /// <summary>
        /// Truncates the MetaTags Table
        /// </summary>
        void Truncate();
        

        /// <summary>
        /// Truncates the MetaTags Table
        /// </summary>
        void Truncate(DalapiTransaction Transaction);

    }
}