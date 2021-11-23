using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Proyecto05ciclo.Models;

namespace Proyecto05ciclo.Logica
{
    public class CarritoDAO
    {
        private static CarritoDAO _instancia=null;

        public CarritoDAO()
        {

        }
        //SINGLETON
        public static CarritoDAO Instancia
        {
            get
            {
                if (_instancia==null)
                {
                    _instancia=new CarritoDAO();
                }
                return _instancia;
            }
        }
        
        public int Registrar(Carrito oCarrito)
        {
            int respuesta = 0;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertarCarrito", oConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", oCarrito.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("IdProducto", oCarrito.oProducto.IdProducto);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToInt32(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception e)
                {
                    respuesta = 0;
                }
            }
            return respuesta;
        }


        public int Cantidad(int idusuario)
        {
            int respuesta = 0;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select count(*) from carrito where idusuario = @idusuario", oConexion);
                    cmd.Parameters.AddWithValue("@idusuario", idusuario);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    respuesta = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                }
                catch (Exception e)
                {
                    respuesta = 0;
                }
            }
            return respuesta;
        }

        public List<Carrito> Obtener(int _idusuario)
        {
            List<Carrito> lst = new List<Carrito>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerCarrito", oConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", _idusuario);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lst.Add(new Carrito() {

                                IdCarrito = Convert.ToInt32(dr["IdCarrito"].ToString()),
                                oProducto = new Producto() {
                                    IdProducto = Convert.ToInt32(dr["IdProducto"].ToString()),
                                    Nombre = dr["Nombre"].ToString(),
                                    oMarca = new Marca() { Descripcion = dr["Descripcion"].ToString() },
                                    Precio = Convert.ToDecimal(dr["Precio"].ToString(), new CultureInfo("es-PE")),
                                    RutaImagen = dr["RutaImagen"].ToString()
                                },
                                
                            });
                        }
                    }

                }
                catch (Exception e)
                {
                    lst = new List<Carrito>();
                }
            }
            return lst;
        }

        public bool Eliminar(string IdCarrito, string IdProducto) {

            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("delete from carrito where idcarrito = @idcarrito");
                    query.AppendLine("update PRODUCTO set Stock = Stock + 1 where IdProducto = @idproducto");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@idcarrito", IdCarrito);
                    cmd.Parameters.AddWithValue("@idproducto", IdProducto);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public List<Compra> ObtenerCompra(int IdUsuario)
        {
            List<Compra> rptDetalleCompra = new List<Compra>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerCompra", oConexion);
                cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();
                    using (XmlReader dr = cmd.ExecuteXmlReader())
                    {
                        while (dr.Read())
                        {
                            XDocument doc = XDocument.Load(dr);
                            if (doc.Element("DATA") != null)
                            {
                                rptDetalleCompra = (from c in doc.Element("DATA").Elements("COMPRA")
                                                    select new Compra()
                                                    {
                                                        Total = Convert.ToDecimal(c.Element("Total").Value,new CultureInfo("es-PE")),
                                                        FechaTexto = c.Element("Fecha").Value,
                                                        oDetalleCompra = (from d in c.Element("DETALLE_PRODUCTO").Elements("PRODUCTO")
                                                                          select new DetalleCompra() {
                                                                              oProducto = new Producto() {
                                                                                  oMarca = new Marca() { Descripcion = d.Element("Descripcion").Value  },
                                                                                  Nombre = d.Element("Nombre").Value,
                                                                                  RutaImagen = d.Element("RutaImagen").Value
                                                                              },
                                                                              Total = Convert.ToDecimal(d.Element("Total").Value,new CultureInfo("es-PE")),
                                                                              Cantidad = Convert.ToInt32(d.Element("Cantidad").Value)
                                                                          }).ToList()
                                                    }).ToList();
                            }
                            else
                            {
                                rptDetalleCompra = new List<Compra>();
                            }
                        }

                        dr.Close();

                    }

                    return rptDetalleCompra;
                }
                catch (Exception e)
                {
                    rptDetalleCompra = null;
                    return rptDetalleCompra;
                }
            }
        }


    }
}