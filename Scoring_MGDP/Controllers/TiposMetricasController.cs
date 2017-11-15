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
    public class TiposMetricasController : Controller
    {
        private Scoring_MGDPEntities db = new Scoring_MGDPEntities();

        // GET: TiposMetricas
        public ActionResult Index(int? page)
        {
            var TiposMetricas = db.TiposMetricas.ToList();

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var TiposMetricasPageList = TiposMetricas.ToPagedList(pageNumber, pageSize);

            var TiposMetricasVmPageList = TiposMetricasPageList.ToMappedPagedList<TiposMetricas, TiposMetricasViewModel>();

            return View(TiposMetricasVmPageList);
        }

        // GET: TiposMetricas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposMetricas tiposMetricas = db.TiposMetricas.Find(id);
            if (tiposMetricas == null)
            {
                return HttpNotFound();
            }
            return View(tiposMetricas);
        }

        // GET: TiposMetricas/Create
        public ActionResult Create()
        {
            var tiposMetricasViewModel = new TiposMetricasViewModel();
            
            return PartialView("Create",tiposMetricasViewModel);
        }

        // POST: TiposMetricas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TiposMetricasViewModel tiposMetricasViewModel)
        {
            if (ModelState.IsValid)
            {
                var tiposMetricas = ModelMappingProfile.Mapper.Map<TiposMetricasViewModel, TiposMetricas>(tiposMetricasViewModel);
                db.TiposMetricas.Add(tiposMetricas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tiposMetricasViewModel);
        }

        // GET: TiposMetricas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposMetricas tiposMetricas = db.TiposMetricas.Find(id);
            if (tiposMetricas == null)
            {
                return HttpNotFound();
            }
            var tiposMetricasViewModel = ModelMappingProfile.Mapper.Map<TiposMetricas,TiposMetricasViewModel>(tiposMetricas);
            return PartialView("Edit", tiposMetricasViewModel);
        }

        // POST: TiposMetricas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TiposMetricasViewModel tiposMetricasViewModel)
        {
            if (ModelState.IsValid)
            {
                var tiposMetricas = ModelMappingProfile.Mapper.Map<TiposMetricasViewModel, TiposMetricas>(tiposMetricasViewModel);
                db.Entry(tiposMetricas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tiposMetricasViewModel);
        }

        // GET: TiposMetricas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposMetricas tiposMetricas = db.TiposMetricas.Find(id);
            if (tiposMetricas == null)
            {
                return HttpNotFound();
            }
            var tiposMetricasViewModel = ModelMappingProfile.Mapper.Map<TiposMetricas, TiposMetricasViewModel>(tiposMetricas);
            return PartialView(tiposMetricasViewModel);
        }

        // POST: TiposMetricas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TiposMetricas tiposMetricas = db.TiposMetricas.Find(id);
            db.TiposMetricas.Remove(tiposMetricas);
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
