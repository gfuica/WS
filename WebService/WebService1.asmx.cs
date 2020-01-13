using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Npgsql;
 
namespace WebApplication2
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        int log = 0;

        [WebMethod] //atributo permite que el método pueda ser llamado desde clientes web remotos, en este caso desde la aplicación Android
        public Restaurantes[] ListaRestaurant()  // método permite recuperar datos desde una BD remota, agregándolos a una lista para luego retornarla como array en formato XML
        {

            using (var con = new NpgsqlConnection("Server=plop.inf.udec.cl;Port=5432;Database=cristobmunoz;User Id=cristobmunoz;Password=V24qe5;"))
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "SELECT id_restaurante, nombre, direccion, telefono, valoracion_r, tipo_r, foto, rut_a, id_horario, discapacitados FROM restclopedia.restaurante";

                NpgsqlDataReader dataReader = cmd.ExecuteReader(); 

                List<Restaurantes> lista = new List<Restaurantes>();

                while (dataReader.Read())
                {
                    lista.Add(
                        new Restaurantes(dataReader.GetInt32(0),
                                    dataReader.GetString(1),
                                    dataReader.GetString(2),
                                    dataReader.GetInt32(3),
                                    Convert.ToInt32(dataReader.GetDecimal(4)), //parche...
                                    dataReader.GetString(5),
                                    dataReader.GetString(6),
                                    dataReader.GetString(7),
                                    dataReader.GetInt32(8),

                                    Convert.ToInt32(dataReader.GetBoolean(9))
                                    )); 
                }

                con.Close();

                return lista.ToArray();
            }



        }

        [WebMethod]
        public Login[] Login(string mail, string contraseña)  //public int Login(string mail, string contraseña)   ***para usar sin array, solo con log
        {
         
            using (var con = new NpgsqlConnection("Server=plop.inf.udec.cl;Port=5432;Database=cristobmunoz;User Id=cristobmunoz;Password=V24qe5;"))
            {

               int log = 0;
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = con;
                con.Open();

                cmd.CommandText = "SELECT rut_c, nombre, apellido, mail, contraseña FROM restclopedia.cliente where mail = @mail and contraseña = @contraseña";
 
                cmd.Parameters.Add(new NpgsqlParameter("@mail", mail));
                cmd.Parameters.Add(new NpgsqlParameter("@contraseña", contraseña));
                cmd.ExecuteNonQuery();
              
    

                NpgsqlDataReader dataReader = cmd.ExecuteReader();
                
                if(dataReader.HasRows)
                {
                    log = 1;
                }
                //return log;
                
                
                List<Login> lista = new List<Login>();

                while (dataReader.Read())
                {
                    lista.Add(
                        new Login(dataReader.GetString(0),
                                    dataReader.GetString(1),
                                    dataReader.GetString(2),
                                    dataReader.GetString(3),
                                    dataReader.GetString(4)
                                    ));
                }
                
                return lista.ToArray();
            }

         

        }

        [WebMethod]
        public Platos[] Platos(int id_restaurante)  //public int Login(string mail, string contraseña)   ***para usar sin array, solo con log
        {

            using (var con = new NpgsqlConnection("Server=plop.inf.udec.cl;Port=5432;Database=cristobmunoz;User Id=cristobmunoz;Password=V24qe5;"))
            {

                int log = 0;
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = con;
                con.Open();

                cmd.CommandText = "select id_plato, id_restaurante, valor, id_infon, nombre, plato.descripcion, tipo from restclopedia.plato inner join restclopedia.menu on menu.id_menu = plato.id_menu where menu.id_restaurante = @id_restaurante";

                cmd.Parameters.Add(new NpgsqlParameter("@id_restaurante", id_restaurante));
                cmd.ExecuteNonQuery();



                NpgsqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    log = 1;
                }
                //return log;


                List<Platos> lista = new List<Platos>();

                while (dataReader.Read())
                {
                    lista.Add(
                        new Platos(dataReader.GetInt32(0),
                                    dataReader.GetInt32(1),
                                    dataReader.GetInt32(2),
                                    dataReader.GetString(3),
                                    dataReader.GetString(4),
                                    dataReader.GetString(5)
                                    ));
                }

                return lista.ToArray();
            }



        }

        [WebMethod]
        public Nutricional[] Nutricional(int id_plato)  //public int Login(string mail, string contraseña)   ***para usar sin array, solo con log
        {

            using (var con = new NpgsqlConnection("Server=plop.inf.udec.cl;Port=5432;Database=cristobmunoz;User Id=cristobmunoz;Password=V24qe5;"))
            {

                int log = 0;
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = con;
                con.Open();

                cmd.CommandText = "SELECT plato.id_infon,kcal,g_totales,g_saturadas,proteina,sal,h_carbono,azucar, string_agg(ingrediente.nombre, ', ') AS ingredientes, plato.tipo, plato.nombre FROM restclopedia.infonutri inner join restclopedia.plato on plato.id_infon=infonutri.id_infon  inner join restclopedia.ingrediente on ingrediente.id_plato = plato.id_plato WHERE plato.id_plato = @id_plato GROUP  BY plato.id_infon,kcal,g_totales,g_saturadas,proteina,sal,h_carbono,azucar,plato.tipo, plato.nombre";

                cmd.Parameters.Add(new NpgsqlParameter("@id_plato", id_plato));
                cmd.ExecuteNonQuery();



                NpgsqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    log = 1;
                }
                //return log;


                List<Nutricional> lista = new List<Nutricional>();

                while (dataReader.Read())
                {
                    lista.Add(
                        new Nutricional(dataReader.GetInt32(0),
                                    dataReader.GetInt32(1),
                                    dataReader.GetInt32(2),
                                    dataReader.GetInt32(3),
                                    dataReader.GetInt32(4),
                                    dataReader.GetInt32(5),
                                    dataReader.GetInt32(6),
                                    dataReader.GetInt32(7),
                                    dataReader.GetString(8),
                                    dataReader.GetString(9),
                                    dataReader.GetString(10)
                                    ));
                }

                return lista.ToArray();
            }



        }


        [WebMethod] //atributo permite que el método pueda ser llamado desde clientes web remotos, en este caso desde la aplicación Android
        public RestaurantesPlatos[] ListaRestaurantPlatos(string nomplato)  // método permite recuperar datos desde una BD remota, agregándolos a una lista para luego retornarla como array en formato XML
        {

            using (var con = new NpgsqlConnection("Server=plop.inf.udec.cl;Port=5432;Database=cristobmunoz;User Id=cristobmunoz;Password=V24qe5;"))
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "SELECT restaurante.id_restaurante, restaurante.nombre, direccion, telefono, valoracion_r, tipo_r, foto, rut_a, id_horario, discapacitados FROM restclopedia.restaurante inner join restclopedia.menu on menu.id_restaurante = restaurante.id_restaurante inner join restclopedia.plato on plato.id_menu = menu.id_menu where plato.nombre like '%"+nomplato+"%'";

                NpgsqlDataReader dataReader = cmd.ExecuteReader();

                List<RestaurantesPlatos> lista = new List<RestaurantesPlatos>();

                while (dataReader.Read())
                {
                    lista.Add(
                        new RestaurantesPlatos(dataReader.GetInt32(0),
                                    dataReader.GetString(1),
                                    dataReader.GetString(2),
                                    dataReader.GetInt32(3),
                                    Convert.ToInt32(dataReader.GetDecimal(4)),
                                    dataReader.GetString(5),
                                    dataReader.GetString(6),
                                    dataReader.GetString(7),
                                    dataReader.GetInt32(8),

                                    Convert.ToInt32(dataReader.GetBoolean(9))
                                    ));
                }

                con.Close();

                return lista.ToArray();
            }



        }




    }
}
