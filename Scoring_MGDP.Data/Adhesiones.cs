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
    
    public partial class Adhesiones
    {
        public int id_Dominio { get; set; }
        public int id_Proveedor { get; set; }
        public Nullable<double> PorcAdhesion { get; set; }
    
        public virtual Dominios Dominios { get; set; }
        public virtual Proveedores Proveedores { get; set; }
    }
}
