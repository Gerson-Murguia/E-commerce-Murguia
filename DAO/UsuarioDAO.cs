using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Proyecto05ciclo.Models;

namespace Proyecto05ciclo.Logica
{
    public class UsuarioDAO
    {
        private static UsuarioDAO _instancia = null;

        public UsuarioDAO() {

        }

        //propiedad con USO DE PATRON SINGLETON
        public static UsuarioDAO Instancia
        {
            get
            {
                if (_instancia==null)
                {
                    _instancia=new UsuarioDAO();
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
                    cmd.CommandType = CommandType.StoredProcedure;

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
                                //no se pone activo es por default, confirmar password eso es pal registro
                            };
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Entro al catch de obtener Usuario " + e.Message);
                    u = null;
                }
            }

            return u;
        }

        public int Modificar(Usuario u){
            int respuesta=0;
            using (SqlConnection oConexion=new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd=new SqlCommand("sp_ModificarUsuario",oConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", u.IdUsuario);
                    cmd.Parameters.AddWithValue("Nombres", u.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", u.Apellidos);
                    cmd.Parameters.AddWithValue("Correo", u.Correo);
                    cmd.Parameters.AddWithValue("Password", u.Password);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction=ParameterDirection.Output;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    //retorna la identidad del ultimo valor insertado
                    respuesta = Convert.ToInt32(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Entro al catch de registrar Usuario " + e.Message);
                    respuesta = 0;
                }
            }

            return respuesta;
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
                    cmd.Parameters.AddWithValue("Apellidos", oUsuario.Apellidos);
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
                    System.Diagnostics.Debug.WriteLine("Entro al catch de registrar Usuario " + e.Message);
                    respuesta = 0;
                }
            }

            return respuesta;
        }

    }
}