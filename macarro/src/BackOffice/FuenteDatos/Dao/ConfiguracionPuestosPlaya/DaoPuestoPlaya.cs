using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.FuenteDatos.IDao.ConfiguracionPuestosPlaya;
using System.Data.SqlClient;
using System.Data;
using BackOffice.Dominio;
using BackOffice.Dominio.Fabrica;
using BackOffice.Dominio.Entidades;
using BackOffice.Excepciones.ExcepcionesDao.ConfiguracionPuestosPlaya;

namespace BackOffice.FuenteDatos.Dao.ConfiguracionPuestosPlaya
{
    public class DaoPuestoPlaya: Dao,IDaoPuestoPlaya
    {

        #region metodos consultar puesto

        /// <summary>
        /// Metodo que crea un objeto de tipo de dato puesto
        /// </summary>
        /// <param name="dr">Es un registro en donde estan contenido los valores de fila,columna,precio y descripcion</param>
        /// <returns>Un Objeto de tipo puesto</returns>
        public Entidad  CrearPuesto(DataRow dr)
        {
            Entidad _puesto= null;

            try
            {
                 _puesto = FabricaEntidad.ObtenerPuestoPlaya(int.Parse(dr[RecursosDao.fila].ToString()),
                                                                    int.Parse(dr[RecursosDao.columna].ToString()),
                                                                    dr[RecursosDao.descripcion].ToString(),
                                                                    float.Parse(dr[RecursosDao.precio].ToString()));
               
                
             }
            catch (NullReferenceException e)
            {

                throw new ExcepcionDaoPuestoPlaya(   RecursosDao.CodigoErrorNullReference,
                                                     RecursosDao.ClaseDaoPuestoPlaya,
                                                     RecursosDao.MetodoCrearPuesto,
                                                     RecursosDao.MensajeErrorExcepcion,
                                                     e);
            }
            catch (Exception e)
            {
                throw new ExcepcionDaoPuestoPlaya(RecursosDao.CodigoErrorGeneral,
                                                      RecursosDao.ClaseDaoPuestoPlaya,
                                                      RecursosDao.MetodoCrearPuesto,
                                                      RecursosDao.MensajeErrorExcepcion,
                                                      e);
            }
            return _puesto;
        }


        /// <summary>
        /// Metodo que crea un arreglo de objetos de tipo puesto
        /// </summary>
        /// <param name="drc">Es un registro en donde estan contenido los valores de fila,columna,descripcion,precio</param>
        /// <returns>Una lista de objetos de tipo Puesto</returns>
        public List<Entidad> CrearArregloPuesto(DataRowCollection drc)
        {
            List<Entidad> _listaPuesto = null;
            try
            {
                _listaPuesto = new List<Entidad>();

                foreach (DataRow row in drc)
                {
                    _listaPuesto.Add(CrearPuesto(row));
                }

            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionDaoPuestoPlaya(RecursosDao.CodigoErrorNullReference,
                                                         RecursosDao.ClaseDaoPuestoPlaya,
                                                         RecursosDao.MetodoCrearArregloPuesto,
                                                         RecursosDao.MensajeErrorExcepcion,
                                                         e);
            }
            catch (Exception e)
            {
                throw new ExcepcionDaoPuestoPlaya(RecursosDao.CodigoErrorGeneral,
                                                        RecursosDao.ClaseDaoPuestoPlaya,
                                                        RecursosDao.MetodoCrearArregloPuesto,
                                                        RecursosDao.MensajeErrorExcepcion,
                                                        e);
            }
            return _listaPuesto;
        }





