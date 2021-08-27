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
            Usuario oUsuario=new Usuario();

            oUsuario = UsuarioLogica.Instancia.Obtener(NCorreo, NPassword);

            if (oUsuario==null)
            {
                ViewBag.Error = "Correo o contraseña no correcta";
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