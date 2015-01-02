using BackOffice.Dominio;
using BackOffice.LogicaNegocio.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.LogicaNegocio.Comandos.ConfiguracionPuestosPlaya;
using BackOffice.LogicaNegocio.Comandos.Proveedores;

namespace BackOffice.LogicaNegocio.Fabrica
{
    public class FabricaComando
    {
        #region EjemploComandoAgregarPersona

        public static Comando<Entidad, Boolean> ObtenerComandoAgregarPersona()
        {
            return new ComandoAgregarPersona();
        }

        #endregion

        #region ConfiguracionEstacionamiento

        #endregion

        #region ConfiguracionPuestosPlaya
        public static Comando<string, List<Entidad>> ObtenerComandoConsultarInventario()
        {
            return new ComandoConsultarInventario();
        }

        public static Comando<int, Entidad> ObtenerComandoConsultarInventarioXId()
        {
            return new ComandoConsultarInventarioXId();
        }

        public static  Comando<int, List<Entidad>> ObtenerComandoConsultarEstadosInventario()
        {
            return new ComandoConsultarEstadosInventario();
        }
        
        public static Comando<Entidad, bool> ObtenerComandoActualizarItemSeleccionado()
        {
            return new ComandoActualizarItemSeleccionado();
        }

        public static Comando<Entidad, bool> ObtenerComandoActualizarInventarioTipo()
        {
            return new ComandoActualizarInventarioTipo();
        }

        public static Comando<int, bool> ObtenerComandoEliminarItemSeleccionado()
        {
            return new ComandoEliminarItemSeleccionado();
        }
        #endregion

        #region ConfiguracionServiciosPlaya

        #endregion

        #region GestionVentaMembresia

        #endregion

        #region IngresoRecuperacionClave

        #endregion

        #region InventarioRestaurante

        #endregion

        #region MenuRestaurante

        #endregion

        #region Proveedores

        public static Comando<int, Entidad> ObtenerComandoConsultarProveedor()
        {
            return new ComandoConsultarProveedor();
        }

        #endregion

        #region ReportesFinancierosExportacion

        #endregion

        #region ReservasSombrillasServiciosPlaya

        #endregion

        #region RolesSeguridad

        #endregion

        #region UsuariosInternos

        #endregion

        #region VentaCierreCaja

        #endregion
    }
}