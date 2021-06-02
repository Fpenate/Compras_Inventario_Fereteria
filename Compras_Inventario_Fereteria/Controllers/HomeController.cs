using Compras_Inventario_Fereteria.Filters;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Compras_Inventario_Fereteria.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Descripcion de la Aplicacion";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Team Members :";

            return View();
        }
    }
}