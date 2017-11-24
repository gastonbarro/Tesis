using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scoring_MGDP.ViewModel
{
    public class MedicionesMetricasIndexViewModel
    {
        public IPagedList<MedicionesMetricasViewModel> PagedMedicionesMetricas { get; set; }
        public  int? IdDefMetricas {get;set;}
        public  int? ProveedorId{get;set;}
        public int? MetricaId { get; set; }
    }
}