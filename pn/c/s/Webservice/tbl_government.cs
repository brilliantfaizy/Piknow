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
    
    public partial class tbl_government
    {
        public tbl_government()
        {
            this.tbl_governmentDetail = new HashSet<tbl_governmentDetail>();
        }
    
        public int government_id { get; set; }
        public string government_code { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public System.DateTime createdAt { get; set; }
        public Nullable<System.DateTime> updatedAt { get; set; }
    
        public virtual ICollection<tbl_governmentDetail> tbl_governmentDetail { get; set; }
    }
}
