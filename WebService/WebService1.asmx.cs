using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Npgsql;

namespace WebService
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

        [WebMethod]
        public Restaurantes[] ListaRestaurant()
        {

            using (var con = new NpgsqlConnection("Server=plop.inf.udec.cl;Port=5432;Database=cristobmunoz;User Id=cristobmunoz;Password=V24qe5;"))
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "SELECT id_restaurante, nombre, direccion, telefono, valoracion_r, tipo_r, foto, rut_a, id_horario FROM restclopedia.restaurante";

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
                                    dataReader.GetInt32(8)
                                    ));
                }

                con.Close();

                return lista.ToArray();
            }



        }

        [WebMethod]
        public int NuevoClienteSimple(string nombre, string telefono)
        {

            using (var con = new NpgsqlConnection("Server=bdd.inf.udec.cl;Port=5432;Database=bdi2018d;User Id=bdi2018d;Password=bdi2018d;"))
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "Insert into test.dbclientes values(@id_cliente, @nombre, @telefono)";
                cmd.Parameters.Add(new NpgsqlParameter("@id_cliente", System.Data.SqlDbType.Int)).Value = 0;
                cmd.Parameters.Add(new NpgsqlParameter("@telefono", System.Data.SqlDbType.NVarChar)).Value = telefono;
                cmd.Parameters.Add(new NpgsqlParameter("@nombre", System.Data.SqlDbType.NVarChar)).Value = nombre;


                int res = cmd.ExecuteNonQuery();
                cmd.Dispose();

                return res;
            }



        }


    }
}
