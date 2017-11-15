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
    public class UnidadesMedidasController : Controller
    {
        private Scoring_MGDPEntities db = new Scoring_MGDPEntities();

        // GET: UnidadesMedidas
        public ActionResult Index(int? page)
        {
            var UnidadesMedidas = db.UnidadeDeMedidas.ToList();

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var UnidadesMedidasPageList = UnidadesMedidas.ToPagedList(pageNumber, pageSize);

            var UnidadesMedidasVmPageList = UnidadesMedidasPageList.ToMappedPagedList<UnidadeDeMedidas,UnidadesMedidasViewModel>();

            return View(UnidadesMedidasVmPageList);
        }

        // GET: UnidadesMedidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeDeMedidas unidadeDeMedidas = db.UnidadeDeMedidas.Find(id);
            if (unidadeDeMedidas == null)
            {
                return HttpNotFound();
            }
            return PartialView(unidadeDeMedidas);
        }

        // GET: UnidadesMedidas/Create
        public ActionResult Create()
        {
            var unidadesMedidasViewModel = new UnidadesMedidasViewModel();

            return PartialView("Create", unidadesMedidasViewModel);
                                         
        }

        // POST: UnidadesMedidas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UnidadesMedidasViewModel unidadesMedidasViewModel)
        {
            if (ModelState.IsValid)
            {
                var unidadesMedidas = ModelMappingProfile.Mapper.Map<UnidadesMedidasViewModel, UnidadeDeMedidas>(unidadesMedidasViewModel);
                db.UnidadeDeMedidas.Add(unidadesMedidas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unidadesMedidasViewModel);
        }

        // GET: UnidadesMedidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeDeMedidas unidadeDeMedidas = db.UnidadeDeMedidas.Find(id);
            if (unidadeDeMedidas == null)
            {
                return HttpNotFound();
            }
            var unidadesMedidasViewModel = ModelMappingProfile.Mapper.Map<UnidadeDeMedidas, UnidadesMedidasViewModel>(unidadeDeMedidas);
            return PartialView("Edit", unidadesMedidasViewModel);
        }

        // POST: UnidadesMedidas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UnidadesMedidasViewModel unidadesMedidasViewModel)
        {
            if (ModelState.IsValid)
            {
                var unidadeDeMedidas = ModelMappingProfile.Mapper.Map<UnidadesMedidasViewModel, UnidadeDeMedidas>(unidadesMedidasViewModel);
                db.Entry(unidadeDeMedidas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unidadesMedidasViewModel);
        }

        // GET: UnidadesMedidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeDeMedidas unidadeDeMedidas = db.UnidadeDeMedidas.Find(id);
            if (unidadeDeMedidas == null)
            {
                return HttpNotFound();
            }
            var unidadesMedidasViewModel = ModelMappingProfile.Mapper.Map<UnidadeDeMedidas, UnidadesMedidasViewModel>(unidadeDeMedidas);
            return PartialView(unidadesMedidasViewModel);
        }

        // POST: UnidadesMedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnidadeDeMedidas unidadeDeMedidas = db.UnidadeDeMedidas.Find(id);
            db.UnidadeDeMedidas.Remove(unidadeDeMedidas);
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
