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
    public class OrganismoLicitantesController : Controller
    {
        private PortalComprasEntities db = new PortalComprasEntities();

        // GET: OrganismoLicitantes
        public ActionResult Index()
        {
            return View(db.OrganismoLicitantes.ToList());
        }

        // GET: OrganismoLicitantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganismoLicitante organismoLicitante = db.OrganismoLicitantes.Find(id);
            if (organismoLicitante == null)
            {
                return HttpNotFound();
            }
            return View(organismoLicitante);
        }

        // GET: OrganismoLicitantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrganismoLicitantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdOrganismoLicitante,NombreOrganismoLicitante,ContactoOrganismoLicitante,DireccionOrganismoLicitante")] OrganismoLicitante organismoLicitante)
        {
            if (ModelState.IsValid)
            {
                db.OrganismoLicitantes.Add(organismoLicitante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organismoLicitante);
        }

        // GET: OrganismoLicitantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganismoLicitante organismoLicitante = db.OrganismoLicitantes.Find(id);
            if (organismoLicitante == null)
            {
                return HttpNotFound();
            }
            return View(organismoLicitante);
        }

        // POST: OrganismoLicitantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdOrganismoLicitante,NombreOrganismoLicitante,ContactoOrganismoLicitante,DireccionOrganismoLicitante")] OrganismoLicitante organismoLicitante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organismoLicitante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organismoLicitante);
        }

        // GET: OrganismoLicitantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganismoLicitante organismoLicitante = db.OrganismoLicitantes.Find(id);
            if (organismoLicitante == null)
            {
                return HttpNotFound();
            }
            return View(organismoLicitante);
        }

        // POST: OrganismoLicitantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrganismoLicitante organismoLicitante = db.OrganismoLicitantes.Find(id);
            db.OrganismoLicitantes.Remove(organismoLicitante);
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
