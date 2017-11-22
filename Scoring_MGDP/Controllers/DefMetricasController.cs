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
using Scoring_MGDP.ViewModel;
using PagedList;
using Scoring_MGDP.Infrastructure;

namespace Scoring_MGDP.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class DefMetricasController : Controller
    {
        private Scoring_MGDPEntities db = new Scoring_MGDPEntities();

        // GET: DefMetricas
        public ActionResult Index(int? currentFilter, int? proveedorId, int? metricaId, int? page)
        {
            var provId = proveedorId.GetValueOrDefault();
            var metId = metricaId.GetValueOrDefault();

            var defMetricasQuery = db.DefMetricas.Include(m => m.Proveedores).Include(m => m.Metricas)
                .Include(m => m.TiposProyectos)
                .Where(m => m.id_Proveedor == provId 
                && m.id_Metricas == metId);

            var defMetricas = defMetricasQuery.OrderBy(m => m.id_DefMetricas);

            var proveedoresViewModel = ModelMappingProfile.Mapper.Map<IEnumerable<Proveedores>, IEnumerable<ProveedorViewModel>>(db.Proveedores.ToList());
            ViewBag.ProveedoresList = new SelectList(proveedoresViewModel, "Id", "NombreProveedor");
            ViewBag.ProveedorId = proveedorId;

            var metricasViewModel = ModelMappingProfile.Mapper.Map<IEnumerable<Metricas>, IEnumerable<MetricasViewModel>>(db.Metricas.ToList());
            ViewBag.MetricasList = new SelectList(metricasViewModel, "IdMetrica", "Descripcion");
            ViewBag.MetricaId = metricaId;


            int pageSize = 10;

            int pageNumber = (page ?? 1);

            var defMetricasPageList = defMetricas.ToPagedList(pageNumber, pageSize);

            var defMetricasVmPageList = defMetricasPageList.ToMappedPagedList<DefMetricas, DefMetricasViewModel>();

            return View(defMetricasVmPageList);
        }

        // GET: DefMetricas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefMetricas defMetricas = db.DefMetricas.Find(id);
            if (defMetricas == null)
            {
                return HttpNotFound();
            }

            var defMetricasViewModel = ModelMappingProfile.Mapper.Map<DefMetricas, DefMetricasViewModel>(defMetricas);

            var metricasViewModel = ModelMappingProfile.Mapper.Map<List<Metricas>, List<MetricasViewModel>>(db.Metricas.ToList());
            defMetricasViewModel.MetricasList = new SelectList(metricasViewModel, "IdMetrica", "Descripcion", defMetricasViewModel.IdMetrica);

            var proveedoresViewModel = ModelMappingProfile.Mapper.Map<List<Proveedores>, List<ProveedorViewModel>>(db.Proveedores.ToList());
            defMetricasViewModel.ProveedoresList = new SelectList(proveedoresViewModel, "Id", "NombreProveedor", defMetricasViewModel.IdProveedor);

            var tiposProyectosViewModel = ModelMappingProfile.Mapper.Map<List<TiposProyectos>, List<TiposProyectosViewModel>>(db.TiposProyectos.ToList());
            defMetricasViewModel.TiposProyectosList = new SelectList(tiposProyectosViewModel, "IdTipoProyecto", "Descripcion", defMetricasViewModel.IdTipoProyecto);

            var visionViewModel = ModelMappingProfile.Mapper.Map<List<Vision>, List<VisionViewModel>>(db.Vision.ToList());
            defMetricasViewModel.VisionList = new SelectList(visionViewModel, "IdVision", "Descripcion", defMetricasViewModel.IdVision);

            return PartialView("Details", defMetricasViewModel);

        }

        // GET: DefMetricas/Create
        public ActionResult Create(int? proveedorId)
        {

            var defMetricasViewModel = new DefMetricasViewModel();

            var metricasViewModel = ModelMappingProfile.Mapper.Map<List<Metricas>, List<MetricasViewModel>>(db.Metricas.ToList());
            defMetricasViewModel.MetricasList = new SelectList(metricasViewModel, "IdMetrica", "Descripcion");

            var proveedoresViewModel = ModelMappingProfile.Mapper.Map<List<Proveedores>, List<ProveedorViewModel>>(db.Proveedores.ToList());
            defMetricasViewModel.ProveedoresList = new SelectList(proveedoresViewModel, "Id", "NombreProveedor", proveedorId);

            var tiposProyectosViewModel = ModelMappingProfile.Mapper.Map<List<TiposProyectos>, List<TiposProyectosViewModel>>(db.TiposProyectos.ToList());
            defMetricasViewModel.TiposProyectosList = new SelectList(tiposProyectosViewModel, "IdTipoProyecto", "Descripcion");

            var visionViewModel = ModelMappingProfile.Mapper.Map<List<Vision>, List<VisionViewModel>>(db.Vision.ToList());
            defMetricasViewModel.VisionList = new SelectList(visionViewModel, "IdVision", "Descripcion");

            return PartialView("Create", defMetricasViewModel);
        }

        // POST: DefMetricas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DefMetricasViewModel defMetricasViewModel)
        {
            if (ModelState.IsValid)
            {
                var defMetricas = ModelMappingProfile.Mapper.Map<DefMetricasViewModel, DefMetricas>(defMetricasViewModel);
                db.DefMetricas.Add(defMetricas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var metricasViewModel = ModelMappingProfile.Mapper.Map<List<Metricas>, List<MetricasViewModel>>(db.Metricas.ToList());
            defMetricasViewModel.MetricasList = new SelectList(metricasViewModel, "IdMetrica", "Descripcion", defMetricasViewModel.IdMetrica);

            var proveedoresViewModel = ModelMappingProfile.Mapper.Map<List<Proveedores>, List<ProveedorViewModel>>(db.Proveedores.ToList());
            defMetricasViewModel.ProveedoresList = new SelectList(proveedoresViewModel, "Id", "NombreProveedor",defMetricasViewModel.IdProveedor);

            var tiposProyectosViewModel = ModelMappingProfile.Mapper.Map<List<TiposProyectos>, List<TiposProyectosViewModel>>(db.TiposProyectos.ToList());
            defMetricasViewModel.TiposProyectosList = new SelectList(tiposProyectosViewModel, "IdTipoProyecto", "Descripcion", defMetricasViewModel.IdTipoProyecto);

            var visionViewModel = ModelMappingProfile.Mapper.Map<List<Vision>, List<VisionViewModel>>(db.Vision.ToList());
            defMetricasViewModel.VisionList = new SelectList(visionViewModel, "IdVision", "Descripcion", defMetricasViewModel.IdVision);

            return View(defMetricasViewModel);
        }

        // GET: DefMetricas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefMetricas defMetricas = db.DefMetricas.Find(id);
            if (defMetricas == null)
            {
                return HttpNotFound();
            }

            var defMetricasViewModel = ModelMappingProfile.Mapper.Map<DefMetricas, DefMetricasViewModel>(defMetricas);

            var metricasViewModel = ModelMappingProfile.Mapper.Map<List<Metricas>, List<MetricasViewModel>>(db.Metricas.ToList());
            defMetricasViewModel.MetricasList = new SelectList(metricasViewModel, "IdMetrica", "Descripcion", defMetricasViewModel.IdMetrica);

            var proveedoresViewModel = ModelMappingProfile.Mapper.Map<List<Proveedores>, List<ProveedorViewModel>>(db.Proveedores.ToList());
            defMetricasViewModel.ProveedoresList = new SelectList(proveedoresViewModel, "Id", "NombreProveedor", defMetricasViewModel.IdProveedor);

            var tiposProyectosViewModel = ModelMappingProfile.Mapper.Map<List<TiposProyectos>, List<TiposProyectosViewModel>>(db.TiposProyectos.ToList());
            defMetricasViewModel.TiposProyectosList = new SelectList(tiposProyectosViewModel, "IdTipoProyecto", "Descripcion", defMetricasViewModel.IdTipoProyecto);

            var visionViewModel = ModelMappingProfile.Mapper.Map<List<Vision>, List<VisionViewModel>>(db.Vision.ToList());
            defMetricasViewModel.VisionList = new SelectList(visionViewModel, "IdVision", "Descripcion", defMetricasViewModel.IdVision);

            return PartialView("Edit", defMetricasViewModel);
        }

        // POST: DefMetricas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DefMetricasViewModel defMetricasViewModel)
        {
            if (ModelState.IsValid)
            {
                var defMetricas = ModelMappingProfile.Mapper.Map<DefMetricasViewModel, DefMetricas>(defMetricasViewModel);
                db.Entry(defMetricas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var metricasViewModel = ModelMappingProfile.Mapper.Map<List<Metricas>, List<MetricasViewModel>>(db.Metricas.ToList());
            defMetricasViewModel.MetricasList = new SelectList(metricasViewModel, "IdMetrica", "Descripcion", defMetricasViewModel.IdMetrica);

            var proveedoresViewModel = ModelMappingProfile.Mapper.Map<List<Proveedores>, List<ProveedorViewModel>>(db.Proveedores.ToList());
            defMetricasViewModel.ProveedoresList = new SelectList(proveedoresViewModel, "Id", "NombreProveedor", defMetricasViewModel.IdProveedor);

            var tiposProyectosViewModel = ModelMappingProfile.Mapper.Map<List<TiposProyectos>, List<TiposProyectosViewModel>>(db.TiposProyectos.ToList());
            defMetricasViewModel.TiposProyectosList = new SelectList(tiposProyectosViewModel, "IdTipoProyecto", "Descripcion", defMetricasViewModel.IdTipoProyecto);

            var visionViewModel = ModelMappingProfile.Mapper.Map<List<Vision>, List<VisionViewModel>>(db.Vision.ToList());
            defMetricasViewModel.VisionList = new SelectList(visionViewModel, "IdVision", "Descripcion", defMetricasViewModel.IdVision);

            return View(defMetricasViewModel);
        }

        // GET: DefMetricas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DefMetricas defMetricas = db.DefMetricas.Find(id);
            if (defMetricas == null)
            {
                return HttpNotFound();
            }

            var defMetricasViewModel = ModelMappingProfile.Mapper.Map<DefMetricas, DefMetricasViewModel>(defMetricas);

            var metricasViewModel = ModelMappingProfile.Mapper.Map<List<Metricas>, List<MetricasViewModel>>(db.Metricas.ToList());
            defMetricasViewModel.MetricasList = new SelectList(metricasViewModel, "IdMetrica", "Descripcion", defMetricasViewModel.IdMetrica);

            var proveedoresViewModel = ModelMappingProfile.Mapper.Map<List<Proveedores>, List<ProveedorViewModel>>(db.Proveedores.ToList());
            defMetricasViewModel.ProveedoresList = new SelectList(proveedoresViewModel, "Id", "NombreProveedor", defMetricasViewModel.IdProveedor);

            var tiposProyectosViewModel = ModelMappingProfile.Mapper.Map<List<TiposProyectos>, List<TiposProyectosViewModel>>(db.TiposProyectos.ToList());
            defMetricasViewModel.TiposProyectosList = new SelectList(tiposProyectosViewModel, "IdTipoProyecto", "Descripcion", defMetricasViewModel.IdTipoProyecto);

            var visionViewModel = ModelMappingProfile.Mapper.Map<List<Vision>, List<VisionViewModel>>(db.Vision.ToList());
            defMetricasViewModel.VisionList = new SelectList(visionViewModel, "IdVision", "Descripcion", defMetricasViewModel.IdVision);

            return PartialView("Delete", defMetricasViewModel);
        }

        // POST: DefMetricas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DefMetricas defMetricas = db.DefMetricas.Find(id);
            db.DefMetricas.Remove(defMetricas);
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
