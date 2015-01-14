using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.FuenteDatos.IDao.ConfiguracionServiciosPlaya;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BackOffice.Excepciones.ExcepcionesDao.ConfiguracionServiciosPlaya;
using BackOffice.Excepciones;

namespace BackOffice.FuenteDatos.Dao.ConfiguracionServiciosPlaya
{
    public class DaoServiciosPlaya : Dao, IDaoServiciosPlaya
    {
        /// <summary>
        /// Trae de la BD todos los datos del servicio
        /// </summary>
        /// <param name="parametro">nombre del servicio a consultar</param>
        /// <returns>El servicio completo</returns>
        public Entidad ConsultarServicioCompleto(string parametro)
        {
            Entidad _servicio = null;
            SqlDataReader _lector;
            int _idServicio = 0;
            
            try
            {
                SqlCommand _comando = new SqlCommand(RecursosDaoServiciosPlaya.ProcedimientoObtenerDatosServicio, IniciarConexion());
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter(RecursosDaoServiciosPlaya.ParametroNombreServicio, parametro));

                IniciarConexion().Open();
                _lector = _comando.ExecuteReader();

                while (_lector.Read())
                {
                    _servicio = LlenarServicio(_lector);
                    _idServicio = (int)_lector[RecursosDaoServiciosPlaya.LectorSER_id];
                                       
                }
                _lector.Close();

                _servicio = obtenerHorarios(_servicio, _idServicio);
            }
            catch (NullReferenceException e)
            {
                ExcepcionDaoServiciosPlaya exDaoServiciosPlaya = new ExcepcionDaoServiciosPlaya(RecursosExcepcionDaoServiciosPlaya.codigoErrorNullReference,
                                                                                                RecursosExcepcionDaoServiciosPlaya.claseDaoServiciosPlaya,
                                                                                                RecursosExcepcionDaoServiciosPlaya.metodoConsultarServicios,
                                                                                                RecursosExcepcionDaoServiciosPlaya.mensajeNullReference, e);
                Logger.EscribirEnLogger(exDaoServiciosPlaya);
                throw exDaoServiciosPlaya;
            }

            catch (SqlException e)
            {
                ExcepcionDaoServiciosPlaya exDaoServiciosPlaya = new ExcepcionDaoServiciosPlaya(RecursosExcepcionDaoServiciosPlaya.codigoErrorSql,
                                                                                                RecursosExcepcionDaoServiciosPlaya.claseDaoServiciosPlaya,
                                                                                                RecursosExcepcionDaoServiciosPlaya.metodoConsultarServicios,
                                                                                                RecursosExcepcionDaoServiciosPlaya.mensajeSql, e);
                Logger.EscribirEnLogger(exDaoServiciosPlaya);
                throw exDaoServiciosPlaya;
            }
            catch (Exception e)
            {
                ExcepcionDaoServiciosPlaya exDaoServiciosPlaya = new ExcepcionDaoServiciosPlaya(RecursosExcepcionDaoServiciosPlaya.codigoErrorGeneral,
                                                                                                RecursosExcepcionDaoServiciosPlaya.claseDaoServiciosPlaya,
                                                                                                RecursosExcepcionDaoServiciosPlaya.metodoConsultarServicios,
                                                                                                RecursosExcepcionDaoServiciosPlaya.mensajeGeneral, e);
                Logger.EscribirEnLogger(exDaoServiciosPlaya);
                throw exDaoServiciosPlaya;
            }

            finally
            {
                CerrarConexion();
            }

            return _servicio;
        }

        /// <summary>
        /// Se crea el servicio con los datos traidos de la BD
        /// </summary>
        /// <param name="objeto">Es la secuencia de filas de los datos traidos de la BD</param>
        /// <returns> El servicio pero sin la lista de horarios</returns>
        private Entidad LlenarServicio(SqlDataReader objeto)
        {
            Entidad _servicio = null;

            _servicio = FabricaEntidad.ObtenerServicio((string)objeto[RecursosDaoServiciosPlaya.LectorSER_nombre], (string)objeto[RecursosDaoServiciosPlaya.LectorSER_descripcion],
                (int)objeto[RecursosDaoServiciosPlaya.LectorSER_capacidad], (int)objeto[RecursosDaoServiciosPlaya.LectorSER_cantidadDis], float.Parse(objeto[RecursosDaoServiciosPlaya.LectorSER_costo].ToString()),
                (string)objeto[RecursosDaoServiciosPlaya.LectorCAT_nombre], (string)objeto[RecursosDaoServiciosPlaya.LectorSER_retiro], (string)objeto[RecursosDaoServiciosPlaya.LectorEST_nombre], null);
            
            return _servicio;
        }
        
