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

        //CATEGORIA AJAX
        [HttpGet]
        public JsonResult ListarCategoria()
        {
            List<Categoria> oLista=new List<Categoria>();
            oLista = CategoriaLogica.Instancia.Listar();
            return Json(new {data=oLista},JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarCategoria(Categoria oCategoria)
        {
            bool respuesta = false;
            respuesta = (oCategoria.IdCategoria == 0)
                ? CategoriaLogica.Instancia.Registrar(oCategoria)
                : CategoriaLogica.Instancia.Modificar(oCategoria);
            return Json(new {resultado=respuesta});
        }

        [HttpPost]
        public JsonResult EliminarCategoria(int id)
        {
            bool respuesta = false;
            respuesta = CategoriaLogica.Instancia.Eliminar(id);
            return Json(new { resultado=respuesta});
        }


        //MARCA AJAX
        [HttpGet]
        public JsonResult ListarMarca()
        {
            List<Categoria> oLista=new List<Categoria>();
            oLista = CategoriaLogica.Instancia.Listar();
            return Json(new {data=oLista},JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarMarca(Marca oMarca)
        {
            bool respuesta = false;
            respuesta = (oMarca.IdMarca == 0)
                ? MarcaLogica.Instancia.Registrar(oMarca)
                : MarcaLogica.Instancia.Modificar(oMarca);
            return Json(new {resultado=respuesta});
        }

        [HttpPost]
        public JsonResult EliminarMarca(int id)
        {
            bool respuesta = false;
            respuesta = MarcaLogica.Instancia.Eliminar(id);
            return Json(new { resultado=respuesta});
        }

        //PRODUCTO AJAX
    }
}