using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BackOffice.FuenteDatos.IDao.ConfiguracionPuestosPlaya;
using BackOffice.Dominio;
using BackOffice.Dominio.Fabrica;
using BackOffice.Dominio.Entidades;
using BackOffice.Excepciones;
using BackOffice.Excepciones.ExcepcionesDao.ConfiguracionPuestosPlaya;

namespace BackOffice.FuenteDatos.Dao.ConfiguracionPuestosPlaya
{
    public class DaoInventarioPlaya : Dao , IDaoInventarioPlaya
    {

        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Realiza la consulta de el inventario deseado
        /// </summary>
        /// <param name="parametro">tipo de inventario a consultar</param>
        /// <returns>lista de Inventario obtenida de la consulta</returns>
        public List<Entidad> ConsultarInventarioTipo(string parametro)
        {
            List<Entidad> listaInventario = new List<Entidad>();
           
            try
            {                
                SqlCommand comando = new SqlCommand(RecursosDao.procedimientoConsultarInventarioTipo, IniciarConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter(RecursosDao.parametroInvId, DBNull.Value));
                comando.Parameters.Add(new SqlParameter(RecursosDao.parametroInvTipo, parametro));
                comando.Parameters.Add(new SqlParameter(RecursosDao.parametroInvEstado, DBNull.Value));
          
                SqlDataReader lector;
            
                    IniciarConexion().Open();
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        Entidad inventario = AsignarInventario(lector);
                        if (inventario != null)
                        {
                            listaInventario.Add(inventario);
                        }
                    }
            }
            catch (NullReferenceException e)
            {
                ExcepcionDaoInventarioPlaya exDaoInventarioPlaya = new ExcepcionDaoInventarioPlaya(RecursosDao.CodigoErrorNullReference,
                                                      RecursosDao.ClaseDaoInventarioPlaya,
                                                      RecursosDao.MetodoConsultarInventarioTipo,
                                                      RecursosDao.MensajeErrorExcepcion,
                                                      e);
                Logger.EscribirEnLogger(exDaoInventarioPlaya);

                throw exDaoInventarioPlaya;
            }
            catch (SqlException e)
            {

                ExcepcionDaoInventarioPlaya exDaoInventarioPlaya = new ExcepcionDaoInventarioPlaya(RecursosDao.CodigoErrorSql,
                                                      RecursosDao.ClaseDaoInventarioPlaya,
                                                      RecursosDao.MetodoConsultarInventarioTipo,
                                                      RecursosDao.MensajeErrorExcepcion,
                                                      e);
                Logger.EscribirEnLogger(exDaoInventarioPlaya);

                throw exDaoInventarioPlaya;                
            }
            catch (Exception e)
            {
                ExcepcionDaoInventarioPlaya exDaoInventarioPlaya = new ExcepcionDaoInventarioPlaya(RecursosDao.CodigoErrorGeneral,
                                                      RecursosDao.ClaseDaoInventarioPlaya,
                                                      RecursosDao.MetodoConsultarInventarioTipo,
                                                      RecursosDao.MensajeErrorExcepcion,
                                                      e);
                Logger.EscribirEnLogger(exDaoInventarioPlaya);

                throw exDaoInventarioPlaya; 
            }
            finally
            {
                CerrarConexion();
            }
            return listaInventario;
        }