        /// <summary>
        /// Trae de la BD los horarios asociados al servicio para luego agregarlos al servicio
        /// </summary>
        /// <param name="_servicio">el servicio creado</param>
        /// <param name="_idServicio">id del servicio</param>
        /// <returns>El servicio completo</returns>
        public Entidad obtenerHorarios(Entidad _servicio, int _idServicio)
        {
            Horario _horarioItem = null;
            SqlDataReader _lector;
            Servicio _elServicio = _servicio as Servicio;
            Entidad _servicioNuevo = null;
            List<Horario> _lista = new List<Horario>();

            try
            {
                SqlCommand _comando = new SqlCommand(RecursosDaoServiciosPlaya.ProcedimientoConsultarHorariosServicioId, IniciarConexion());
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter(RecursosDaoServiciosPlaya.ParametroIdServicio, _idServicio));
                _lector = _comando.ExecuteReader();

                while (_lector.Read())
                {
                    _horarioItem = new Horario(DateTime.Parse(_lector[RecursosDaoServiciosPlaya.LectorHOR_inicio].ToString()),
                        DateTime.Parse(_lector[RecursosDaoServiciosPlaya.LectorHOR_fin].ToString()));

                    _lista.Add(_horarioItem);

                }
                _servicioNuevo = FabricaEntidad.ObtenerServicio(_elServicio.Nombre, _elServicio.Descripcion, _elServicio.Capacidad,
                        _elServicio.Cantidad, _elServicio.Costo, _elServicio.Categoria, _elServicio.LugarRetiro, _elServicio.Estado,
                        _lista);

                _lector.Close();
            }
            catch (NullReferenceException e)
            {
                ExcepcionDaoServiciosPlaya exDaoServiciosPlaya = new ExcepcionDaoServiciosPlaya(RecursosExcepcionDaoServiciosPlaya.codigoErrorNullReference,
                                                                                                RecursosExcepcionDaoServiciosPlaya.claseDaoServiciosPlaya,
                                                                                                RecursosExcepcionDaoServiciosPlaya.metodoConsultarServicios,
                                                                                                RecursosExcepcionDaoServiciosPlaya.mensajeNullReference, e);
                Logger.EscribirEnLogger(exDaoServiciosPlaya);
                throw exDaoServiciosPlaya;
            }

            catch (SqlException e)
            {
                ExcepcionDaoServiciosPlaya exDaoServiciosPlaya = new ExcepcionDaoServiciosPlaya(RecursosExcepcionDaoServiciosPlaya.codigoErrorSql,
                                                                                                RecursosExcepcionDaoServiciosPlaya.claseDaoServiciosPlaya,
                                                                                                RecursosExcepcionDaoServiciosPlaya.metodoConsultarServicios,
                                                                                                RecursosExcepcionDaoServiciosPlaya.mensajeSql, e);
                Logger.EscribirEnLogger(exDaoServiciosPlaya);
                throw exDaoServiciosPlaya;
            }
            catch (Exception e)
            {
                ExcepcionDaoServiciosPlaya exDaoServiciosPlaya = new ExcepcionDaoServiciosPlaya(RecursosExcepcionDaoServiciosPlaya.codigoErrorGeneral,
                                                                                                RecursosExcepcionDaoServiciosPlaya.claseDaoServiciosPlaya,
                                                                                                RecursosExcepcionDaoServiciosPlaya.metodoConsultarServicios,
                                                                                                RecursosExcepcionDaoServiciosPlaya.mensajeGeneral, e);
                Logger.EscribirEnLogger(exDaoServiciosPlaya);
                throw exDaoServiciosPlaya;
            }

