using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scoring_MGDP.ViewModel
{
    public class MetricasViewModel
    {
        [Display(Name = "Id")]
        public int IdMetrica { get; set; }
        [Display(Name = "Sigla")]
        public string Sigla { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Display(Name = "Tipo")]
        public TiposMetricasViewModel TiposMetricasViewModel { get; set; }
        [Display(Name = "Unidad de medida")]
        public UnidadesMedidasViewModel UnidadesMedidasViewModel { get; set; }
        [Display(Name = "Id tipo")]
        public int? IdTipo { get; set; }
        [Display(Name = "Id unidad")]
        public int? IdUnidad { get; set; }

        public SelectList TipoMetricaList { get; set; }

        public SelectList UnidadMedidaList { get; set; }
    }

}