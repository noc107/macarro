using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.FuenteDatos.IDao.ReportesFinancierosExportacion;
using System.Data;
using System.Data.SqlClient;
using BackOffice.Excepciones.ExcepcionesDao.ReportesFinancierosExportacion;

namespace BackOffice.FuenteDatos.Dao.ReportesFinancierosExportacion
{
    public class DaoReportesFinancierosExportacion : Dao, IDaoReportesFinancierosExportacion
    {
        /// <summary>
        /// El metodo GetDatosActivos extrae de la BD a travez de un query
        /// el numero de usuarios estan activos y usuarios inactivos. 
        /// </summary>
        /// <returns>
        /// El metodo regresa un DataTable con los datos necesarios para realizar
        /// el reporte.
        /// </returns>
        public DataTable GetDatosActivos()
        {
            DataTable _tablaDatos = new DataTable();
            SqlDataAdapter _adaptadorSql = new SqlDataAdapter();
            SqlCommand _comandoSql;
            try
            {
                _comandoSql = new SqlCommand("ReporteUsuarioActivoInactivo", IniciarConexion());
                _comandoSql.CommandType = CommandType.StoredProcedure;
                _adaptadorSql.SelectCommand = _comandoSql;
                _adaptadorSql.Fill(_tablaDatos);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoSqlException,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosActivos,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorSql, e);
            }

