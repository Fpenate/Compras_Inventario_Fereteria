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
    public class rolesController : Controller
    {
        private InventarioBDEntities1 db = new InventarioBDEntities1();

        // GET: roles
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Index()
        {
            return View(db.roles.ToList());
        }

        // GET: roles/Details/5
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            roles roles = db.roles.Find(id);
            if (roles == null)
            {
                return HttpNotFound();
            }
            return View(roles);
        }

        // GET: roles/Create
        [AuthorizeUser(idOperacion: 3)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: roles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_rol,nombre")] roles roles)
        {
            if (ModelState.IsValid)
            {
                db.roles.Add(roles);
                db.SaveChanges();
                Request.Flash("success", "Rol Creado Correctamente");
                return RedirectToAction("Index");
            }

            return View(roles);
        }

        // GET: roles/Edit/5
        [AuthorizeUser(idOperacion: 2)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            roles roles = db.roles.Find(id);
            if (roles == null)
            {
                return HttpNotFound();
            }
            return View(roles);
        }

        // POST: roles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_rol,nombre")] roles roles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roles).State = EntityState.Modified;
                db.SaveChanges();
                Request.Flash("success", "Rol Editado Correctamente");
                return RedirectToAction("Index");
            }
            return View(roles);
        }

        // GET: roles/Delete/5
        [AuthorizeUser(idOperacion: 4)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            roles roles = db.roles.Find(id);
            if (roles == null)
            {
                return HttpNotFound();
            }
            return View(roles);
        }

        // POST: roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            roles roles = db.roles.Find(id);
            db.roles.Remove(roles);
            db.SaveChanges();
            Request.Flash("success", "Rol Eliminado Correctamente");
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
