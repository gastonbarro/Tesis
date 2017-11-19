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
    public class ContratoProvController : Controller
    {
        private Scoring_MGDPEntities db = new Scoring_MGDPEntities();

        // GET: ContratoProv
        public ActionResult Index(int? currentFilter, int? search, int? page)
        {

            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }

            var proveedoresViewModel = ModelMappingProfile.Mapper.Map<IEnumerable<Proveedores>, IEnumerable<ProveedorViewModel>>(db.Proveedores.ToList());
            ViewBag.ProveedoresList = new SelectList(proveedoresViewModel, "Id", "NombreProveedor");

            var contratoProvQuery = db.ContratoProv.Include(c => c.Proveedores);
            if (search.HasValue)
                contratoProvQuery = contratoProvQuery.Where(s => s.id_Proveedor == (search));

            var contratoProv = contratoProvQuery.OrderByDescending(i => i.id_Contrato);

            int pageSize = 10;

            int pageNumber = (page ?? 1);

            var contratoProvPageList = contratoProv.ToPagedList(pageNumber, pageSize);

            var contratoProvVmPageList = contratoProvPageList.ToMappedPagedList<ContratoProv, ContratoProvViewModel>();


         
             return View(contratoProvVmPageList);

            //var contratoProvPageList = contratoProv.ToPagedList(pageNumber, pageSize);

            //return View(contratoProvPageList);
        }

        // GET: ContratoProv/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoProv contratoProv = db.ContratoProv.Find(id);
            if (contratoProv == null)
            {
                return HttpNotFound();
            }
            return View(contratoProv);
        }

        // GET: ContratoProv/Create
        public ActionResult Create()
        {
            var contratoProvViewModel = new ContratoProvViewModel();

            //ViewBag.id_Proveedor = new SelectList(db.Proveedores, "id_Proveedor", "NombreProv");

            var proveedoresViewModel = ModelMappingProfile.Mapper.Map<List<Proveedores>, List<ProveedorViewModel>>(db.Proveedores.ToList());
            contratoProvViewModel.ProveedoresList = new SelectList(proveedoresViewModel, "Id", "NombreProveedor");
            return PartialView("Create", contratoProvViewModel);

        }

        // POST: ContratoProv/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContratoProvViewModel contratoProvViewModel)
        {
            if (ModelState.IsValid)
            {
                var contratoProv = ModelMappingProfile.Mapper.Map<ContratoProvViewModel, ContratoProv>(contratoProvViewModel);
                db.ContratoProv.Add(contratoProv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var proveedoresViewModel = ModelMappingProfile.Mapper.Map<List<Proveedores>, List<ProveedorViewModel>>(db.Proveedores.ToList());
            contratoProvViewModel.ProveedoresList = new SelectList(proveedoresViewModel, "Id", "NombreProveedor", contratoProvViewModel.IdProveedor);
            return View(contratoProvViewModel);
        }

        // GET: ContratoProv/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoProv contratoProv = db.ContratoProv.Find(id);
            if (contratoProv == null)
            {
                return HttpNotFound();
            }
            var contratoProvViewModel = ModelMappingProfile.Mapper.Map<ContratoProv, ContratoProvViewModel>(contratoProv);
            var proveedoresViewModel = ModelMappingProfile.Mapper.Map<List<Proveedores>, List<ProveedorViewModel>>(db.Proveedores.ToList());
            contratoProvViewModel.ProveedoresList = new SelectList(proveedoresViewModel, "Id", "NombreProveedor", contratoProvViewModel.IdProveedor);

            return PartialView("Edit", contratoProvViewModel);
            //ViewBag.id_Proveedor = new SelectList(db.Proveedores, "id_Proveedor", "NombreProv", contratoProv.id_Proveedor);
            //return View(contratoProv);
        }

        // POST: ContratoProv/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContratoProvViewModel contratoProvViewModel)
        {
            if (ModelState.IsValid)
            {
                var contratoProv = ModelMappingProfile.Mapper.Map<ContratoProvViewModel, ContratoProv>(contratoProvViewModel);
                db.Entry(contratoProv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var proveedoresViewModel = ModelMappingProfile.Mapper.Map<List<Proveedores>, List<ProveedorViewModel>>(db.Proveedores.ToList());
            contratoProvViewModel.ProveedoresList = new SelectList(proveedoresViewModel, "Id", "NombreProveedor", contratoProvViewModel.IdProveedor);
            return View(contratoProvViewModel);
        }

        // GET: ContratoProv/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoProv contratoProv = db.ContratoProv.Find(id);
            if (contratoProv == null)
            {
                return HttpNotFound();
            }
            var contratoProvViewModel = ModelMappingProfile.Mapper.Map<ContratoProv, ContratoProvViewModel>(contratoProv);
            var proveedoresViewModel = ModelMappingProfile.Mapper.Map<List<Proveedores>, List<ProveedorViewModel>>(db.Proveedores.ToList());
            contratoProvViewModel.ProveedoresList = new SelectList(proveedoresViewModel, "Id", "NombreProveedor", contratoProvViewModel.IdProveedor);
            return PartialView(contratoProvViewModel);
            //return View(contratoProv);
        }

        // POST: ContratoProv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContratoProv contratoProv = db.ContratoProv.Find(id);
            db.ContratoProv.Remove(contratoProv);
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
