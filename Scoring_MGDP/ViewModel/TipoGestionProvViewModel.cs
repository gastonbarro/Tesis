using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scoring_MGDP.ViewModel
{
    public class TipoGestionProvViewModel
    {
        public TipoGestionProvViewModel( string tipo)
        {
            Tipo = tipo;
        }

        public String Tipo { get; set; }

        public static List<TipoGestionProvViewModel> TipoGestionList()
        {
            var TipoGestionList = new List<TipoGestionProvViewModel>();
            TipoGestionList.Add(new TipoGestionProvViewModel("Capacidad e Infraestructura Técnica"));
            TipoGestionList.Add(new TipoGestionProvViewModel("Desarrollo"));
            TipoGestionList.Add(new TipoGestionProvViewModel("Seguridad de la Información"));
            TipoGestionList.Add(new TipoGestionProvViewModel("Servicio Productivo"));
            TipoGestionList.Add(new TipoGestionProvViewModel("Soporte Metodológico"));
            TipoGestionList.Add(new TipoGestionProvViewModel("Testeo"));
            TipoGestionList.Add(new TipoGestionProvViewModel("Workplace"));
            TipoGestionList.Add(new TipoGestionProvViewModel("Otros"));

            return TipoGestionList;
        }
    }

}