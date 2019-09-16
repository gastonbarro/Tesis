using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scoring_MGDP.ViewModel
{
    public class ProveedorViewModel
    {
        public ProveedorViewModel()
        {
            this.AMList = new SelectList(YesNoViewModel.GetYesNoList(), "Id", "Nombre", this.AM);
            this.ModeloImplementadoList = new SelectList(YesNoViewModel.GetYesNoList(), "Id", "Nombre", this.ModeloImplementado);
            this.VigenteList = new SelectList(YesNoViewModel.GetYesNoList(), "Id", "Nombre", this.Vigente);
            this.TipoGestionList = new SelectList(TipoGestionProvViewModel.TipoGestionList(), "Tipo", "Tipo", this.Gestion);
        }


        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string NombreProveedor { get; set; }
        [Display(Name = "Clasificación")]
        public ClasifProveedoresViewModel ClasifProveedoresViewModel { get; set; }
        [Display(Name = "Clasificación")]
        public int ClasifProveedorId { get; set; }
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

        public SelectList ClasificacionesProveedores { get; set; }
        public SelectList AMList { get; set; }
        public SelectList ModeloImplementadoList { get; set; }
        public SelectList VigenteList { get; set; }

        public SelectList TipoGestionList { get; set; }

        //public string VigenteSiNo { get { if (Vigente == "S") return "Si"; else return "No"; } }
        public string VigenteSiNo { get { return (Vigente == "S" ? "Si" : "No"); } }
        public string ModeloImplementadoSiNo { get { return (ModeloImplementado == "S" ? "Si" : "No"); } }
        public string AMSiNo { get { return (AM == "S" ? "Si" : "No"); } }


    }
}