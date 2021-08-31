using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto05ciclo.Models;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto05ciclo.Logica
{
    public class MarcaLogica
    {
        private static MarcaLogica _instancia;

        public MarcaLogica()
        {
        }

        //SINGLETON
        public static MarcaLogica Instancia
        {
            get
            {
                if (_instancia==null)
                {
                    _instancia=new MarcaLogica();
                }
                return _instancia;
            }
        }

        public List<Marca> Listar()
        {
            List<Marca> oListaMarca=new List<Marca>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("sp_obtenerMarca", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        oListaMarca.Add(new Marca()
                        {
                            IdMarca = Convert.ToInt32(dr["IdMarca"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"].ToString())
                        });
                    }
                    dr.Close();

                    return oListaMarca;

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Entro al catch de obtener Marca " + ex.Message);
                    oListaMarca = null;
                    return oListaMarca;
                }
            }
        }

        

        public bool Registrar(Marca oMarca)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarMarca", oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oMarca.Descripcion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Entro al catch de registrar Marca " + e.Message);

                    respuesta = false;
                }
            }
            return respuesta;
        }

        public bool Modificar(Marca oMarca)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarMarca", oConexion);
                    cmd.Parameters.AddWithValue("IdMarca", oMarca.IdMarca);
                    cmd.Parameters.AddWithValue("Descripcion", oMarca.Descripcion);
                    cmd.Parameters.AddWithValue("Activo", oMarca.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Entro al catch de modificar Marca " + e.Message);
                    respuesta = false;
                }

            }

            return respuesta;

        }

        public bool Eliminar(int id)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("delete from Marca where idMarca = @id", oConexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = true;

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Entro al catch de eliminar Marca " + e.Message);

                    respuesta = false;
                }

            }

            return respuesta;
        }
    }
}