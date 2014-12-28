using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Vistas.Web.Reservas 
{
    public partial class web_07_consultaSombrilla : System.Web.UI.Page
    {
        DataTable _tabla;
        protected void Page_Load(object sender, EventArgs e)
        {
            //_tabla = new DataTable();

            //_tabla.Columns.Add("Puesto", typeof(string));
            //_tabla.Columns.Add("Fecha", typeof(string));
            //_tabla.Columns.Add("Hora Inicio", typeof(string));
            //_tabla.Columns.Add("Hora Fin", typeof(string));
            //_tabla.Columns.Add("Acciones", typeof(string));

            //_tabla.Rows.Add("1 - 2", "12/02/2014", "3:00pm", "3:10pm");
            //_tabla.Rows.Add("1 - 2", "12/02/2014", "3:00pm", "3:10pm");
            //_tabla.Rows.Add("1 - 2", "12/02/2014", "3:00pm", "3:10pm");
            //_tabla.Rows.Add("1 - 2", "12/02/2014", "3:00pm", "3:10pm");
            //_tabla.Rows.Add("1 - 2", "12/02/2014", "3:00pm", "3:10pm");

            //GridViewUsuario.DataSource = _tabla;
            //GridViewUsuario.DataBind();
        }

        protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //ImageButton editar = new ImageButton();
                //editar.ID = "bEditar";
                //editar.ImageUrl = "../../../comun/resources/img/Data-Edit-128.png";
                //editar.Height = 50;
                //editar.Width = 50;
                //editar.Click += new ImageClickEventHandler(this.editarBtn_Click);

                //ImageButton eliminar = new ImageButton();
                //eliminar.ID = "bEliminar";
                //eliminar.ImageUrl = "../../../comun/resources/img/Garbage-Closed-128.png";
                //eliminar.Height = 50;
                //eliminar.Width = 50;
                //eliminar.Click += new ImageClickEventHandler(this.eliminarBtn_Click);
                //eliminar.OnClientClick = "return confirm('Esta acción eliminará el ítem permanentemente del sistema ¿desea continuar?')";

                //e.Row.Cells[4].Controls.Add(editar);
                //e.Row.Cells[4].Controls.Add(eliminar);
            }
        }

        void editarBtn_Click(Object sender, ImageClickEventArgs e)
        {
            Response.Redirect("web_07_modificarSombrilla1.aspx");
        }

        void eliminarBtn_Click(Object sender, ImageClickEventArgs e)
        {
            Response.Redirect("web_07_consultaSombrilla.aspx");
        }

        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_07_confirmacionReserva.aspx");
        }

    }
}