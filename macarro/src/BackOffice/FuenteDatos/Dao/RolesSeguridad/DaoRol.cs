using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.Excepciones;
using BackOffice.Excepciones.ExcepcionesComando.RolesSeguridad;
using BackOffice.Excepciones.ExcepcionesDao.RolesSeguridad;
using BackOffice.FuenteDatos.Dao.RolesSeguridad.Recursos;
using BackOffice.FuenteDatos.IDao.RolesSeguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BackOffice.FuenteDatos.Dao.RolesSeguridad
{
    public class DaoRol : Dao, IDaoRol
    {
        /// <summary>
        /// Metodo para agregar un rol en la base de datos
        /// </summary>
        /// <param name="rol">rol a agregar</param>
        /// <returns>bool si agrego el rol</returns>
        public bool Agregar(Entidad rol) 
        {
            Int64 secuenciaActual;
            
            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();

                SqlCommand _comando = new SqlCommand("Procedure_AgregarRol", _cn);
                _comando.Parameters.Add(new SqlParameter("@_rolNombre", SqlDbType.VarChar));
                _comando.Parameters.Add(new SqlParameter("@_rolDescripcion", SqlDbType.VarChar));
                _comando.Parameters["@_rolNombre"].Value = ((Rol)rol).Nombre;
                _comando.Parameters["@_rolDescripcion"].Value = ((Rol)rol).Descripcion;
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.ExecuteNonQuery();

                CerrarConexion();
                secuenciaActual = ConsultarSecuencia();
                _cn = IniciarConexion();
                _cn.Open();

                for (int i = 0; i < ((Rol)rol).Acciones.Count; i++)
                {
                    _comando = new SqlCommand("Procedure_AgregarRol_Accion", _cn);
                    _comando.Parameters.Add(new SqlParameter("@_rolID", SqlDbType.Int));
                    _comando.Parameters.Add(new SqlParameter("@_accionID", SqlDbType.Int));
                    _comando.Parameters["@_rolID"].Value = secuenciaActual;
                    _comando.Parameters["@_accionID"].Value = ((Rol)rol).Acciones[i].Id;
                    _comando.CommandType = System.Data.CommandType.StoredProcedure;
                    _comando.ExecuteNonQuery();
                }
                return true;
            }
            catch (NullReferenceException e)
            {
                ExcepcionDaoRol exDaoRol = new ExcepcionDaoRol(RecursosDaoRolesSeguridad.CodigoNullReferenceException,
                                          RecursosDaoRolesSeguridad.ClaseDaoRol,
                                          RecursosDaoRolesSeguridad.MetodoAgregar,
                                          RecursosDaoRolesSeguridad.MensajeNullReferenceException,
                                          e);
                Logger.EscribirEnLogger(exDaoRol);

                throw exDaoRol;
            }
            catch (SqlException e)
            {
                ExcepcionDaoRol exDaoRol = new ExcepcionDaoRol(RecursosDaoRolesSeguridad.CodigoSQLException,
                                          RecursosDaoRolesSeguridad.ClaseDaoRol,
                                          RecursosDaoRolesSeguridad.MetodoAgregar,
                                          RecursosDaoRolesSeguridad.MensajeSQLException,
                                          e);
                Logger.EscribirEnLogger(exDaoRol);

                throw exDaoRol;
            }
            catch (Exception e)
            {
                ExcepcionDaoRol exDaoRol = new ExcepcionDaoRol(RecursosDaoRolesSeguridad.CodigoGeneralError,
                                          RecursosDaoRolesSeguridad.ClaseDaoRol,
                                          RecursosDaoRolesSeguridad.MetodoAgregar,
                                          RecursosDaoRolesSeguridad.MensajeGeneralError,
                                          e);
                Logger.EscribirEnLogger(exDaoRol);

                throw exDaoRol;
            }
            finally
            {
                CerrarConexion();
            }

        }

        /// <summary>
        ///  Metodo para modficar las caracteristicas de un rol en especifico
        /// </summary>
        /// <param name="rol">rol a modificar</param>
        /// <returns>bool si se realizo la modificacion del rol</returns>
        public bool Modificar(Entidad rol) 
        {
            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();

                SqlCommand _comando = new SqlCommand("Procedure_ModificarRol", _cn);
                _comando.Parameters.Add(new SqlParameter("@_rolID", SqlDbType.Int));
                _comando.Parameters.Add(new SqlParameter("@_rolNombre", SqlDbType.VarChar));
                _comando.Parameters.Add(new SqlParameter("@_rolDescripcion", SqlDbType.VarChar));
                _comando.Parameters["@_rolID"].Value = ((Rol)rol).Id;
                _comando.Parameters["@_rolNombre"].Value = ((Rol)rol).Nombre;
                _comando.Parameters["@_rolDescripcion"].Value = ((Rol)rol).Descripcion;
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.ExecuteNonQuery();

                _comando = new SqlCommand("Procedure_EliminarAccionRol", _cn);
                _comando.Parameters.Add(new SqlParameter("@_rolID", SqlDbType.Int));
                _comando.Parameters["@_rolID"].Value = ((Rol)rol).Id;
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.ExecuteNonQuery();

                for (int i = 0; i < ((Rol)rol).Acciones.Count; i++)
                {
                    _comando = new SqlCommand("Procedure_AgregarRol_Accion", _cn);
                    _comando.Parameters.Add(new SqlParameter("@_rolID", SqlDbType.Int));
                    _comando.Parameters.Add(new SqlParameter("@_accionID", SqlDbType.Int));
                    _comando.Parameters["@_rolID"].Value = ((Rol)rol).Id;
                    _comando.Parameters["@_accionID"].Value = ((Rol)rol).Acciones[i].Id;
                    _comando.CommandType = System.Data.CommandType.StoredProcedure;
                    _comando.ExecuteNonQuery();
                }
                return true;
            }
            catch (NullReferenceException e)
            {
                ExcepcionDaoRol exDaoRol = new ExcepcionDaoRol(RecursosDaoRolesSeguridad.CodigoNullReferenceException,
                                          RecursosDaoRolesSeguridad.ClaseDaoRol,
                                          RecursosDaoRolesSeguridad.MetodoModificar,
                                          RecursosDaoRolesSeguridad.MensajeNullReferenceException,
                                          e);
                Logger.EscribirEnLogger(exDaoRol);

                throw exDaoRol;
            }
            catch (SqlException e)
            {
                ExcepcionDaoRol exDaoRol = new ExcepcionDaoRol(RecursosDaoRolesSeguridad.CodigoSQLException,
                                          RecursosDaoRolesSeguridad.ClaseDaoRol,
                                          RecursosDaoRolesSeguridad.MetodoModificar,
                                          RecursosDaoRolesSeguridad.MensajeSQLException,
                                          e);
                Logger.EscribirEnLogger(exDaoRol);

                throw exDaoRol;
            }
            catch (Exception e)
            {
                ExcepcionDaoRol exDaoRol = new ExcepcionDaoRol(RecursosDaoRolesSeguridad.CodigoGeneralError,
                                          RecursosDaoRolesSeguridad.ClaseDaoRol,
                                          RecursosDaoRolesSeguridad.MetodoModificar,
                                          RecursosDaoRolesSeguridad.MensajeGeneralError,
                                          e);
                Logger.EscribirEnLogger(exDaoRol);

                throw exDaoRol;
            }
            finally
            {
                CerrarConexion();
            }
        }

        /// <summary>
        /// Metodo para extraer todos los roles en la base de datos
        /// </summary>
        /// <returns>List de roles</returns>
        public List<Entidad> ConsultarTodos()
        {
            List<Entidad> roles = new List<Entidad>();
            SqlDataReader reader;

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand("Procedure_ConsultarRolGeneral", _cn);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    roles.Add((Rol)FabricaEntidad.ObtenerRol((int)reader[0], (string)reader[1], (string)reader[2], null));
                }

                return roles;
            }
            catch (NullReferenceException e)
            {
                ExcepcionDaoRol exDaoRol = new ExcepcionDaoRol(RecursosDaoRolesSeguridad.CodigoNullReferenceException,
                                          RecursosDaoRolesSeguridad.ClaseDaoRol,
                                          RecursosDaoRolesSeguridad.MetodoConsultarTodos,
                                          RecursosDaoRolesSeguridad.MensajeNullReferenceException,
                                          e);
                Logger.EscribirEnLogger(exDaoRol);

                throw exDaoRol;
            }
            catch (SqlException e)
            {
                ExcepcionDaoRol exDaoRol = new ExcepcionDaoRol(RecursosDaoRolesSeguridad.CodigoSQLException,
                                          RecursosDaoRolesSeguridad.ClaseDaoRol,
                                          RecursosDaoRolesSeguridad.MetodoConsultarTodos,
                                          RecursosDaoRolesSeguridad.MensajeSQLException,
                                          e);
                Logger.EscribirEnLogger(exDaoRol);

                throw exDaoRol;
            }
            catch (Exception e)
            {
                ExcepcionDaoRol exDaoRol = new ExcepcionDaoRol(RecursosDaoRolesSeguridad.CodigoGeneralError,
                                          RecursosDaoRolesSeguridad.ClaseDaoRol,
                                          RecursosDaoRolesSeguridad.MetodoConsultarTodos,
                                          RecursosDaoRolesSeguridad.MensajeGeneralError,
                                          e);
                Logger.EscribirEnLogger(exDaoRol);

                throw exDaoRol;
            }
            finally
            {
                CerrarConexion();
            }
        }

        /// <summary>
        /// Metodo para obtener la posicion actual de la secuencia de Rol
        /// </summary>
        /// <returns>Int64 de la posicion actual de la secuencia</returns>
        public Int64 ConsultarSecuencia()
        {
            Int64 secuenciaActual = 0;
            SqlDataReader reader;
            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand("Procedure_ConsultarSecuenciaRol", _cn);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    secuenciaActual = reader.GetInt64(0);
                }

                return secuenciaActual;
            }
            catch (NullReferenceException e)
            {
                ExcepcionDaoRol exDaoRol = new ExcepcionDaoRol(RecursosDaoRolesSeguridad.CodigoNullReferenceException,
                                          RecursosDaoRolesSeguridad.ClaseDaoRol,
                                          RecursosDaoRolesSeguridad.MetodoConsultarSecuencia,
                                          RecursosDaoRolesSeguridad.MensajeNullReferenceException,
                                          e);
                Logger.EscribirEnLogger(exDaoRol);

                throw exDaoRol;
            }
            catch (SqlException e)
            {
                ExcepcionDaoRol exDaoRol = new ExcepcionDaoRol(RecursosDaoRolesSeguridad.CodigoSQLException,
                                          RecursosDaoRolesSeguridad.ClaseDaoRol,
                                          RecursosDaoRolesSeguridad.MetodoConsultarSecuencia,
                                          RecursosDaoRolesSeguridad.MensajeSQLException,
                                          e);
                Logger.EscribirEnLogger(exDaoRol);

                throw exDaoRol;
            }
            catch (Exception e)
            {
                ExcepcionDaoRol exDaoRol = new ExcepcionDaoRol(RecursosDaoRolesSeguridad.CodigoGeneralError,
                                          RecursosDaoRolesSeguridad.ClaseDaoRol,
                                          RecursosDaoRolesSeguridad.MetodoConsultarSecuencia,
                                          RecursosDaoRolesSeguridad.MensajeGeneralError,
                                          e);
                Logger.EscribirEnLogger(exDaoRol);

                throw exDaoRol;
            }
            finally
            {
                CerrarConexion();
            }
        }

        /// <summary>
        /// Metodo para consultar las acciones de un rol
        /// </summary>
        /// <param name="rol">rol para consultar</param>
        /// <returns>List de acciones del rol</returns>
        public List<Entidad> ConsultarRol(Entidad rol) 
        {
            List<Entidad> acciones = new List<Entidad>();
            SqlDataReader reader;
            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand("Procedure_ConsultarRol", _cn);
                _comando.Parameters.Add(new SqlParameter("@_rolID", SqlDbType.Int));
                _comando.Parameters["@_rolID"].Value = ((Rol)rol).Id;
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    acciones.Add((Accion)FabricaEntidad.ObtenerAccion((int)reader[0], (string)reader[1], (string)reader[2]));
                }

                return acciones;
            }
            catch (NullReferenceException e)
            {
                ExcepcionDaoRol exDaoRol = new ExcepcionDaoRol(RecursosDaoRolesSeguridad.CodigoNullReferenceException,
                                          RecursosDaoRolesSeguridad.ClaseDaoRol,
                                          RecursosDaoRolesSeguridad.MetodoConsultarRol,
                                          RecursosDaoRolesSeguridad.MensajeNullReferenceException,
                                          e);
                Logger.EscribirEnLogger(exDaoRol);

                throw exDaoRol;
            }
            catch (SqlException e)
            {
                ExcepcionDaoRol exDaoRol = new ExcepcionDaoRol(RecursosDaoRolesSeguridad.CodigoSQLException,
                                          RecursosDaoRolesSeguridad.ClaseDaoRol,
                                          RecursosDaoRolesSeguridad.MetodoConsultarRol,
                                          RecursosDaoRolesSeguridad.MensajeSQLException,
                                          e);
                Logger.EscribirEnLogger(exDaoRol);

                throw exDaoRol;
            }
            catch (Exception e)
            {
                ExcepcionDaoRol exDaoRol = new ExcepcionDaoRol(RecursosDaoRolesSeguridad.CodigoGeneralError,
                                          RecursosDaoRolesSeguridad.ClaseDaoRol,
                                          RecursosDaoRolesSeguridad.MetodoConsultarRol,
                                          RecursosDaoRolesSeguridad.MensajeGeneralError,
                                          e);
                Logger.EscribirEnLogger(exDaoRol);

                throw exDaoRol;
            }
            finally
            {
                CerrarConexion();
            }
        }
       
        /// <summary>
        /// Metodo para eliminar un rol de la base de datos junto con las n a n de la tabla ROL_ACCION
        /// </summary>
        /// <param name="rol">rol a eliminar</param>
        /// <returns>bool si se elimino el rol</returns>
        public bool EliminarRol(Entidad rol) 
        {
            SqlDataReader reader;

            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();

                SqlCommand _comando = new SqlCommand("Procedure_ConsultarUsuarioSinRol", _cn);
                _comando.Parameters.Add(new SqlParameter("@_rolID", SqlDbType.Int));
                _comando.Parameters["@_rolID"].Value = ((Rol)rol).Id;
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                reader = _comando.ExecuteReader();
                reader.Read();

                if (reader.GetInt32(0) == 0)
                {
                    reader.Close();
                    _comando = new SqlCommand("Procedure_EliminarRol", _cn);
                    _comando.Parameters.Add(new SqlParameter("@_rolID", SqlDbType.Int));
                    _comando.Parameters["@_rolID"].Value = ((Rol)rol).Id;
                    _comando.CommandType = System.Data.CommandType.StoredProcedure;
                    _comando.ExecuteNonQuery();

                    return true;
                }
                else
                {
                    throw new ExcepcionFKRol(RecursosDaoRolesSeguridad.CodigoFKRolException,
                                             RecursosDaoRolesSeguridad.ClaseDaoRol,
                                             RecursosDaoRolesSeguridad.MetodoEliminarRol,
                                             RecursosDaoRolesSeguridad.MensajeFKRolException,
                                             new Exception());
                }
            }
            catch (ExcepcionFKRol e)
            {
                ExcepcionFKRol exDaoRol = new ExcepcionFKRol(e.Codigo, e.Clase, e.Metodo, e.Message, e);
                Logger.EscribirEnLogger(exDaoRol);

                throw exDaoRol;
            }
            catch (NullReferenceException e)
            {
                ExcepcionDaoRol exDaoRol = new ExcepcionDaoRol(RecursosDaoRolesSeguridad.CodigoNullReferenceException,
                                          RecursosDaoRolesSeguridad.ClaseDaoRol,
                                          RecursosDaoRolesSeguridad.MetodoEliminarRol,
                                          RecursosDaoRolesSeguridad.MensajeNullReferenceException,
                                          e);
                Logger.EscribirEnLogger(exDaoRol);

                throw exDaoRol;
            }
            catch (SqlException e)
            {
                ExcepcionDaoRol exDaoRol = new ExcepcionDaoRol(RecursosDaoRolesSeguridad.CodigoSQLException,
                                          RecursosDaoRolesSeguridad.ClaseDaoRol,
                                          RecursosDaoRolesSeguridad.MetodoEliminarRol,
                                          RecursosDaoRolesSeguridad.MensajeSQLException,
                                          e);
                Logger.EscribirEnLogger(exDaoRol);

                throw exDaoRol;
            }
            catch (Exception e)
            {
                ExcepcionDaoRol exDaoRol = new ExcepcionDaoRol(RecursosDaoRolesSeguridad.CodigoGeneralError,
                                          RecursosDaoRolesSeguridad.ClaseDaoRol,
                                          RecursosDaoRolesSeguridad.MetodoEliminarRol,
                                          RecursosDaoRolesSeguridad.MensajeGeneralError,
                                          e);
                Logger.EscribirEnLogger(exDaoRol);

                throw exDaoRol;
            }
            finally
            {
                CerrarConexion();
            }
        }

        /// <summary>
        /// Metodo para consultar rol por id. No implementado
        /// </summary>
        /// <param name="id">id del rol</param>
        /// <returns>rol consultado</returns>
        public Entidad ConsultarXId(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}