using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scoring_MGDP.ViewModel
{
    public class TiposProyectosViewModel
    {
        [Display(Name = "Id")]
        public int IdTipoProyecto { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Display(Name = "Sigla")]
        public string Sigla { get; set; }
    }
}