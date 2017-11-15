using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scoring_MGDP.ViewModel
{
    public class ContratoProvViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Número contrato")]
        public string Numcontrato { get; set; }
        [Display(Name = "Proveedor")]
        public ProveedorViewModel ProveedorViewModel { get; set; }
        [Display(Name = "Id proveedor")]
        public int IdProveedor { get; set; }
        [Display(Name = "Responsable")]
        public string Responsable { get; set; }
        [Display(Name = "Monto")]
        public double Monto { get; set; }

        public SelectList Proveedores { get; set; }
    }
}