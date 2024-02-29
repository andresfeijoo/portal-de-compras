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
    public class AdjudicacionLicitacionProveedorController : Controller
    {
        private PortalComprasEntities db = new PortalComprasEntities();

        // GET: AdjudicacionLicitacionProveedor
        public ActionResult Index()
        {
            var adjudicacionLicitacionProveedors = db.AdjudicacionLicitacionProveedors.Include(a => a.LicitacionCotizacionProv).Include(a => a.Licitacione).Include(a => a.Producto);
            return View(adjudicacionLicitacionProveedors.ToList());
        }

        // GET: AdjudicacionLicitacionProveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdjudicacionLicitacionProveedor adjudicacionLicitacionProveedor = db.AdjudicacionLicitacionProveedors.Find(id);
            if (adjudicacionLicitacionProveedor == null)
            {
                return HttpNotFound();
            }
            return View(adjudicacionLicitacionProveedor);
        }

        // GET: AdjudicacionLicitacionProveedor/Create
        public ActionResult Create()
        {
            ViewBag.IdCotizacion = new SelectList(db.LicitacionCotizacionProvs, "IdCotizacion", "IdCotizacion");
            ViewBag.IdLicitacion = new SelectList(db.Licitaciones, "IdLicitacion", "NombreLicitacion");
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "NombreProducto");
            return View();
        }

        // POST: AdjudicacionLicitacionProveedor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAdjudicacion,IdLicitacion,IdCotizacion,IdProducto,FormaPagoAdj")] AdjudicacionLicitacionProveedor adjudicacionLicitacionProveedor)
        {
            if (ModelState.IsValid)
            {
                db.AdjudicacionLicitacionProveedors.Add(adjudicacionLicitacionProveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCotizacion = new SelectList(db.LicitacionCotizacionProvs, "IdCotizacion", "IdCotizacion", adjudicacionLicitacionProveedor.IdCotizacion);
            ViewBag.IdLicitacion = new SelectList(db.Licitaciones, "IdLicitacion", "NombreLicitacion", adjudicacionLicitacionProveedor.IdLicitacion);
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "NombreProducto", adjudicacionLicitacionProveedor.IdProducto);
            return View(adjudicacionLicitacionProveedor);
        }

        // GET: AdjudicacionLicitacionProveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdjudicacionLicitacionProveedor adjudicacionLicitacionProveedor = db.AdjudicacionLicitacionProveedors.Find(id);
            if (adjudicacionLicitacionProveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCotizacion = new SelectList(db.LicitacionCotizacionProvs, "IdCotizacion", "IdCotizacion", adjudicacionLicitacionProveedor.IdCotizacion);
            ViewBag.IdLicitacion = new SelectList(db.Licitaciones, "IdLicitacion", "NombreLicitacion", adjudicacionLicitacionProveedor.IdLicitacion);
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "NombreProducto", adjudicacionLicitacionProveedor.IdProducto);
            return View(adjudicacionLicitacionProveedor);
        }

        // POST: AdjudicacionLicitacionProveedor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAdjudicacion,IdLicitacion,IdCotizacion,IdProducto,FormaPagoAdj")] AdjudicacionLicitacionProveedor adjudicacionLicitacionProveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adjudicacionLicitacionProveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCotizacion = new SelectList(db.LicitacionCotizacionProvs, "IdCotizacion", "IdCotizacion", adjudicacionLicitacionProveedor.IdCotizacion);
            ViewBag.IdLicitacion = new SelectList(db.Licitaciones, "IdLicitacion", "NombreLicitacion", adjudicacionLicitacionProveedor.IdLicitacion);
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "NombreProducto", adjudicacionLicitacionProveedor.IdProducto);
            return View(adjudicacionLicitacionProveedor);
        }

        // GET: AdjudicacionLicitacionProveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdjudicacionLicitacionProveedor adjudicacionLicitacionProveedor = db.AdjudicacionLicitacionProveedors.Find(id);
            if (adjudicacionLicitacionProveedor == null)
            {
                return HttpNotFound();
            }
            return View(adjudicacionLicitacionProveedor);
        }

        // POST: AdjudicacionLicitacionProveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdjudicacionLicitacionProveedor adjudicacionLicitacionProveedor = db.AdjudicacionLicitacionProveedors.Find(id);
            db.AdjudicacionLicitacionProveedors.Remove(adjudicacionLicitacionProveedor);
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
