using FrontOffice.FuenteDatos.Dao.Reservas;
using FrontOffice.FuenteDatos.Dao.Membresia;
using FrontOffice.FuenteDatos.IDao.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontOffice.FuenteDatos.Dao.ConfiguracionEstacionamientos;
using FrontOffice.FuenteDatos.IDao.ConfiguracionEstacionamientos;
using FrontOffice.FuenteDatos.IDao.IngresoRecuperacionClave;
using FrontOffice.FuenteDatos.Dao.IngresoRecuperacionClave;

namespace FrontOffice.FuenteDatos.Fabrica
{
    public class FabricaDao
    {
        #region ConfiguracionEstacionamientos
        public static IDaoEstacionamiento ObtenerDaoEstacionamiento()
        {
            return new DaoEstacionamiento();
        }

        public static IDaoTicket ObtenerDaoTicket()
        {
            return new DaoTicket();

        }
        #endregion

        #region IngresoRecuperacionClave
		public static IDaoIniciarSesion ObtenerDaoIniciarSesion()
        {
            return new DaoInicio();
        }
        #endregion

        #region Membresia
        public static DaoMembresia ObtenerDaoMembresia()
        {
            return new DaoMembresia();
        }
        public static DaoPago ObtenerDaoPagoMembresia()
        {
            return new DaoPago();
        }
        public static DaoTarjeta ObtenerDaoTarjetaMembresia()
        {
            return new DaoTarjeta();
        } 
        #endregion

        #region Menu

        #endregion

        #region Reservas

        public static IDaoReservaServicio ObtenerDaoReservaServicio()
        {
            return new DaoReservaServicio();
        }
        public static IDaoReservaPlaya ObtenerDaoReservaPlaya()
        {
            return new DaoReservaPlaya();
        }
        public static IDaoReservaPuesto ObtenerDaoReservaPuesto()
        {
            return new DaoReservaPuesto();
        }

        public static IDaoReservaReserva_Puesto ObtenerDaoReservaReserva_Puesto()
        {
            return new DaoReservaReserva_Puesto();
        }
        
        public static IDaoReserva ObtenerDaoReservaReserva()
        {
            return new DaoReserva();
        }

        #endregion
    }
}