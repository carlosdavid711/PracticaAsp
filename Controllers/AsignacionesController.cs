using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Terceintento.Data;
using Terceintento.Models;

namespace Terceintento.Controllers
{
    public class AsignacionesController : Controller
    {
        private TerceintentoContext db = new TerceintentoContext();

        // GET: Asignaciones
        public ActionResult Index()
        {
            var asignaciones = db.Asignaciones.Include(a => a.Estudiante).Include(a => a.Maestro);
            return View(asignaciones.ToList());
        }

        // GET: Asignaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignaciones asignaciones = db.Asignaciones.Find(id);
            if (asignaciones == null)
            {
                return HttpNotFound();
            }
            return View(asignaciones);
        }

        // GET: Asignaciones/Create
        public ActionResult Create()
        {
            ViewBag.EstudiantesID = new SelectList(db.Estudiantes, "ID", "PrimerNombre");
            ViewBag.MaestroID = new SelectList(db.Maestros, "ID", "PrimerNombre");
            return View();
        }

        // POST: Asignaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CursoID,EstudiantesID,MaestroID")] Asignaciones asignaciones)
        {
            if (ModelState.IsValid)
            {
                db.Asignaciones.Add(asignaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstudiantesID = new SelectList(db.Estudiantes, "ID", "PrimerNombre", asignaciones.EstudiantesID);
            ViewBag.MaestroID = new SelectList(db.Maestros, "ID", "PrimerNombre", asignaciones.MaestroID);
            return View(asignaciones);
        }

        // GET: Asignaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignaciones asignaciones = db.Asignaciones.Find(id);
            if (asignaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstudiantesID = new SelectList(db.Estudiantes, "ID", "PrimerNombre", asignaciones.EstudiantesID);
            ViewBag.MaestroID = new SelectList(db.Maestros, "ID", "PrimerNombre", asignaciones.MaestroID);
            return View(asignaciones);
        }

        // POST: Asignaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CursoID,EstudiantesID,MaestroID")] Asignaciones asignaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstudiantesID = new SelectList(db.Estudiantes, "ID", "PrimerNombre", asignaciones.EstudiantesID);
            ViewBag.MaestroID = new SelectList(db.Maestros, "ID", "PrimerNombre", asignaciones.MaestroID);
            return View(asignaciones);
        }

        // GET: Asignaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignaciones asignaciones = db.Asignaciones.Find(id);
            if (asignaciones == null)
            {
                return HttpNotFound();
            }
            return View(asignaciones);
        }

        // POST: Asignaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asignaciones asignaciones = db.Asignaciones.Find(id);
            db.Asignaciones.Remove(asignaciones);
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
