using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Compras_Inventario_Fereteria.Filters;
using Compras_Inventario_Fereteria.Models;

namespace Compras_Inventario_Fereteria.Controllers
{
    public class rol_operacionController : Controller
    {
        private InventarioBDEntities db = new InventarioBDEntities();

        // GET: rol_operacion
        public ActionResult Index()
        {
            var rol_operacion = db.rol_operacion.Include(r => r.operacioes).Include(r => r.roles);
            return View(rol_operacion.ToList());
        }

        // GET: rol_operacion/Details/5
        [AuthorizeUser(idOperacion: 3)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rol_operacion rol_operacion = db.rol_operacion.Find(id);
            if (rol_operacion == null)
            {
                return HttpNotFound();
            }
            return View(rol_operacion);
        }

        // GET: rol_operacion/Create
        [AuthorizeUser(idOperacion: 3)]
        public ActionResult Create()
        {
            ViewBag.id_operacion = new SelectList(db.operacioes, "id_operaciones", "nombre");
            ViewBag.id_rol = new SelectList(db.roles, "id_rol", "nombre");
            return View();
        }

        // POST: rol_operacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_rol_operacion,id_rol,id_operacion")] rol_operacion rol_operacion)
        {
            if (ModelState.IsValid)
            {
                db.rol_operacion.Add(rol_operacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_operacion = new SelectList(db.operacioes, "id_operaciones", "nombre", rol_operacion.id_operacion);
            ViewBag.id_rol = new SelectList(db.roles, "id_rol", "nombre", rol_operacion.id_rol);
            return View(rol_operacion);
        }

        // GET: rol_operacion/Edit/5
        [AuthorizeUser(idOperacion: 3)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rol_operacion rol_operacion = db.rol_operacion.Find(id);
            if (rol_operacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_operacion = new SelectList(db.operacioes, "id_operaciones", "nombre", rol_operacion.id_operacion);
            ViewBag.id_rol = new SelectList(db.roles, "id_rol", "nombre", rol_operacion.id_rol);
            return View(rol_operacion);
        }

        // POST: rol_operacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_rol_operacion,id_rol,id_operacion")] rol_operacion rol_operacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rol_operacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_operacion = new SelectList(db.operacioes, "id_operaciones", "nombre", rol_operacion.id_operacion);
            ViewBag.id_rol = new SelectList(db.roles, "id_rol", "nombre", rol_operacion.id_rol);
            return View(rol_operacion);
        }

        // GET: rol_operacion/Delete/5
        [AuthorizeUser(idOperacion: 3)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rol_operacion rol_operacion = db.rol_operacion.Find(id);
            if (rol_operacion == null)
            {
                return HttpNotFound();
            }
            return View(rol_operacion);
        }

        // POST: rol_operacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rol_operacion rol_operacion = db.rol_operacion.Find(id);
            db.rol_operacion.Remove(rol_operacion);
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
