using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontOffice.Dominio;
using FrontOffice.Dominio.Entidades;
using FrontOffice.Dominio.Fabrica;
using FrontOffice.Excepciones.ExcepcionesComando;
using FrontOffice.Excepciones.ExcepcionesComando.IngresoRecuperacionClave;
using FrontOffice.LogicaNegocio;
using FrontOffice.LogicaNegocio.Fabrica;
using FrontOffice.Presentacion.Contratos.IngresoRecuperacionClave;

namespace FrontOffice.Presentacion.Presentadores.IngresoRecuperacionClave
{
    public class Presentador_01_inicioSesion : PresentadorGeneral
    {
        private IContrato_01_inicioSesion _contratoInicioSesion;

        //Constructor
        public Presentador_01_inicioSesion(IContrato_01_inicioSesion _contratoInicioSesion)
            : base(_contratoInicioSesion)
        {
            this._contratoInicioSesion = _contratoInicioSesion;
        }

        public bool verificarDatos(string _correo, string _contrasena)
        {
            Usuario usuarioRetornado = (Usuario)FabricaEntidad.ObtenerUsuarioInicio();
            Persona personaRetornada = (Persona)FabricaEntidad.ObtenerPersonaInicio();
            try
            {
                Comando<Entidad, Entidad> comandoVerificarDatos;
                Comando<Entidad, Entidad> comandoVerificarDatosPersona;

                Entidad usuarioEntrante;

                // Usuario Resultante
                Entidad usuarioResultante = FabricaEntidad.ObtenerUsuarioInicio();

                // Persona Resultante
                Entidad personaResultante = FabricaEntidad.ObtenerPersonaInicio();

                string _contrasenaHash;

                Hash hash = new Hash();

                _contrasenaHash = hash.ObtenerMd5Hash(_contrasena);

                usuarioEntrante = FabricaEntidad.ObtenerUsuarioInicio(_correo, _contrasenaHash);

                comandoVerificarDatos = FabricaComando.obtenerComandoUsuarioInicio();

                comandoVerificarDatosPersona = FabricaComando.obtenerComandoPersonaInicio();

                usuarioResultante = comandoVerificarDatos.Ejecutar(usuarioEntrante);

                personaResultante = comandoVerificarDatosPersona.Ejecutar(usuarioEntrante);

                personaRetornada = (Persona)personaResultante;

                usuarioRetornado = (Usuario)usuarioResultante;

                if (personaRetornada.nombre != string.Empty && usuarioRetornado.Correo != string.Empty)
                {

                    // Inicialización de variables de sesión
                    HttpContext.Current.Session["correo"] = usuarioRetornado.Correo;
                    HttpContext.Current.Session["docIdentidad"] = personaRetornada.Cedula;
                    HttpContext.Current.Session["primerNombre"] = personaRetornada.nombre;
                    HttpContext.Current.Session["primerApellido"] = personaRetornada.apellido;

                    _contratoInicioSesion.LabelMensajeError.Visible = false;
                    _contratoInicioSesion.LabelMensajeExito.Visible = true;

                    HttpContext.Current.Response.Redirect("../inicio.aspx");

                    return true;

                }
                else
                {
                    MostrarMensajeError("El correo y/o la contraseña son incorrectos, Inténtalo nuevamente.");
                    _contratoInicioSesion.LabelMensajeExito.Visible = false;
                    _contratoInicioSesion.LabelMensajeError.Visible = true;
                    return false;
                }

            }
            catch (ExcepcionComandoPersona e)
            {
                _contratoInicioSesion.LabelMensajeExito.Visible = false;
                _contratoInicioSesion.LabelMensajeError.Visible = true;
                MostrarMensajeError(e.Mensaje);
                return false;
            }
            catch (ExcepcionComandoUsuario e)
            {
                _contratoInicioSesion.LabelMensajeExito.Visible = false;
                _contratoInicioSesion.LabelMensajeError.Visible = true;
                MostrarMensajeError(e.Mensaje);
                return false;
            }
            catch (ExcepcionComando e)
            {
                _contratoInicioSesion.LabelMensajeExito.Visible = false;
                _contratoInicioSesion.LabelMensajeError.Visible = true;
                MostrarMensajeError(e.Mensaje);
                return false;
            }
        }

        public void BOlvidasteContrasena_Click()
        {
            // Se procede con el caso de olvido de contraseña
        }

        
    }
}