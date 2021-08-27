using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Proyecto05ciclo.Models;

namespace Proyecto05ciclo.Logica
{
    public class UsuarioLogica
    {
        private static UsuarioLogica _instancia = null;

        public UsuarioLogica() {

        }

        //propiedad con USO DE PATRON SINGLETON
        public static UsuarioLogica Instancia
        {
            get
            {
                if (_instancia==null)
                {
                    _instancia=new UsuarioLogica();
                }

                return _instancia;
            }
        }

        public Usuario Obtener(string _correo, string _password)
        {
            Usuario u = null;
            using (SqlConnection oConexion=new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd= new SqlCommand("sp_obtenerUsuario",oConexion);
                    cmd.Parameters.AddWithValue("Correo", _correo);
                    cmd.Parameters.AddWithValue("Password", _password);

                    oConexion.Open();

                    using (SqlDataReader dr=cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            u = new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"].ToString()),
                                Nombres = dr["Nombres"].ToString(),
                                Apellidos = dr["Apellidos"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Password = dr["Contrasena"].ToString(),
                                EsAdministrador = Convert.ToBoolean(dr["EsAdministrador"])
                                //no se pone activo !?, confirmar password eso es pal registro
                            };
                        }
                    }
                }
                catch (Exception e)
                {
                    u = null;
                }
            }

            return u;
        }

        public int Registrar(Usuario oUsuario)
        {
            int respuesta = 0;
            using (SqlConnection oConexion=new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd=new SqlCommand("sp_registrarUsuario",oConexion);
                    cmd.Parameters.AddWithValue("Nombres", oUsuario.Nombres);
                    cmd.Parameters.AddWithValue("Apeliidos", oUsuario.Apellidos);
                    cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                    cmd.Parameters.AddWithValue("Password", oUsuario.Password);
                    cmd.Parameters.AddWithValue("EsAdministrador", oUsuario.EsAdministrador);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction=ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    //retorna la identidad del ultimo valor insertado
                    respuesta = Convert.ToInt32(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception e)
                {
                    respuesta = 0;
                }
            }

            return respuesta;
        }

    }
}