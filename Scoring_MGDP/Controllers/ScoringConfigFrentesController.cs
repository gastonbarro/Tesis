using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Scoring_MGDPData;

namespace Scoring_MGDP.Controllers
{
    public class ScoringConfigFrentesController : Controller
    {
        private Scoring_MGDPEntities db = new Scoring_MGDPEntities();

        // GET: ScoringConfigFrentes
        public ActionResult Index()
        {
            var scoringConfigFrentes = db.Scoring_Configuracion.Where(p => p.Tipo.Contains("Scoring"));

            var scoringConfigFrentesList = scoringConfigFrentes.ToList();

            return View(scoringConfigFrentesList);
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
            return View();
        }

        // POST: ScoringConfigFrentes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_MetricasScoring,Metrica,Peso,Ambito,Tipo")] Scoring_Configuracion scoring_Configuracion)
        {
            if (ModelState.IsValid)
            {
                db.Scoring_Configuracion.Add(scoring_Configuracion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scoring_Configuracion);
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
            return View(scoring_Configuracion);
        }

        // POST: ScoringConfigFrentes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_MetricasScoring,Metrica,Peso,Ambito,Tipo")] Scoring_Configuracion scoring_Configuracion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scoring_Configuracion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scoring_Configuracion);
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
            return View(scoring_Configuracion);
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