            finally
            {
                CerrarConexion();
            }

            return _servicioNuevo;
        }

        /// <summary>
        /// Consulta los servicios por estado, nombre o descripcion del servicio
        /// </summary>
        /// <param name="parametro">Entidad, que a su vez es un servicio</param>
        /// <returns>Una lista de entidades</returns>
        public List<Entidad> ConsultarServicios(Entidad parametro)
        {

            string _procedimiento = "Procedure_buscarServicio";
            List<Entidad> listaServicio = new List<Entidad>();
            Servicio _ser = parametro as Servicio;

            try
            {
                SqlCommand comando = new SqlCommand(_procedimiento, IniciarConexion());

                comando.CommandType = CommandType.StoredProcedure;
                SqlParameter parametro1 = new SqlParameter("@_busqueda", _ser.Nombre);
                SqlParameter parametro2 = new SqlParameter("@_estado", _ser.Estado);
                comando.Parameters.Add(parametro1);
                comando.Parameters.Add(parametro2);

                SqlDataReader lector;

                IniciarConexion().Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Entidad _servicio = TransformaServicio(lector);
                    if (_servicio != null)
                    {
                        listaServicio.Add(_servicio);
                    }
                }
            }
            catch (NullReferenceException e)
            {
                ExcepcionDaoServiciosPlaya exDaoServiciosPlaya = new ExcepcionDaoServiciosPlaya(RecursosExcepcionDaoServiciosPlaya.codigoErrorNullReference,
                                                                                                RecursosExcepcionDaoServiciosPlaya.claseDaoServiciosPlaya,
                                                                                                RecursosExcepcionDaoServiciosPlaya.metodoConsultarServicios,
                                                                                                RecursosExcepcionDaoServiciosPlaya.mensajeNullReference, e);
                Logger.EscribirEnLogger(exDaoServiciosPlaya);
                throw exDaoServiciosPlaya;
            }

            catch (SqlException e)
            {
                ExcepcionDaoServiciosPlaya exDaoServiciosPlaya = new ExcepcionDaoServiciosPlaya(RecursosExcepcionDaoServiciosPlaya.codigoErrorSql,
                                                                                                RecursosExcepcionDaoServiciosPlaya.claseDaoServiciosPlaya,
                                                                                                RecursosExcepcionDaoServiciosPlaya.metodoConsultarServicios,
                                                                                                RecursosExcepcionDaoServiciosPlaya.mensajeSql, e);
                Logger.EscribirEnLogger(exDaoServiciosPlaya);
                throw exDaoServiciosPlaya;
            }
            catch (Exception e)
            {
                ExcepcionDaoServiciosPlaya exDaoServiciosPlaya = new ExcepcionDaoServiciosPlaya(RecursosExcepcionDaoServiciosPlaya.codigoErrorGeneral,
                                                                                                RecursosExcepcionDaoServiciosPlaya.claseDaoServiciosPlaya,
                                                                                                RecursosExcepcionDaoServiciosPlaya.metodoConsultarServicios,
                                                                                                RecursosExcepcionDaoServiciosPlaya.mensajeGeneral, e);
                Logger.EscribirEnLogger(exDaoServiciosPlaya);
                throw exDaoServiciosPlaya;
            }

            finally
            {
                CerrarConexion();
            }

            return listaServicio;
        }

        /// <summary>
        /// Elimina logicamente los servicios en la BD
        /// </summary>
        /// <param name="parametro">El nombre del servicio</param>
        /// <returns>True o false dependiendo de si realizo la operacion o no</returns>
        public bool EliminarServicioPlaya(string parametro)
        {

            string _procedimiento = "Procedure_eliminarServicio";
            bool _respuesta = false;

            try
            {
                SqlCommand comando = new SqlCommand(_procedimiento, IniciarConexion());

                comando.CommandType = CommandType.StoredProcedure;
                SqlParameter parametro1 = new SqlParameter("@_nombreServicio", parametro);
                comando.Parameters.Add(parametro1);

                SqlDataReader lector;

                IniciarConexion().Open();
                lector = comando.ExecuteReader();
                _respuesta = true;

            }

            catch (NullReferenceException e)
            {
                ExcepcionDaoServiciosPlaya exDaoServiciosPlaya = new ExcepcionDaoServiciosPlaya(RecursosExcepcionDaoServiciosPlaya.codigoErrorNullReference,
                                                                                                RecursosExcepcionDaoServiciosPlaya.claseDaoServiciosPlaya,
                                                                                                RecursosExcepcionDaoServiciosPlaya.metodoEliminarServicioPlaya,
                                                                                                RecursosExcepcionDaoServiciosPlaya.mensajeNullReference, e);
                Logger.EscribirEnLogger(exDaoServiciosPlaya);
                throw exDaoServiciosPlaya;
            }

            catch (SqlException e)
            {
                ExcepcionDaoServiciosPlaya exDaoServiciosPlaya = new ExcepcionDaoServiciosPlaya(RecursosExcepcionDaoServiciosPlaya.codigoErrorSql,
                                                                                                RecursosExcepcionDaoServiciosPlaya.claseDaoServiciosPlaya,
                                                                                                RecursosExcepcionDaoServiciosPlaya.metodoEliminarServicioPlaya,
                                                                                                RecursosExcepcionDaoServiciosPlaya.mensajeSql, e);
                Logger.EscribirEnLogger(exDaoServiciosPlaya);
                throw exDaoServiciosPlaya;
            }
            catch (Exception e)
            {
                ExcepcionDaoServiciosPlaya exDaoServiciosPlaya = new ExcepcionDaoServiciosPlaya(RecursosExcepcionDaoServiciosPlaya.codigoErrorGeneral,
                                                                                                RecursosExcepcionDaoServiciosPlaya.claseDaoServiciosPlaya,
                                                                                                RecursosExcepcionDaoServiciosPlaya.metodoEliminarServicioPlaya,
                                                                                                RecursosExcepcionDaoServiciosPlaya.mensajeGeneral, e);
                Logger.EscribirEnLogger(exDaoServiciosPlaya);
                throw exDaoServiciosPlaya;
            }

            finally
            {
                CerrarConexion();
            }

            return _respuesta;
        }

        /// <summary>
        /// Transforma los obejtos de la BD en servicios, para luego ser agregados a la lista de servicios
        /// </summary>
        /// <param name="objeto">Un objeto traeido de la BD</param>
        /// <returns>Una entidad, que a su vez es un servicio</returns>
        private Entidad TransformaServicio(SqlDataReader objeto)
        {
            try
            {
                Entidad _servicio = FabricaEntidad.ObtenerServicio(objeto.GetString(0), objeto.GetString(1), objeto.GetString(2));
                return _servicio;
            }
            catch (NullReferenceException e)
            {
                ExcepcionDaoServiciosPlaya exDaoServiciosPlaya = new ExcepcionDaoServiciosPlaya(RecursosExcepcionDaoServiciosPlaya.codigoErrorNullReference,
                                                                                                RecursosExcepcionDaoServiciosPlaya.claseDaoServiciosPlaya,
                                                                                                RecursosExcepcionDaoServiciosPlaya.metodoTransformaServicio,
                                                                                                RecursosExcepcionDaoServiciosPlaya.mensajeNullReference, e);
                Logger.EscribirEnLogger(exDaoServiciosPlaya);
                throw exDaoServiciosPlaya;
            }
            catch (Exception e)
            {
                ExcepcionDaoServiciosPlaya exDaoServiciosPlaya = new ExcepcionDaoServiciosPlaya(RecursosExcepcionDaoServiciosPlaya.codigoErrorGeneral,
                                                                                                RecursosExcepcionDaoServiciosPlaya.claseDaoServiciosPlaya,
                                                                                                RecursosExcepcionDaoServiciosPlaya.metodoTransformaServicio,
                                                                                                RecursosExcepcionDaoServiciosPlaya.mensajeGeneral, e);
                Logger.EscribirEnLogger(exDaoServiciosPlaya);
                throw exDaoServiciosPlaya;
            }
        }

        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public Entidad ConsultarXId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
    }
}