// CREATED BY: Nathan Townsend
// CREATED DATE: 1/6/2015
// DO NOT MODIFY THIS CODE
// CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
// GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



using System;

namespace DealerDAL.DO
{
    /// <summary>
    /// Encapsulates a row of data in the MetaTags table
    /// </summary>
    public partial class MetaTagsDO
    {

        public virtual Int32 MetaTagsId {get; set;}
        public virtual String Title {get; set;}
        public virtual String Description {get; set;}
        public virtual String KeyWords {get; set;}
        public virtual String Author {get; set;}
        public virtual String Robots {get; set;}

    }
}