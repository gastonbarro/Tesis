using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Scoring_MGDPData;
using PagedList;
using Scoring_MGDP.ViewModel;
using Scoring_MGDP.Mapping;
using Scoring_MGDP.Infrastructure;

namespace Scoring_MGDP.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class ScoringConfigMedidasController : Controller
    {
        private Scoring_MGDPEntities db = new Scoring_MGDPEntities();

        // GET: ScoringConfigMedidas
        public ActionResult Index(int? page)
        {
            var scoringConfigMedidas = db.Scoring_Configuracion.OrderByDescending(i => i.id_MetricasScoring).Where(p => !p.Tipo.Equals("Scoring Proveedor")); //Where(p => p.Ambito.Equals("Proveedor"));

            int pageSize = 20;
            int pageNumber = (page ?? 1);

            var scoringConfigMedidasPageList = scoringConfigMedidas.ToPagedList(pageNumber, pageSize);

            var scoringConfigMedidasVmPageList = scoringConfigMedidasPageList.ToMappedPagedList<Scoring_Configuracion, ScoringConfigMedidasViewModel>();

            return View(scoringConfigMedidasVmPageList);

        }

        // GET: ScoringConfigMedidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scoring_Configuracion scoring_Configuracion = db.Scoring_Configuracion.Find(id);
            if (scoring_Configuracion == null)
            {
                return HttpNotFound();
            }
            return View(scoring_Configuracion);
        }

        // GET: ScoringConfigMedidas/Create
        public ActionResult Create()
        {

            var scoringConfigMedidasViewModel = new ScoringConfigMedidasViewModel();

            return PartialView("Create", scoringConfigMedidasViewModel);

        }

        // POST: ScoringConfigMedidas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScoringConfigMedidasViewModel scoringConfigMedidasViewModel)
        {
            if (ModelState.IsValid)
            {
                var scoring_Configuracion = ModelMappingProfile.Mapper.Map<ScoringConfigMedidasViewModel, Scoring_Configuracion>(scoringConfigMedidasViewModel);
                db.Scoring_Configuracion.Add(scoring_Configuracion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scoringConfigMedidasViewModel);
        }

        // GET: ScoringConfigMedidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scoring_Configuracion scoring_Configuracion = db.Scoring_Configuracion.Find(id);
            if (scoring_Configuracion == null)
            {
                return HttpNotFound();
            }
            var scoringConfigMedidasViewModel = ModelMappingProfile.Mapper.Map<Scoring_Configuracion, ScoringConfigMedidasViewModel>(scoring_Configuracion);
            return PartialView("Edit", scoringConfigMedidasViewModel);
        }

        // POST: ScoringConfigMedidas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ScoringConfigMedidasViewModel scoringConfigMedidasViewModel)
        {
            if (ModelState.IsValid)
            {
                var scoring_Configuracion = ModelMappingProfile.Mapper.Map<ScoringConfigMedidasViewModel, Scoring_Configuracion>(scoringConfigMedidasViewModel);
                db.Entry(scoring_Configuracion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scoringConfigMedidasViewModel);
        }

        // GET: ScoringConfigMedidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scoring_Configuracion scoring_Configuracion = db.Scoring_Configuracion.Find(id);
            if (scoring_Configuracion == null)
            {
                return HttpNotFound();
            }
            var scoringConfigMedidasViewModel = ModelMappingProfile.Mapper.Map<Scoring_Configuracion, ScoringConfigMedidasViewModel>(scoring_Configuracion);
            return PartialView(scoringConfigMedidasViewModel);
        }

        // POST: ScoringConfigMedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Scoring_Configuracion scoring_Configuracion = db.Scoring_Configuracion.Find(id);
            db.Scoring_Configuracion.Remove(scoring_Configuracion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
