﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Scoring_MGDPData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Scoring_MGDPEntities : DbContext
    {
        public Scoring_MGDPEntities()
            : base("name=Scoring_MGDPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adhesiones> Adhesiones { get; set; }
        public virtual DbSet<CfgControlExtracciones> CfgControlExtracciones { get; set; }
        public virtual DbSet<ClasificacionesProv> ClasificacionesProv { get; set; }
        public virtual DbSet<ContratoProv> ContratoProv { get; set; }
        public virtual DbSet<DefMetricas> DefMetricas { get; set; }
        public virtual DbSet<Dominios> Dominios { get; set; }
        public virtual DbSet<Metricas> Metricas { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Scoring_Configuracion> Scoring_Configuracion { get; set; }
        public virtual DbSet<TiposMetricas> TiposMetricas { get; set; }
        public virtual DbSet<TiposProyectos> TiposProyectos { get; set; }
        public virtual DbSet<UnidadeDeMedidas> UnidadeDeMedidas { get; set; }
        public virtual DbSet<Vision> Vision { get; set; }
        public virtual DbSet<EncuestaCompras> EncuestaCompras { get; set; }
        public virtual DbSet<MedicionesMetricas> MedicionesMetricas { get; set; }
    }
}
