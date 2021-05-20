using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Compras_Inventario_Fereteria.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Usuario, string Pass)
        {
            try
            {
                using (Models.InventarioBDEntities1 db = new Models.InventarioBDEntities1())
                {
                    var oUser = (from d in db.usuarios
                                 where d.email == Usuario.Trim() && d.pasword == Pass.Trim()
                                 select d).FirstOrDefault();
                    if (oUser == null)
                    {
                        //ViewBag.Error = "Usuario o contraseña invalida";
                        Request.Flash("danger", "Usuario o Contraseña Incorrectos");
                        return View();
                    }

                    Session["User"] = oUser;
                    Session["Usuario"] = Usuario;
                    ViewBag.User = Usuario;
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}