﻿using System;
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
    public class ClasifProveedoresController : Controller
    {
        private Scoring_MGDPEntities db = new Scoring_MGDPEntities();

        // GET: ClasifProveedores
        public ActionResult Index(int? page)
        {
            var ClasifProveedores = db.ClasificacionesProv.ToList();

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var ClasifProveedoresPageList = ClasifProveedores.ToPagedList(pageNumber, pageSize);

            var ClasifProveedoresVmPageList = ClasifProveedoresPageList.ToMappedPagedList<ClasificacionesProv, ClasifProveedoresViewModel>();

            return View(ClasifProveedoresVmPageList);
        }

        // GET: ClasifProveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClasificacionesProv clasificacionesProv = db.ClasificacionesProv.Find(id);
            if (clasificacionesProv == null)
            {
                return HttpNotFound();
            }
            return View(clasificacionesProv);
        }

        // GET: ClasifProveedores/Create
        public ActionResult Create()
        {
            return PartialView("Create");
        }

        // POST: ClasifProveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_ClasificacionProv,DescripcionClasifProv")] ClasificacionesProv clasificacionesProv)
        {
            if (ModelState.IsValid)
            {
                db.ClasificacionesProv.Add(clasificacionesProv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clasificacionesProv);
        }

        // GET: ClasifProveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClasificacionesProv clasificacionesProv = db.ClasificacionesProv.Find(id);
            if (clasificacionesProv == null)
            {
                return HttpNotFound();
            }
            return PartialView(clasificacionesProv);
        }

        // POST: ClasifProveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_ClasificacionProv,DescripcionClasifProv")] ClasificacionesProv clasificacionesProv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clasificacionesProv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clasificacionesProv);
        }

        // GET: ClasifProveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClasificacionesProv clasificacionesProv = db.ClasificacionesProv.Find(id);
            if (clasificacionesProv == null)
            {
                return HttpNotFound();
            }
            return View(clasificacionesProv);
        }

        // POST: ClasifProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClasificacionesProv clasificacionesProv = db.ClasificacionesProv.Find(id);
            db.ClasificacionesProv.Remove(clasificacionesProv);
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
