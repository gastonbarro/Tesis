using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scoring_MGDP.ViewModel
{
    public class DefMetricasViewModel
    {
        [Display(Name = "Id")]
        public int IdDefMetrica { get; set; }
        [Display(Name = "IdTipoProyecto")]
        public int IdTipoProyecto { get; set; }
        [Display(Name = "IdProveedor")]
        public int IdProveedor { get; set; }
        [Display(Name = "IdMetrica")]
        public int IdMetrica { get; set; }
        [Display(Name = "IdVisión")]
        public int IdVision { get; set; }
        [Display(Name = "Fecha Desde")]
        public System.DateTime FechaDesde { get; set; }
        [Display(Name = "Fecha Hasta")]
        public System.DateTime FechaHasta { get; set; }
        [Display(Name = "Clave")]
        public string Clave { get; set; }
        [Display(Name = "Ratio")]
        public string Ratio { get; set; }
        [Display(Name = "Peso Ponderado")]
        public double PesoPonderado { get; set; }
        [Display(Name = "Peso")]
        public double Peso { get; set; }
        [Display(Name = "Objetivo Crítico")]
        public double ObjCritico { get; set; }
        [Display(Name = "Objetivo Mínimo")]
        public double ObjMinimo { get; set; }
        [Display(Name = "Objetivo Excelencia")]
        public double ObjExcelencia { get; set; }
        [Display(Name = "¿HUB?")]
        public string HubNoHub { get; set; }

        public TiposProyectosViewModel TiposProyectosViewModel { get; set; }
        public ProveedorViewModel ProveedorViewModel { get; set; }
        public MetricasViewModel MetricasViewModel { get; set; }

        public SelectList TiposProyectosList { get; set; }
        public SelectList ProveedoresList { get; set; }
        public SelectList MetricasList { get; set; }
        //Falta View Model de visión

    }
}