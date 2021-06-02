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
using Rotativa;

namespace Compras_Inventario_Fereteria.Controllers
{
    public class reportesController : Controller
    {

        usuarios oUsuario;
        // GET: reportes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Print()
        {
            return new Rotativa.ViewAsPdf("Index");
        }
    }
}