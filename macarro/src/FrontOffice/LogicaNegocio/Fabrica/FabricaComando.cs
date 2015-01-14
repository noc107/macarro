using FrontOffice.Dominio;
using FrontOffice.LogicaNegocio.Comandos.Membresia;
using FrontOffice.LogicaNegocio.Comandos;
using FrontOffice.LogicaNegocio.Comandos.ConfiguracionEstacionamientos;
using FrontOffice.LogicaNegocio.Comandos.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontOffice.Dominio.Entidades;
using FrontOffice.LogicaNegocio.Comandos.IngresoRecuperacionClave;

namespace FrontOffice.LogicaNegocio.Fabrica
{
    public class FabricaComando
    {

        #region ConfiguracionEstacionamientos
        public static Comando<int, Entidad> ObtenerComandoConsultarEstacionamiento()
        {
            return new ComandoConsultarEstacionamiento();
        }


        public static Comando<Entidad, Boolean> ObtenerComandoGenerarTicket()
        {
            return new ComandoGenerarTicket();

        }

        public static Comando<string, Entidad> ObtenerComandoConsultarTicketPlaca()
        {
            return new ComandoConsultarTicket();
        }

        public static Comando<Entidad, Boolean> ObtenerComandoCobrarTicketPorPlaca()
        {
            return new ComandoCobrarTicket();
        }

        public static Comando<Entidad, Boolean> ObtenerComandoCobrarTicketPorNumero()
        {
            return new ComandoCobrarTicketPorNumeroTicket();
        }

        #endregion

        #region Estacionamiento

        #endregion

        #region IngresoRecuperacionClave
		public static Comando<Entidad, Entidad> obtenerComandoUsuarioInicio()
        {
            return new ComandoUsuarioInicio();
        }

        public static Comando<Entidad, Entidad> obtenerComandoPersonaInicio()
        {
            return new ComandoPersonaInicio();
        }
        #endregion

        #region Membresia
        public static ComandoConsultarMembresia ObtenerComandoConsultarMembresia()
        {
            return new ComandoConsultarMembresia();
        }
        public static ComandoGenerarCarnetPdf ObtenerComandoGenerarPdfMembresia()
        {
            return new ComandoGenerarCarnetPdf();
        }
        public static ComandoConsultarTodosLosPagos ObtenerComandoConsultarTodosLosPagos()
        {
            return new ComandoConsultarTodosLosPagos();
        }
        public static ComandoConsultarPagosPorIdYFecha ObtenerComandoConsultarPagoConParametros()
        {
            return new ComandoConsultarPagosPorIdYFecha();
        }
        public static ComandoConsultaDetallePago ObtenerComandoConsultaDetallePago()
        {
            return new ComandoConsultaDetallePago();
        }
        public static ComandoConsultaTarjeta ObtenerComandoConsultaTarjeta(){

            return new ComandoConsultaTarjeta();
        }
        #endregion

        #region Menu

        #endregion

        #region Reservas
		 public static Comando<string, List<string>> ObtenerComandoConsultarServicios()
        {
            return new ComandoConsultarServicios();
        }

        public static Comando<string[], int> ObtenerComandoConsultarVerificarHorario()
        {
            return new ComandoVerificarHorarioServicio();
        }

        public static Comando<Entidad, bool> ObtenerModificarReservaServicio()
        {
            return new ComandoModificarReservaServicio();
        }

        public static Comando<Entidad, bool> ObtenerInsertarReservaServicio()
        {
            return new ComandoInsertarReservaServicio();
        }

        public static Comando<int, Entidad> ObtenerReservaServicioXID()
        {
            return new ComandoConsultarReservaServicioXID();
        }
		
		public static Comando<Entidad, bool> ObtenerComandoModificarStatusReserva()
        {
            return new ComandoModificarStatusReserva();
        }

        public static Comando<string[], int> ObtenerComandoCantidadServiciosDisponibles()
        {
            return new ComandoConsultarCantidadServiciosDisponibles();
        }

        public static Comando<string, Entidad> ObtenerComandoConsultarReservaXID()
        {
            return new ComandoConsultarReservaXID();
        }
		
		
        public static Comando<string, List<Entidad>> ObtenerComandoConsultarReservaServicio()
        {
            return new ComandoConsultarReservaServicio();
        }
        public static Comando<int, Entidad> ObtenerComandoConsultarReservaPlaya()
        {
            return new ComandoConsultarReservaPlaya();
        }
        public static Comando<int,List<Entidad>> ObtenerComandoConsultarReservaPuesto()
        {
            return new ComandoConsultarReservaPuesto();
        }
        public static Comando<int[], List<Entidad>> ObtenerComandoConsultarReseservaReserva_PuestoPorPlaya_Reserva()
        {
            return new ComandoConsultarReservaReserva_PuestoPorPlayaReserva();
        }
        public static Comando<string[], List<Entidad>> ObtenerComandoConsultarReseservaReserva_PuestoPorPlaya_Inicio_Fin()
        {
            return new ComandoConsultarReservaReservaPuesto_Incio_Fin_Playa();
        }
        public static Comando<int, bool> ObtenerComandoEliminarReservaReserva_Puesto()
        {
            return new ComandoEliminarReservaReserva_Puesto();
        }
        public static Comando<int, bool> ObtenerComandoEliminarReserva()
        {
            return new ComandoEliminarReservaReserva();
        }
        public static Comando<string,List<Entidad>> ObtenerComandoConsultarReservaMayorAHoy()
        {
            return new ComandoConsultarReservaMayorAHoy();
        }

        public static Comando<int[],bool> ObtenerComandoEliminarReservaReserva_PuestoFactores()
        {
            return new CommandoEliminarReservaReserva_PuestoFactores();
        }
        public static Comando<ReservaReserva_Puesto,bool> ObtenerInsertarSinInventario()
        {
            return new ComandoInsertarReservaReserva_Puesto();
        }
        public static Comando<bool,int> ObtenerReservaSecuencia()
        {
            return new ComandoConsultarReservaSecuencia();
        }
        public static Comando<string[],bool> ObtenerInsertarReservaSinSecuencia()
        {
            return new ComandoInsertarReservaSinSecuencia();
        }
        #endregion

    }
}