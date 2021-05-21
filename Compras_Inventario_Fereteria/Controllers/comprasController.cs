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
    public class comprasController : Controller
    {
        private InventarioBDEntities1 db = new InventarioBDEntities1();

        // GET: compras
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Index()
        {
            var compras = db.compras.Include(c => c.productos).Include(c => c.usuarios);
            return View(compras.ToList());
        }

        // GET: compras/Details/5
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compras compras = db.compras.Find(id);
            if (compras == null)
            {
                return HttpNotFound();
            }
            return View(compras);
        }

        // GET: compras/Create
        [AuthorizeUser(idOperacion: 3)]
        public ActionResult Create()
        {
            ViewBag.id_producto = new SelectList(db.productos, "id_producto", "nombre_producto");
            ViewBag.id_usuario = new SelectList(db.usuarios, "id_usuario", "nombre");
            return View();
        }

        // POST: compras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_compras,id_usuario,id_producto,cantidad,total_compra,fecha")] compras compras)
        {
            if (ModelState.IsValid)
            {
                db.compras.Add(compras);
                db.SaveChanges();
                Request.Flash("success", "Compra Agregada correctamente");
                return RedirectToAction("Index");
            }

            ViewBag.id_producto = new SelectList(db.productos, "id_producto", "nombre_producto", compras.id_producto);
            ViewBag.id_usuario = new SelectList(db.usuarios, "id_usuario", "nombre", compras.id_usuario);
            return View(compras);
        }

        // GET: compras/Edit/5
        [AuthorizeUser(idOperacion: 2)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compras compras = db.compras.Find(id);
            if (compras == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_producto = new SelectList(db.productos, "id_producto", "nombre_producto", compras.id_producto);
            ViewBag.id_usuario = new SelectList(db.usuarios, "id_usuario", "nombre", compras.id_usuario);
            return View(compras);
        }

        // POST: compras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_compras,id_usuario,id_producto,cantidad,total_compra,fecha")] compras compras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compras).State = EntityState.Modified;
                db.SaveChanges();
                Request.Flash("success", "Compra Editada correctamente");
                return RedirectToAction("Index");
            }
            ViewBag.id_producto = new SelectList(db.productos, "id_producto", "nombre_producto", compras.id_producto);
            ViewBag.id_usuario = new SelectList(db.usuarios, "id_usuario", "nombre", compras.id_usuario);
            return View(compras);
        }

        // GET: compras/Delete/5
        [AuthorizeUser(idOperacion: 4)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compras compras = db.compras.Find(id);
            if (compras == null)
            {
                return HttpNotFound();
            }
            return View(compras);
        }

        // POST: compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            compras compras = db.compras.Find(id);
            db.compras.Remove(compras);
            db.SaveChanges();
            Request.Flash("success", "Compra Eliminada correctamente");
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
