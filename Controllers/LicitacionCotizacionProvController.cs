using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PortalCompras.Models;

namespace PortalCompras.Controllers
{
    public class LicitacionCotizacionProvController : Controller
    {
        private PortalComprasEntities db = new PortalComprasEntities();

        // GET: LicitacionCotizacionProv
        public ActionResult Index()
        {
            var licitacionCotizacionProvs = db.LicitacionCotizacionProvs.Include(l => l.Licitacione).Include(l => l.Producto).Include(l => l.Proveedor);
            return View(licitacionCotizacionProvs.ToList());
        }

        // GET: LicitacionCotizacionProv/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionCotizacionProv licitacionCotizacionProv = db.LicitacionCotizacionProvs.Find(id);
            if (licitacionCotizacionProv == null)
            {
                return HttpNotFound();
            }
            return View(licitacionCotizacionProv);
        }

        // GET: LicitacionCotizacionProv/Create
        public ActionResult Create()
        {
            ViewBag.IdLicitacion = new SelectList(db.Licitaciones, "IdLicitacion", "NombreLicitacion");
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "NombreProducto");
            ViewBag.IdProveedor = new SelectList(db.Proveedors, "IdProveedor", "NombreProveedor");
            return View();
        }

        // POST: LicitacionCotizacionProv/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCotizacion,IdLicitacion,IdProducto,IdProveedor,FechaCotizacionProveedor,PrecioUnitario")] LicitacionCotizacionProv licitacionCotizacionProv)
        {
            if (ModelState.IsValid)
            {
                db.LicitacionCotizacionProvs.Add(licitacionCotizacionProv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLicitacion = new SelectList(db.Licitaciones, "IdLicitacion", "NombreLicitacion", licitacionCotizacionProv.IdLicitacion);
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "NombreProducto", licitacionCotizacionProv.IdProducto);
            ViewBag.IdProveedor = new SelectList(db.Proveedors, "IdProveedor", "NombreProveedor", licitacionCotizacionProv.IdProveedor);
            return View(licitacionCotizacionProv);
        }

        // GET: LicitacionCotizacionProv/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionCotizacionProv licitacionCotizacionProv = db.LicitacionCotizacionProvs.Find(id);
            if (licitacionCotizacionProv == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLicitacion = new SelectList(db.Licitaciones, "IdLicitacion", "NombreLicitacion", licitacionCotizacionProv.IdLicitacion);
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "NombreProducto", licitacionCotizacionProv.IdProducto);
            ViewBag.IdProveedor = new SelectList(db.Proveedors, "IdProveedor", "NombreProveedor", licitacionCotizacionProv.IdProveedor);
            return View(licitacionCotizacionProv);
        }

        // POST: LicitacionCotizacionProv/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCotizacion,IdLicitacion,IdProducto,IdProveedor,FechaCotizacionProveedor,PrecioUnitario")] LicitacionCotizacionProv licitacionCotizacionProv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licitacionCotizacionProv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLicitacion = new SelectList(db.Licitaciones, "IdLicitacion", "NombreLicitacion", licitacionCotizacionProv.IdLicitacion);
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "NombreProducto", licitacionCotizacionProv.IdProducto);
            ViewBag.IdProveedor = new SelectList(db.Proveedors, "IdProveedor", "NombreProveedor", licitacionCotizacionProv.IdProveedor);
            return View(licitacionCotizacionProv);
        }

        // GET: LicitacionCotizacionProv/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionCotizacionProv licitacionCotizacionProv = db.LicitacionCotizacionProvs.Find(id);
            if (licitacionCotizacionProv == null)
            {
                return HttpNotFound();
            }
            return View(licitacionCotizacionProv);
        }

        // POST: LicitacionCotizacionProv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LicitacionCotizacionProv licitacionCotizacionProv = db.LicitacionCotizacionProvs.Find(id);
            db.LicitacionCotizacionProvs.Remove(licitacionCotizacionProv);
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
