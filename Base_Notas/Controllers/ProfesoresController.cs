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
    public class ProfesoresController : Controller
    {
        private Modelo db = new Modelo();

        // GET: Profesores
        public ActionResult Index()
        {
            return View(db.Profesores.ToList());
        }

        // GET: Profesores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesores profesores = db.Profesores.Find(id);
            if (profesores == null)
            {
                return HttpNotFound();
            }
            return View(profesores);
        }

        // GET: Profesores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profesores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre,Apellido")] Profesores profesores)
        {
            if (ModelState.IsValid)
            {
                db.Profesores.Add(profesores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profesores);
        }

        // GET: Profesores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesores profesores = db.Profesores.Find(id);
            if (profesores == null)
            {
                return HttpNotFound();
            }
            return View(profesores);
        }

        // POST: Profesores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombre,Apellido")] Profesores profesores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profesores);
        }

        // GET: Profesores/Delete/5
        public ActionResult Delete(int? id, string error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesores profesores = db.Profesores.Find(id);
            if (profesores == null)
            {
                return HttpNotFound();
            }
			string e = ViewBag.error;
			ViewBag.errorMsj = error;

			return View(profesores);
        }

       //Para la accion del boton eliminar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			// para capturar el error de eliminar datos 
			try
			{
				Profesores profesores = db.Profesores.Find(id);
				db.Profesores.Remove(profesores);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			catch (Exception e)
			{

				return RedirectToAction("Delete", new { id = id,error= "It can not be deleted because it is being used" });

			}
           
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
