using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scoring_MGDP.ViewModel
{
    public class VisionViewModel
    {
        [Display(Name = "Id")]
        public int IdVision { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}