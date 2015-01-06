// CREATED BY: Nathan Townsend
// CREATED DATE: 1/6/2015
// DO NOT MODIFY THIS CODE
// CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
// GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



using System;

namespace DealerDAL.DO
{
    /// <summary>
    /// Encapsulates a row of data in the WebsiteUpdateLog table
    /// </summary>
    public partial class WebsiteUpdateLogDO
    {

        public virtual Int32 WebsiteUpdateId {get; set;}
        public virtual Int32 InstallSequence {get; set;}
        public virtual String ActionType {get; set;}
        public virtual String Message {get; set;}

    }
}