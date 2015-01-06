// CREATED BY: Nathan Townsend
// CREATED DATE: 1/6/2015
// DO NOT MODIFY THIS CODE
// CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
// GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



using System;

namespace DealerDAL.DO
{
    /// <summary>
    /// Encapsulates a row of data in the Lookup table
    /// </summary>
    public partial class LookupDO
    {

        public virtual Int32 LookupId {get; set;}
        public virtual String Category {get; set;}
        public virtual String Name {get; set;}
        public virtual String Value {get; set;}
        public virtual String Description {get; set;}

    }
}