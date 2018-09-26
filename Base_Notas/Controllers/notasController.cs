using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Base_Notas.Models;

namespace Base_Notas.Controllers
{
    public class notasController : Controller
    {
        private Modelo db = new Modelo();

        // GET: notas
        public ActionResult Index()
        {
            var notas = db.notas.Include(n => n.alumnos).Include(n => n.Materias).Include(n => n.Profesores);
          
            return View(notas.ToList());
        }

        //consulta con post
        [HttpPost]
        public ActionResult Index(String filtro)
        {
            var no = db.notas.Include(n => n.alumnos).Include(n => n.Materias).Include(n => n.Profesores);
            var notasFiltradas = from n in no
                                 where n.Materias.Nombre.Contains(filtro)
                                 select n;
            return View(notasFiltradas.ToList());
        }
        //GET: notas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notas notas = db.notas.Find(id);
            if (notas == null)
            {
                return HttpNotFound();
            }
            return View(notas);
        }

        // GET: notas/Create
        public ActionResult Create()
        {
            ViewBag.id_alum = new SelectList(db.alumnos, "id", "Nombre");
            ViewBag.id_materia = new SelectList(db.Materias, "id", "Nombre");
            ViewBag.id_prof = new SelectList(db.Profesores, "id", "Nombre");
            return View();
        }

        // POST: notas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nota,descripcion,id_materia,id_alum,id_prof")] notas notas)
        {
            if (ModelState.IsValid)
            {
                db.notas.Add(notas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_alum = new SelectList(db.alumnos, "id", "Nombre", notas.id_alum);
            ViewBag.id_materia = new SelectList(db.Materias, "id", "Nombre", notas.id_materia);
            ViewBag.id_prof = new SelectList(db.Profesores, "id", "Nombre", notas.id_prof);
            return View(notas);
        }

        // GET: notas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notas notas = db.notas.Find(id);
            if (notas == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_alum = new SelectList(db.alumnos, "id", "Nombre", notas.id_alum);
            ViewBag.id_materia = new SelectList(db.Materias, "id", "Nombre", notas.id_materia);
            ViewBag.id_prof = new SelectList(db.Profesores, "id", "Nombre", notas.id_prof);
            return View(notas);
        }

        // POST: notas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nota,descripcion,id_materia,id_alum,id_prof")] notas notas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_alum = new SelectList(db.alumnos, "id", "Nombre", notas.id_alum);
            ViewBag.id_materia = new SelectList(db.Materias, "id", "Nombre", notas.id_materia);
            ViewBag.id_prof = new SelectList(db.Profesores, "id", "Nombre", notas.id_prof);
            return View(notas);
        }

        // GET: notas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notas notas = db.notas.Find(id);
            if (notas == null)
            {
                return HttpNotFound();
            }
            return View(notas);
        }

        // POST: notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            notas notas = db.notas.Find(id);
            db.notas.Remove(notas);
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
