using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto05ciclo.Models;
using Proyecto05ciclo.Logica;

namespace Proyecto05ciclo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["Usuario"]==null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        public ActionResult Categoria()
        {
            if (Session["Usuario"]==null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        public ActionResult Marca()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

        public ActionResult Producto()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

        public ActionResult Tienda()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

        [HttpGet]
        public JsonResult ListarCategoria()
        {
            List<Categoria> oLista=new List<Categoria>();
            oLista = CategoriaLogica.Instancia.Listar();
            return Json(new {data=oLista},JsonRequestBehavior.AllowGet);
        }
    }
}