using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scoring_MGDP.ViewModel
{
    public class ScoringConfigMedidasViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Medida")]
        public string Metrica { get; set; }
        [Display(Name = "Peso")]
        public float? Peso { get; set; }
        [Display(Name = "Ambito")]
        public string Ambito { get; set; }
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        
    }
}