            catch (Exception ex)
            {

                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoErrorGeneral,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosActivos,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorGeneral, ex);
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */
            }
            finally
            {
                CerrarConexion();
            }
            return _tablaDatos;
        }
        /// <summary>
        /// El metodo GetDatosRoles extrae de la BD a travez de un query
        /// el nombre de los diferentes roles y la cantidad de usuarios 
        /// del sistema que tienes asignado dicho rol.
        /// </summary>
        /// <returns>
        /// El metodo regresa un DataTable con los datos necesarios para realizar
        /// el reporte.
        /// </returns>
        public DataTable GetDatosRoles()
        {
            DataTable _tablaDatos = new DataTable();
            SqlDataAdapter _adaptadorSql = new SqlDataAdapter();
            SqlCommand _comandoSql;
            try
            {
                _comandoSql = new SqlCommand("ReporteRolesCantidadUsuariosAsignadosAlRol", IniciarConexion());
                _comandoSql.CommandType = CommandType.StoredProcedure;
                _adaptadorSql.SelectCommand = _comandoSql;
                _adaptadorSql.Fill(_tablaDatos);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoSqlException,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosRoles,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorSql, e);
            }

            catch (Exception ex)
            {

                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoErrorGeneral,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosRoles,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorGeneral, ex);
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */
            }
            finally
            {
                CerrarConexion();
            }
            return _tablaDatos;
        }
        /// <summary>
        /// El metodo GetDatosProveedores extrae de la BD a travez de un query
        /// la identificacion de los proveedores junto con cuales item 
        /// han vendido al negocio y la cantidad.
        /// </summary>
        /// <returns>
        /// El metodo regresa un DataTable con los datos necesarios para realizar
        /// el reporte.
        /// </returns>
        public DataTable GetDatosProveedores()
        {
            DataTable _tablaDatos = new DataTable();
            SqlDataAdapter _adaptadorSql = new SqlDataAdapter();
            SqlCommand _comandoSql;
            try
            {
                _comandoSql = new SqlCommand("ReporteProveedorItemsVendidosYCantidad", IniciarConexion());
                _comandoSql.CommandType = CommandType.StoredProcedure;
                _adaptadorSql.SelectCommand = _comandoSql;
                _adaptadorSql.Fill(_tablaDatos);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoSqlException,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosProveedores,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorSql, e);
            }

            catch (Exception ex)
            {

                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoErrorGeneral,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosProveedores,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorGeneral, ex);
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */
            }
            finally
            {
                CerrarConexion();
            }
            return _tablaDatos;
        }
        /// <summary>
        /// El metodo GetDatosProducto extrae de la BD a travez de un query
        /// la identificacion de los productos junto con su cantidad actual y 
        /// cantidad minima.
        /// </summary>
        /// <returns>
        /// El metodo regresa un DataTable con los datos necesarios para realizar
        /// el reporte.
        /// </returns>
        public DataTable GetDatosProductos()
        {
            DataTable _tablaDatos = new DataTable();
            SqlDataAdapter _adaptadorSql = new SqlDataAdapter();
            SqlCommand _comandoSql;
            try
            {
                _comandoSql = new SqlCommand("ReporteProductoCantidadActualYMinima", IniciarConexion());
                _comandoSql.CommandType = CommandType.StoredProcedure;
                _adaptadorSql.SelectCommand = _comandoSql;
                _adaptadorSql.Fill(_tablaDatos);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoSqlException,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosProductos,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorSql, e);
            }

            catch (Exception ex)
            {

                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoErrorGeneral,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosProductos,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorGeneral, ex);
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */
            }
            finally
            {
                CerrarConexion();
            }
            return _tablaDatos;
        }
        /// <summary>
        /// El metodo GetDatosIngresosMembresia extrae de la BD a travez de un query 
        /// los ingresos obtenidos por las membresias y 
        /// la fecha en la cual fueron generados, dentro de un periodo
        /// de tiempo establecido.
        /// </summary>
        /// <param name="_fechaini">
        /// Este atributo es la fecha inicial de donde comenzara la busqueda, 
        /// es establecido por el usuario.
        /// </param>
        /// <param name="_fechafin">
        /// Este atributo es la fecha final hasta donde llegara la busqueda,
        /// es establecido por el usuario.
        /// </param>
        /// <returns>
        /// El metodo regresa un DataTable con los datos necesarios para realizar
        /// el reporte.
        /// </returns>
        public DataTable GetDatosIngresosMembresia(string _fechaini, string _fechafin)
        {
            DataTable _tablaDatos = new DataTable();
            SqlDataAdapter _adaptadorSql = new SqlDataAdapter();
            SqlCommand _comandoSql;
            try
            {
                _comandoSql = new SqlCommand("ReporteIngresosPorMembresiaConFecha", IniciarConexion());
                _comandoSql.Parameters.Add(new SqlParameter("@_fechaini", _fechaini));
                _comandoSql.Parameters.Add(new SqlParameter("@_fechafin", _fechafin));
                _comandoSql.CommandType = CommandType.StoredProcedure;
                _adaptadorSql.SelectCommand = _comandoSql;
                _adaptadorSql.Fill(_tablaDatos);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoSqlException,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosIngresosMembresia,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorSql, e);
            }

            catch (Exception ex)
            {

                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoErrorGeneral,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosIngresosMembresia,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorGeneral, ex);
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */
            }
            return _tablaDatos;
        }
        /// <summary>
        /// El metodo GetDatosIngresosSombrilla extrae de la BD a travez de un query
        /// el monto de los ingresos que genera el puesto de sombrilla
        /// y en que fecha se generaron estos ingresos, dentro de un
        /// periodo de tiempo establecido.
        /// </summary>
        /// <param name="_fechaini">
        /// Este atributo es la fecha inicial de donde comenzara la busqueda, 
        /// es establecido por el usuario.
        /// </param>
        /// <param name="_fechafin">
        /// Este atributo es la fecha final hasta donde llegara la busqueda,
        /// es establecido por el usuario.
        /// </param>
        /// <returns>
        /// El metodo regresa un DataTable con los datos necesarios para realizar
        /// el reporte.
        /// </returns>
        public DataTable GetDatosIngresosSombrilla(string _fechaini, string _fechafin)
        {
            DataTable _tablaDatos = new DataTable();
            SqlDataAdapter _adaptadorSql = new SqlDataAdapter();
            SqlCommand _comandoSql;
            try
            {
                _comandoSql = new SqlCommand("ReporteIngresosPorPuestoSombrillaConFecha", IniciarConexion());
                _comandoSql.Parameters.Add(new SqlParameter("@_fechaini", _fechaini));
                _comandoSql.Parameters.Add(new SqlParameter("@_fechafin", _fechafin));
                _comandoSql.CommandType = CommandType.StoredProcedure;
                _adaptadorSql.SelectCommand = _comandoSql;
                _adaptadorSql.Fill(_tablaDatos);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoSqlException,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosIngresosSombrilla,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorSql, e);
            }

            catch (Exception ex)
            {

                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoErrorGeneral,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosIngresosSombrilla,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorGeneral, ex);
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */
            }
            return _tablaDatos;
        }
        /// <summary>
        /// El metodo GetDatosIngresosRestaurante extrae de la BD a travez de un query
        /// el monto de los ingresos que genera el puesto de restaurante
        /// y en que fecha se generaron estos ingresos, dentro de un
        /// periodo de tiempo establecido.
        /// </summary>
        /// <param name="_fechaini">
        /// Este atributo es la fecha inicial de donde comenzara la busqueda, 
        /// es establecido por el usuario.
        /// </param>
        /// <param name="_fechafin">
        /// Este atributo es la fecha final hasta donde llegara la busqueda,
        /// es establecido por el usuario.
        /// </param>
        /// <returns>
        /// El metodo regresa un DataTable con los datos necesarios para realizar
        /// el reporte.
        /// </returns>
        public DataTable GetDatosIngresosRestaurante(string _fechaini, string _fechafin)
        {
            DataTable _tablaDatos = new DataTable();
            SqlDataAdapter _adaptadorSql = new SqlDataAdapter();
            SqlCommand _comandoSql;
            try
            {
                _comandoSql = new SqlCommand("ReporteIngresosPorPuestoRestauranteConFecha", IniciarConexion());
                _comandoSql.Parameters.Add(new SqlParameter("@_fechaini", _fechaini));
                _comandoSql.Parameters.Add(new SqlParameter("@_fechafin", _fechafin));
                _comandoSql.CommandType = CommandType.StoredProcedure;
                _adaptadorSql.SelectCommand = _comandoSql;
                _adaptadorSql.Fill(_tablaDatos);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoSqlException,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosIngresosRestaurante,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorSql, e);
            }

            catch (Exception ex)
            {

                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoErrorGeneral,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosIngresosRestaurante,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorGeneral, ex);
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */
            }
            return _tablaDatos;
        }
        /// <summary>
        /// El metodo GetDatosIngresosServicio extrae de la BD a travez de un query
        /// el monto de los ingresos que genera el puesto de servicios
        /// y en que fecha se generaron estos ingresos, dentro de un
        /// periodo de tiempo establecido.
        /// </summary>
        /// <param name="_fechaini">
        /// Este atributo es la fecha inicial de donde comenzara la busqueda, 
        /// es establecido por el usuario.
        /// </param>
        /// <param name="_fechafin">
        /// Este atributo es la fecha final hasta donde llegara la busqueda,
        /// es establecido por el usuario.
        /// </param>
        /// <returns>
        /// El metodo regresa un DataTable con los datos necesarios para realizar
        /// el reporte.
        /// </returns>
        public DataTable GetDatosIngresosServicio(string _fechaini, string _fechafin)
        {
            DataTable _tablaDatos = new DataTable();
            SqlDataAdapter _adaptadorSql = new SqlDataAdapter();
            SqlCommand _comandoSql;
            try
            {
                _comandoSql = new SqlCommand("ReporteIngresosPorPuestoServicioConFecha", IniciarConexion());
                _comandoSql.Parameters.Add(new SqlParameter("@_fechaini", _fechaini));
                _comandoSql.Parameters.Add(new SqlParameter("@_fechafin", _fechafin));
                _comandoSql.CommandType = CommandType.StoredProcedure;
                _adaptadorSql.SelectCommand = _comandoSql;
                _adaptadorSql.Fill(_tablaDatos);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoSqlException,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosIngresosServicio,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorSql, e);
            }

            catch (Exception ex)
            {

                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoErrorGeneral,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosIngresosServicio,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorGeneral, ex);
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */
            }
            return _tablaDatos;
        }
        /// <summary>
        /// El metodo GetDatosEstacionamiento extrae de la BD a travez de un query
        /// el monto de los ingresos que genera el puesto de servicios
        /// y en que fecha se generaron estos ingresos, dentro de un
        /// periodo de tiempo establecido.
        /// </summary>
        /// <param name="_fechaini">
        /// Este atributo es la fecha inicial de donde comenzara la busqueda, 
        /// es establecido por el usuario.
        /// </param>
        /// <param name="_fechafin">
        /// Este atributo es la fecha final hasta donde llegara la busqueda,
        /// es establecido por el usuario.
        /// </param>
        /// <returns>
        /// El metodo regresa un DataTable con los datos necesarios para realizar
        /// el reporte.
        /// </returns>
        public DataTable GetDatosIngresosEstacionamiento(string _fechaini, string _fechafin)
        {
            DataTable _tablaDatos = new DataTable();
            SqlDataAdapter _adaptadorSql = new SqlDataAdapter();
            SqlCommand _comandoSql;
            try
            {
                _comandoSql = new SqlCommand("ReporteIngresosPorPuestoEstacionamientoConFecha", IniciarConexion());
                _comandoSql.Parameters.Add(new SqlParameter("@_fechaini", _fechaini));
                _comandoSql.Parameters.Add(new SqlParameter("@_fechafin", _fechafin));
                _comandoSql.CommandType = CommandType.StoredProcedure;
                _adaptadorSql.SelectCommand = _comandoSql;
                _adaptadorSql.Fill(_tablaDatos);
            }
            
            catch (SqlException e)
            {
                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoSqlException,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosIngresosEstacionamiento,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorSql, e);
            }

            catch (Exception ex)
            {

                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoErrorGeneral,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosIngresosEstacionamiento,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorGeneral, ex);
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */              
            }
            return _tablaDatos;
        }
        /// <summary>
        /// El metodo GetDataBebidas extrae de la BD a travez de un query 
        /// el nombre y ingresos de las bebidas dentro de la BD 
        /// en un periodo de tiempo establecido.
        /// </summary>
        /// <param name="_fechaini">
        /// Este atributo es la fecha inicial de donde comenzara la busqueda, 
        /// es establecido por el usuario.
        /// </param>
        /// <param name="_fechafin">
        /// Este atributo es la fecha final hasta donde llegara la busqueda,
        /// es establecido por el usuario.
        /// </param>
        /// <returns>
        /// El metodo regresa un DataTable con los datos necesarios para realizar
        /// el reporte.
        /// </returns>
        public DataTable GetDatosBebidas(string _fechaini, string _fechafin)
        {
            DataTable _tablaDatos = new DataTable();
            SqlDataAdapter _adaptadorSql = new SqlDataAdapter();
            SqlCommand _comandoSql;
            try
            {
                _comandoSql = new SqlCommand("ReporteIngresosPorBebidasConFecha", IniciarConexion());
                _comandoSql.Parameters.Add(new SqlParameter("@_fechaini", _fechaini));
                _comandoSql.Parameters.Add(new SqlParameter("@_fechafin", _fechafin));
                _comandoSql.CommandType = CommandType.StoredProcedure;
                _adaptadorSql.SelectCommand = _comandoSql;
                _adaptadorSql.Fill(_tablaDatos);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoSqlException,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosBebidas,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorSql, e);
            }

            catch (Exception ex)
            {

                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoErrorGeneral,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosBebidas,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorGeneral, ex);
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */
            }
            finally
            {
                CerrarConexion();
            }
            return _tablaDatos;
        }
        /// <summary>
        /// El metodo GetDataPlatos extrae de la BD a travez de un query 
        /// el nombre y ingresos de los platos dentro de la BD 
        /// en un periodo de tiempo establecido.
        /// </summary>
        /// <param name="_fechaini">
        /// Este atributo es la fecha inicial de donde comenzara la busqueda, 
        /// es establecido por el usuario.
        /// </param>
        /// <param name="_fechafin">
        /// Este atributo es la fecha final hasta donde llegara la busqueda,
        /// es establecido por el usuario.
        /// </param>
        /// <returns>
        /// El metodo regresa un DataTable con los datos necesarios para realizar
        /// el reporte.
        /// </returns>
        public DataTable GetDatosComidas(string _fechaini, string _fechafin)
        {
            DataTable _tablaDatos = new DataTable();
            SqlDataAdapter _adaptadorSql = new SqlDataAdapter();
            SqlCommand _comandoSql;
            try
            {
                _comandoSql = new SqlCommand("ReporteIngresosPorPlatosConFecha", IniciarConexion());
                _comandoSql.Parameters.Add(new SqlParameter("@_fechaini", _fechaini));
                _comandoSql.Parameters.Add(new SqlParameter("@_fechafin", _fechafin));
                _comandoSql.CommandType = CommandType.StoredProcedure;
                _adaptadorSql.SelectCommand = _comandoSql;
                _adaptadorSql.Fill(_tablaDatos);
            }
            catch (SqlException e)
            {
                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoSqlException,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosComidas,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorSql, e);
            }

            catch (Exception ex)
            {

                throw new ExcepcionDaoReportesFinancierosExportacion(RecurosDaoReportesFinancierosExportacion.CodigoErrorGeneral,
                    RecurosDaoReportesFinancierosExportacion.ClaseDaoReportesFinancierosExportacion,
                    RecurosDaoReportesFinancierosExportacion.MetodoGetDatosComidas,
                    RecurosDaoReportesFinancierosExportacion.MensajeErrorGeneral, ex);
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */
            }
            finally
            {
                CerrarConexion();
            }
            return _tablaDatos;
        }
    }
}