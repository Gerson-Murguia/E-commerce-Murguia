using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Proyecto05ciclo.Models;

namespace Proyecto05ciclo.Logica
{
    //int 0 es false
    public class CategoriaDAO
    {
        private static CategoriaDAO _instancia = null;

        public CategoriaDAO()
        {
        }

        //singleton
        public static CategoriaDAO Instancia
        {
            get
            {
                if (_instancia==null)
                {
                    _instancia=new CategoriaDAO();
                }
                return _instancia;
            }
        }

        public List<Categoria> Listar()
        {
            List<Categoria> rptListaCategoria=new List<Categoria>();
            using (SqlConnection oConexion=new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("sp_obtenerCategoria", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaCategoria.Add(new Categoria()
                        {
                            IdCategoria = Convert.ToInt32(dr["IdCategoria"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"].ToString())
                        });
                    }
                    dr.Close();
                    return rptListaCategoria;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    rptListaCategoria = null;
                    return rptListaCategoria;
                }
            }
        }

        public bool Registrar(Categoria oCategoria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion=new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd=new SqlCommand("sp_RegistrarCategoria",oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oCategoria.Descripcion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    respuesta=false;
                }
               
            }

            return respuesta;
        }

        public bool Modificar(Categoria oCategoria)
        {
            bool respuesta = true;

            using (SqlConnection oConexion=new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd=new SqlCommand("sp_ModificarCategoria",oConexion);
                    cmd.Parameters.AddWithValue("IdCategoria", oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Descripcion", oCategoria.Descripcion);
                    cmd.Parameters.AddWithValue("Activo", oCategoria.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    respuesta = false;
                }

            }

            return respuesta;
        }

        public bool Eliminar(int id)
        {
            bool respuesta = true;
            using (SqlConnection oConexion=new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd=new SqlCommand("delete from CATEGORIA where idcategoria=@id",oConexion);
                    cmd.Parameters.AddWithValue("@id", id);

                    oConexion.Open();

                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); 
                    respuesta=false;
                }
            }
            return respuesta;
        }
    }
}