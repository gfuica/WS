using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//esta clase permite implementar los 

namespace WebApplication2
{
    public class RestaurantesPlatos
    {
        public int id_restaurante { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public int valoracion_r { get; set; }
        public string tipo_r { get; set; }
        public string foto { get; set; }
        public string rut_a { get; set; }
        public int id_horario { get; set; }
        public int discapacitados { get; set; }



        public RestaurantesPlatos()
        {
            this.id_restaurante = 0;
            this.nombre = "";
            this.direccion = "";
            this.telefono = 0;
            this.valoracion_r = 0;
            this.tipo_r = "";
            this.foto = "";
            this.rut_a = "";
            this.id_horario = 0;
            this.discapacitados = 0;
        }

        public RestaurantesPlatos(int id_restaurante, string nombre, string direccion, int telefono, int valoracion_r, string tipo_r, string foto, string rut_a, int id_horario, int discapacitados)
        {
            this.id_restaurante = id_restaurante; //0
            this.nombre = nombre;
            this.telefono = telefono;
            this.direccion = direccion;
            this.valoracion_r = valoracion_r;
            this.tipo_r = tipo_r;
            this.foto = foto;
            this.rut_a = rut_a;
            this.id_horario = id_horario;
            this.discapacitados = discapacitados;
        }
    }
}