using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace back_office.Interfaz.web.ReservasSombrillasServiciosPlaya
{
    public partial class web_07_gestionarReservas : System.Web.UI.Page
    {
        DataTable _tabla;
        protected void Page_Load(object sender, EventArgs e)
        {
            _tabla = new DataTable();

            _tabla.Columns.Add("Nombre", typeof(string));
            _tabla.Columns.Add("Cedula", typeof(string));
            _tabla.Columns.Add("Acciones", typeof(string));

            _tabla.Rows.Add("Andreina Betancourt", "17.555.666");
            _tabla.Rows.Add("Carlos Ayala", "11.222.333");
            _tabla.Rows.Add("Jorge Gomez", "18.222.666");
            _tabla.Rows.Add("Andreina Betancourt", "17.555.666");
            _tabla.Rows.Add("Carlos Ayala", "11.222.333");

            GridViewUsuario.DataSource = _tabla;
            GridViewUsuario.DataBind();
        }

        protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
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

                e.Row.Cells[2].Controls.Add(editar);
                e.Row.Cells[2].Controls.Add(eliminar);
            }
        }

        void editarBtn_Click(Object sender, ImageClickEventArgs e)
        {
            Response.Redirect("web_07_confirmacionReserva.aspx");
        }

        void eliminarBtn_Click(Object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../inicio.aspx");
        }

        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_07_confirmacionReserva.aspx");
        }

    }
}