        /// <summary>
        /// Elimina el item seleccionado del inventario
        /// </summary>
        /// <param name="parametro">Id del inventario a eliminar</param>
        /// <returns>true en caso de exito; false en caso de error</returns>
        public bool EliminarItemSeleccionado(int parametro)
        {
            bool respuesta = false;            
            SqlDataReader lector;
            try
            {
                SqlCommand comando = new SqlCommand(RecursosDao.ProcedimientoEliminarInventario, IniciarConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter(RecursosDao.parametroInvId, parametro));

                IniciarConexion().Open();
                lector = comando.ExecuteReader();
                respuesta = true;
            }
            catch (NullReferenceException e)
            {
                ExcepcionDaoInventarioPlaya exDaoInventarioPlaya = new ExcepcionDaoInventarioPlaya(RecursosDao.CodigoErrorNullReference,
                                                      RecursosDao.ClaseDaoInventarioPlaya,
                                                      RecursosDao.MetodoEliminarItemSeleccionado,
                                                      RecursosDao.MensajeErrorExcepcion,
                                                      e);
                Logger.EscribirEnLogger(exDaoInventarioPlaya);

                throw exDaoInventarioPlaya;                
            }
            catch (SqlException e)
            {
                ExcepcionDaoInventarioPlaya exDaoInventarioPlaya = new ExcepcionDaoInventarioPlaya(RecursosDao.CodigoErrorSql,
                                                      RecursosDao.ClaseDaoInventarioPlaya,
                                                      RecursosDao.MetodoEliminarItemSeleccionado,
                                                      RecursosDao.MensajeErrorExcepcion,
                                                      e);
                Logger.EscribirEnLogger(exDaoInventarioPlaya);

                throw exDaoInventarioPlaya;                
            }
            catch (Exception e)
            {
                ExcepcionDaoInventarioPlaya exDaoInventarioPlaya = new ExcepcionDaoInventarioPlaya(RecursosDao.CodigoErrorGeneral,
                                                      RecursosDao.ClaseDaoInventarioPlaya,
                                                      RecursosDao.MetodoEliminarItemSeleccionado,
                                                      RecursosDao.MensajeErrorExcepcion,
                                                      e);
                Logger.EscribirEnLogger(exDaoInventarioPlaya);

                throw exDaoInventarioPlaya; 

            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;
        }

        /// <summary>
        /// se actualizan los datos de inventario en la bd
        /// </summary>
        /// <param name="parametro">Entidad que se va a modificar en la bd</param>
        /// <returns>true en caso de exito; false en caso de error</returns>
        public bool Modificar(Entidad parametro)
        {
            bool respuesta = false;
            SqlDataReader lector;            
                        
            try
            {
                InventarioPlaya inventario = parametro as InventarioPlaya;
                SqlCommand comando = new SqlCommand(RecursosDao.ProcedimientoActualizarInventario, IniciarConexion());
                comando.CommandType = CommandType.StoredProcedure;
                if (inventario.Id != 0)
                {
                    comando.Parameters.Add(new SqlParameter(RecursosDao.parametroInvId, inventario.Id));
                    comando.Parameters.Add(new SqlParameter(RecursosDao.parametroInvTipo, inventario.Tipo));
                    comando.Parameters.Add(new SqlParameter(RecursosDao.parametroInvPrecio, inventario.Precio));
                    comando.Parameters.Add(new SqlParameter(RecursosDao.parametroInvEstado, inventario.Estado));
                    comando.Parameters.Add(new SqlParameter(RecursosDao.parametroInvDescripcion, inventario.Descripcion));
                }
                else
                {
                    comando.Parameters.Add(new SqlParameter(RecursosDao.parametroInvId, DBNull.Value));
                    comando.Parameters.Add(new SqlParameter(RecursosDao.parametroInvTipo, inventario.Tipo));
                    comando.Parameters.Add(new SqlParameter(RecursosDao.parametroInvPrecio, inventario.Precio));
                    comando.Parameters.Add(new SqlParameter(RecursosDao.parametroInvEstado, DBNull.Value));
                    comando.Parameters.Add(new SqlParameter(RecursosDao.parametroInvDescripcion, DBNull.Value));
                }

                IniciarConexion().Open();
                lector = comando.ExecuteReader();
                respuesta = true;
            }
            catch (NullReferenceException e)
            {
                ExcepcionDaoInventarioPlaya exDaoInventarioPlaya = new ExcepcionDaoInventarioPlaya(RecursosDao.CodigoErrorNullReference,
                                                      RecursosDao.ClaseDaoInventarioPlaya,
                                                      RecursosDao.MetodoModificar,
                                                      RecursosDao.MensajeErrorExcepcion,
                                                      e);
                Logger.EscribirEnLogger(exDaoInventarioPlaya);

                throw exDaoInventarioPlaya; 
            }
            catch (SqlException e)
            {
                ExcepcionDaoInventarioPlaya exDaoInventarioPlaya = new ExcepcionDaoInventarioPlaya(RecursosDao.CodigoErrorSql,
                                                      RecursosDao.ClaseDaoInventarioPlaya,
                                                      RecursosDao.MetodoModificar,
                                                      RecursosDao.MensajeErrorExcepcion,
                                                      e);
                Logger.EscribirEnLogger(exDaoInventarioPlaya);

                throw exDaoInventarioPlaya; 
            }
            catch (Exception e)
            {
                ExcepcionDaoInventarioPlaya exDaoInventarioPlaya = new ExcepcionDaoInventarioPlaya(RecursosDao.CodigoErrorGeneral,
                                                      RecursosDao.ClaseDaoInventarioPlaya,
                                                      RecursosDao.MetodoModificar,
                                                      RecursosDao.MensajeErrorExcepcion,
                                                      e);
                Logger.EscribirEnLogger(exDaoInventarioPlaya);

                throw exDaoInventarioPlaya; 
            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;
        }

        /// <summary>
        /// Realiza la consulta de el inventario deseado
        /// </summary>
        /// <param name="parametro">ID de inventario a consultar</param>
        /// <returns>El inventario requerido</returns>
        public Entidad ConsultarXId(int id)
        {
            Entidad Inventario = null;
            SqlDataReader lector;
            try
            {
                SqlCommand comando = new SqlCommand(RecursosDao.procedimientoConsultarInventarioTipo, IniciarConexion());

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter(RecursosDao.parametroInvId, id));
                comando.Parameters.Add(new SqlParameter(RecursosDao.parametroInvTipo, DBNull.Value));
                comando.Parameters.Add(new SqlParameter(RecursosDao.parametroInvEstado, DBNull.Value));

                IniciarConexion().Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Inventario = AsignarInventario(lector);
                }
                
            }
            catch (NullReferenceException e)
            {
                ExcepcionDaoInventarioPlaya exDaoInventarioPlaya = new ExcepcionDaoInventarioPlaya(RecursosDao.CodigoErrorNullReference,
                                                      RecursosDao.ClaseDaoInventarioPlaya,
                                                      RecursosDao.MetodoConsultarXId,
                                                      RecursosDao.MensajeErrorExcepcion,
                                                      e);
                Logger.EscribirEnLogger(exDaoInventarioPlaya);

                throw exDaoInventarioPlaya; 
            }
            catch (SqlException e)
            {
                ExcepcionDaoInventarioPlaya exDaoInventarioPlaya = new ExcepcionDaoInventarioPlaya(RecursosDao.CodigoErrorSql,
                                                      RecursosDao.ClaseDaoInventarioPlaya,
                                                      RecursosDao.MetodoConsultarXId,
                                                      RecursosDao.MensajeErrorExcepcion,
                                                      e);
                Logger.EscribirEnLogger(exDaoInventarioPlaya);

                throw exDaoInventarioPlaya; 
            }
            catch (Exception e)
            {
                ExcepcionDaoInventarioPlaya exDaoInventarioPlaya = new ExcepcionDaoInventarioPlaya(RecursosDao.CodigoErrorGeneral,
                                                      RecursosDao.ClaseDaoInventarioPlaya,
                                                      RecursosDao.MetodoConsultarXId,
                                                      RecursosDao.MensajeErrorExcepcion,
                                                      e);
                Logger.EscribirEnLogger(exDaoInventarioPlaya);

                throw exDaoInventarioPlaya; 
            }
            finally
            {
                CerrarConexion();
            }
            return Inventario;
        }                    

