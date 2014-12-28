using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionEstacionamientos
{
    public partial class web_5_gestionarEstacionamiento : System.Web.UI.Page
    {
        //List<Estacionamiento> _listaEstacionamiento = new List<Estacionamiento>();
        #region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //variableSesion();
            //String _campoNombre = textBoxNombre.Text.ToString();
            //String _estatus = DropDown_estatus.SelectedItem.ToString();
            //if (_campoNombre != "" && _estatus == "Seleccione")
            //{
            //    LimpiarGridView();
            //    busquedaPorNombre(_campoNombre);

            //}

            //else if (_estatus != "Seleccione" && _campoNombre == "") 
            //{
            //    LimpiarGridView();
            //    busquedaPorEstatus(_estatus);
            //}
            //else
            //{
            //    LogicaEstacionamiento solicitudLogica = new LogicaEstacionamiento();
            //    _listaEstacionamiento = solicitudLogica.solicitarServicio_ConsultarEstacionamiento();

            //    this.My_GV.DataSource = _listaEstacionamiento;
            //    this.My_GV.DataBind();
            //}
               
        }

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
                //MensajeErrores.Text = "No se han podido cargar los datos de sesion";
                //MensajeErrores.Visible = true;
                ex.GetType();
            }
        }

        private void LimpiarGridView()
        {

            this.My_GV.DataSource = null;
            My_GV.DataBind();

        }

       //public void busquedaPorNombre(string _campoBusqueda)
       // {
       //     LogicaEstacionamiento solicitudLogica = new LogicaEstacionamiento();

       //     if (solicitudLogica.solicitarServicio_ConsultarEstacionamientoPorNombre(_campoBusqueda).Count == 0)
       //     {
       //         ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No hay Estacionamientos que Coincidan con la busqueda')", true);
       //         LimpiarGridView();
       //     }
       //     else
       //     {
       //         _listaEstacionamiento = solicitudLogica.solicitarServicio_ConsultarEstacionamientoPorNombre(_campoBusqueda);
       //         this.My_GV.DataSource = _listaEstacionamiento;
       //         this.My_GV.DataBind();
       //     }
       // }

       // public void busquedaPorEstatus(string _campoBusqueda)
       // {
       //     LogicaEstacionamiento solicitudLogica = new LogicaEstacionamiento();

       //     if (solicitudLogica.solicitarServicio_ConsultarEstacionamientoPorEstatus(_campoBusqueda).Count == 0)
       //     {
       //         ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No hay Estacionamientos con ese Estatus')", true);
       //         LimpiarGridView();
       //     }
       //     else
       //     {
       //         _listaEstacionamiento = solicitudLogica.solicitarServicio_ConsultarEstacionamientoPorEstatus(_campoBusqueda);
       //         this.My_GV.DataSource = _listaEstacionamiento;
       //         this.My_GV.DataBind();
       //     }
       // }

        protected void My_GV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
       //     if (e.Row.RowType == DataControlRowType.DataRow)
       //     {
       //         ImageButton consultar = new ImageButton();
       //         consultar.ID = "bConsultar";
       //         consultar.ImageUrl = "../../../comun/resources/img/View-128.png";
       //         consultar.Height = 50;
       //         consultar.Width = 50;
       //         consultar.Click += new ImageClickEventHandler(this.consultarBtn_Click);

       //         ImageButton editar = new ImageButton();
       //         editar.ID = "bEditar";
       //         editar.ImageUrl = "../../../comun/resources/img/Data-Edit-128.png";
       //         editar.Height = 50;
       //         editar.Width = 50;
       //         editar.Click += new ImageClickEventHandler(this.editarBtn_Click);

       //         ImageButton eliminar = new ImageButton();
       //         eliminar.ID = "bEliminar";
       //         eliminar.ImageUrl = "../../../comun/resources/img/Garbage-Closed-128.png";
       //         eliminar.Height = 50;
       //         eliminar.Width = 50;
       //         eliminar.Click += new ImageClickEventHandler(this.eliminarBtn_Click);

       //         e.Row.Cells[5].Controls.Add(consultar);
       //         e.Row.Cells[5].Controls.Add(editar);
       //         e.Row.Cells[5].Controls.Add(eliminar);
       //     }
        }

       // void consultarBtn_Click(Object sender, ImageClickEventArgs e)
       // {
       //     ImageButton img = (ImageButton)sender;
       //     GridViewRow row = (GridViewRow)img.Parent.Parent;

       //     Estacionamiento estacionamiento = _listaEstacionamiento[row.RowIndex];
       //     String id = estacionamiento.Id.ToString();
       //     Response.Redirect("web_5_consultarEstacionamiento.aspx?id=" + id);
       // }

       // void editarBtn_Click(Object sender, ImageClickEventArgs e)
       // {
       //     ImageButton img = (ImageButton)sender;
       //     GridViewRow row = (GridViewRow)img.Parent.Parent;

       //     Estacionamiento estacionamiento = _listaEstacionamiento[row.RowIndex];
       //     String id = estacionamiento.Id.ToString();
       //     Response.Redirect("web_5_editarEstacionamiento.aspx?id=" + id);
       // }

       // void eliminarBtn_Click(Object sender, ImageClickEventArgs e)
       // {
       //     if (ControlRolAccion.listaAcciones(_correoS).Contains("Eliminar estacionamiento"))
       //     {
       //         ImageButton img = (ImageButton)sender;
       //         GridViewRow row = (GridViewRow)img.Parent.Parent;

       //         Estacionamiento estacionamiento = _listaEstacionamiento[row.RowIndex];
       //         String id = estacionamiento.Id.ToString();

       //         LogicaEstacionamiento solicitudLogica = new LogicaEstacionamiento();
       //         solicitudLogica.solicitarServicio_cambiarEstadoEstacionamiento(int.Parse(id), "Desactivado");
       //         //Response.Redirect("../inicio.aspx");
       //     }
       //     else
       //     {
       //         //MensajeErrores.Text = "No posee los perminsos para eliminar el ítem";
       //         //MensajeErrores.Visible = true;
       //     }
       // }

        protected void BotonAgregarEstacionamiento_Click(object sender, EventArgs e)
        {

       //     if (listaDeOpciones.SelectedValue == "0")
       //     {
       //         //  TODO
       //     }

       //     if (listaDeOpciones.SelectedValue == "1")
       //     {
       //         //  FILTRO POR NOMBRE
       //         LogicaEstacionamiento solicitudLogica = new LogicaEstacionamiento();
       //         _listaEstacionamiento = solicitudLogica.solicitarServicio_ConsultarEstacionamientoPorNombre(textBoxNombre.Text);
       //     }

       //     if (listaDeOpciones.SelectedValue == "2")
       //     {
       //         //  FILTRO POR ESTATUS [DropDown_estatus]
       //         LogicaEstacionamiento solicitudLogica = new LogicaEstacionamiento();
       //         _listaEstacionamiento = solicitudLogica.solicitarServicio_ConsultarEstacionamientoPorEstatus(DropDown_estatus.Text);
       //     }
            
       //     this.My_GV.DataSource = _listaEstacionamiento;
       //     this.My_GV.DataBind();

        }

        protected void GVAccion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

       //     My_GV.PageIndex = e.NewPageIndex;
       //     My_GV.DataSource = _listaEstacionamiento;
        } 

        protected void validar_entrada(object sender, EventArgs e)
        {
       //     if (listaDeOpciones.SelectedValue == "0")
       //     {
       //         fila_nombre.Enabled = false;
       //         fila_estado.Enabled = false;
       //         fila_nombre.Visible = false;
       //         fila_estado.Visible = false;
       //         anti_salto.Visible = true;
                
       //     }
            
       //     if (listaDeOpciones.SelectedValue == "1")
       //     {
       //         fila_nombre.Enabled = true;
       //         fila_estado.Enabled = false;
       //         fila_nombre.Visible = true;
       //         fila_estado.Visible = false;
       //         anti_salto.Visible = false;

       //     }

       //     if (listaDeOpciones.SelectedValue == "2")
       //     {
       //         fila_nombre.Enabled = false;
       //         fila_estado.Enabled = true;
       //         fila_nombre.Visible = false;
       //         fila_estado.Visible = true;
       //         anti_salto.Visible = false;
       //     }
        }
    }
}