        /// <summary>
        /// Metodo que realiza la busqueda de los puesto por fila,columna  bien sea activo o inactivo.
        /// </summary>
        /// <param name="estado">Si es true=activado y false=desactivado</param>
        /// <returns>Un arreglo de objetos de tipo Puesto</returns>
        public List<Entidad> ConsultarPuesto(string filar, string columnaR)
        {

            int _filaI = 0;
            int _columnaI = 0;


            List<Entidad> _arregloPuesto = null;
            try
            {
                SqlDataAdapter _datos = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(RecursosDao._funcionConsultarPuesto, IniciarConexion());

                if (filar.Equals(string.Empty))
                {
                    command.Parameters.Add(new SqlParameter(RecursosDao._filaparametro, SqlDbType.Int)).Value = DBNull.Value;
                }
                else
                {
                    _filaI = int.Parse(filar);
                    command.Parameters.Add(new SqlParameter(RecursosDao._filaparametro, SqlDbType.Int)).Value = _filaI;
                }

                if (columnaR.Equals(string.Empty))
                {
                    command.Parameters.Add(new SqlParameter(RecursosDao._columnaparametro, SqlDbType.Int)).Value = DBNull.Value;
                }
                else
                {
                    _columnaI = int.Parse(columnaR);
                    command.Parameters.Add(new SqlParameter(RecursosDao._columnaparametro, SqlDbType.Int)).Value = _columnaI;

                }
                command.Parameters.Add(new SqlParameter(RecursosDao._Estadoparametro, SqlDbType.VarChar)).Value = RecursosDao._estado;


                _datos.SelectCommand = command;
                _datos.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet dt = new DataSet();
                _datos.Fill(dt, RecursosDao._Resultado);

                _arregloPuesto = CrearArregloPuesto(dt.Tables[RecursosDao._Resultado].Rows);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDaoPuestoPlaya(RecursosDao.CodigoErrorSql,
                                                            RecursosDao.ClaseDaoPuestoPlaya,
                                                            RecursosDao.MetodoConsultarPuesto,
                                                            RecursosDao.MensajeErrorExcepcion,
                                                            e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionDaoPuestoPlaya(RecursosDao.CodigoErrorNullReference,
                                                           RecursosDao.ClaseDaoPuestoPlaya,
                                                           RecursosDao.MetodoConsultarPuesto,
                                                           RecursosDao.MensajeErrorExcepcion,
                                                           e);
            }
            catch (Exception e)
            {
                throw new ExcepcionDaoPuestoPlaya(RecursosDao.CodigoErrorGeneral,
                                                          RecursosDao.ClaseDaoPuestoPlaya,
                                                          RecursosDao.MetodoConsultarPuesto,
                                                          RecursosDao.MensajeErrorExcepcion,
                                                          e);
            }

            return _arregloPuesto;

        }


        /// <summary>
        /// Toma los datos de puesto y los actualizo en bd
        /// </summary>
        /// <param name="configuracion">configuracion a actualizar dentro de la base dedatos</param>
        /// <returns>true en caso de exito; false en caso de error</returns>
        public bool ActualizacionPuesto(string fila, string columna, string descripcion, string monto, string estado)
        {
            bool respuesta;
            respuesta = false;

            SqlCommand comando = new SqlCommand(RecursosDao.ProcedimientoActualizarPuesto, IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;

            if (fila.Equals(string.Empty))
            {
                comando.Parameters.Add(new SqlParameter(RecursosDao._filaparametro, DBNull.Value));
            }
            else
            {
                comando.Parameters.Add(new SqlParameter(RecursosDao._filaparametro, int.Parse(fila)));
            }
            if (columna.Equals(string.Empty))
            {
                comando.Parameters.Add(new SqlParameter(RecursosDao._columnaparametro, DBNull.Value));
            }
            else
            {
                comando.Parameters.Add(new SqlParameter(RecursosDao._columnaparametro, int.Parse(columna)));
            }


            if (descripcion.Equals(string.Empty))
                comando.Parameters.Add(new SqlParameter(RecursosDao.descripcionPar, DBNull.Value));

            else
                comando.Parameters.Add(new SqlParameter(RecursosDao.descripcionPar, descripcion));

            if (monto.Equals(string.Empty))
                comando.Parameters.Add(new SqlParameter(RecursosDao.precioPar, DBNull.Value));
            else
                comando.Parameters.Add(new SqlParameter(RecursosDao.precioPar, float.Parse(monto)));

            if (estado.Equals(string.Empty))
                comando.Parameters.Add(new SqlParameter(RecursosDao.estadoPar, DBNull.Value));
            else
                comando.Parameters.Add(new SqlParameter(RecursosDao.estadoPar, estado));


            SqlDataReader lector;
            try
            {
                IniciarConexion().Open();
                lector = comando.ExecuteReader();
                respuesta = true;
            }
            catch (SqlException e)
            {
                throw new ExcepcionDaoPuestoPlaya(RecursosDao.CodigoErrorSql,
                                                             RecursosDao.ClaseDaoPuestoPlaya,
                                                             RecursosDao.MetodoActualizacionPuesto,
                                                             RecursosDao.MensajeErrorExcepcion,
                                                             e);
            }
            catch (NullReferenceException e)
            {
                throw new ExcepcionDaoPuestoPlaya(RecursosDao.CodigoErrorNullReference,
                                                             RecursosDao.ClaseDaoPuestoPlaya,
                                                             RecursosDao.MetodoActualizacionPuesto,
                                                             RecursosDao.MensajeErrorExcepcion,
                                                             e);
            }
            catch (Exception e)
            {
                throw new ExcepcionDaoPuestoPlaya(RecursosDao.CodigoErrorGeneral,
                                                            RecursosDao.ClaseDaoPuestoPlaya,
                                                            RecursosDao.MetodoActualizacionPuesto,
                                                            RecursosDao.MensajeErrorExcepcion,
                                                            e);
            }
            finally
            {
               CerrarConexion();
            }
            return respuesta;
        }

        public bool Agregar(Entidad parametro) {
            throw new NotImplementedException();
        }

        public bool Modificar(Entidad parametro){
              throw new NotImplementedException();
        }
        public Entidad ConsultarXId(int id) {

            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos() 
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}