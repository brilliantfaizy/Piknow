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
    
    public partial class tbl_Notification
    {
        public int ID { get; set; }
        public int user_id { get; set; }
        public int notification_user_id { get; set; }
        public string message { get; set; }
        public Nullable<System.DateTime> notificationDatetime { get; set; }
        public Nullable<bool> isDeleted { get; set; }
    }
}
