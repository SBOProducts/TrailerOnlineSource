// CREATED BY: Nathan Townsend
// CREATED DATE: 12/29/2014
// DO NOT MODIFY THIS CODE
// CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
// GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



using System;

namespace DealerDAL.DO
{
    /// <summary>
    /// Encapsulates a row of data in the Log table
    /// </summary>
    public partial class LogDO
    {

        public virtual Int32 Id {get; set;}
        public virtual DateTime Date {get; set;}
        public virtual String Thread {get; set;}
        public virtual String Level {get; set;}
        public virtual String Logger {get; set;}
        public virtual String Message {get; set;}
        public virtual String Exception {get; set;}

    }
}