using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI.WebControls;
using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.Excepciones.ExcepcionesComando;
using BackOffice.Excepciones.ExcepcionesComando.IngresoRecuperacionClave;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Presentacion.Contratos.IngresoRecuperacionClave;

namespace BackOffice.Presentacion.Presentadores.IngresoRecuperacionClave
{
    public class Presentador_01_inicioSesionA : PresentadorGeneral
    {
        private IContrato_01_inicioSesionA _contratoInicioSesion;

        //Constructor
        public Presentador_01_inicioSesionA(IContrato_01_inicioSesionA _contratoInicioSesion)
            : base(_contratoInicioSesion)
        {
            this._contratoInicioSesion = _contratoInicioSesion;
            // aquí se fabrica la instanciación
        }

        public void Boton_IniciarSesion()
        {
            // Se procede con el inicio de Sesión
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

                BackOffice.Dominio.Entidades.Hash hash = new BackOffice.Dominio.Entidades.Hash();

                _contrasenaHash = hash.ObtenerMd5Hash(_contrasena);

                usuarioEntrante = FabricaEntidad.ObtenerUsuarioInicio(_correo, _contrasenaHash);

                comandoVerificarDatos = FabricaComando.obtenerComandoUsuarioInicio();

                comandoVerificarDatosPersona = FabricaComando.obtenerComandoPersonaInicio();

                usuarioResultante = comandoVerificarDatos.Ejecutar(usuarioEntrante);

                personaResultante = comandoVerificarDatosPersona.Ejecutar(usuarioEntrante);

                personaRetornada = (Persona)personaResultante;

                usuarioRetornado = (Usuario)usuarioResultante;
                

                if (personaRetornada.Nombre != string.Empty && usuarioRetornado.Correo != string.Empty)
                {

                    // Inicialización de variables de sesión
                    HttpContext.Current.Session["correo"] = usuarioRetornado.Correo;
                    HttpContext.Current.Session["docIdentidad"] = personaRetornada.Cedula;
                    HttpContext.Current.Session["primerNombre"] = personaRetornada.Nombre;
                    HttpContext.Current.Session["primerApellido"] = personaRetornada.Apellido;

                    //
                    #region Roles y Seguridad
                    Comando<string, List<string>> ComandoListaAccionesUsuario;
                    ComandoListaAccionesUsuario = FabricaComando.ObtenerComandoListaAccionesUsuario();

                    Comando<string, List<string>> ComandoListaUrlAccionesUsuario;
                    ComandoListaUrlAccionesUsuario = FabricaComando.ObtenerComandoListaURLAccionesUsuario();

                    Comando<string, Menu> ComandoObtenerMenuMaster;
                    ComandoObtenerMenuMaster = FabricaComando.ObtenerComandoObtenerMenuMaster();

                    // modificación del usuario cableado...
                    HttpContext.Current.Session["menu"] = ComandoObtenerMenuMaster.Ejecutar(usuarioRetornado.Correo);
                    HttpContext.Current.Session["acciones"] = ComandoListaAccionesUsuario.Ejecutar(usuarioRetornado.Correo);
                    HttpContext.Current.Session["urls"] = ComandoListaUrlAccionesUsuario.Ejecutar(usuarioRetornado.Correo);

                    #endregion
                    //
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
                    //HttpContext.Current.Response.Write("Correo o Contraseña invalido");
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
    }
}