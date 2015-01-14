using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.FuenteDatos.IDao.Proveedores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BackOffice.FuenteDatos.Dao.Proveedores
{
    public class DaoProveedor: Dao, IDaoProveedor
    {
        private Entidad _proveedor = FabricaEntidad.ObtenerProveedor();

        public Dominio.Entidad ConsultarXId(int id)
        {
            SqlCommand comando = new SqlCommand("Procedure_consultarProveedorGeneral", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("_proId", id));

            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                while (_lectura.Read())
                {
                    _proveedor = ObtenerBDReader(_lectura);
                    if (_proveedor != null)
                    {
                        return _proveedor;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                CerrarConexion();
            }
            return null;   
        }

        public List<Entidad> ConsultarTodos()
        {
            List<Entidad> proveedor = new List<Entidad>();
            SqlDataReader reader;

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand("Procedure_llenarGVProveedores", _cn);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("_paramBusq", ""));
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    proveedor.Add(ObtenerProveedores(reader));
                }

                return proveedor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public List<Entidad> ConsultarTodosBusq(string busqueda)
        {
            List<Entidad> proveedor = new List<Entidad>();
            SqlDataReader reader;

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand("Procedure_llenarGVProveedores", _cn);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("_paramBusq", busqueda));
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    proveedor.Add(ObtenerProveedores(reader));
                }

                return proveedor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public bool eliminarProveedor(int id)
        {
            SqlCommand comando = new SqlCommand("Procedure_eliminarProveedor", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("_proId", id));

            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                CerrarConexion();
            }
            return false;
        }

        public string consultarDireccion(int fklugar)
        {
            CerrarConexion();
            SqlCommand comando = new SqlCommand("Procedure_consultarDireccionProveedor", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("idDireccion", fklugar));

            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                while (_lectura.Read())
                {
                    return (string)_lectura[0];
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;   
        }

        private Proveedor ObtenerBDReader(SqlDataReader objetoBD)
        {
            Proveedor proveedor = new Proveedor();
            try
            {
                proveedor.Id = objetoBD.GetInt32(0);
                proveedor.Rif = objetoBD.GetString(1).ToString();
                proveedor.RazonSocial = objetoBD.GetString(2).ToString();
                proveedor.Correo = objetoBD.GetString(3).ToString();
                proveedor.PagWeb = objetoBD.GetString(4).ToString();
                proveedor.FechaContrato = objetoBD.GetDateTime(5).ToString().Remove(10);
                proveedor.Telefono = objetoBD.GetString(6).ToString();
                proveedor.estado = objetoBD.GetString(8).ToString();
                proveedor.IdLugar = (consultarDireccion(objetoBD.GetInt32(7)));                
            }
            catch (Exception ex)
            {

            }
            return proveedor;
        }

       
        private Proveedor ObtenerProveedores(SqlDataReader objetoBD)
        {
            Proveedor proveedor = new Proveedor();
            try
            {
                proveedor.Id = objetoBD.GetInt32(0);
                proveedor.Rif = objetoBD.GetString(1).ToString();
                proveedor.RazonSocial = objetoBD.GetString(2).ToString();
                proveedor.Correo = objetoBD.GetString(3).ToString();
                proveedor.PagWeb = objetoBD.GetString(4).ToString();
                proveedor.FechaContrato = objetoBD.GetDateTime(5).ToString().Remove(10);
                proveedor.Telefono = objetoBD.GetString(6).ToString();
                proveedor.estado = objetoBD.GetString(8).ToString();
                proveedor.IdLugar = "";
            }
            catch (Exception ex)
            {

            }
            return proveedor;
        }

        

        bool IDao.IDao<Entidad, bool, Entidad>.Agregar(Entidad parametro)
        {
            Proveedor _proveedor = (Proveedor)parametro;
            SqlCommand comando = new SqlCommand("Procedure_AlmacenarProveedor", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("_proRif", _proveedor.Rif));
            comando.Parameters.Add(new SqlParameter("_proRazonSocial", _proveedor.RazonSocial));
            comando.Parameters.Add(new SqlParameter("_proCorreo", _proveedor.Correo));
            comando.Parameters.Add(new SqlParameter("_proPaginaWeb", _proveedor.PagWeb));
            comando.Parameters.Add(new SqlParameter("_proFechaContrato", DateTime.Parse(_proveedor.FechaContrato)));
            comando.Parameters.Add(new SqlParameter("_proTelefono", _proveedor.Telefono));
            comando.Parameters.Add(new SqlParameter("_proDireccion", _proveedor.IdLugar));
            comando.Parameters.Add(new SqlParameter("_proEstado", _proveedor.estado));
            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                CerrarConexion();
            }
            return false;   
        }

        bool IDao.IDao<Entidad, bool, Entidad>.Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public List<string> EstadosDePais(string parametro) 
        {
            List<string> estados = new List<string>();
            SqlDataReader reader;

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand("Procedure_ObtenerEstadosPais", _cn);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("_paramBusq", parametro));
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    estados.Add(reader.GetString(0).ToString());
                }

                return estados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public List<string> CiudadesDeEstado(string parametro)
        {
            List<string> ciudades = new List<string>();
            SqlDataReader reader;

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand("Procedure_ObtenerCiudadesEstado", _cn);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("_paramBusq", parametro));
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    ciudades.Add(reader.GetString(0).ToString());
                }

                return ciudades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public List<string> ConsultarTodosPaises(string parametro) 
        {
            List<string> Paises =  new List<string>();
            SqlDataReader reader;

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand("Procedure_ObtenerTodosLosPaises", _cn);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                reader = _comando.ExecuteReader();
               // int i = 0;
                while (reader.Read())
                {
                    Paises.Add(reader.GetString(0).ToString());
                   // i = i + 1;
                }

                return Paises;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }


        public List<string> ConsultarTodosEstados(string parametro)
        {
            List<string> Estados = new List<string>();
            SqlDataReader reader;

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand("Procedure_ObtenerTodosLosEstados", _cn);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                reader = _comando.ExecuteReader();
                // int i = 0;
                while (reader.Read())
                {
                    Estados.Add(reader.GetString(0).ToString());
                    // i = i + 1;
                }

                return Estados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }


        public List<string> ConsultarTodasCiudades(string parametro)
        {
            List<string> Ciudades = new List<string>();
            SqlDataReader reader;

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand("Procedure_ObtenerTodosLasCiudades", _cn);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                reader = _comando.ExecuteReader();
                // int i = 0;
                while (reader.Read())
                {
                    Ciudades.Add(reader.GetString(0).ToString());
                    // i = i + 1;
                }

                return Ciudades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }
    }
    }
