using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scoring_MGDP.ViewModel
{
    public class ClasifProveedoresViewModel
    {

        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Clasificación")]
        public string ClasificacionProv { get; set; }
    }

}