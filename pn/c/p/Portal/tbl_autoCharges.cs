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
    
    public partial class tbl_autoCharges
    {
        public int chargesID { get; set; }
        public int from_city { get; set; }
        public int to_city { get; set; }
        public string charges { get; set; }
        public string type { get; set; }
        public Nullable<bool> VehicleTypeIsNormal { get; set; }
        public System.DateTime createdAt { get; set; }
        public Nullable<System.DateTime> updatedAt { get; set; }
    
        public virtual tbl_cities tbl_cities { get; set; }
        public virtual tbl_cities tbl_cities1 { get; set; }
    }
}
