﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PN_Entities : DbContext
    {
        public PN_Entities()
            : base("name=PN_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tbl_accountDetail> tbl_accountDetail { get; set; }
        public DbSet<tbl_admin> tbl_admin { get; set; }
        public DbSet<tbl_adminBank> tbl_adminBank { get; set; }
        public DbSet<tbl_adminTransaction> tbl_adminTransaction { get; set; }
        public DbSet<tbl_autoCharges> tbl_autoCharges { get; set; }
        public DbSet<tbl_book> tbl_book { get; set; }
        public DbSet<tbl_chat> tbl_chat { get; set; }
        public DbSet<tbl_chatDetails> tbl_chatDetails { get; set; }
        public DbSet<tbl_cities> tbl_cities { get; set; }
        public DbSet<tbl_commissionFee> tbl_commissionFee { get; set; }
        public DbSet<tbl_company> tbl_company { get; set; }
        public DbSet<tbl_companyDetail> tbl_companyDetail { get; set; }
        public DbSet<tbl_complaint> tbl_complaint { get; set; }
        public DbSet<tbl_discountCode> tbl_discountCode { get; set; }
        public DbSet<tbl_discountDetails> tbl_discountDetails { get; set; }
        public DbSet<tbl_fastRide> tbl_fastRide { get; set; }
        public DbSet<tbl_fastRide_canceled> tbl_fastRide_canceled { get; set; }
        public DbSet<tbl_fastRideDetails> tbl_fastRideDetails { get; set; }
        public DbSet<tbl_fastTrack> tbl_fastTrack { get; set; }
        public DbSet<tbl_fastTransDetails> tbl_fastTransDetails { get; set; }
        public DbSet<tbl_fastUserRating> tbl_fastUserRating { get; set; }
        public DbSet<tbl_general> tbl_general { get; set; }
        public DbSet<tbl_government> tbl_government { get; set; }
        public DbSet<tbl_governmentDetail> tbl_governmentDetail { get; set; }
        public DbSet<tbl_kmCharges> tbl_kmCharges { get; set; }
        public DbSet<tbl_Notification> tbl_Notification { get; set; }
        public DbSet<tbl_offerRide> tbl_offerRide { get; set; }
        public DbSet<tbl_profile> tbl_profile { get; set; }
        public DbSet<tbl_transDetails> tbl_transDetails { get; set; }
        public DbSet<tbl_userComesFrom> tbl_userComesFrom { get; set; }
        public DbSet<tbl_userRating> tbl_userRating { get; set; }
        public DbSet<tbl_vehicle> tbl_vehicle { get; set; }
        public DbSet<tbl_vehicleBrands> tbl_vehicleBrands { get; set; }
        public DbSet<tbl_vehicleColors> tbl_vehicleColors { get; set; }
        public DbSet<tbl_vehicleTypes> tbl_vehicleTypes { get; set; }
        public DbSet<tbl_WalletTransaction> tbl_WalletTransaction { get; set; }
    }
}