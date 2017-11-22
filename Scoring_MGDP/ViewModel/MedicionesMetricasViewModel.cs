using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scoring_MGDP.ViewModel
{
    public class MedicionesMetricasViewModel
    {
        [Display(Name = "Id")]
        public int IdMedicionMetrica { get; set; }
        [Display(Name = "IdDefMetrica")]
        public int IdDefMetrica { get; set; }
        [Display(Name = "IdTipoProyecto")]
        public int IdTipoProyecto { get; set; }
        [Display(Name = "Fecha Medición")]
        public System.DateTime FechaMedicion { get; set; }
        [Display(Name = "Valor Medido")]
        public double ValorMedido { get; set; }
        [Display(Name = "¿Calculado?")]
        public string Calculado { get; set; }
        [Display(Name = "Ratio")]
        public double Ratio { get; set; }
        [Display(Name = "¿Cumple ratio?")]
        public string RatioSiNo { get; set; }
        [Display(Name = "Tipo Proyecto")]
        public TiposProyectosViewModel TiposProyectosViewModel { get; set; }

        public DefMetricasViewModel DefMetricasViewModel { get; set; }

        public SelectList TiposProyectosList{ get; set; }

    }
}