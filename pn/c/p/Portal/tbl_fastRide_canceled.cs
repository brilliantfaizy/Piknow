//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Portal
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_fastRide_canceled
    {
        public int ID { get; set; }
        public int fastRide_ID { get; set; }
        public int driver_id { get; set; }
        public System.DateTime createdAt { get; set; }
    
        public virtual tbl_fastRide tbl_fastRide { get; set; }
        public virtual tbl_profile tbl_profile { get; set; }
    }
}
