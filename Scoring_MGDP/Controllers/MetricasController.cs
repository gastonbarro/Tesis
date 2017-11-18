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
    public class MetricasController : Controller
    {
        private Scoring_MGDPEntities db = new Scoring_MGDPEntities();

        // GET: Metricas
        public ActionResult Index(int? page)
        {

            var metricas = db.Metricas.Include(m => m.TiposMetricas).Include(m => m.UnidadeDeMedidas).OrderByDescending(i => i.id_Metrica);

            int pageSize = 10;

            int pageNumber = (page ?? 1);

            var metricasPageList = metricas.ToPagedList(pageNumber, pageSize);

            var metricasVmPageList = metricasPageList.ToMappedPagedList<Metricas, MetricasViewModel>();

            return View(metricasVmPageList);


            //return View(metricas.ToList());
        }

        // GET: Metricas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Metricas metricas = db.Metricas.Find(id);
            if (metricas == null)
            {
                return HttpNotFound();
            }
            return View(metricas);
        }

        // GET: Metricas/Create
        public ActionResult Create()
        {
            var metricaViewModel = new MetricasViewModel();


            var tipoMetricaViewModel = ModelMappingProfile.Mapper.Map<List<TiposMetricas>, List<TiposMetricasViewModel>>(db.TiposMetricas.ToList());
            metricaViewModel.TipoMetricaList = new SelectList(tipoMetricaViewModel, "Id", "TipoMetrica");

            var unidadMedidaViewModel = ModelMappingProfile.Mapper.Map<List<UnidadeDeMedidas>, List<UnidadesMedidasViewModel>>(db.UnidadeDeMedidas.ToList());
            metricaViewModel.UnidadMedidaList = new SelectList(unidadMedidaViewModel, "Id", "UnidadMedida");

            return PartialView("Create", metricaViewModel);
        }

        // POST: Metricas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MetricasViewModel metricaViewModel)
        {
            if (ModelState.IsValid)
            {
                var metricas = ModelMappingProfile.Mapper.Map<MetricasViewModel, Metricas>(metricaViewModel);
                db.Metricas.Add(metricas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var tipoMetricaViewModel = ModelMappingProfile.Mapper.Map<List<TiposMetricas>, List<TiposMetricasViewModel>>(db.TiposMetricas.ToList());
            metricaViewModel.TipoMetricaList = new SelectList(tipoMetricaViewModel, "Id", "TipoMetrica", metricaViewModel.IdMetrica);

            var unidadMedidaViewModel = ModelMappingProfile.Mapper.Map<List<UnidadeDeMedidas>, List<UnidadesMedidasViewModel>>(db.UnidadeDeMedidas.ToList());
            metricaViewModel.UnidadMedidaList = new SelectList(unidadMedidaViewModel, "Id", "UnidadMedida", metricaViewModel.IdUnidad);

            return View(metricaViewModel);
        }

        // GET: Metricas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Metricas metricas = db.Metricas.Find(id);
            if (metricas == null)
            {
                return HttpNotFound();
            }

            var metricasViewModel = ModelMappingProfile.Mapper.Map<Metricas, MetricasViewModel>(metricas);

            var tipoMetricaViewModel = ModelMappingProfile.Mapper.Map<List<TiposMetricas>, List<TiposMetricasViewModel>>(db.TiposMetricas.ToList());
            metricasViewModel.TipoMetricaList = new SelectList(tipoMetricaViewModel, "Id", "TipoMetrica", metricasViewModel.TiposMetricasViewModel.Id);

            var unidadMedidaViewModel = ModelMappingProfile.Mapper.Map<List<UnidadeDeMedidas>, List<UnidadesMedidasViewModel>>(db.UnidadeDeMedidas.ToList());
            metricasViewModel.UnidadMedidaList = new SelectList(unidadMedidaViewModel, "Id", "UnidadMedida", metricasViewModel.UnidadesMedidasViewModel.Id);

            return PartialView("Edit", metricasViewModel);
        }

        // POST: Metricas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MetricasViewModel metricaViewModel)
        {
            if (ModelState.IsValid)
            {
                var metricas = ModelMappingProfile.Mapper.Map<MetricasViewModel, Metricas>(metricaViewModel);
                db.Entry(metricas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var tipoMetricaViewModel = ModelMappingProfile.Mapper.Map<List<TiposMetricas>, List<TiposMetricasViewModel>>(db.TiposMetricas.ToList());
            metricaViewModel.TipoMetricaList = new SelectList(tipoMetricaViewModel, "Id", "TipoMetrica", metricaViewModel.IdMetrica);

            var unidadMedidaViewModel = ModelMappingProfile.Mapper.Map<List<UnidadeDeMedidas>, List<UnidadesMedidasViewModel>>(db.UnidadeDeMedidas.ToList());
            metricaViewModel.UnidadMedidaList = new SelectList(unidadMedidaViewModel, "Id", "UnidadMedida", metricaViewModel.IdUnidad);

            return View(metricaViewModel);
        }

        // GET: Metricas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Metricas metricas = db.Metricas.Find(id);
            if (metricas == null)
            {
                return HttpNotFound();
            }
            return View(metricas);
        }

        // POST: Metricas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Metricas metricas = db.Metricas.Find(id);
            db.Metricas.Remove(metricas);
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
