using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Proyecto05ciclo.Models;
using Proyecto05ciclo.Logica;

namespace Proyecto05ciclo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string NCorreo, string NPassword)
        {
            Usuario oUsuario;

            oUsuario = UsuarioLogica.Instancia.Obtener(NCorreo, NPassword);

            if (oUsuario==null)
            {
                ViewBag.Error = "Correo o contraseña incorrecta";
                return View();
            }
            FormsAuthentication.SetAuthCookie(oUsuario.Correo,false);
            Session["Usuario"] = oUsuario;

            if (oUsuario.EsAdministrador==true)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Tienda");
            }
        }

        public ActionResult Registrarse()
        {
            return View(new Usuario() {Nombres = "", Apellidos = "", Correo = "", Password = "", ConfirmarPassword = ""});
        }

        [HttpPost]
        public ActionResult Registrarse(string NNombres,string NApellidos,string NCorreo,string NPassword,string NConfirmarPassword)
        {
            //Registra a usuarios NO administradores

            Usuario rUsuario = new Usuario()
            {
                Nombres = NNombres,
                Apellidos = NApellidos,
                Correo = NCorreo,
                Password = NPassword,
                ConfirmarPassword = NConfirmarPassword,
                EsAdministrador = false
            };

            if (NPassword != NConfirmarPassword)
            {
                ViewBag.Error = "Las contraseñas no coinciden";
                return View(rUsuario);
            }
            else
            {
                //la id del ultimo usuario registrado(scope identity),
                //del parametro "respuesta" con direccion output
                int idusuario_respuesta = UsuarioLogica.Instancia.Registrar(rUsuario);
                if (idusuario_respuesta==0)
                {
                    ViewBag.Error = "Error al registrar";
                    return View(rUsuario);
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
        }
    }

}

/*
 *Uso de [AllowAnonymus]
 * [AllowAnonymous]
   public ActionResult LogIn () {
      // This action can be accessed by unauthorized users
   }

   public ActionResult UserDetails () {
      // This action can NOT be accessed by unauthorized users
   }
 */

/*TUTORIAL GUARDAR Y OBTENER DE SESSION
 string firstName = "Jeff";
string lastName = "Smith";
string city = "Seattle";

// Save to session state in a Web Forms page class. GUARDAR EN SESSION
Session["FirstName"] = firstName;
Session["LastName"] = lastName;
Session["City"] = city;

// Read from session state in a Web Forms page class. OBTENER DE SESSION
firstName = (string)(Session["FirstName"]);
lastName = (string)(Session["LastName"]);
city = (string)(Session["City"]);

// Outside of Web Forms page class, use HttpContext.Current.
HttpContext context = HttpContext.Current;
context.Session["FirstName"] = firstName;
firstName = (string)(context.Session["FirstName"]);

 */