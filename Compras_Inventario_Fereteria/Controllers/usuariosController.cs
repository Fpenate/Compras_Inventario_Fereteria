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
    public class usuariosController : Controller
    {
        private InventarioBDEntities1 db = new InventarioBDEntities1();

        // GET: usuarios
        public ActionResult Index()
        {
            var usuarios = db.usuarios.Include(u => u.roles);
            return View(usuarios.ToList());
        }

        // GET: usuarios/Details/5
        [AuthorizeUser(idOperacion: 3)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuarios usuarios = db.usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // GET: usuarios/Create
        [AuthorizeUser(idOperacion: 3)]
        public ActionResult Create()
        {
            ViewBag.id_rol = new SelectList(db.roles, "id_rol", "nombre");
            return View();
        }

        // POST: usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_usuario,nombre,email,pasword,id_rol")] usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.usuarios.Add(usuarios);
                db.SaveChanges();
                Request.Flash("success", "Usuario agregado correctamente");
                return RedirectToAction("Index");
            }

            ViewBag.id_rol = new SelectList(db.roles, "id_rol", "nombre", usuarios.id_rol);
            return View(usuarios);
        }

        // GET: usuarios/Edit/5
        [AuthorizeUser(idOperacion: 3)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuarios usuarios = db.usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_rol = new SelectList(db.roles, "id_rol", "nombre", usuarios.id_rol);
            return View(usuarios);
        }

        // POST: usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_usuario,nombre,email,pasword,id_rol")] usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                Request.Flash("success", "Usuario Modificado correctamente");
                return RedirectToAction("Index");
            }
            ViewBag.id_rol = new SelectList(db.roles, "id_rol", "nombre", usuarios.id_rol);
            return View(usuarios);
        }

        // GET: usuarios/Delete/5
        [AuthorizeUser(idOperacion: 3)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuarios usuarios = db.usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usuarios usuarios = db.usuarios.Find(id);
            db.usuarios.Remove(usuarios);
            db.SaveChanges();
            Request.Flash("success", "Usuario Eliminado correctamente");
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
