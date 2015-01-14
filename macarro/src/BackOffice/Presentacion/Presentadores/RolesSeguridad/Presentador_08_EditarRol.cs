using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.RolesSeguridad;
using BackOffice.Dominio;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using System.Linq;
using BackOffice.Excepciones.ExcepcionesComando.RolesSeguridad;
using BackOffice.Excepciones.ExcepcionesComando;
using BackOffice.Presentacion.Vistas.Web.RolesSeguridad.Recursos;
using BackOffice.Excepciones;

namespace BackOffice.Presentacion.Presentadores.RolesSeguridad
{
    public class Presentador_08_EditarRol : PresentadorGeneral
    {

        private IContrato_08_EditarRol _vista;
        private static int idRol;

        /// <summary>
        /// Propiedad de idRol
        /// </summary>
        public static int IdRol
        {
            get { return idRol; }
            set { idRol = value; }
        }
        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="vistaConsultarAcciones">Interfaz</param>
        public Presentador_08_EditarRol(IContrato_08_EditarRol vistaEditarRol)
            : base(vistaEditarRol)
        {
            _vista = vistaEditarRol;
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
                IdRol = ((Rol)RolActual).Id;

                Comando<bool, List<Entidad>> ComandoObtenerGridAcciones;
                ComandoObtenerGridAcciones = FabricaComando.ObtenerComandoLlenarGridAcciones();

                Comando<List<Entidad>, List<string>> ComandoListaString;
                ComandoListaString = FabricaComando.ObtenerComandoListaString();


                _vista.TBNombre.Text = ((Rol)RolActual).Nombre;
                _vista.TBDescripcion.Text = ((Rol)RolActual).Descripcion;

                List<string> listAcc = ComandoListaString.Ejecutar((ComandoObtenerGridAcciones.Ejecutar(true)));

                foreach (Accion a in ((Rol)RolActual).Acciones)
                {
                    _vista.LBAccionesAsignadas.Items.Add(a.Nombre);

                    listAcc.RemoveAll(delegate(string ac)
                    {
                        if (ac == a.Nombre)
                            return true;
                        else
                            return false;
                    });
                }

                foreach (string a in listAcc)
                {
                    _vista.LBAccionesDisponibles.Items.Add(a);
                }
            }
            catch (ExcepcionComandoObtenerRolActual e)
            {
                _vista.LabelMensajeError.Visible = true;
                MostrarMensajeError(e.Mensaje);
                Logger.EscribirEnLogger(e);
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

                    Entidad rol = FabricaEntidad.ObtenerRol(IdRol, _vista.TBNombre.Text, _vista.TBDescripcion.Text, null);

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

                    Comando<Entidad, bool> ComandoModificarRol;
                    ComandoModificarRol = FabricaComando.ObtenerComandoModificarRol();
                    return ComandoModificarRol.Ejecutar(rol);
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
            catch (ExcepcionComandoModificarRol e)
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