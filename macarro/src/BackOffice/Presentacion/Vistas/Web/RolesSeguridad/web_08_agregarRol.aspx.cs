using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.RolesSeguridad
{
    public partial class Agregar_Rol : System.Web.UI.Page
    {
        #region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    cargarInfo();
            //    variableSesion();
            //}
        }

        /// <summary>
        /// Metodo para cargar las variables de sesion
        /// </summary>
        private void variableSesion()
        {
            try
            {
                _correoS = (string)(Session["correo"]);
                _docIdentidadS = (string)(Session["docIdentidad"]);
                _primerNombreS = (string)(Session["primerNombre"]);
                _primerApellidoS = (string)(Session["primerApellido"]);
            }
            catch (Exception ex)
            {
                MensajeErrores.Text = "No se han podido cargar los datos de sesion";
                MensajeErrores.Visible = true;
                ex.GetType();
            }
        }

        /// <summary>
        /// Metodo para cargar las acciones disponibles
        /// </summary>
        private void cargarInfo()
        {
            //try
            //{
            //    foreach (Accion a in ControlRolAccion.listaGeneralAcciones())
            //    {
            //        ListaAccionesDisponibles.Items.Add(a.Nombre);
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    MensajeErrores.Text = "No se han podido cargar los datos debido a que existe un conflicto con la conexión a la base de datos";
            //    MensajeErrores.Visible = true;
            //    ex.GetType();
            //}
            //catch (Exception ex)
            //{
            //    MensajeErrores.Text = "No se han podido cargar los datos. Error " + ex.GetType().ToString();
            //    MensajeErrores.Visible = true;
            //}

        }

        /// <summary>
        /// Metodo para manejar elvento del boton aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Aceptar_Click(object sender, EventArgs e)
        {
        //    try
        //    {
        //        if (!ControlRolAccion.verificarRol(TextBoxNombre.Text))
        //        {
        //            MensajeErrores.Visible = false;
        //            ControlRolAccion.agregarRol(TextBoxNombre.Text, TextBoxDescripcion.Text, ListaAccionesDisponibles);

        //            MensajeExitoso.Text = "El ítem ha sido creado satisfactoriamente";
        //            MensajeExitoso.Visible = true;
        //        }
        //        else
        //        {
        //            MensajeErrores.Text = "Este rol ya está registrado en el sistema";
        //            MensajeErrores.Visible = true;
        //        }
        //    }
        //    catch (ExcepcionListAccionVacia ex)
        //    {
        //        MensajeErrores.Text = ex.Message;
        //        MensajeErrores.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MensajeErrores.Text = "No se han podido cargar los datos. Error " + ex.GetType().ToString();
        //        MensajeErrores.Visible = true;
        //    }
        }

        /// <summary>
        /// Metodo para manejar elvento del boton de agregar accion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void agregar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (ListaAccionesDisponibles.SelectedIndex != -1)
                {
                    MensajeErrores.Visible = false;
                    ListaAccionesAsignadas.Items.Add(ListaAccionesDisponibles.SelectedItem);
                    ListaAccionesDisponibles.Items.RemoveAt(ListaAccionesDisponibles.SelectedIndex);
                    ListaAccionesDisponibles.ClearSelection();
                    ListaAccionesAsignadas.ClearSelection();
                }
                else
                {
                    MensajeErrores.Text = "Seleccione un elemento a agregar";
                    MensajeErrores.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MensajeErrores.Text = "No se han podido cargar los datos. Error " + ex.GetType().ToString();
                MensajeErrores.Visible = true;
            }

        }

        /// <summary>
        /// Metodo para manejar elvento del boton de quitar accion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void quitar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (ListaAccionesAsignadas.SelectedIndex != -1)
                {
                    MensajeErrores.Visible = false;
                    ListaAccionesDisponibles.Items.Add(ListaAccionesAsignadas.SelectedItem);
                    ListaAccionesAsignadas.Items.RemoveAt(ListaAccionesAsignadas.SelectedIndex);
                    ListaAccionesAsignadas.ClearSelection();
                    ListaAccionesDisponibles.ClearSelection();
                }
                else
                {
                    MensajeErrores.Text = "Seleccione un elemento a eliminar";
                    MensajeErrores.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MensajeErrores.Text = "No se han podido cargar los datos. Error " + ex.GetType().ToString();
                MensajeErrores.Visible = true;
            }
        }


    }
}