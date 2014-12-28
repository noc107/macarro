using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace BackOffice.Presentacion.Vistas.Web.RolesSeguridad
{
    public partial class web_08_editarRol : System.Web.UI.Page
    {
        string rolN;
        #region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
        //    if (ControlRolAccion.RolActual != null)
        //    {
        //        if (!Page.IsPostBack)
        //        {
        //            cargarInfo();
        //            variableSesion();
        //        }
        //        rolN = ControlRolAccion.RolActual.Nombre;
        //    }
        //    else
        //    {
        //        Response.Redirect("web_08_gestionarRoles.aspx");
        //    }
        }

        /// <summary>
        /// Metodo para cargar las variables de sesion
        /// </summary>
        //private void variableSesion()
        //{
        //    try
        //    {
        //        _correoS = (string)(Session["correo"]);
        //        _docIdentidadS = (string)(Session["docIdentidad"]);
        //        _primerNombreS = (string)(Session["primerNombre"]);
        //        _primerApellidoS = (string)(Session["primerApellido"]);
        //    }
        //    catch (Exception ex)
        //    {
        //        MensajeErrores.Text = "No se han podido cargar los datos de sesion";
        //        MensajeErrores.Visible = true;
        //        ex.GetType();
        //    }
        //}

        /// <summary>
        /// Metodo para cargar la informacion del rol seleccionado
        /// </summary>
        //private void cargarInfo()
        //{
        //    try
        //    {
        //        List<Accion> listAcc = ControlRolAccion.listaGeneralAcciones();

        //        tNombre.Text = ControlRolAccion.RolActual.Nombre;
        //        tDescripcion.Text = ControlRolAccion.RolActual.Descripcion;

        //        foreach (Accion a in ControlRolAccion.RolActual.Acciones)
        //        {
        //            ListaAccionesAsignadas.Items.Add(a.Nombre);
        //            listAcc.RemoveAll(delegate(Accion ac)
        //            {
        //                if (ac.Nombre == a.Nombre)
        //                    return true;
        //                else
        //                    return false;
        //            });
        //        }

        //        foreach (Accion a in listAcc)
        //        {
        //            ListaAccionesDisponibles.Items.Add(a.Nombre);
        //        }
        //    }
        //    catch (NullReferenceException ex)
        //    {
        //        MensajeErrores.Text = "No se han podido cargar los datos debido a que no hay un item seleccionado";
        //        MensajeErrores.Visible = true;
        //        ex.GetType();
        //    }
        //    catch (SqlException ex)
        //    {
        //        MensajeErrores.Text = "No se han podido cargar los datos debido a que existe un conflicto con la conexión a la base de datos";
        //        MensajeErrores.Visible = true;
        //        ex.GetType();
        //    }
        //    catch (Exception ex)
        //    {
        //        MensajeErrores.Text = "No se han podido cargar los datos. Error " + ex.GetType().ToString();
        //        MensajeErrores.Visible = true;
        //    }


        //}

        /// <summary>
        /// Metodo para manejar elvento del boton cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_08_gestionarRoles.aspx");
        }

        /// <summary>
        /// Metodo para manejar elvento del boton modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void aceptar_Click(object sender, EventArgs e)
        {

        //    try
        //    {
        //        if (rolN.Equals(tNombre.Text, StringComparison.OrdinalIgnoreCase) || !ControlRolAccion.verificarRol(tNombre.Text))
        //        {
        //            MensajeErrores.Visible = false;
        //            ControlRolAccion.modificarRol(tNombre.Text, tDescripcion.Text, ListaAccionesDisponibles);

        //            MensajeExitoso.Text = "El ítem ha sido modificado satisfactoriamente";
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
        //    try
        //    {
        //        if (ListaAccionesDisponibles.SelectedIndex != -1)
        //        {
        //            MensajeErrores.Visible = false;
        //            ListaAccionesAsignadas.Items.Add(ListaAccionesDisponibles.SelectedItem);
        //            ListaAccionesDisponibles.Items.RemoveAt(ListaAccionesDisponibles.SelectedIndex);
        //            ListaAccionesDisponibles.ClearSelection();
        //            ListaAccionesAsignadas.ClearSelection();
        //        }
        //        else
        //        {
        //            MensajeErrores.Text = "Seleccione un elemento a agregar";
        //            MensajeErrores.Visible = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MensajeErrores.Text = "No se han podido cargar los datos. Error " + ex.GetType().ToString();
        //        MensajeErrores.Visible = true;
        //    }

        }

        /// <summary>
        /// Metodo para manejar elvento del boton de quitar accion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void quitar_Click(object sender, ImageClickEventArgs e)
        {
        //    try
        //    {
        //        if (ListaAccionesAsignadas.SelectedIndex != -1)
        //        {
        //            MensajeErrores.Visible = false;
        //            ListaAccionesDisponibles.Items.Add(ListaAccionesAsignadas.SelectedItem);
        //            ListaAccionesAsignadas.Items.RemoveAt(ListaAccionesAsignadas.SelectedIndex);
        //            ListaAccionesAsignadas.ClearSelection();
        //            ListaAccionesDisponibles.ClearSelection();
        //        }
        //        else
        //        {
        //            MensajeErrores.Text = "Seleccione un elemento a eliminar";
        //            MensajeErrores.Visible = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MensajeErrores.Text = "No se han podido cargar los datos. Error " + ex.GetType().ToString();
        //        MensajeErrores.Visible = true;
        //    }
        }
    }

}