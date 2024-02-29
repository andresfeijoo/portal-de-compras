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
    public class LicitadorController : Controller
    {
        private PortalComprasEntities db = new PortalComprasEntities();

        // GET: Licitador
        public ActionResult Index()
        {
            var licitadors = db.Licitadors.Include(l => l.OrganismoLicitante);
            return View(licitadors.ToList());
        }

        // GET: Licitador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licitador licitador = db.Licitadors.Find(id);
            if (licitador == null)
            {
                return HttpNotFound();
            }
            return View(licitador);
        }

        // GET: Licitador/Create
        public ActionResult Create()
        {
            ViewBag.IdOrganismoLicitante = new SelectList(db.OrganismoLicitantes, "IdOrganismoLicitante", "NombreOrganismoLicitante");
            return View();
        }

        // POST: Licitador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLicitador,IdOrganismoLicitante,NombreLicitador")] Licitador licitador)
        {
            if (ModelState.IsValid)
            {
                db.Licitadors.Add(licitador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdOrganismoLicitante = new SelectList(db.OrganismoLicitantes, "IdOrganismoLicitante", "NombreOrganismoLicitante", licitador.IdOrganismoLicitante);
            return View(licitador);
        }

        // GET: Licitador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licitador licitador = db.Licitadors.Find(id);
            if (licitador == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdOrganismoLicitante = new SelectList(db.OrganismoLicitantes, "IdOrganismoLicitante", "NombreOrganismoLicitante", licitador.IdOrganismoLicitante);
            return View(licitador);
        }

        // POST: Licitador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLicitador,IdOrganismoLicitante,NombreLicitador")] Licitador licitador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licitador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdOrganismoLicitante = new SelectList(db.OrganismoLicitantes, "IdOrganismoLicitante", "NombreOrganismoLicitante", licitador.IdOrganismoLicitante);
            return View(licitador);
        }

        // GET: Licitador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licitador licitador = db.Licitadors.Find(id);
            if (licitador == null)
            {
                return HttpNotFound();
            }
            return View(licitador);
        }

        // POST: Licitador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Licitador licitador = db.Licitadors.Find(id);
            db.Licitadors.Remove(licitador);
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
