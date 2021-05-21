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
    public class operacioesController : Controller
    {
        private InventarioBDEntities1 db = new InventarioBDEntities1();

        // GET: operacioes
        [AuthorizeUser(idOperacion: 4)]
        public ActionResult Index()
        {
            return View(db.operacioes.ToList());
        }

        // GET: operacioes/Details/5
        [AuthorizeUser(idOperacion: 4)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            operacioes operacioes = db.operacioes.Find(id);
            if (operacioes == null)
            {
                return HttpNotFound();
            }
            return View(operacioes);
        }

        // GET: operacioes/Create
        [AuthorizeUser(idOperacion: 4)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: operacioes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_operaciones,nombre")] operacioes operacioes)
        {
            if (ModelState.IsValid)
            {
                db.operacioes.Add(operacioes);
                db.SaveChanges();
                Request.Flash("success", "Operacion agregada correctamente");
                return RedirectToAction("Index");
            }

            return View(operacioes);
        }

        // GET: operacioes/Edit/5
        [AuthorizeUser(idOperacion: 4)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            operacioes operacioes = db.operacioes.Find(id);
            if (operacioes == null)
            {
                return HttpNotFound();
            }
            return View(operacioes);
        }

        // POST: operacioes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_operaciones,nombre")] operacioes operacioes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operacioes).State = EntityState.Modified;
                db.SaveChanges();
                Request.Flash("success", "Operacion Editada correctamente");
                return RedirectToAction("Index");
            }
            return View(operacioes);
        }

        // GET: operacioes/Delete/5
        [AuthorizeUser(idOperacion: 4)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            operacioes operacioes = db.operacioes.Find(id);
            if (operacioes == null)
            {
                return HttpNotFound();
            }
            return View(operacioes);
        }

        // POST: operacioes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            operacioes operacioes = db.operacioes.Find(id);
            db.operacioes.Remove(operacioes);
            db.SaveChanges();
            Request.Flash("success", "Operacion Eliminada correctamente");
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
