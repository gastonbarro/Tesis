using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scoring_MGDP.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class TablerosController : Controller
    {
        // GET: Tableros
        public ActionResult TableroScoring()
        {
            return View("_TableroScoring");
        }

        public ActionResult TableroDetalleScoring()
        {
            return View("_TableroDetalleScoring");
        }
    }
}