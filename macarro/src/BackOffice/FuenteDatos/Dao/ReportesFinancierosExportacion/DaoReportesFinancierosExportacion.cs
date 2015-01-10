using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.FuenteDatos.IDao.ReportesFinancierosExportacion;
using System.Data;
using System.Data.SqlClient;

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
            SqlDataAdapter _adaptadorSql;
            try
            {
                string _queryString =
                                    "select (select count(*) from USUARIO u where u.FK_estado = 1) " +
                                    "as Activos , (select count(*) from USUARIO u " +
                                    "where u.FK_estado = 2) as Inactivos";
                _adaptadorSql = new SqlDataAdapter(_queryString,IniciarConexion());
                _adaptadorSql.Fill(_tablaDatos);
            }
            catch (Exception ex)
            {   /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);*/
                //throw _excepcion;
                throw ex;
            }
            CerrarConexion();
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
            SqlDataAdapter _adapterSql;
            try
            {
                string _queryString =
                             "select count(*) as cantidad,(select r2.rol_nombre from rol r2 " +
                             "where r2.rol_id = r.rol_id) as rol " +
                             "from usuario u,usuario_rol ur,rol r " +
                             "where u.usu_id = ur.fk_usuario and ur.fk_rol = r.rol_id " +
                             "group by (r.rol_id)";
                _adapterSql = new SqlDataAdapter(_queryString,IniciarConexion());
                _adapterSql.Fill(_tablaDatos);
            }
            catch (Exception ex)
            {
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */
                throw ex;
            }
            CerrarConexion();
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
            SqlDataAdapter _adaptadorSql;
            DataTable _tablaDatos = new DataTable();
            try
            {
                string _queryString =
                                    "select (select p.pro_razonsocial from proveedor p where p.PRO_rif = pro.PRO_rif) as nombre " +
                                    ",SUM(proinv.PRO_INV_cantidad) as cantidad,i.ITE_nombre " +
                                    "from proveedor pro, PROV_INVENTARIO proinv, ITEM_INVENTARIO iv,item i " +
                                    "where iv.FK_item = i.ITE_id and proinv.FK_item_inventario = iv.ITE_INV_id " +
                                    "and pro.PRO_id = proinv.FK_proveedor " +
                                    "group by pro.PRO_rif,i.ITE_nombre";
                _adaptadorSql = new SqlDataAdapter(_queryString,IniciarConexion());
                _adaptadorSql.Fill(_tablaDatos);
            }
            catch (Exception ex)
            {
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */
                throw ex;
            }
            CerrarConexion();
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
            SqlDataAdapter _adaptadorSql;
            DataTable _tablaDatos = new DataTable();
            try
            {
                string _queryString =
                                    "select i.ite_nombre,iv.ite_inv_cantidad,iv.ite_inv_cantidadmin " +
                                    "from item_inventario iv ,item i " +
                                    "where i.ite_id=iv.fk_item ";
                _adaptadorSql = new SqlDataAdapter(_queryString,IniciarConexion());
                _adaptadorSql.Fill(_tablaDatos);
            }
            catch (Exception ex)
            {
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */
                throw ex;
            }
            CerrarConexion();
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
            SqlDataAdapter _adaptadorSql;
            try
            {
                string _queryString =
                                    "select sum(p.pag_monto) as ingreso,format(p.pag_fecha,'yyyy, MM, dd')  as fecha " +
                                    "from Pago p " +
                                    "where p.pag_fecha >= '" + _fechaini + "' and p.pag_fecha<= '" + _fechafin + "' " +
                                    "group by p.pag_fecha ";
                _adaptadorSql = new SqlDataAdapter(_queryString,IniciarConexion());
                _adaptadorSql.Fill(_tablaDatos);
            }
            catch (Exception ex)
            {
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */
                throw ex;
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
            SqlDataAdapter _adapterSql;
            try
            {
                string _queryString =
                                    "select format(f.FAC_fecha,'yyyy, MM, dd') as fecha, " +
                                    "sum(s.ser_costo*rs.res_ser_cantidad) as ingreso " +
                                    "from factura f, linea_factura lf, servicio s, horario h, reserva_servicio rs ,"+
                                    "reserva r where lf.fk_reserva_servicio=rs.res_ser_id and rs.fk_horario=h.hor_id "+
                                    "and s.ser_id=h.fk_servicio and lf.fk_factura=f.fac_id "+
                                    "and rs.fk_reserva=r.res_id and " +
                                    "(f.fac_fecha>='" + _fechaini + "'  and f.fac_fecha<='" + _fechafin + "') " +
                                    "group by f.fac_fecha";
                _adapterSql = new SqlDataAdapter(_queryString,IniciarConexion());
                _adapterSql.Fill(_tablaDatos);
            }
            catch (Exception ex)
            {
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */
                throw ex;
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
            SqlDataAdapter _adapterSql;
            try
            {
                string _queryString =
                                    "select format(f.FAC_fecha,'yyyy, MM, dd') as fecha, " +
                                    "sum(p.pla_precio*lf.lin_fac_cantidad) as ingreso " +
                                    "from factura f, linea_factura lf, plato p  " +
                                    "where p.pla_id=lf.fk_plato and lf.fk_factura=f.fac_id and " +
                                    "(f.fac_fecha>='" + _fechaini + "'  and f.fac_fecha<='" + _fechafin + "') " +
                                    "group by f.fac_fecha";
                _adapterSql = new SqlDataAdapter(_queryString,IniciarConexion());
                _adapterSql.Fill(_tablaDatos);
            }
            catch (Exception ex)
            {
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */
                throw ex;
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
            SqlDataAdapter _adapterSql;
            try
            {
                string _queryString =
                                    "select format(f.FAC_fecha,'yyyy, MM, dd') as fecha, " +
                                    "sum(s.ser_costo*lf.lin_fac_cantidad) as ingreso " +
                                    "from factura f, linea_factura lf, reserva_servicio rs, horario h, servicio s " +
                                    "where lf.fk_reserva_servicio=rs.res_ser_id and rs.fk_horario=h.hor_id and s.ser_id=h.fk_servicio and lf.fk_factura=f.fac_id and " +
                                    "(f.fac_fecha>='" + _fechaini + "'  and f.fac_fecha<='" + _fechafin + "') " +
                                    "group by f.fac_fecha";
                _adapterSql = new SqlDataAdapter(_queryString,IniciarConexion());
                _adapterSql.Fill(_tablaDatos);
            }
            catch (Exception ex)
            {
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */
                throw ex;
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
            SqlDataAdapter _adapterSql;

            try
            {
                string _queryString =
                                    "select format(f.FAC_fecha,'yyyy, MM, dd') as fecha, " +
                                    "sum(e.est_tarifa*DATEDIFF(mi, t.TIC_fechaEntrada," +
                                    "t.TIC_fechaSalida)) as ingreso  " +
                                    "from factura f, linea_factura lf, ticket t, estacionamiento e " +
                                    "where lf.fk_factura=f.fac_id and t.tic_id=lf.fk_ticket " +
                                    "and t.fk_estacionamiento=e.est_id and " +
                                    "(f.fac_fecha>='" + _fechaini + "'  and f.fac_fecha<='" + _fechafin + "') " +
                                    "group by f.fac_fecha";
                _adapterSql = new SqlDataAdapter(_queryString,IniciarConexion());
                _adapterSql.Fill(_tablaDatos);

            }
            catch (Exception ex)
            {
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */
                throw ex;
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
            try
            {
                SqlDataAdapter _adaptadorSql;
                string _queryString =
                                    "select p.PLA_nombre, sum(lf.lin_fac_cantidad*p.pla_precio) as ingresos " +
                                    "from Plato p,linea_factura lf,seccion s,factura f " +
                                    "where p.pla_id=lf.fk_plato and s.sec_id = p.fk_seccion and " +
                                    "f.fac_id=lf.fk_factura and s.sec_nombre ='Bebidas' and " +
                                    "f.fac_fecha >=  '" + _fechaini + "' and f.fac_fecha <='" + _fechafin + "' " +
                                    "group by p.PLA_nombre";
                _adaptadorSql = new SqlDataAdapter(_queryString,IniciarConexion());
                _adaptadorSql.Fill(_tablaDatos);
            }
            catch (Exception ex)
            {
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */
                throw ex;
            }
            CerrarConexion();
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
            SqlDataAdapter _adaptadorSql;
            try
            {
                string _queryString =
                                    "select p.PLA_nombre, sum(lf.lin_fac_cantidad*p.pla_precio) as ingresos " +
                                    "from Plato p,linea_factura lf,seccion s,factura f " +
                                    "where p.pla_id=lf.fk_plato and s.sec_id = p.fk_seccion and " +
                                    "f.fac_id=lf.fk_factura and s.sec_nombre !='Bebidas' and " +
                                    "f.fac_fecha >=  '" + _fechaini + "' and f.fac_fecha <='" + _fechafin + "' " +
                                    "group by p.PLA_nombre";
                _adaptadorSql = new SqlDataAdapter(_queryString,IniciarConexion());
                _adaptadorSql.Fill(_tablaDatos);
            }
            catch (Exception ex)
            {
                /*
                string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
                back_office.Excepciones.
                ReportesFinancierosExportacion.
                ExcepcionBaseDatos
                _excepcion = new back_office.Excepciones.
                                 ReportesFinancierosExportacion.ExcepcionBaseDatos(_mensaje);
                throw _excepcion;
                */
                throw ex;
            }
            CerrarConexion();
            return _tablaDatos;
        }
    }
}