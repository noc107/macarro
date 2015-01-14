using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.FuenteDatos.Dao.ReportesFinancierosExportacion;
using BackOffice.FuenteDatos.Dao.ConfiguracionPuestosPlaya;
using BackOffice.FuenteDatos.Dao.VentaCierreCaja;
using BackOffice.FuenteDatos.Dao.Proveedores;
using BackOffice.FuenteDatos.Dao.RolesSeguridad;
using BackOffice.FuenteDatos.Dao.UsuariosInternos;
using BackOffice.FuenteDatos.Dao.MenuRestaurante;
using BackOffice.FuenteDatos.Dao.GestionVentaMembresia;
using BackOffice.FuenteDatos.Dao.ConfiguracionServiciosPlaya;
using BackOffice.FuenteDatos.IDao.ConfiguracionPuestosPlaya;
using BackOffice.FuenteDatos.IDao.VentaCierreCaja;
using BackOffice.FuenteDatos.IDao.Proveedores;
using BackOffice.FuenteDatos.IDao.ReportesFinancierosExportacion;
using BackOffice.FuenteDatos.IDao.RolesSeguridad;
using BackOffice.FuenteDatos.IDao.UsuariosInternos;
using BackOffice.FuenteDatos.IDao.MenuRestaurante;
using BackOffice.FuenteDatos.IDao.GestionVentaMembresia;
using BackOffice.FuenteDatos.IDao.ConfiguracionServiciosPlaya;
using BackOffice.FuenteDatos.Dao.IngresoRecuperacionClave;
using BackOffice.FuenteDatos.IDao.IngresoRecuperacionClave;
using BackOffice.FuenteDatos.Dao.ReservasSombrillasServiciosPlaya;
using BackOffice.FuenteDatos.IDao.ReservasSombrillasServiciosPlaya;
using BackOffice.FuenteDatos.IDao.InventarioRestaurante;
using BackOffice.FuenteDatos.Dao.InventarioRestaurante;




namespace BackOffice.FuenteDatos.Fabrica
{
    public class FabricaDao
    {
        #region ConfiguracionEstacionamiento

        #endregion

        #region ConfiguracionPuestosPlaya
        public static IDaoInventarioPlaya ObtenerDaoInventarioPlaya()      {
            return new DaoInventarioPlaya();
        }


        public static IDaoPuestoPlaya ObtenerDaoPuestoPlaya()
        {
            return new DaoPuestoPlaya();
        }



        #endregion

        #region ConfiguracionServiciosPlaya

        public static IDaoServiciosPlaya ObtenerDaoServiciosPlaya()
        {
            return new DaoServiciosPlaya();
        }

        #endregion

        #region GestionVentaMembresia

        /// <summary>
        /// Metodo para la fabrica del DaoMembresia
        /// </summary>
        /// <returns>la interfaz</returns>
        public static IDaoMembresia ObtenerDaoMembresia()
        {
            return new DaoMembresia();
        }

        /// <summary>
        /// Metodo para la fabrica del DaoCosto 
        /// </summary>
        /// <returns>la interfaz</returns>
        public static IDaoCosto ObtenerDaoCosto()
        {
            return new DaoCosto();
        }

        /// <summary>
        /// Metodo para la fabrica del DaoPago 
        /// </summary>
        /// <returns>la interfaz</returns>
        public static IDaoPago ObtenerDaoPago()
        {
            return new DaoPago();
        }
        #endregion

        #region IngresoRecuperacionClave
        public static IDaoIniciarSesion ObtenerDaoIniciarSesion()
        {
            return new DaoInicio();
        }
        #endregion

        #region InventarioRestaurante
        public static IDao_06_inventarioRestaurante ObtenerDaoInventarioRestaurante()
        {
            return new DaoInventarioRestaurante();
        }
        #endregion

        #region MenuRestaurante

       public static IDaoPlato ObtenerDaoPlato()
       {
            return new DaoPlato();
       }

       public static IDaoSeccion ObtenerDaoSeccion()
       {
            return new DaoSeccion();
       }

      

        #endregion

        #region Proveedores

        public static IDaoProveedor ObtenerDaoProveedor()
        {
            return new DaoProveedor();
        }

        #endregion

        #region ReportesFinancierosExportacion
            public static IDaoReportesFinancierosExportacion ObtenerDaoReportesFinancierosExportacion()
            {
                return new DaoReportesFinancierosExportacion();
            }
        #endregion

        #region ReservasSombrillasServiciosPlaya
            public static IdaoReserva ObtenerReserva()
            {

                return new DaoReserva();
            }

            public static IdaoReservaPuesto ObtenerReservaPuesto()
            {

                return new DaoReservaPuesto();
            }

            public static IdaoReservaServicio ObtenerReservaServicio()
            {

                return new DaoReservaServicio();
            }
        #endregion

        #region RolesSeguridad

            /// <summary>
            /// Metodo para la fabrica del DaoRol 
            /// </summary>
            /// <returns>la interfaz</returns>
            public static IDaoRol ObtenerDaoRol()
            {
                return new DaoRol();
            }

            /// <summary>
            /// Metodo para la fabrica del DaoAccion 
            /// </summary>
            /// <returns>la interfaz</returns>
            public static IDaoAccion ObtenerDaoAccion()
            {
                return new DaoAccion();
            }
        
            /// <summary>
            /// Metodo para la fabrica del DaoMenu 
            /// </summary>
            /// <returns>la interfaz</returns>
            public static IDaoMenu ObtenerDaoMenu()
            {
                return new DaoMenu();
            }

            #endregion

        #region UsuariosInternos
		
		
        /// <summary>
		/// Método para la fábrica de DaoEmpleado
		/// </summary>
		/// <returns>Dao Empleado</returns>
        public static IDaoEmpleado ObtenerDaoEmpleado() 
        {
            return new DaoEmpleado(); 
        }

        /// <summary>
        /// Método para la fábrica de DaoLugar
        /// </summary>
        /// <returns>Dao Lugar</returns>
        public static IDaoLugar ObtenerDaoLugar()
        {
            return new DaoLugar();
        }

        

        #endregion

        #region VentaCierreCaja
            public static IDaoFacturacion ObtenerDaoFacturacion()
            {
                return new DaoFacturacion();
            }

            public static IDaoCierreCaja obtenerDaoCierreCaja()
            {
                return new DaoCierreCaja();
            }

            public static IDaoGestionarVenta obtenerDaoGestionarVenta()
            {
                return new DaoGestionarVenta();
            }

            public static IDaoImprimirFactura obtenerDaoImprimirFactura()
            {
                return new DaoImprimirFactura();
            }
        #endregion
        
    }
}