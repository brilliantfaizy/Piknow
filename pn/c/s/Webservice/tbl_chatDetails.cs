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
    
    public partial class tbl_chatDetails
    {
        public int chatDetail_id { get; set; }
        public int chat_ID { get; set; }
        public string message { get; set; }
        public int user_id { get; set; }
        public System.DateTime createdAt { get; set; }
    
        public virtual tbl_chat tbl_chat { get; set; }
        public virtual tbl_profile tbl_profile { get; set; }
    }
}
