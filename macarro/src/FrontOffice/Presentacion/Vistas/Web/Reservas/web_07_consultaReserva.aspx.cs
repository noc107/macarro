using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Vistas.Web.Reservas
{

    public partial class web_07_consultaReserva : System.Web.UI.Page
    {
        DataTable _tabla;
        protected void Page_Load(object sender, EventArgs e)
        {
            //_tabla = new DataTable();

            //_tabla.Columns.Add("Nombre", typeof(string));
            //_tabla.Columns.Add("Cantidad de Reserva", typeof(string));
            //_tabla.Columns.Add("Fecha", typeof(string));
            //_tabla.Columns.Add("Hora Inicio", typeof(string));
            //_tabla.Columns.Add("Hora Fin", typeof(string));
            //_tabla.Columns.Add("Costo", typeof(string));
            //_tabla.Columns.Add("Acciones", typeof(string));


            //_tabla.Rows.Add("Moto de Agua", "2", "22/12/2014", "2:00pm", "4:00pm", "500$");
            //_tabla.Rows.Add("Tumbona", "2", "22/12/2014", "2:00pm", "4:00pm", "500$");
            //_tabla.Rows.Add("Banana", "2", "22/12/2014", "2:00pm", "4:00pm", "500$");
            //_tabla.Rows.Add("Raquetas de Playa", "2", "22/12/2014", "2:00pm", "4:00pm", "500$");
            //_tabla.Rows.Add("Lancha", "2", "22/12/2014", "2:00pm", "4:00pm", "500$");
            //_tabla.Rows.Add("Pelota", "2", "22/12/2014", "2:00pm", "4:00pm", "500$");

            //GridViewUsuario1.DataSource = _tabla;
            //GridViewUsuario1.DataBind();
        }

        protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //    ImageButton editar = new ImageButton();
            //    editar.ID = "bEditar";
            //    editar.ImageUrl = "../../../comun/resources/img/Data-Edit-128.png";
            //    editar.Height = 50;
            //    editar.Width = 50;
            //    editar.Click += new ImageClickEventHandler(this.editarBtn_Click);

            //    ImageButton eliminar = new ImageButton();
            //    eliminar.ID = "bEliminar";
            //    eliminar.ImageUrl = "../../../comun/resources/img/Garbage-Closed-128.png";
            //    eliminar.Height = 50;
            //    eliminar.Width = 50;
            //    eliminar.Click += new ImageClickEventHandler(this.eliminarBtn_Click);
            //    eliminar.OnClientClick ="return confirm('Esta acción eliminará el ítem permanentemente del sistema ¿desea continuar?')";

            //    e.Row.Cells[6].Controls.Add(editar);
            //    e.Row.Cells[6].Controls.Add(eliminar);
            //}
        }

        void eliminarBtn_Click(Object sender, ImageClickEventArgs e)
        {
            Response.Redirect("web_07_consultaReserva.aspx");
        }

        void editarBtn_Click(Object sender, ImageClickEventArgs e)
        {
            Response.Redirect("web_07_modificarReserva.aspx");
        }

    }
}