﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infraestructure.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MiCondominioDBEntities : DbContext
    {
        public MiCondominioDBEntities()
            : base("name=MiCondominioDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AreaComunal> AreaComunal { get; set; }
        public virtual DbSet<EstadoIncidencia> EstadoIncidencia { get; set; }
        public virtual DbSet<EstadoPropiedad> EstadoPropiedad { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Incidencias> Incidencias { get; set; }
        public virtual DbSet<PlanCobro> PlanCobro { get; set; }
        public virtual DbSet<Propiedad> Propiedad { get; set; }
        public virtual DbSet<Reservacion> Reservacion { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<RubroCobro> RubroCobro { get; set; }
        public virtual DbSet<Tarjeta> Tarjeta { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
