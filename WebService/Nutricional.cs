using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Nutricional
    {

        public int id_infon { get; set; }
        public int kcal { get; set; }
        public int g_totales { get; set; }
        public int g_saturadas { get; set; }
        public int proteina { get; set; }
        public int sal { get; set; }
        public int h_carbono { get; set; }
        public int azucar { get; set; }
        public string ingredientes { get; set; }
        public string tipo { get; set; }
        public string nombre { get; set; }



        public Nutricional()
    {
        this.id_infon = 0;
        this.kcal = 0;
        this.g_totales = 0;
        this.g_saturadas = 0;
        this.proteina = 0;
        this.sal = 0;
        this.h_carbono = 0;
        this.azucar = 0;
        this.ingredientes = "";
        this.tipo = "";
        this.nombre = "";

    }

    public Nutricional(int id_infon, int kcal, int g_totales, int g_saturadas, int proteina, int sal, int h_carbono, int azucar, string ingredientes, string tipo, string nombre)
    {
            this.id_infon = id_infon;
            this.kcal = kcal;
            this.g_totales = g_totales;
            this.g_saturadas = g_saturadas;
            this.proteina = proteina;
            this.sal = sal;
            this.h_carbono = h_carbono;
            this.azucar = azucar;
            this.ingredientes = ingredientes;
            this.tipo = tipo;
            this.nombre = nombre;

        
    }

    }
}




