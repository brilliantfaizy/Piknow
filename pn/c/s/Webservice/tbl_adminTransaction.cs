//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Webservice
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_adminTransaction
    {
        public int transaction_ID { get; set; }
        public Nullable<int> user_id { get; set; }
        public string type { get; set; }
        public string transaction_Title { get; set; }
        public System.DateTime transaction_datetime { get; set; }
        public string receivedCommission { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
        public string Balance { get; set; }
    
        public virtual tbl_profile tbl_profile { get; set; }
    }
}