using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace back_office.Interfaz.web.ReservasSombrillasServiciosPlaya
{
    public partial class web_07_confirmacionReserva : System.Web.UI.Page
    {
        DataTable _tabla;
        protected void Page_Load(object sender, EventArgs e)
        {
            _tabla = new DataTable();

            _tabla.Columns.Add("Nombre", typeof(string));
            _tabla.Columns.Add("Cantidad de Reserva", typeof(string));
            _tabla.Columns.Add("Fecha", typeof(string));
            _tabla.Columns.Add("Hora Inicio", typeof(string));
            _tabla.Columns.Add("Hora Fin", typeof(string));
            _tabla.Columns.Add("Costo", typeof(string));
            _tabla.Columns.Add("Confirmar", typeof(string));
            _tabla.Columns.Add("Acciones", typeof(string));

            _tabla.Rows.Add("Servicio", "2", "22/12/2014", "2:00pm", "4:00pm", "500$");
            _tabla.Rows.Add("Servicio", "2", "22/12/2014", "2:00pm", "4:00pm", "500$");
            _tabla.Rows.Add("Servicio", "2", "22/12/2014", "2:00pm", "4:00pm", "500$");
            _tabla.Rows.Add("Servicio", "2", "22/12/2014", "2:00pm", "4:00pm", "500$");
            _tabla.Rows.Add("Servicio", "2", "22/12/2014", "2:00pm", "4:00pm", "500$");
            _tabla.Rows.Add("Servicio", "2", "22/12/2014", "2:00pm", "4:00pm", "500$");

            GridViewUsuario.DataSource = _tabla;
            GridViewUsuario.DataBind();
        }

        protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox check = new CheckBox();
                check.ID = "cCheck";

                ImageButton editar = new ImageButton();
                editar.ID = "bEditar";
                editar.ImageUrl = "../../../comun/resources/img/Data-Edit-128.png";
                editar.Height = 50;
                editar.Width = 50;
                editar.Click += new ImageClickEventHandler(this.editarBtn_Click);


                ImageButton eliminar = new ImageButton();
                eliminar.ID = "bEliminar";
                eliminar.ImageUrl = "../../../comun/resources/img/Garbage-Closed-128.png";
                eliminar.Height = 50;
                eliminar.Width = 50;
                eliminar.Click += new ImageClickEventHandler(this.eliminarBtn_Click);
                eliminar.OnClientClick = "return confirm('Esta acción eliminará el ítem permanentemente del sistema ¿desea continuar?')";

                e.Row.Cells[6].Controls.Add(check);
                e.Row.Cells[7].Controls.Add(editar);
                e.Row.Cells[7].Controls.Add(eliminar);
            }
        }

        void editarBtn_Click(Object sender, ImageClickEventArgs e)
        {
            Response.Redirect("web_07_editarReserva.aspx");
        }

        void eliminarBtn_Click(Object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../inicio.aspx");
        }

        protected void botonAceptar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("web_07_confirmacionReserva.aspx");
        }


    }
}