        public List<Entidad> ConsultarEstadosInventario()
        {
            List<Entidad> listaEstados = new List<Entidad>();

            try
            {
                SqlCommand comando = new SqlCommand(RecursosDao.ProcedimientoConsultarEstadosInv, IniciarConexion());

                comando.CommandType = CommandType.StoredProcedure;                

                SqlDataReader lector;

                IniciarConexion().Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Entidad estados = AsignarEstados(lector);
                    if (estados != null)
                    {
                        listaEstados.Add(estados);
                    }
                }
            }
            catch (NullReferenceException e)
            {
                ExcepcionDaoInventarioPlaya exDaoInventarioPlaya = new ExcepcionDaoInventarioPlaya(RecursosDao.CodigoErrorNullReference,
                                                      RecursosDao.ClaseDaoInventarioPlaya,
                                                      RecursosDao.MetodoConsultarEstadosInventario,
                                                      RecursosDao.MensajeErrorExcepcion,
                                                      e);
                Logger.EscribirEnLogger(exDaoInventarioPlaya);

                throw exDaoInventarioPlaya;                 
            }
            catch (SqlException e)
            {
                ExcepcionDaoInventarioPlaya exDaoInventarioPlaya = new ExcepcionDaoInventarioPlaya(RecursosDao.CodigoErrorSql,
                                                      RecursosDao.ClaseDaoInventarioPlaya,
                                                      RecursosDao.MetodoConsultarEstadosInventario,
                                                      RecursosDao.MensajeErrorExcepcion,
                                                      e);
                Logger.EscribirEnLogger(exDaoInventarioPlaya);

                throw exDaoInventarioPlaya;  
            }
            catch (Exception e)
            {
                ExcepcionDaoInventarioPlaya exDaoInventarioPlaya = new ExcepcionDaoInventarioPlaya(RecursosDao.CodigoErrorGeneral,
                                                      RecursosDao.ClaseDaoInventarioPlaya,
                                                      RecursosDao.MetodoConsultarEstadosInventario,
                                                      RecursosDao.MensajeErrorExcepcion,
                                                      e);
                Logger.EscribirEnLogger(exDaoInventarioPlaya);

                throw exDaoInventarioPlaya;
                
            }
            finally
            {
                CerrarConexion();
            }
            return listaEstados;
        }

        /// <summary>
        /// Asignación del objeto de la BD a un objeto tipo Entidad
        /// según las posiciones de cada columna especificacda en la consulta
        /// </summary>
        /// <param name="objeto">Objeto leído de la BD tipo SqlDataReader</param>
        /// <returns>Retorna el objeto Entidad</returns>
        private Entidad AsignarInventario(SqlDataReader objeto)
        {
            Entidad itemInventario = FabricaEntidad.ObtenerInventarioPlaya(objeto.GetInt32(0),
                                                                       (float)objeto.GetSqlDouble(2),
                                                                       objeto.GetString(5),
                                                                       objeto.GetString(1),
                                                                       objeto.GetString(4));
            return itemInventario;
        }

        /// <summary>
        /// Asignación del objeto de la BD a un objeto tipo Entidad
        /// según las posiciones de cada columna especificacda en la consulta
        /// </summary>
        /// <param name="objeto">Objeto leído de la BD tipo SqlDataReader</param>
        /// <returns>Retorna el objeto Entidad</returns>
        private Entidad AsignarEstados(SqlDataReader objeto)
        {
            Entidad itemEstado = FabricaEntidad.ObtenerEstado(objeto.GetInt32(0),objeto.GetString(1));
            return itemEstado;
        }


        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }


    }
}