using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Login
    {
        public string rut_c { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public string contraseña { get; set; }

        public Login()
        {
            this.rut_c = "";
            this.nombre = "";
            this.apellido = "";
            this.mail = "";
            this.contraseña = "";

        }

        public Login(string rut_c, string nombre, string apellido, string mail, string contraseña)
        {
            this.rut_c = rut_c;
            this.nombre = nombre;
            this.apellido = apellido;
            this.mail = mail;
            this.contraseña = contraseña;
        }

    }
}