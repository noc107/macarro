using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace BackOffice.Presentacion.Vistas.Web.RolesSeguridad
{
    public partial class web_08_gestionarRoles : System.Web.UI.Page
    {
        DataTable mytable = new DataTable();
        //ControlRolAccion cRA;
        #region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //loadDataTable();
            //variableSesion();
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
        /// Metodo para cargar la informacion del GridView
        /// </summary>
        //private void loadDataTable()
        //{
        //    try
        //    {
        //        MensajeErrores.Visible = false;
        //        cRA = new ControlRolAccion();
        //        mytable = cRA.llenarGridRoles();
        //        GVRol.DataSource = mytable;
        //        GVRol.DataBind();
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
        /// Metodo para manejar el evento de cambio de la paginacion del GridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GVRol_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GVRol.PageIndex = e.NewPageIndex;
                GVRol.DataSource = mytable;
                MensajeErrores.Visible = false;
            }
            catch (SqlException ex)
            {
                MensajeErrores.Text = "No se han podido cargar los datos debido a que existe un conflicto con la conexión a la base de datos";
                MensajeErrores.Visible = true;
                ex.GetType();
            }
            catch (Exception ex)
            {
                MensajeErrores.Text = "No se han podido cargar los datos. Error " + ex.GetType().ToString();
                MensajeErrores.Visible = true;
            }
        }

        /// <summary>
        /// Metodo para manejar el evento de la generacion de la data del GridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GVRol_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            ImageButton consultar = new ImageButton();
        //            consultar.ID = "bConsultar";
        //            consultar.ImageUrl = "../../../comun/resources/img/View-128.png";
        //            consultar.Height = 60;
        //            consultar.Width = 60;
        //            consultar.Click += new ImageClickEventHandler(this.consultarBtn_Click);

        //            ImageButton editar = new ImageButton();
        //            editar.ID = "bEditar";
        //            editar.ImageUrl = "../../../comun/resources/img/Data-Edit-128.png";
        //            editar.Height = 60;
        //            editar.Width = 60;
        //            editar.Click += new ImageClickEventHandler(this.editarBtn_Click);

        //            ImageButton eliminar = new ImageButton();
        //            eliminar.ID = "bEliminar";
        //            eliminar.ImageUrl = "../../../comun/resources/img/Garbage-Closed-128.png";
        //            eliminar.Height = 60;
        //            eliminar.Width = 60;
        //            eliminar.OnClientClick = "return confirm('Esta acción eliminará el ítem permanentemente del sistema ¿desea continuar?')";
        //            eliminar.Click += new ImageClickEventHandler(this.eliminarBtn_Click);

        //            e.Row.Cells[2].Controls.Add(consultar);
        //            e.Row.Cells[2].Controls.Add(editar);
        //            e.Row.Cells[2].Controls.Add(eliminar);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MensajeErrores.Text = "No se han podido cargar los datos. Error " + ex.GetType().ToString();
        //        MensajeErrores.Visible = true;
        //    }
        }

        /// <summary>
        /// Metodo para manejar elvento del boton consultar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void consultarBtn_Click(object sender, ImageClickEventArgs e)
        {
        //    try
        //    {
        //        ImageButton b = (ImageButton)sender;
        //        GridViewRow row = (GridViewRow)b.Parent.Parent;
        //        int i = row.DataItemIndex;

        //        ControlRolAccion.setRolActual(i);
        //        Response.Redirect("web_08_consultarRol.aspx");
        //    }
        //    catch (Exception ex)
        //    {
        //        MensajeErrores.Text = "No se han podido cargar los datos. Error " + ex.GetType().ToString();
        //        MensajeErrores.Visible = true;
        //    }
        }

        /// <summary>
        /// Metodo para manejar elvento del boton editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void editarBtn_Click(object sender, ImageClickEventArgs e)
        {
        //    try
        //    {
        //        ImageButton b = (ImageButton)sender;
        //        GridViewRow row = (GridViewRow)b.Parent.Parent;
        //        int i = row.DataItemIndex;

        //        ControlRolAccion.setRolActual(i);
        //        Response.Redirect("web_08_editarRol.aspx");
        //    }
        //    catch (Exception ex)
        //    {
        //        MensajeErrores.Text = "No se han podido cargar los datos. Error " + ex.GetType().ToString();
        //        MensajeErrores.Visible = true;
        //    }
        }

        /// <summary>
        /// Metodo para manejar elvento del boton eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void eliminarBtn_Click(object sender, ImageClickEventArgs e)
        {
        //    try
        //    {
        //        if (ControlRolAccion.listaAcciones(_correoS).Contains("Eliminar rol"))
        //        {

        //            ImageButton b = (ImageButton)sender;
        //            GridViewRow row = (GridViewRow)b.Parent.Parent;
        //            int i = row.DataItemIndex;

        //            ControlRolAccion.setRolActual(i);
        //            ControlRolAccion.eliminarRol();
        //            loadDataTable();
        //        }
        //        else
        //        {
        //            MensajeErrores.Text = "No posee los perminsos para eliminar el ítem";
        //            MensajeErrores.Visible = true;
        //        }
        //    }
        //    catch (ExcepcionFKRol ex)
        //    {
        //        MensajeErrores.Text = ex.Message;
        //        MensajeErrores.Visible = true;
        //    }

        //    catch (SqlException ex)
        //    {
        //        MensajeErrores.Text = "El ítem no ha podido ser eliminado debido a que  existe un conflicto con la conexión a la base de datos";
        //        MensajeErrores.Visible = true;
        //        ex.GetType();
        //    }
        //    catch (Exception ex)
        //    {
        //        MensajeErrores.Text = "El ítem no ha podido ser eliminado. Error " + ex.GetType().ToString();
        //        MensajeErrores.Visible = true;
        //    }
        }
    }
}