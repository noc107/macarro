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
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_002",
                                          "DaoProveedor",
                                          "Consultar",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_003",
                                                           "DaoProvedor",
                                                           "Consultar",
                                                           "No se han podido cargar los datos debido a que existe un conflicto con la conexión a la base de datos",
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex) 
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_004",
                                                            "DaoProveedor",
                                                            "Consultar",
                                                            "No se han podido cargar los datos debido a un error en el sistema",
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
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_002",
                                          "DaoProveedor",
                                          "Consultar todos los proveedores",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_003",
                                                           "DaoProvedor",
                                                           "Consultar todos los proveedores",
                                                           "No se han podido cargar los datos debido a que existe un conflicto con la conexión a la base de datos",
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_004",
                                                            "DaoProveedor",
                                                            "Consultar todos los proveedores",
                                                            "No se han podido cargar los datos debido a un error en el sistema",
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
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_002",
                                          "DaoProveedor",
                                          "Consultar Busqueda",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_003",
                                                           "DaoProvedor",
                                                           "Consultar Busqueda",
                                                           "No se han podido cargar los datos debido a que existe un conflicto con la conexión a la base de datos",
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_004",
                                                            "DaoProveedor",
                                                            "Consultar Busqueda",
                                                            "No se han podido cargar los datos debido a un error en el sistema",
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
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_002",
                                          "DaoProveedor",
                                          "Eliminar",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_003",
                                                           "DaoProvedor",
                                                           "Eliminar",
                                                           "No se han podido cargar los datos debido a que existe un conflicto con la conexión a la base de datos",
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_004",
                                                            "DaoProveedor",
                                                            "Eliminar",
                                                            "No se han podido cargar los datos debido a un error en el sistema",
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
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_002",
                                          "DaoProveedor",
                                          "Consultar Direccion",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_003",
                                                           "DaoProvedor",
                                                           "Consultar Direccion",
                                                           "No se han podido cargar los datos debido a que existe un conflicto con la conexión a la base de datos",
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_004",
                                                            "DaoProveedor",
                                                            "Consultar Direccion",
                                                            "No se han podido cargar los datos debido a un error en el sistema",
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
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_004",
                                                            "DaoProveedor",
                                                            "Consultar Direccion",
                                                            "No se han podido cargar los datos debido a un error en el sistema",
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
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_004",
                                                            "DaoProveedor",
                                                            "Consultar Direccion",
                                                            "No se han podido cargar los datos debido a un error en el sistema",
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
            SqlCommand comando = new SqlCommand("Procedure_AlmacenarProveedor", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("_proRif", _proveedor.Rif));
            comando.Parameters.Add(new SqlParameter("_proRazonSocial", _proveedor.RazonSocial));
            comando.Parameters.Add(new SqlParameter("_proCorreo", _proveedor.Correo));
            comando.Parameters.Add(new SqlParameter("_proPaginaWeb", _proveedor.PagWeb));
            comando.Parameters.Add(new SqlParameter("_proFechaContrato", DateTime.Parse(_proveedor.FechaContrato)));
            comando.Parameters.Add(new SqlParameter("_proTelefono", _proveedor.Telefono));
            comando.Parameters.Add(new SqlParameter("_proDireccion", _proveedor.IdLugar));
            comando.Parameters.Add(new SqlParameter("_proCiudad", _proveedor.Ciudad));
            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                return true;
            }
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_002",
                                          "DaoProveedor",
                                          "Agregar",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_003",
                                                           "DaoProvedor",
                                                           "Agregar",
                                                           "No se han podido cargar los datos debido a que existe un conflicto con la conexión a la base de datos",
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_004",
                                                            "DaoProveedor",
                                                            "Agregar",
                                                            "No se han podido cargar los datos debido a un error en el sistema",
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
            SqlCommand comando = new SqlCommand("Procedure_modificarProveedor", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("_proRif", _proveedor.Rif));
            comando.Parameters.Add(new SqlParameter("_proRazonSocial", _proveedor.RazonSocial));
            comando.Parameters.Add(new SqlParameter("_proCorreo", _proveedor.Correo));
            comando.Parameters.Add(new SqlParameter("_proPaginaWeb", _proveedor.PagWeb));
            comando.Parameters.Add(new SqlParameter("_proFechaContrato", DateTime.Parse(_proveedor.FechaContrato)));
            comando.Parameters.Add(new SqlParameter("_proTelefono", _proveedor.Telefono));
            comando.Parameters.Add(new SqlParameter("_proDireccion", _proveedor.IdLugar));
            comando.Parameters.Add(new SqlParameter("_proCiudad", _proveedor.Ciudad));

            if (_proveedor.Status == "Activado") 
                status = 1;
            if (_proveedor.Status == "Desactivado") 
                status = 2;
                
            comando.Parameters.Add(new SqlParameter("_proStatus", status));
            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                return true;
            }
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_002",
                                          "DaoProveedor",
                                          "Modificar",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_003",
                                                           "DaoProvedor",
                                                           "Modificar",
                                                           "No se han podido cargar los datos debido a que existe un conflicto con la conexión a la base de datos",
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_004",
                                                            "DaoProveedor",
                                                            "Modificar",
                                                            "No se han podido cargar los datos debido a un error en el sistema",
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
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_002",
                                          "DaoProveedor",
                                          "Consultar Estados De Pais",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_003",
                                                           "DaoProvedor",
                                                           "Consultar Estados De Pais",
                                                           "No se han podido cargar los datos debido a que existe un conflicto con la conexión a la base de datos",
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_004",
                                                            "DaoProveedor",
                                                            "Consultar Estados De Pais",
                                                            "No se han podido cargar los datos debido a un error en el sistema",
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
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_002",
                                          "DaoProveedor",
                                          "Ciudades de Estado",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_003",
                                                           "DaoProvedor",
                                                           "Ciudades de Estado",
                                                           "No se han podido cargar los datos debido a que existe un conflicto con la conexión a la base de datos",
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_004",
                                                            "DaoProveedor",
                                                            "Ciudades de Estado",
                                                            "No se han podido cargar los datos debido a un error en el sistema",
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
                SqlCommand _comando = new SqlCommand("Procedure_ObtenerTodosLosPaises", _cn);
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
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_002",
                                          "DaoProveedor",
                                          "Consultar Paises",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_003",
                                                           "DaoProvedor",
                                                           "Consultar Paises",
                                                           "No se han podido cargar los datos debido a que existe un conflicto con la conexión a la base de datos",
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_004",
                                                            "DaoProveedor",
                                                            "Consultar Paises",
                                                            "No se han podido cargar los datos debido a un error en el sistema",
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
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_002",
                                          "DaoProveedor",
                                          "Consultar Estados",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_003",
                                                           "DaoProvedor",
                                                           "Consultar Estados",
                                                           "No se han podido cargar los datos debido a que existe un conflicto con la conexión a la base de datos",
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_004",
                                                            "DaoProveedor",
                                                            "Consultar Estados",
                                                            "No se han podido cargar los datos debido a un error en el sistema",
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
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_002",
                                          "DaoProveedor",
                                          "Consultar Ciudades",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_003",
                                                           "DaoProvedor",
                                                           "Consultar Ciudades",
                                                           "No se han podido cargar los datos debido a que existe un conflicto con la conexión a la base de datos",
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_004",
                                                            "DaoProveedor",
                                                            "Consultar Ciudades",
                                                            "No se han podido cargar los datos debido a un error en el sistema",
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
                SqlCommand _comando = new SqlCommand("Procedure_cargarItemLT", _cn);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("_provId", parametro));
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    items.Add(reader.GetString(0).ToString());
                }

                return items;
            }
            catch (NullReferenceException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_002",
                                          "DaoProveedor",
                                          "Items de Proveedor",
                                          "No se han podido cargar los datos debido a que hay una referencia nula",
                                          ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (SqlException ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_003",
                                                           "DaoProvedor",
                                                           "Items de Proveedor",
                                                           "No se han podido cargar los datos debido a que existe un conflicto con la conexión a la base de datos",
                                                            ex);
                Logger.EscribirEnLogger(exDaoProveedor);
                Console.WriteLine(ex.ToString());
                throw exDaoProveedor;
            }
            catch (Exception ex)
            {
                ExcepcionDaoProveedor exDaoProveedor = new ExcepcionDaoProveedor("RS_08_004",
                                                            "DaoProveedor",
                                                            "Items de Proveedor",
                                                            "No se han podido cargar los datos debido a un error en el sistema",
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
