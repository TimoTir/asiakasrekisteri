﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace asiakasrekisteri.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AsiakasrekisteriEntities1 : DbContext
    {
        public AsiakasrekisteriEntities1()
            : base("name=AsiakasrekisteriEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Asiakasluokittelu> Asiakasluokittelu { get; set; }
        public virtual DbSet<Asiakastiedot> Asiakastiedot { get; set; }
        public virtual DbSet<Laskutusosoite> Laskutusosoite { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<Postitoimipaikat> Postitoimipaikat { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<AccesLevels> AccesLevels { get; set; }
    }
}
