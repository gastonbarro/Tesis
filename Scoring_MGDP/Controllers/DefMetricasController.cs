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
                .Where(m => m.id_Metricas == metId
                && m.id_Proveedor == provId);

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
            return View(defMetricas);
        }

        // GET: DefMetricas/Create
        public ActionResult Create()
        {
            ViewBag.id_Metricas = new SelectList(db.Metricas, "id_Metrica", "SiglaMetrica");
            ViewBag.id_Proveedor = new SelectList(db.Proveedores, "id_Proveedor", "NombreProv");
            ViewBag.id_TiposProyectos = new SelectList(db.TiposProyectos, "id_TiposProyectos", "DescTipoProyecto");
            ViewBag.id_vision = new SelectList(db.Vision, "id_vision", "DescripcionVision");
            return View();
        }

        // POST: DefMetricas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_DefMetricas,id_Proveedor,id_Metricas,FechaDesde,FechaHasta,Clave,Ratio,PesoPonderado,Peso,ObjCritico,ObjMinimo,ObjExcelencia,id_TiposProyectos,Hub_NoHub,id_vision")] DefMetricas defMetricas)
        {
            if (ModelState.IsValid)
            {
                db.DefMetricas.Add(defMetricas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Metricas = new SelectList(db.Metricas, "id_Metrica", "SiglaMetrica", defMetricas.id_Metricas);
            ViewBag.id_Proveedor = new SelectList(db.Proveedores, "id_Proveedor", "NombreProv", defMetricas.id_Proveedor);
            ViewBag.id_TiposProyectos = new SelectList(db.TiposProyectos, "id_TiposProyectos", "DescTipoProyecto", defMetricas.id_TiposProyectos);
            ViewBag.id_vision = new SelectList(db.Vision, "id_vision", "DescripcionVision", defMetricas.id_vision);
            return View(defMetricas);
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
            ViewBag.id_Metricas = new SelectList(db.Metricas, "id_Metrica", "SiglaMetrica", defMetricas.id_Metricas);
            ViewBag.id_Proveedor = new SelectList(db.Proveedores, "id_Proveedor", "NombreProv", defMetricas.id_Proveedor);
            ViewBag.id_TiposProyectos = new SelectList(db.TiposProyectos, "id_TiposProyectos", "DescTipoProyecto", defMetricas.id_TiposProyectos);
            ViewBag.id_vision = new SelectList(db.Vision, "id_vision", "DescripcionVision", defMetricas.id_vision);
            return View(defMetricas);
        }

        // POST: DefMetricas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_DefMetricas,id_Proveedor,id_Metricas,FechaDesde,FechaHasta,Clave,Ratio,PesoPonderado,Peso,ObjCritico,ObjMinimo,ObjExcelencia,id_TiposProyectos,Hub_NoHub,id_vision")] DefMetricas defMetricas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(defMetricas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Metricas = new SelectList(db.Metricas, "id_Metrica", "SiglaMetrica", defMetricas.id_Metricas);
            ViewBag.id_Proveedor = new SelectList(db.Proveedores, "id_Proveedor", "NombreProv", defMetricas.id_Proveedor);
            ViewBag.id_TiposProyectos = new SelectList(db.TiposProyectos, "id_TiposProyectos", "DescTipoProyecto", defMetricas.id_TiposProyectos);
            ViewBag.id_vision = new SelectList(db.Vision, "id_vision", "DescripcionVision", defMetricas.id_vision);
            return View(defMetricas);
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
            return View(defMetricas);
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
