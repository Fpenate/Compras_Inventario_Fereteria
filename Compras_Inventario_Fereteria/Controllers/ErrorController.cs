using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Compras_Inventario_Fereteria.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [HttpGet]
        public ActionResult UnauthorizedOperation(String operacion, String modulo, String msjeErrorExcepcion)
        {
            ViewBag.operacion = operacion;
            ViewBag.modulo = modulo;
            ViewBag.msjeErrorExcepcion = msjeErrorExcepcion;
            Request.Flash("info", "No tienes permiso para hacer esta operacion");
            return View();
        }
    }
}