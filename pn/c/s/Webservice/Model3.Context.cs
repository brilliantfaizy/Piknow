﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FinancialsEntities : DbContext
    {
        public FinancialsEntities()
            : base("name=FinancialsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tbl_company> tbl_company { get; set; }
        public DbSet<tbl_country> tbl_country { get; set; }
        public DbSet<tbl_currencySetting> tbl_currencySetting { get; set; }
        public DbSet<tbl_loginAs> tbl_loginAs { get; set; }
        public DbSet<tbl_myCompany> tbl_myCompany { get; set; }
        public DbSet<tbl_myLogo> tbl_myLogo { get; set; }
        public DbSet<tbl_userRights> tbl_userRights { get; set; }
        public DbSet<tbl_userTypes> tbl_userTypes { get; set; }
    }
}
