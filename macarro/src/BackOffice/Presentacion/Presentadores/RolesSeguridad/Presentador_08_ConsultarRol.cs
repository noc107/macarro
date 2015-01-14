using System;
using System.Collections.Generic;
using BackOffice.Presentacion.Contratos.RolesSeguridad;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Excepciones.ExcepcionesComando.RolesSeguridad;
using BackOffice.Excepciones.ExcepcionesComando;
using BackOffice.Excepciones;

namespace BackOffice.Presentacion.Presentadores.RolesSeguridad
{
    public class Presentador_08_ConsultarRol : PresentadorGeneral
    {

        private IContrato_08_ConsultarRol _vista;
        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="vistaConsultarAcciones">Interfaz</param>
        public Presentador_08_ConsultarRol(IContrato_08_ConsultarRol vistaConsultarRol)
            : base(vistaConsultarRol)
        {
            _vista = vistaConsultarRol;
        }

        /// <summary>
        /// Metodo para llenar la informacion del rol seleccionado
        /// </summary>
        public void llenarInfo(int rol)
        {
            try
            {
                Comando<int, Entidad> ComandoObtenerRolActual;
                ComandoObtenerRolActual = FabricaComando.ObtenerComandoObtenerRolActual();
                Entidad RolActual = ComandoObtenerRolActual.Ejecutar(rol);

                _vista.LNombre.Text = ((Rol)RolActual).Nombre;
                _vista.LDescripcion.Text = ((Rol)RolActual).Descripcion;

                foreach (Accion a in ((Rol)RolActual).Acciones)
                {
                    _vista.LBAcciones.Items.Add(a.Nombre);

                }
            }
            catch (ExcepcionComandoObtenerRolActual e)
            {
                _vista.LabelMensajeError.Visible = true;
                MostrarMensajeError(e.Mensaje);
                Logger.EscribirEnLogger(e);
            }
            catch (ExcepcionComando e)
            {
                _vista.LabelMensajeError.Visible = true;
                MostrarMensajeError(e.Mensaje);
                Logger.EscribirEnLogger(e);
            }

        }
    
    }
}