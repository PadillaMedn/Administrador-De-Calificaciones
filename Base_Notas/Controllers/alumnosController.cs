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
    public class alumnosController : Controller
    {
        private Modelo db = new Modelo();

        // GET: alumnos
        public ActionResult Index()
        {
           
            return View(db.alumnos.ToList());
        }
     
        // GET: alumnos/Details/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alumnos alumnos = db.alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos);
        }

        // GET: alumnos/Create
        public ActionResult Crear()
        {
            return View();
        }

        // POST: alumnos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "id,Nombre,Apellido,Edad")] alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
                db.alumnos.Add(alumnos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alumnos);
        }

        // GET: alumnos/Edit/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alumnos alumnos = db.alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos);
        }

        // POST: alumnos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "id,Nombre,Apellido,Edad")] alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumnos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alumnos);
        }

        // GET: alumnos/Delete/5
        public ActionResult Eliminar(int? id, string  error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alumnos alumnos = db.alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
			string e = ViewBag.error;
			ViewBag.errorMsj = error;

			return View(alumnos);
        }

        // Para detener los errores de relacion
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
			try
			{
				  alumnos alumnos = db.alumnos.Find(id);
                  db.alumnos.Remove(alumnos);
                  db.SaveChanges();
                  return RedirectToAction("Index");

			}
			catch (Exception e)
			{
				return RedirectToAction("Eliminar", new { id = id,error= "It can not be deleted because it is being used  " });

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
