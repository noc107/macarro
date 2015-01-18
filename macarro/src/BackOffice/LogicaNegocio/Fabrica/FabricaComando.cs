using BackOffice.Dominio;
using BackOffice.LogicaNegocio.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.LogicaNegocio.Comandos.ConfiguracionPuestosPlaya;
using BackOffice.LogicaNegocio.Comandos.VentaCierreCaja;
using BackOffice.LogicaNegocio.Comandos.Proveedores;
using BackOffice.LogicaNegocio.Comandos.InventarioRestaurante;
using BackOffice.LogicaNegocio.Comandos.UsuariosInternos;
using System.Data;
using BackOffice.LogicaNegocio.Comandos.RolesSeguridad;
using BackOffice.LogicaNegocio.Comandos.MenuRestaurante;
using BackOffice.LogicaNegocio.Comandos.GestionVentaMembresia;
using BackOffice.LogicaNegocio.Comandos.ConfiguracionServiciosPlaya;
using BackOffice.LogicaNegocio.Comandos.IngresoRecuperacionClave;
using System.Web.UI.WebControls;
using BackOffice.LogicaNegocio.Comandos.ReservasSombrillasServiciosPlaya;
using BackOffice.LogicaNegocio.Comandos.ReportesFinancierosExportacion;


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
        public static Comando<string, List<Entidad>> ObtenerComandoConsultarInventarioTipo()
        {
            return new ComandoConsultarInventarioTipo();
        }



        public static Comando<string, List<Entidad>> ObtenerComandoConsultarPuesto()
        {
            return new ComandoConsultarPuesto();
        }

        public static Comando<Entidad, bool> ObtenerComandoActualizarPuesto()
        {
            return new ComandoActualizarPuesto();
        }


        public static Comando<int, Entidad> ObtenerComandoConsultarInventarioXId()
        {
            return new ComandoConsultarInventarioXId();
        }

        public static Comando<int, List<Entidad>> ObtenerComandoConsultarEstadosInventario()
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

        public static Comando<string, Entidad> ObtenerComandoConsultarServicioCompleto()
        {
            return new ComandoConsultarServicioCompleto();
        }

        public static Comando<Entidad, List<Entidad>> ObtenerComandoConsultarServicios()
        {
            return new ComandoConsultarServicios();
        }

        public static Comando<string, bool> ObtenerComandoEliminarServicio()
        {
            return new ComandoEliminarServicio();
        }

        #endregion

        #region GestionVentaMembresia

        /// <summary>
        /// Metodo para la fabrica del ObtenerComandoConsultarMembresia 
        /// </summary>
        /// <returns>el comando</returns>
        public static Comando<int, Entidad> ObtenerComandoConsultarMembresia()
        {
            return new ComandoConsultarMembresia();
        }
        /// <summary>
        /// Metodo para la fabrica del ObtenerComandoModificarMembresia 
        /// </summary>
        /// <returns>el comando</returns>
        public static Comando<Entidad, bool> ObtenerComandoModificarMembresia()
        {
            return new ComandoModificarMembresia();
        }

        /// <summary>
        /// Metodo para la fabrica del ObtenerComandoConsultarCosto 
        /// </summary>
        /// <returns>el comando</returns>
        public static Comando<int, Entidad> ObtenerComandoConsultarCosto()
        {
            return new ComandoConsultarCosto();
        }
        /// <summary>
        /// Metodo para la fabrica del ObtenerComandoModificarCosto 
        /// </summary>
        /// <returns>el comando</returns>
        public static Comando<Entidad, bool> ObtenerComandoModificarCosto()
        {
            return new ComandoModificarCosto();
        }

        /// <summary>
        /// Metodo para la fabrica del ComandoConsultarGVMembresias 
        /// </summary>
        /// <returns>el comando</returns>
        public static Comando<string, List<Entidad>> ObtenerComandoConsultarGVMembresias()
        {
            return new ComandoConsultarGVMembresias();
        }

        /// <summary>
        /// Metodo para la fabrica del ComandoConsultarGVPagos 
        /// </summary>
        /// <returns>el comando</returns>
        public static Comando<string, List<Entidad>> ObtenerComandoConsultarGVPagos()
        {
            return new ComandoConsultarGVPagos();
        }


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

        #region InventarioRestaurante
        public static Comando<Entidad,bool> ObtenerComandoAgregarItem()
        {
            return new Comando_06_agregarItem();
        }

        public static Comando<int,DataTable> ObtenerListaRazonSocial()
        {
            return new Comando_06_verRazonSocial();
        }
        #endregion
        
        #region MenuRestaurante

        public static Comando<int, Entidad> ObtenerComandoConsultarPlato()
        {
            return new ComandoConsultarPlato();
        }

        public static Comando<Entidad, bool> ObtenerComandoAgregarPlato()
        {
            return new ComandoAgregarPlato();
        }

        public static Comando<Entidad, bool> ObtenerComandoModificarPlato()
        {
            return new ComandoModificarPlato();
        }

        public static Comando<Entidad, bool> ObtenerComandoEliminarPlato()
        {
            return new ComandoEliminarPlato();
        }

       public static Comando<int, Entidad> ObtenerComandoConsultarSeccion()
       {
            return new ComandoConsultarSeccion();
       }

       public static Comando<Entidad, bool> ObtenerComandoAgregarSeccion()
       {
            return new ComandoAgregarSeccion();
       }

       public static Comando<Entidad, bool> ObtenerComandoModificarSeccion()
       {
           return new ComandoModificarSeccion();
       }

       public static Comando<Entidad, bool> ObtenerComandoEliminarSeccion()
       {
            return new ComandoEliminarSeccion();
       }
        
       public static Comando<bool, List<Entidad>> ObtenerComandoLlenarGridPlatos()
       {
            return new ComandoLlenarGridPlatos();
       }

       public static Comando<List<Entidad>, List<string>> ObtenerComandoLista()
       {
           return new ComandoLista();
       }

       public static Comando<bool, List<Entidad>> ObtenerComandoLlenarSecciones()
       {
           return new ComandoLlenarSecciones();
       }
       
      //public static Comando<bool, List<Entidad>> ObtenerComandoLlenarGridSecciones()
      //{
      //      return new ComandoLlenarGridSecciones();
      //}

        #endregion

        #region Proveedores

        public static Comando<int, Entidad> ObtenerComandoConsultarProveedor()
        {
            return new ComandoConsultarProveedor();
        }

        public static Comando<Entidad, bool> ObtenerComandoAgregarProveedor()
        {
            return new ComandoAgregarProveedor();
        }

        public static Comando<string, List<string>> ObtenerComandoEstadosDePais() 
        {
            return new ComandoCambioPais();
        }
        public static Comando<string, List<string>> ObtenerComandoPaisesTodos() 
        {
            return new ComandoObtenerPaisesTodos();
        }

        public static Comando<string, List<string>> ObtenerComandoEstadosTodos() 
        {
            return new ComandoObtenerTodosLosEstados();
        }

        public static Comando<string, List<string>> ObtenerComandoCiudadesTodas() 
        {
            return new ComandoObtenerTodasLasCiudades();
        }

        public static Comando<string, List<string>> ObtenerComandoCiudadesDeEstado() 
        {
            return new ComandoCambioEstado();    
        }

        public static Comando<string, List<Entidad>> ObtenerComandoCargarGVProveedores()
        {
            return new ComandoCargarGVProveedores();
        }

        public static Comando<int, bool> ObtenerComandoEliminarProveedor()
        {
            return new ComandoEliminarProveedor();
        }

        public static Comando<Entidad, bool> ObtenerComandoModificarProveedor()
        {
            return new ComandoModificarProveedor();
        }

        #endregion

        #region ReportesFinancierosExportacion
        public static Comando<int,DataTable> ObtenerComandoReporteTabla()
            {
                return new ComandoReporteTabla();
            }
        public static Comando<string[], DataTable> ObtenerComandoReporteTablaConParametros()
        {
            return new ComandoReporteTablaConParametros();
        }
        public static Comando<int, string> ObtenerComandoReporteUsuariosGrafica()
        {
            return new ComandoReporteUsuariosGrafica();
        }
        public static Comando<int, string> ObtenerComandoReporteRolesGrafica()
        {
            return new ComandoReporteRolesGrafica();
        }
        public static Comando<int, string> ObtenerComandoReporteProveedoresGrafica()
        {
            return new ComandoReporteProveedoresGrafica();
        }
        public static Comando<int, string> ObtenerComandoReporteProductosGrafica()
        {
            return new ComandoReporteProductosGrafica();
        }
        public static Comando<string[], string> ObtenerComandoReporteMembresiasGrafica()
        {
            return new ComandoReporteMembresiasGrafica();
        }
        public static Comando<string[], string> ObtenerComandoReporteSombrillaGrafica()
        {
            return new ComandoReporteSombrillaGrafica();
        }
        public static Comando<string[], string> ObtenerComandoReporteRestauranteGrafica()
        {
            return new ComandoReporteRestauranteGrafica();
        }
        public static Comando<string[], string> ObtenerComandoReporteServicioGrafica()
        {
            return new ComandoReporteServicioGrafica();
        }
        public static Comando<string[], string> ObtenerComandoReporteEstacionamientoGrafica()
        {
            return new ComandoReporteEstacionamientoGrafica();
        }
        public static Comando<string[], string> ObtenerComandoReporteComidaGrafica()
        {
            return new ComandoReporteComidaGrafica();
        }
        public static Comando<string[], string> ObtenerComandoReporteBebidaGrafica()
        {
            return new ComandoReporteBebidaGrafica();
        }
        #endregion

        #region ReservasSombrillasServiciosPlaya
        public static Comando<Entidad, List<Entidad>> ObtenerComandoConsultarReserva()
        {
            return new ComandoConsultarReserva();
        }

        public static Comando<int, List<Entidad>> ObtenerComandoConsultarReservaPuesto()
        {
            return new ComandoConsultarReservaPuesto();
        }

        public static Comando<int, Entidad> ObtenerComandoConsultarReservaServicio()
        {
            return new ComandoConsultarReservaServicio();
        }

        public static Comando<int, Entidad> ObtenerComandoConsultarReservaX()
        {
            return new ComandoConsultarReservaX();
        }

        public static Comando<Entidad, Boolean> ObtenerComandoModificarReserva()
        {
            return new ComandoModificarReserva();
        }
        #endregion

        #region RolesSeguridad

        /// <summary>
        /// Metodo para la fabrica del ComandoLlenarGridAcciones 
        /// </summary>
        /// <returns>el comando</returns>
        public static Comando<bool, List<Entidad>> ObtenerComandoLlenarGridAcciones()
        {
            return new ComandoLlenarGridAcciones();
        }

        /// <summary>
        /// Metodo para la fabrica del ComandoLlenarGridRoles 
        /// </summary>
        /// <returns>el comando</returns>
        public static Comando<bool, List<Entidad>> ObtenerComandoLlenarGridRoles()
        {
            return new ComandoLlenarGridRoles();
        }

        /// <summary>
        /// Metodo para la fabrica del ComandoEliminarRol 
        /// </summary>
        /// <returns>el comando</returns>
        public static Comando<int, bool> ObtenerComandoEliminarRol()
        {
            return new ComandoEliminarRol();
        }

        /// <summary>
        /// Metodo para la fabrica del ComandoObtenerRolActual 
        /// </summary>
        /// <returns>el comando</returns>
        public static Comando<int, Entidad> ObtenerComandoObtenerRolActual()
        {
            return new ComandoObtenerRolActual();
        }

        /// <summary>
        /// Metodo para la fabrica del ComandoListaString 
        /// </summary>
        /// <returns>el comando</returns>
        public static Comando<List<Entidad>, List<string>> ObtenerComandoListaString()
        {
            return new ComandoListaString();
        }

        /// <summary>
        /// Metodo para la fabrica del ComandoModificarRol 
        /// </summary>
        /// <returns>el comando</returns>
        public static Comando<Entidad, bool> ObtenerComandoModificarRol()
        {
            return new ComandoModificarRol();
        }

        /// <summary>
        /// Metodo para la fabrica del ComandoVerificarRol 
        /// </summary>
        /// <returns>el comando</returns>
        public static Comando<string, bool> ObtenerComandoVerificarRol()
        {
            return new ComandoVerificarRol();
        }

        /// <summary>
        /// Metodo para la fabrica del ComandoAgregarRol 
        /// </summary>
        /// <returns>el comando</returns>
        public static Comando<Entidad, bool> ObtenerComandoAgregarRol()
        {
            return new ComandoAgregarRol();
        }

        /// <summary>
        /// Metodo para la fabrica del ComandoListaIdsAccionesUsuario
        /// </summary>
        /// <returns>el comando</returns>
        public static Comando<string, Menu> ObtenerComandoObtenerMenuMaster()
        {
            return new ComandoObtenerMenuMaster();
        }

        /// <summary>
        /// Metodo para la fabrica del ComandoListaUrlAccionesUsuario
        /// </summary>
        /// <returns>el comando</returns>
        public static Comando<string, List<string>> ObtenerComandoListaURLAccionesUsuario()
        {
            return new ComandoListaUrlAccionesUsuario();
        }

        /// <summary>
        /// Metodo para la fabrica del ComandoListaAccionesUsuario
        /// </summary>
        /// <returns>el comando</returns>
        public static Comando<string, List<string>> ObtenerComandoListaAccionesUsuario()
        {
            return new ComandoListaAccionesUsuario();
        }

        #endregion

        #region UsuariosInternos
		
		public static Comando<int, Entidad> ObtenerComandoConsultarEmpleadoXId()
        {
            return new ComandoConsultarEmpleadoXId();
        }

        public static Comando<int, List<string>> ObtenerComandoConsultarRolesEmpleado() 
        {
            return new ComandoConsultarRolesEmpleado(); 
        }

        public static Comando<Entidad, bool> ObtenerComandoModificarEmpleado() 
        {
            return new ComandoModificarEmpleado(); 
        }

        public static Comando<Entidad, bool> ObtenerComandoModificarPerfilEmpleado() 
        {
            return new ComandoModificarPerfilEmpleado(); 
        }

        public static Comando<bool, List<Entidad>> ObtenerComandoLlenarCBPais() 
        {
            return new ComandoLlenarCBPaises(); 
        }

        public static Comando<int, List<Entidad>> ObtenerComandoLlenarCBEstado() 
        {
            return new ComandoLlenarCBEstado(); 
        }

        public static Comando<int, List<Entidad>> ObtenerComandoLlenarCBCiudad() 
        {
            return new ComandoLlenarCBCiudad(); 
        }

        public static Comando<int, string> ObtenerComandoObtenerDireccion() 
        {
            return new ComandoObtenerDireccionBD(); 
        }

        public static Comando<int, List<int>> ObtenerComandoConsultarDireccionCompleta() 
        {
            return new ComandoConsultarDireccionCompleta(); 
        }

        public static Comando<bool, List<Entidad>> ObtenerComandoLlenarCBEstatusUsuario() 
        {
            return new ComandoLlenarCBEstatusUsuario(); 
        }

        #endregion

        #region VentaCierreCaja
            public static Comando<int, string> ObtenerComandoConsultarCorreos()
            {
                return new ComandoConsultarCorreos();
            }

            public static Comando<string, Entidad> ObtenerComandoVerificarCorreo()
            {
                return new ComandoValidarCorreo();
            }

            public static Comando<string, List<Entidad>> ObtenerComandoObtenerServicio()
            {
                return new ComandoObtenerServicios();
            }


            public static Comando<string[], Entidad> ObtenerComandoCerrarCajaDiario()
            {
                return new ComandoCerrarCajaDiario();
            }

            public static Comando<string[], Entidad> ObtenerComandoCerrarCajaMensual()
            {
                return new ComandoCerrarCajaMensual();
            }

            public static Comando<string[], DataTable> ObtenerComandoConsultarFactura()
            {
                return new ComandoConsultarFactura();
            }

            public static Comando<string, int> ObtenerComandoEliminarFactura()
            {
                return new ComandoEliminarFactura();
            }

            public static Comando<int, Entidad> ObtenerComandoConsultarDatosBasicosFactura()
            {
                return new ComandoConsultarDatosBasicosFactura();
            }

            public static Comando<int, Entidad> ObtenerComandoConsultarClienteFactura()
            {
                return new ComandoConsultarClienteFactura();
            }

            public static Comando<int, DataTable> ObtenerComandoConsultarLineaFactura()
            {
                return new ComandoConsultarLineaFactura();
            }

        
        #endregion
    }
}