using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Platos
    {
        public int id_plato { get; set; }
        public int id_restaurante { get; set; }
        public int valor { get; set; }
        public string nombre { get; set; }
        public string descripcion  { get; set; }
        public string tipo  { get; set; }

        public Platos()
        {
            this.id_plato = 0;
            this.id_restaurante = 0;
            this.valor = 0;
            this.nombre = "";
            this.descripcion = "";
            this.tipo = "";

        }

        public Platos(int id_plato, int id_restaurante, int valor, string nombre, string descripcion, string tipo)
        {
            this.id_plato = id_plato;
            this.id_restaurante = id_restaurante;
            this.valor = valor;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.tipo = tipo;

        }
    }
}