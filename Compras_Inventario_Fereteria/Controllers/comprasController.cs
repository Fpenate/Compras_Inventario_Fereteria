using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Compras_Inventario_Fereteria.Models;

namespace Compras_Inventario_Fereteria.Controllers
{
    public class comprasController : Controller
    {
        private InventarioBDEntities db = new InventarioBDEntities();

        // GET: compras
        public ActionResult Index()
        {
            var compras = db.compras.Include(c => c.empleado).Include(c => c.productos);
            return View(compras.ToList());
        }

        // GET: compras/Details/5
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
        public ActionResult Create()
        {
            ViewBag.id_empleado = new SelectList(db.empleado, "id_empleado", "nombre");
            ViewBag.id_compras = new SelectList(db.productos, "id_producto", "nombre_producto");
            return View();
        }

        // POST: compras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_compras,id_producto,id_empleado,total_compra,cantidad,fecha")] compras compras)
        {
            if (ModelState.IsValid)
            {
                db.compras.Add(compras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_empleado = new SelectList(db.empleado, "id_empleado", "nombre", compras.id_empleado);
            ViewBag.id_compras = new SelectList(db.productos, "id_producto", "nombre_producto", compras.id_compras);
            return View(compras);
        }

        // GET: compras/Edit/5
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
            ViewBag.id_empleado = new SelectList(db.empleado, "id_empleado", "nombre", compras.id_empleado);
            ViewBag.id_compras = new SelectList(db.productos, "id_producto", "nombre_producto", compras.id_compras);
            return View(compras);
        }

        // POST: compras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_compras,id_producto,id_empleado,total_compra,cantidad,fecha")] compras compras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_empleado = new SelectList(db.empleado, "id_empleado", "nombre", compras.id_empleado);
            ViewBag.id_compras = new SelectList(db.productos, "id_producto", "nombre_producto", compras.id_compras);
            return View(compras);
        }

        // GET: compras/Delete/5
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
