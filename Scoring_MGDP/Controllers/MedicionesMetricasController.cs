using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Scoring_MGDPData;
using Scoring_MGDP.Mapping;
using PagedList;
using Scoring_MGDP.ViewModel;
using Scoring_MGDP.Infrastructure;

namespace Scoring_MGDP.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class MedicionesMetricasController : Controller
    {
        private Scoring_MGDPEntities db = new Scoring_MGDPEntities();

        // GET: MedicionesMetricas
        public ActionResult Index(int? currentFilter, int? proveedorId, int? metricaId, int? page)
        {
            var medicionesMetricasQuery = db.MedicionesMetricas.Include(m => m.DefMetricas)
                .Include(m => m.TiposProyectos)
                .Include(m => m.DefMetricas.Proveedores);
                //.Where(m => m.DefMetricas.id_Metricas == metricaId.GetValueOrDefault()
                //&& m.DefMetricas.id_Proveedor == proveedorId.GetValueOrDefault());

            var medicionesMetricas = medicionesMetricasQuery.OrderBy(m => m.id_Medicion_Metrica);

            //var proveedoresViewModel = ModelMappingProfile.Mapper.Map<IEnumerable<Proveedores>, IEnumerable<ProveedorViewModel>>(db.Proveedores.ToList());
            //ViewBag.ProveedoresList = new SelectList(proveedoresViewModel, "Id", "NombreProveedor");
            //ViewBag.ProveedorId = proveedorId;

            //var metricasViewModel = ModelMappingProfile.Mapper.Map<IEnumerable<Metricas>, IEnumerable<MetricasViewModel>>(db.Metricas.ToList());
            //ViewBag.MetricasList = new SelectList(proveedoresViewModel, "IdMetrica", "Descripcion");
            //ViewBag.MetricaId = metricaId;

            int pageSize = 10;

            int pageNumber = (page ?? 1);

            var medicionesMetricasPageList = medicionesMetricas.ToPagedList(pageNumber, pageSize);

            var medicionesMetricasVmPageList = medicionesMetricasPageList.ToMappedPagedList<MedicionesMetricas, MedicionesMetricasViewModel>();

            return View(medicionesMetricasVmPageList);


        }

        // GET: MedicionesMetricas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicionesMetricas medicionesMetricas = db.MedicionesMetricas.Find(id);
            if (medicionesMetricas == null)
            {
                return HttpNotFound();
            }
            return View(medicionesMetricas);
        }

        // GET: MedicionesMetricas/Create
        public ActionResult Create()
        {
            var medicionesMetricasViewModel = new MedicionesMetricasViewModel();
            
            var defMetricasViewMolde = ModelMappingProfile.Mapper.Map<List<DefMetricas>, List<DefMetricasViewModel>>(db.DefMetricas.ToList());
            medicionesMetricasViewModel.TiposProyectosList = new SelectList(defMetricasViewMolde, "IdDefMetrica", "Descripcion");

            var tiposProyectosViewModel = ModelMappingProfile.Mapper.Map<List<TiposProyectos>, List<TiposProyectosViewModel>>(db.TiposProyectos.ToList());
            medicionesMetricasViewModel.TiposProyectosList = new SelectList(tiposProyectosViewModel, "IdTipoProyecto", "Descripcion");

            return PartialView("Create",medicionesMetricasViewModel);

        }

        // POST: MedicionesMetricas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicionesMetricasViewModel medicionesMetricasViewModel)
        {
            if (ModelState.IsValid)
            {
                var medicionesMetricas = ModelMappingProfile.Mapper.Map<MedicionesMetricasViewModel, MedicionesMetricas>(medicionesMetricasViewModel);
                db.MedicionesMetricas.Add(medicionesMetricas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var defMetricasViewMolde = ModelMappingProfile.Mapper.Map<List<DefMetricas>, List<DefMetricasViewModel>>(db.DefMetricas.ToList());
            medicionesMetricasViewModel.TiposProyectosList = new SelectList(defMetricasViewMolde, "IdDefMetrica", "Descripcion", medicionesMetricasViewModel.IdDefMetrica);

            var tiposProyectosViewModel = ModelMappingProfile.Mapper.Map<List<TiposProyectos>, List<TiposProyectosViewModel>>(db.TiposProyectos.ToList());
            medicionesMetricasViewModel.TiposProyectosList = new SelectList(tiposProyectosViewModel, "IdTipoProyecto", "Descripcion", medicionesMetricasViewModel.IdTipoProyecto);

            return View(medicionesMetricasViewModel);
        }

        // GET: MedicionesMetricas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicionesMetricas medicionesMetricas = db.MedicionesMetricas.Find(id);
            if (medicionesMetricas == null)
            {
                return HttpNotFound();
            }

            var medicionesMetricasViewModel = ModelMappingProfile.Mapper.Map<MedicionesMetricas, MedicionesMetricasViewModel>(medicionesMetricas);

            var defMetricasViewMolde = ModelMappingProfile.Mapper.Map<List<DefMetricas>, List<DefMetricasViewModel>>(db.DefMetricas.ToList());
            medicionesMetricasViewModel.TiposProyectosList = new SelectList(defMetricasViewMolde, "IdDefMetrica", "Descripcion", medicionesMetricasViewModel.IdDefMetrica);

            var tiposProyectosViewModel = ModelMappingProfile.Mapper.Map<List<TiposProyectos>, List<TiposProyectosViewModel>>(db.TiposProyectos.ToList());
            medicionesMetricasViewModel.TiposProyectosList = new SelectList(tiposProyectosViewModel, "IdTipoProyecto", "Descripcion", medicionesMetricasViewModel.IdTipoProyecto);

            return PartialView("Edit",medicionesMetricasViewModel);
        }

        // POST: MedicionesMetricas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MedicionesMetricasViewModel medicionesMetricasViewModel)
        {
            if (ModelState.IsValid)
            {
                var medicionesMetricas = ModelMappingProfile.Mapper.Map<MedicionesMetricasViewModel, MedicionesMetricas>(medicionesMetricasViewModel);
                db.Entry(medicionesMetricas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var defMetricasViewMolde = ModelMappingProfile.Mapper.Map<List<DefMetricas>, List<DefMetricasViewModel>>(db.DefMetricas.ToList());
            medicionesMetricasViewModel.TiposProyectosList = new SelectList(defMetricasViewMolde, "IdDefMetrica", "Descripcion", medicionesMetricasViewModel.IdDefMetrica);

            var tiposProyectosViewModel = ModelMappingProfile.Mapper.Map<List<TiposProyectos>, List<TiposProyectosViewModel>>(db.TiposProyectos.ToList());
            medicionesMetricasViewModel.TiposProyectosList = new SelectList(tiposProyectosViewModel, "IdTipoProyecto", "Descripcion", medicionesMetricasViewModel.IdTipoProyecto);

            return View(medicionesMetricasViewModel);
        }

        // GET: MedicionesMetricas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicionesMetricas medicionesMetricas = db.MedicionesMetricas.Find(id);
            if (medicionesMetricas == null)
            {
                return HttpNotFound();
            }

            var medicionesMetricasViewModel = ModelMappingProfile.Mapper.Map<MedicionesMetricas, MedicionesMetricasViewModel>(medicionesMetricas);

            var defMetricasViewMolde = ModelMappingProfile.Mapper.Map<List<DefMetricas>, List<DefMetricasViewModel>>(db.DefMetricas.ToList());
            medicionesMetricasViewModel.TiposProyectosList = new SelectList(defMetricasViewMolde, "IdDefMetrica", "Descripcion", medicionesMetricasViewModel.IdDefMetrica);

            var tiposProyectosViewModel = ModelMappingProfile.Mapper.Map<List<TiposProyectos>, List<TiposProyectosViewModel>>(db.TiposProyectos.ToList());
            medicionesMetricasViewModel.TiposProyectosList = new SelectList(tiposProyectosViewModel, "IdTipoProyecto", "Descripcion", medicionesMetricasViewModel.IdTipoProyecto);

            return PartialView("Delete",medicionesMetricasViewModel);
        }

        // POST: MedicionesMetricas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicionesMetricas medicionesMetricas = db.MedicionesMetricas.Find(id);
            db.MedicionesMetricas.Remove(medicionesMetricas);
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
