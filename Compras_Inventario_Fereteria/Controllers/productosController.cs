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
    public class productosController : Controller
    {
        private InventarioBDEntities1 db = new InventarioBDEntities1();

        // GET: productos
        public ActionResult Index()
        {
            var productos = db.productos.Include(p => p.categoria).Include(p => p.proveedor);
            return View(productos.ToList());
        }

        // GET: productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: productos/Create
        [AuthorizeUser(idOperacion: 3)]
        public ActionResult Create()
        {
            ViewBag.id_categoria = new SelectList(db.categoria, "id_categoria", "tipo_categoria");
            ViewBag.id_proveedor = new SelectList(db.proveedor, "id_proveedor", "nombre");
            return View();
        }

        // POST: productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_producto,nombre_producto,descripcion,cantidad,precio,id_categoria,id_proveedor")] productos productos)
        {
            if (ModelState.IsValid)
            {
                db.productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria = new SelectList(db.categoria, "id_categoria", "tipo_categoria", productos.id_categoria);
            ViewBag.id_proveedor = new SelectList(db.proveedor, "id_proveedor", "nombre", productos.id_proveedor);
            return View(productos);
        }

        // GET: productos/Edit/5
        [AuthorizeUser(idOperacion: 3)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categoria = new SelectList(db.categoria, "id_categoria", "tipo_categoria", productos.id_categoria);
            ViewBag.id_proveedor = new SelectList(db.proveedor, "id_proveedor", "nombre", productos.id_proveedor);
            return View(productos);
        }

        // POST: productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_producto,nombre_producto,descripcion,cantidad,precio,id_categoria,id_proveedor")] productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_categoria = new SelectList(db.categoria, "id_categoria", "tipo_categoria", productos.id_categoria);
            ViewBag.id_proveedor = new SelectList(db.proveedor, "id_proveedor", "nombre", productos.id_proveedor);
            return View(productos);
        }

        // GET: productos/Delete/5
        [AuthorizeUser(idOperacion: 3)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productos productos = db.productos.Find(id);
            db.productos.Remove(productos);
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
