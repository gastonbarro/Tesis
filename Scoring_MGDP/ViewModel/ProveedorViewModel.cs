using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scoring_MGDP.ViewModel
{
    public class ProveedorViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string NombreProveedor { get; set; }
        [Display(Name = "Clasificación")]
        public int ClasificacionProveedorId { get; set; }
        [Display(Name = "¿AM?")]
        public string AM { get; set; }
        [Display(Name = "¿Modelo implementado?")]
        public string ModeloImplementado { get; set; }
        [Display(Name = "Nombre compras")]
        public string NombreCompras { get; set; }
        [Display(Name = "Tipo gestión")]
        public string Gestion { get; set; }
        [Display(Name = "¿Activo?")]
        public string Vigente { get; set; }


        //public string VigenteSiNo { get { if (Vigente == "S") return "Si"; else return "No"; } }
        public string VigenteSiNo { get { return (Vigente == "S" ? "Si" : "No"); } }
        public string ModeloImplementadoSiNo { get { return (ModeloImplementado == "S" ? "Si" : "No"); } }
        public string AMSiNo { get { return (AM == "S" ? "Si" : "No"); } }


    }
}