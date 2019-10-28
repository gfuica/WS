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
        
        
        

        
    }
}
