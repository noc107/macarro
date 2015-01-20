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
using BackOffice.Excepciones.ExcepcionesDao.Proveedores;
using BackOffice.Excepciones;
using BackOffice.FuenteDatos.Dao.Proveedores.Recursos;

namespace BackOffice.FuenteDatos.Dao.Proveedores
{
    public class DaoProveedor: Dao, IDaoProveedor
    {
        private Entidad _proveedor = FabricaEntidad.ObtenerProveedor();
        /// <summary>
        /// Metodo para consultar un proveedor por ID
        /// </summary>
        /// <param name="id">Integer que contiene el id de proveedor</param>
        /// <returns>Un objeto de tipo proveedor</returns>
        public Dominio.Entidad ConsultarXId(int id)
        {
            SqlCommand comando = new SqlCommand(RecursosDaoProveedores.PcdConsultarProv, IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramProId, id));

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
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs02,
                                          RecursosDaoProveedores.DaoProv,
                                          RecursosDaoProveedores.Consultar,
                                          RecursosDaoProveedores.ex02,
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs03,
                                                           RecursosDaoProveedores.DaoProv,
                                                           RecursosDaoProveedores.Consultar,
                                                           RecursosDaoProveedores.ex03,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex) 
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs04,
                                                            RecursosDaoProveedores.DaoProv,
                                                            RecursosDaoProveedores.Consultar,
                                                            RecursosDaoProveedores.ex04,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            finally
            {
                CerrarConexion();
            }
            return null;   
        }
        /// <summary>
        /// Metodo que permite consultar todos los proveedores para llenar el GridView
        /// </summary>
        /// <returns>Una Lista con todos los proveedores</returns>
        public List<Entidad> ConsultarTodos()
        {
            List<Entidad> proveedor = new List<Entidad>();
            SqlDataReader reader;

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand(RecursosDaoProveedores.PcdLlenarGV, _cn);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramBusq, RecursosDaoProveedores.Vacio));
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    proveedor.Add(ObtenerProveedores(reader));
                }

                return proveedor;
            }
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs02,
                                          RecursosDaoProveedores.DaoProv,
                                          RecursosDaoProveedores.ConsultarTodosProv,
                                          RecursosDaoProveedores.ex02,
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs03,
                                                           RecursosDaoProveedores.DaoProv,
                                                           RecursosDaoProveedores.ConsultarTodosProv,
                                                           RecursosDaoProveedores.ex03,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs04,
                                                            RecursosDaoProveedores.DaoProv,
                                                            RecursosDaoProveedores.ConsultarTodosProv,
                                                            RecursosDaoProveedores.ex04,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            finally
            {
                CerrarConexion();
            }
        }
        /// <summary>
        /// Metodo que se utiliza para consultar todos los proveedores a traves de una busqueda
        /// </summary>
        /// <param name="busqueda">String por el cual se realiza la busqueda</param>
        /// <returns>Lista de Proveedores</returns>
        public List<Entidad> ConsultarTodosBusq(string busqueda)
        {
            List<Entidad> proveedor = new List<Entidad>();
            SqlDataReader reader;

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand(RecursosDaoProveedores.PcdLlenarGV, _cn);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramBusq, busqueda));
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    proveedor.Add(ObtenerProveedores(reader));
                }

                return proveedor;
            }
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs02,
                                          RecursosDaoProveedores.DaoProv,
                                          RecursosDaoProveedores.ConsultarBusq,
                                          RecursosDaoProveedores.ex02,
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs03,
                                                           RecursosDaoProveedores.DaoProv,
                                                           RecursosDaoProveedores.ConsultarBusq,
                                                           RecursosDaoProveedores.ex03,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs04,
                                                            RecursosDaoProveedores.DaoProv,
                                                            RecursosDaoProveedores.ConsultarBusq,
                                                            RecursosDaoProveedores.ex04,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            finally
            {
                CerrarConexion();
            }
        }
        /// <summary>
        /// Metodo que se usa para eliminar un proveedor
        /// </summary>
        /// <param name="id">Integer que tiene el id del proveedor a eliminar</param>
        /// <returns>Devuelve un boolean: True en caso de eliminar el proveedor</returns>
        public bool eliminarProveedor(int id)
        {
            SqlCommand comando = new SqlCommand(RecursosDaoProveedores.PcdEliminarProv, IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramProId, id));

            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                return true;
            }
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs02,
                                          RecursosDaoProveedores.DaoProv,
                                          RecursosDaoProveedores.Eliminar,
                                          RecursosDaoProveedores.ex02,
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs03,
                                                           RecursosDaoProveedores.DaoProv,
                                                           RecursosDaoProveedores.Eliminar,
                                                           RecursosDaoProveedores.ex03,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs04,
                                                            RecursosDaoProveedores.DaoProv,
                                                            RecursosDaoProveedores.Eliminar,
                                                            RecursosDaoProveedores.ex04,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            finally
            {
                CerrarConexion();
            }
            
        }
        /// <summary>
        /// Metodo que se utiliza para consultar la direccion del proveedor
        /// </summary>
        /// <param name="fklugar">Integer que indica el id de la direccion que se quiere consultar</param>
        /// <returns>Un string que contiene la direccion</returns>
        public string consultarDireccion(int fklugar)
        {
            CerrarConexion();
            SqlCommand comando = new SqlCommand(RecursosDaoProveedores.PcdConsDireccion, IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramIdDireccion, fklugar));

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
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs02,
                                          RecursosDaoProveedores.DaoProv,
                                          RecursosDaoProveedores.ConsultarDireccion,
                                          RecursosDaoProveedores.ex02,
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs03,
                                                           RecursosDaoProveedores.DaoProv,
                                                           RecursosDaoProveedores.ConsultarDireccion,
                                                           RecursosDaoProveedores.ex03,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs04,
                                                            RecursosDaoProveedores.DaoProv,
                                                            RecursosDaoProveedores.ConsultarDireccion,
                                                            RecursosDaoProveedores.ex04,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            return null;   
        }
        /// <summary>
        /// Metodo para crear un objeto proveedor
        /// </summary>
        /// <param name="objetoBD">SqlDataReader que contiene la informacion del proveedor</param>
        /// <returns>El objeto proveedor con todos sus atributos</returns>
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
                proveedor.Status = objetoBD.GetString(8).ToString();
                proveedor.IdLugar = (consultarDireccion(objetoBD.GetInt32(7)));                
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs04,
                                                            RecursosDaoProveedores.DaoProv,
                                                            RecursosDaoProveedores.ConsultarDireccion,
                                                            RecursosDaoProveedores.ex04,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            return proveedor;
        }

       /// <summary>
       /// Metodo para obtener un objeto proveedor
       /// </summary>
       /// <param name="objetoBD">SqlDataReader que contiene la informacion del proveedor</param>
       /// <returns>Objeto proveedor con todos sus atributos</returns>
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
                proveedor.Status = objetoBD.GetString(8).ToString();
                proveedor.IdLugar = "";
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs04,
                                                            RecursosDaoProveedores.DaoProv,
                                                            RecursosDaoProveedores.ConsultarDireccion,
                                                            RecursosDaoProveedores.ex04,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            return proveedor;
        }

        
        /// <summary>
        /// Metodo para agregar un proveedor
        /// </summary>
        /// <param name="parametro">Entidad proveedor que se va a almacenar</param>
        /// <returns>Boolean que indica el exito de la operacion</returns>
        bool IDao.IDao<Entidad, bool, Entidad>.Agregar(Entidad parametro)
        {
            Proveedor _proveedor = (Proveedor)parametro;
            SqlCommand comando = new SqlCommand(RecursosDaoProveedores.PcdAlmacenarProv, IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramRif, _proveedor.Rif));
            comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramRazonSocial, _proveedor.RazonSocial));
            comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramCorreo, _proveedor.Correo));
            comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramWeb, _proveedor.PagWeb));
            comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramFechaContrato, DateTime.Parse(_proveedor.FechaContrato)));
            comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramTlf, _proveedor.Telefono));
            comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramDireccion, _proveedor.IdLugar));
            comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramCiudad, _proveedor.Ciudad));
            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                if (_lectura.FieldCount == 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs02,
                                          RecursosDaoProveedores.DaoProv,
                                          RecursosDaoProveedores.Agregar,
                                          RecursosDaoProveedores.ex02,
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs03,
                                                           RecursosDaoProveedores.DaoProv,
                                                           RecursosDaoProveedores.Agregar,
                                                           RecursosDaoProveedores.ex03,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs04,
                                                            RecursosDaoProveedores.DaoProv,
                                                            RecursosDaoProveedores.Agregar,
                                                            RecursosDaoProveedores.ex04,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            finally
            {
                CerrarConexion();
            }
            
        }
        /// <summary>
        /// Metodo para modificar la informacion de un proveedor
        /// </summary>
        /// <param name="parametro">Entidad proveedor que contiene los datos que se van a modificar</param>
        /// <returns>Boolean para indicar el exito de la operacion</returns>
        bool IDao.IDao<Entidad, bool, Entidad>.Modificar(Entidad parametro)
        {
            int status = 1;
            Proveedor _proveedor = (Proveedor)parametro;
            SqlCommand comando = new SqlCommand(RecursosDaoProveedores.PcdModificarProv, IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramRif, _proveedor.Rif));
            comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramRazonSocial, _proveedor.RazonSocial));
            comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramCorreo, _proveedor.Correo));
            comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramWeb, _proveedor.PagWeb));
            comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramFechaContrato, DateTime.Parse(_proveedor.FechaContrato)));
            comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramTlf, _proveedor.Telefono));
            comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramDireccion, _proveedor.IdLugar));
            comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramCiudad, _proveedor.Ciudad));
            comando.Parameters.Add(new SqlParameter("@_proARif", _proveedor.ARif));

            if (_proveedor.Status == RecursosDaoProveedores.Activado) 
                status = 1;
            if (_proveedor.Status == RecursosDaoProveedores.Desactivado) 
                status = 2;
                
            comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramStatus, status));
            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                return true;
            }
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs02,
                                          RecursosDaoProveedores.DaoProv,
                                          RecursosDaoProveedores.Modificar,
                                          RecursosDaoProveedores.ex02,
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs03,
                                                           RecursosDaoProveedores.DaoProv,
                                                           RecursosDaoProveedores.Modificar,
                                                           RecursosDaoProveedores.ex03,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs04,
                                                            RecursosDaoProveedores.DaoProv,
                                                            RecursosDaoProveedores.Modificar,
                                                            RecursosDaoProveedores.ex04,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            finally
            {
                CerrarConexion();
            }
            
        }
        /// <summary>
        /// Metodo para obtener los estados de un pais
        /// </summary>
        /// <param name="parametro">String que contiene el nombre del pais</param>
        /// <returns>Lista de String con los nombres de los estados de ese pais</returns>
        public List<string> EstadosDePais(string parametro) 
        {
            List<string> estados = new List<string>();
            SqlDataReader reader;

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand(RecursosDaoProveedores.PcdObtenerEstadosPais, _cn);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramBusq, parametro));
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    estados.Add(reader.GetString(0).ToString());
                }

                return estados;
            }
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs02,
                                          RecursosDaoProveedores.DaoProv,
                                          RecursosDaoProveedores.ConsultarEstadosPais,
                                          RecursosDaoProveedores.ex02,
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs03,
                                                           RecursosDaoProveedores.DaoProv,
                                                           RecursosDaoProveedores.ConsultarEstadosPais,
                                                           RecursosDaoProveedores.ex03,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs04,
                                                            RecursosDaoProveedores.DaoProv,
                                                            RecursosDaoProveedores.ConsultarEstadosPais,
                                                            RecursosDaoProveedores.ex04,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            finally
            {
                CerrarConexion();
            }
        }
        /// <summary>
        /// Metodo para obtener las ciudades de un estado
        /// </summary>
        /// <param name="parametro">string que contiene el nombre del estado</param>
        /// <returns>Lista de string que contiene las ciudades del estado</returns>
        public List<string> CiudadesDeEstado(string parametro)
        {
            List<string> ciudades = new List<string>();
            SqlDataReader reader;

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand(RecursosDaoProveedores.PcdObtenerCiudadesEstado, _cn);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramBusq, parametro));
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    ciudades.Add(reader.GetString(0).ToString());
                }

                return ciudades;
            }
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs02,
                                          RecursosDaoProveedores.DaoProv,
                                          RecursosDaoProveedores.CiudadesDeEstados,
                                          RecursosDaoProveedores.ex02,
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs03,
                                                           RecursosDaoProveedores.DaoProv,
                                                           RecursosDaoProveedores.CiudadesDeEstados,
                                                           RecursosDaoProveedores.ex03,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs04,
                                                            RecursosDaoProveedores.DaoProv,
                                                            RecursosDaoProveedores.CiudadesDeEstados,
                                                            RecursosDaoProveedores.ex04,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            finally
            {
                CerrarConexion();
            }
        }
        /// <summary>
        /// Metodo para consultar todos los paises
        /// </summary>
        /// <param name="parametro">string que contiene el parametro de busqueda</param>
        /// <returns>Lista con todos los paises</returns>
        public List<string> ConsultarTodosPaises(string parametro) 
        {
            List<string> Paises =  new List<string>();
            SqlDataReader reader;

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand(RecursosDaoProveedores.PcdObtenerTodosPaises, _cn);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                reader = _comando.ExecuteReader();
              
                while (reader.Read())
                {
                    Paises.Add(reader.GetString(0).ToString());
                   
                }

                return Paises;
            }
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs02,
                                          RecursosDaoProveedores.DaoProv,
                                          RecursosDaoProveedores.ConsultarPaises,
                                          RecursosDaoProveedores.ex02,
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs03,
                                                           RecursosDaoProveedores.DaoProv,
                                                           RecursosDaoProveedores.ConsultarPaises,
                                                           RecursosDaoProveedores.ex03,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs04,
                                                            RecursosDaoProveedores.DaoProv,
                                                            RecursosDaoProveedores.ConsultarPaises,
                                                            RecursosDaoProveedores.ex04,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            finally
            {
                CerrarConexion();
            }
        }

        /// <summary>
        /// Metodo para consultar todos los estados
        /// </summary>
        /// <param name="parametro">String que contiene el parametro de busqueda</param>
        /// <returns>Lista con todos los estados</returns>
        public List<string> ConsultarTodosEstados(string parametro)
        {
            List<string> Estados = new List<string>();
            SqlDataReader reader;

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand(RecursosDaoProveedores.PcdObtenerTodosEstados, _cn);
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
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs02,
                                          RecursosDaoProveedores.DaoProv,
                                          RecursosDaoProveedores.ConsultarEstados,
                                          RecursosDaoProveedores.ex02,
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs03,
                                                           RecursosDaoProveedores.DaoProv,
                                                           RecursosDaoProveedores.ConsultarEstados,
                                                           RecursosDaoProveedores.ex03,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs04,
                                                            RecursosDaoProveedores.DaoProv,
                                                            RecursosDaoProveedores.ConsultarEstados,
                                                            RecursosDaoProveedores.ex04,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            finally
            {
                CerrarConexion();
            }
        }

        /// <summary>
        /// Metodo para consultar todas las ciudades
        /// </summary>
        /// <param name="parametro">string que contiene el parametro de busqueda</param>
        /// <returns>Lista con todas las ciudades</returns>
        public List<string> ConsultarTodasCiudades(string parametro)
        {
            List<string> Ciudades = new List<string>();
            SqlDataReader reader;

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand(RecursosDaoProveedores.PcdObtenerTodosCiudades, _cn);
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
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs02,
                                          RecursosDaoProveedores.DaoProv,
                                          RecursosDaoProveedores.ConsultarCiudades,
                                          RecursosDaoProveedores.ex02,
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs03,
                                                           RecursosDaoProveedores.DaoProv,
                                                           RecursosDaoProveedores.ConsultarCiudades,
                                                           RecursosDaoProveedores.ex03,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs04,
                                                            RecursosDaoProveedores.DaoProv,
                                                            RecursosDaoProveedores.ConsultarCiudades,
                                                            RecursosDaoProveedores.ex04,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            finally
            {
                CerrarConexion();
            }
        }
        /// <summary>
        /// Metodo para obtener los items de un proveedor
        /// </summary>
        /// <param name="parametro">Integer que contiene el id del proveedor</param>
        /// <returns>Lista con los nombres de los items asociados a ese proveedor</returns>
        public List<string> CargarItemLt(int parametro)
        {
            List<string> items = new List<string>();
            SqlDataReader reader;

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand(RecursosDaoProveedores.PcdCargarItemLT, _cn);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter(RecursosDaoProveedores.paramProvId, parametro));
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    items.Add(reader.GetString(0).ToString());
                }

                return items;
            }
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs02,
                                          RecursosDaoProveedores.DaoProv,
                                          RecursosDaoProveedores.ItemsProv,
                                          RecursosDaoProveedores.ex02,
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs03,
                                                           RecursosDaoProveedores.DaoProv,
                                                           RecursosDaoProveedores.ItemsProv,
                                                           RecursosDaoProveedores.ex03,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor(RecursosDaoProveedores.rs04,
                                                            RecursosDaoProveedores.DaoProv,
                                                            RecursosDaoProveedores.ItemsProv,
                                                            RecursosDaoProveedores.ex04,
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            finally
            {
                CerrarConexion();
            }
        }


    }
    }
