using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto05ciclo.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string ConfirmarPassword { get; set; }
        public bool EsAdministrador { get; set; }
        public bool Activo { get; set; }
    }
}