using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.RolesSeguridad;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Dominio;
using BackOffice.Dominio.Fabrica;
using BackOffice.Dominio.Entidades;
using System.Linq;
using BackOffice.Excepciones.ExcepcionesComando.RolesSeguridad;
using BackOffice.Excepciones.ExcepcionesComando;
using BackOffice.Presentacion.Vistas.Web.RolesSeguridad.Recursos;
using BackOffice.Excepciones;

namespace BackOffice.Presentacion.Presentadores.RolesSeguridad
{
    public class Presentador_08_AgregarRol : PresentadorGeneral
    {
        private IContrato_08_AgregarRol _vista;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="vistaConsultarAcciones">Interfaz</param>
        public Presentador_08_AgregarRol(IContrato_08_AgregarRol vistaAgregarRol)
            : base(vistaAgregarRol)
        {
            _vista = vistaAgregarRol;
        }

        /// <summary>
        /// Metodo para llenar la informacion del rol seleccionado
        /// </summary>
        public void llenarInfo()
        {
            try
            {
                Comando<bool, List<Entidad>> ComandoObtenerGridAcciones;
                ComandoObtenerGridAcciones = FabricaComando.ObtenerComandoLlenarGridAcciones();

                Comando<List<Entidad>, List<string>> ComandoListaString;
                ComandoListaString = FabricaComando.ObtenerComandoListaString();

                foreach (string a in ComandoListaString.Ejecutar((ComandoObtenerGridAcciones.Ejecutar(true))))
                {
                    _vista.LBAccionesDisponibles.Items.Add(a);
                }
            }
            catch (ExcepcionComandoLlenarGridAcciones e)
            {
                _vista.LabelMensajeError.Visible = true;
                MostrarMensajeError(e.Mensaje);
                Logger.EscribirEnLogger(e);
            }
            catch (ExcepcionComandoListaString e)
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

        /// <summary>
        /// Metodo para manejar el evento del boton agregar
        /// </summary>
        /// <param name="ListaAccionesAsignadas">lista acciones asignadas</param>
        /// <param name="ListaAccionesDisponibles">lista acciones disponibles</param>
        public void EventoAgregar_Click()
        {
            _vista.LabelMensajeError.Visible = false;
            _vista.LBAccionesAsignadas.Items.Add(_vista.LBAccionesDisponibles.SelectedItem);
            _vista.LBAccionesDisponibles.Items.RemoveAt(_vista.LBAccionesDisponibles.SelectedIndex);
            _vista.LBAccionesDisponibles.ClearSelection();
            _vista.LBAccionesAsignadas.ClearSelection();
        }


        /// <summary>
        /// Metodo para manejar el evento del boton quitar
        /// </summary>
        /// <param name="ListaAccionesAsignadas">lista acciones asignadas</param>
        /// <param name="ListaAccionesDisponibles">lista acciones disponibles</param>
        public void EventoQuitar_Click()
        {
            _vista.LabelMensajeError.Visible = false;
            _vista.LBAccionesDisponibles.Items.Add(_vista.LBAccionesAsignadas.SelectedItem);
            _vista.LBAccionesAsignadas.Items.RemoveAt(_vista.LBAccionesAsignadas.SelectedIndex);
            _vista.LBAccionesAsignadas.ClearSelection();
            _vista.LBAccionesDisponibles.ClearSelection();
        }

        /// <summary>
        /// Metodo para manejar el evento del boton aceptar
        /// </summary>
        /// <param name="nombre">nombre rol</param>
        /// <param name="descripcion">descripcion rol</param>
        /// <param name="listaAcciones">lista de acciones</param>
        public bool EventoAceptar_Click()
        {
            _vista.LabelMensajeError.Visible = false;
            List<string> ls = new List<string>();

            try
            {
                if (_vista.LBAccionesAsignadas.Items.Count > 0)
                {

                    foreach (ListItem i in _vista.LBAccionesDisponibles.Items)
                    {
                        ls.Add(i.Text);
                    }

                    Entidad rol = FabricaEntidad.ObtenerRol();
                    ((Rol)rol).Nombre = _vista.TBNombre.Text;
                    ((Rol)rol).Descripcion = _vista.TBDescripcion.Text;

                    Comando<bool, List<Entidad>> ComandoObtenerGridAcciones;
                    ComandoObtenerGridAcciones = FabricaComando.ObtenerComandoLlenarGridAcciones();

                    List<Accion> listAcc = ComandoObtenerGridAcciones.Ejecutar(true).Cast<Accion>().ToList();
                    List<Accion> listAccNueva = new List<Accion>();

                    foreach (string i in ls)
                    {
                        Entidad ac = FabricaEntidad.ObtenerAccion();
                        ((Accion)ac).Nombre = i;
                        listAccNueva.Add((Accion)ac);
                    }

                    foreach (Accion a in listAccNueva)
                    {
                        listAcc.RemoveAll(delegate(Accion ac)
                        {
                            if (ac.Nombre == a.Nombre)
                                return true;
                            else
                                return false;
                        });
                    }

                    ((Rol)rol).Acciones = listAcc;

                    Comando<Entidad, bool> ComandoAgregarRol;
                    ComandoAgregarRol = FabricaComando.ObtenerComandoAgregarRol();
                    return ComandoAgregarRol.Ejecutar(rol);
                }
                else
                {
                    _vista.LabelMensajeError.Visible = true;
                    MostrarMensajeError(RecursosInterfazRolesSeguridad.mensajeElemento);
                }
            }

            catch (ExcepcionComandoLlenarGridAcciones e)
            {
                _vista.LabelMensajeError.Visible = true;
                MostrarMensajeError(e.Mensaje);
                Logger.EscribirEnLogger(e);
            }
            catch (ExcepcionComandoAgregarRol e)
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
            return false;
        }


        /// <summary>
        /// Metodo para verificar si el rol existe
        /// </summary>
        /// <param name="nombre">nombre rol</param>
        /// <returns></returns>
        public bool VerificarRol(string nombre)
        {
            try
            {
                Comando<string, bool> ComandoVerificarRol;
                ComandoVerificarRol = FabricaComando.ObtenerComandoVerificarRol();

                return ComandoVerificarRol.Ejecutar(nombre);
            }
            catch (ExcepcionComandoVerificarRol e)
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
            return false;
        }
    }

}