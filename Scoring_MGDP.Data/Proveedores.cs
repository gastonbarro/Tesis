//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Scoring_MGDP.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Proveedores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proveedores()
        {
            this.Adhesiones = new HashSet<Adhesiones>();
            this.ContratoProv = new HashSet<ContratoProv>();
            this.DefMetricas = new HashSet<DefMetricas>();
            this.Encuestas = new HashSet<Encuestas>();
            this.Auditorias = new HashSet<Auditorias>();
        }
    
        public int id_Proveedor { get; set; }
        public string NombreProv { get; set; }
        public int id_ClasificacionProv { get; set; }
        public string EsAM { get; set; }
        public string ModeloImplementado { get; set; }
        public string NombreProvCompras { get; set; }
        public string Gestion { get; set; }
        public string Vigente { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adhesiones> Adhesiones { get; set; }
        public virtual ClasificacionesProv ClasificacionesProv { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContratoProv> ContratoProv { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DefMetricas> DefMetricas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Encuestas> Encuestas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Auditorias> Auditorias { get; set; }
    }
}
