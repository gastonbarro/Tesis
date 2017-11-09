//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class DefMetricas
    {
        public int id_DefMetricas { get; set; }
        public int id_Proveedor { get; set; }
        public int id_Metricas { get; set; }
        public Nullable<System.DateTime> FechaDesde { get; set; }
        public Nullable<System.DateTime> FechaHasta { get; set; }
        public string Clave { get; set; }
        public string Ratio { get; set; }
        public Nullable<double> PesoPonderado { get; set; }
        public Nullable<double> Peso { get; set; }
        public Nullable<double> ObjCritico { get; set; }
        public Nullable<double> ObjMinimo { get; set; }
        public Nullable<double> ObjExcelencia { get; set; }
        public Nullable<int> id_TiposProyectos { get; set; }
        public string Hub_NoHub { get; set; }
        public Nullable<int> id_vision { get; set; }
    
        public virtual Metricas Metricas { get; set; }
        public virtual Proveedores Proveedores { get; set; }
        public virtual TiposProyectos TiposProyectos { get; set; }
        public virtual Vision Vision { get; set; }
    }
}
