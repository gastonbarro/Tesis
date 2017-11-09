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
    public class ProveedoresController : Controller
    {
        private Scoring_MGDPEntities db = new Scoring_MGDPEntities();

        // GET: Proveedores
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            var YesNoList = new[] {
            new ListEntry { Id = "S", Name = "Si" },
            new ListEntry { Id = "N", Name = "No" }
            };

            ViewBag.YesNoList = new SelectList(YesNoList, "Id", "Name");


            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var proveedores = db.Proveedores.Include(p => p.ClasificacionesProv);

            if (!String.IsNullOrEmpty(searchString))
            {
                proveedores = proveedores.Where(s => s.NombreProv.Contains(searchString)
                                       || s.Gestion.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    proveedores = proveedores.OrderByDescending(s => s.NombreProv);
                    break;
                case "Name":
                    proveedores = proveedores.OrderBy(s => s.NombreProv);
                    break;
                default:
                    proveedores = proveedores.OrderBy(s => s.id_Proveedor);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var proveedoresPageList = proveedores.ToPagedList(pageNumber, pageSize);

            // Transforme la pagedlist de proveedores a pagedlist de proveedorViewModel
            var proveedoresVmPageList = proveedoresPageList.ToMappedPagedList<Proveedores, ProveedorViewModel>();
            // retorno la lista de los Proveedores View Model
            return View(proveedoresVmPageList);
        }

        // GET: Proveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedores proveedores = db.Proveedores.Find(id);
            if (proveedores == null)
            {
                return HttpNotFound();
            }
            return View(proveedores);
        }

        // GET: Proveedores/Create
        public ActionResult Create()
        {

            var YesNoList = new[] {
            new ListEntry { Id = "S", Name = "Si" },
            new ListEntry { Id = "N", Name = "No" }
            };

            ViewBag.YesNoList = new SelectList(YesNoList, "Id", "Name");

            ViewBag.id_ClasificacionProv = new SelectList(db.ClasificacionesProv, "id_ClasificacionProv", "DescripcionClasifProv");
            return PartialView("Create");
        }

        // POST: Proveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Proveedor,NombreProv,id_ClasificacionProv,EsAM,ModeloImplementado,NombreProvCompras,Gestion,Vigente")] Proveedores proveedores)
        {
            if (ModelState.IsValid)
            {
                db.Proveedores.Add(proveedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_ClasificacionProv = new SelectList(db.ClasificacionesProv, "id_ClasificacionProv", "DescripcionClasifProv", proveedores.id_ClasificacionProv);
            return View(proveedores);
        }

        // GET: Proveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedores proveedores = db.Proveedores.Find(id);
            if (proveedores == null)
            {
                return HttpNotFound();
            }

            var YesNoList = new[] {
            new ListEntry { Id = "S", Name = "Si" },
            new ListEntry { Id = "N", Name = "No" }
            };

            ViewBag.YesNoList = new SelectList(YesNoList, "Id", "Name");
            ViewBag.id_ClasificacionProv = new SelectList(db.ClasificacionesProv, "id_ClasificacionProv", "DescripcionClasifProv", proveedores.id_ClasificacionProv);
            return PartialView(proveedores);
            //return PartialView("Edit");
        }

        // POST: Proveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Proveedor,NombreProv,id_ClasificacionProv,EsAM,ModeloImplementado,NombreProvCompras,Gestion,Vigente")] Proveedores proveedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var YesNoList = new[] {
            new ListEntry { Id = "S", Name = "Si" },
            new ListEntry { Id = "N", Name = "No" }
            };

            ViewBag.YesNoList = new SelectList(YesNoList, "Id", "Name");

            ViewBag.id_ClasificacionProv = new SelectList(db.ClasificacionesProv, "id_ClasificacionProv", "DescripcionClasifProv", proveedores.id_ClasificacionProv);
            return View(proveedores);
        }

        // GET: Proveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedores proveedores = db.Proveedores.Find(id);
            if (proveedores == null)
            {
                return HttpNotFound();
            }
            return View(proveedores);
        }

        // POST: Proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proveedores proveedores = db.Proveedores.Find(id);
            db.Proveedores.Remove(proveedores);
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

    internal class ListEntry
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }

}
