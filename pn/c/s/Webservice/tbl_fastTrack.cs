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
    
    public partial class tbl_fastTrack
    {
        public int ID { get; set; }
        public int user_id { get; set; }
        public string userType { get; set; }
        public Nullable<System.DateTime> InDatetime { get; set; }
        public Nullable<System.DateTime> OutDatetime { get; set; }
        public string status { get; set; }
        public string LatLong { get; set; }
        public Nullable<int> vehicle_id { get; set; }
        public string cityName { get; set; }
        public string cityName_persian { get; set; }
    
        public virtual tbl_profile tbl_profile { get; set; }
        public virtual tbl_vehicle tbl_vehicle { get; set; }
    }
}