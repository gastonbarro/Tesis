using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scoring_MGDP.ViewModel
{
    public class UnidadesMedidasViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Unidad de Medida")]
        public string UnidadMedida { get; set; }

    }
}