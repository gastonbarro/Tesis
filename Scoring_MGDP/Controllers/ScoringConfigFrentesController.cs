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
    public class ScoringConfigFrentesController : Controller
    {
        private Scoring_MGDPEntities db = new Scoring_MGDPEntities();

        // GET: ScoringConfigFrentes
        public ActionResult Index(int? page)
        {
            var scoringConfigFrentes = db.Scoring_Configuracion.OrderByDescending(i => i.Metrica).Where(p => p.Tipo.Equals("Scoring"));

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var scoringConfigFrentesPageList = scoringConfigFrentes.ToPagedList(pageNumber, pageSize);

            var scoringConfigFerntesVmPageList = scoringConfigFrentesPageList.ToMappedPagedList<Scoring_Configuracion, ScoringConfigFrentesViewModel>();

            return View(scoringConfigFerntesVmPageList);
        }

        // GET: ScoringConfigFrentes/Details/5
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

        // GET: ScoringConfigFrentes/Create
        public ActionResult Create()
        {
            var scoringConfigFrentesViewModel = new ScoringConfigFrentesViewModel();

            return PartialView("Create", scoringConfigFrentesViewModel);
        }

        // POST: ScoringConfigFrentes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScoringConfigFrentesViewModel scoringConfigFrentesViewModel)
        {
            if (ModelState.IsValid)
            {
                scoringConfigFrentesViewModel.Metrica = scoringConfigFrentesViewModel.Ambito;
                scoringConfigFrentesViewModel.Tipo = "Scoring";

                var scoring_Configuracion = ModelMappingProfile.Mapper.Map<ScoringConfigFrentesViewModel, Scoring_Configuracion>(scoringConfigFrentesViewModel);
                db.Scoring_Configuracion.Add(scoring_Configuracion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scoringConfigFrentesViewModel);
        }

        // GET: ScoringConfigFrentes/Edit/5
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
            var scoringConfigFrentesViewModel = ModelMappingProfile.Mapper.Map<Scoring_Configuracion, ScoringConfigFrentesViewModel>(scoring_Configuracion);
            return PartialView("Edit", scoringConfigFrentesViewModel);
        }

        // POST: ScoringConfigFrentes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ScoringConfigFrentesViewModel scoringConfigFrentesViewModel)
        {
            if (ModelState.IsValid)
            {
                scoringConfigFrentesViewModel.Metrica = scoringConfigFrentesViewModel.Ambito;
                scoringConfigFrentesViewModel.Tipo = "Scoring";

                var scoring_Configuracion = ModelMappingProfile.Mapper.Map<ScoringConfigFrentesViewModel, Scoring_Configuracion>(scoringConfigFrentesViewModel);
                db.Entry(scoring_Configuracion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scoringConfigFrentesViewModel);
        }

        // GET: ScoringConfigFrentes/Delete/5
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
            var scoringConfigFrentesViewModel = ModelMappingProfile.Mapper.Map<Scoring_Configuracion, ScoringConfigFrentesViewModel>(scoring_Configuracion);
            return PartialView(scoringConfigFrentesViewModel);
        }

        // POST: ScoringConfigFrentes/Delete/5
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
