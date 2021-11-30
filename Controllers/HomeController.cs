using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto05ciclo.Models;
using Proyecto05ciclo.Logica;
using Newtonsoft.Json;
using System.IO;

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
            if ((Session["Usuario"] as Usuario).EsAdministrador==false)
            {
                return RedirectToAction("Index", "Tienda");
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
        //todo:  duplicado de controller tienda
        public ActionResult Tienda()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

        public ActionResult Usuario()
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
            oLista = CategoriaDAO.Instancia.Listar();
            return Json(new {data=oLista},JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarCategoria(Categoria oCategoria)
        {
            bool respuesta = false;
            respuesta = (oCategoria.IdCategoria == 0)
                ? CategoriaDAO.Instancia.Registrar(oCategoria)
                : CategoriaDAO.Instancia.Modificar(oCategoria);
            return Json(new {resultado=respuesta});
        }

        [HttpPost]
        public JsonResult EliminarCategoria(int id)
        {
            bool respuesta = false;
            respuesta = CategoriaDAO.Instancia.Eliminar(id);
            return Json(new { resultado=respuesta});
        }


        //MARCA AJAX
        [HttpGet]
        public JsonResult ListarMarca()
        {
            List<Marca> oLista=new List<Marca>();
            oLista = MarcaLogica.Instancia.Listar();
            return Json(new {data=oLista},JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarMarca(Marca oMarca)
        {
            //TODO: Si se deja en blanco los datos al crear nuevo hay un null exception, agregar limitaciones a los imputs del modal
            bool respuesta = false;
            //PORQUE IDMARCA ES 0? EN DONDE SE LE ASIGNA?(SE LE ASIGNA EN JQUERY)
            respuesta = (oMarca.IdMarca == 0)
                ? MarcaLogica.Instancia.Registrar(oMarca)
                : MarcaLogica.Instancia.Modificar(oMarca);
            return Json(new {resultado=respuesta},JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarMarca(int id)
        {
            bool respuesta = false;
            respuesta = MarcaLogica.Instancia.Eliminar(id);
            return Json(new { resultado=respuesta});
        }

        //PRODUCTO AJAX
        [HttpGet]
        public JsonResult ListarProducto()
        {
            List<Producto> oLista = new List<Producto>();

            oLista = ProductoDAO.Instancia.Listar();
            //para cada producto en la lista es remplazado por productos con mas datos aptos para frontend json
            oLista = (from o in oLista
                      select new Producto()
                      {
                          IdProducto = o.IdProducto,
                          Nombre = o.Nombre,
                          Descripcion = o.Descripcion,
                          oMarca = o.oMarca,
                          oCategoria = o.oCategoria,
                          Precio = o.Precio,
                          Stock = o.Stock,
                          RutaImagen = o.RutaImagen,
                          base64 = utilidades.convertirBase64(Server.MapPath(o.RutaImagen)),
                          //devuelve la extension con .,con replace se cambia a ninguno
                          extension = Path.GetExtension(o.RutaImagen).Replace(".", ""),
                          Activo = o.Activo
                      }).ToList();


            var json = Json(new {data = oLista}, JsonRequestBehavior.AllowGet);
            //cambio para permitir mas tamaño de imagenes
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        [HttpPost]
        public JsonResult GuardarProducto(string objeto, HttpPostedFileBase imagenArchivo)
        {

            Response oresponse = new Response() { resultado = true, mensaje = "" };

            try
            {
                Producto oProducto = new Producto();

                //Deserializa el string objeto pasado en una clase .NET Producto
                oProducto = JsonConvert.DeserializeObject<Producto>(objeto);

                string GuardarEnRuta = "~/Imagenes/Productos/";
                string physicalPath = Server.MapPath("~/Imagenes/Productos");

                //Si el directoria especificado no existe, se crea
                if (!Directory.Exists(physicalPath))
                    Directory.CreateDirectory(physicalPath);

                //si el id producto es 0¿? se registra, sino se modifica
                if (oProducto.IdProducto == 0)
                {
                    int id = ProductoDAO.Instancia.Registrar(oProducto);
                    oProducto.IdProducto = id;
                    //Si el id producto es =0 el resultado es false sino true
                    //oresponse.resultado = oProducto.IdProducto == 0 ? false : true;
                    oresponse.resultado = oProducto.IdProducto != 0;

                }
                else
                {
                    oresponse.resultado = ProductoDAO.Instancia.Modificar(oProducto);
                }

                //Si la imagen es diferente de null y el id producto ya existe o se acaba de crear
                //REEMPLAZA LA RUTA IMAGEN por imagenArchivo especificado
                if (imagenArchivo != null && oProducto.IdProducto != 0)
                {
                    string extension = Path.GetExtension(imagenArchivo.FileName);
                    //"~/Imagenes/Productos/+26+.jpg
                    GuardarEnRuta = GuardarEnRuta + oProducto.IdProducto.ToString() + extension;
                    oProducto.RutaImagen = GuardarEnRuta;

                    //Ruta fisica de la RutaImagen "D://~/Imagenes/Productos/+idproducto+.jpg")
                    imagenArchivo.SaveAs(physicalPath + "/" + oProducto.IdProducto.ToString() + extension );

                    oresponse.resultado = ProductoDAO.Instancia.ActualizarRutaImagen(oProducto);
                }

            }
            catch (Exception e)
            {
                oresponse.resultado = false;
                oresponse.mensaje = e.Message;
            }

            return Json(oresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarProducto(int id)
        {
            bool respuesta;
            respuesta = ProductoDAO.Instancia.Eliminar(id);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
    
    public class Response {

        public bool resultado { get; set; }
        public string mensaje { get; set; }
    }
}