using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scoring_MGDP.ViewModel
{
    public class MedicionesMetricasViewModel
    {

        public MedicionesMetricasViewModel()
        {
            this.CalculadoList = new SelectList(YesNoViewModel.GetYesNoList(), "Id", "Nombre", this.Calculado);
            this.RatioSiNoList = new SelectList(YesNoViewModel.GetYesNoList(), "Id", "Nombre", this.RatioSiNo);
        }
       
        [Display(Name = "Id")]
        public int IdMedicionMetrica { get; set; }
        [Display(Name = "Definición Metrica")]
      public int IdDefMetrica { get; set; }
        [Display(Name = "IdTipoProyecto")]
        public int IdTipoProyecto { get; set; }
        [Display(Name = "Fecha Medición"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime? FechaMedicion { get; set; }
        [Display(Name = "Valor Medido")]
        public double ValorMedido { get; set; }
        [Display(Name = "¿Calculado?")]
        public string Calculado { get; set; }
        [Display(Name = "Ratio")]
        public double? Ratio { get; set; }
        [Display(Name = "¿Cumple ratio?")]
        public string RatioSiNo { get; set; }
        [Display(Name = "Tipo Proyecto")]
        public TiposProyectosViewModel TiposProyectosViewModel { get; set; }

        public DefMetricasViewModel DefMetricasViewModel { get; set; }

        public SelectList TiposProyectosList{ get; set; }

        public SelectList CalculadoList { get; set; }

        public SelectList RatioSiNoList { get; set; }

        public string CalculadoSN { get { return (Calculado == "S" ? "Si" : Calculado == "N" ? "No" : null); } }
        public string RatioSN { get { return (RatioSiNo == "S" ? "Si" : RatioSiNo == "N" ? "No" : null); } }

    }
}