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
    
    public partial class tbl_fastUserRating
    {
        public int ID { get; set; }
        public int ratingCount { get; set; }
        public int user_id { get; set; }
        public int rate_user_id { get; set; }
        public Nullable<System.DateTime> rateDatetime { get; set; }
        public Nullable<int> fastRide_ID { get; set; }
    
        public virtual tbl_fastRide tbl_fastRide { get; set; }
    }
}