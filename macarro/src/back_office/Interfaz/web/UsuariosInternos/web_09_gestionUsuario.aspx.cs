using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace back_office.Interfaz.web.UsuariosInternos
{
    public partial class web_09_gestionUsuario : System.Web.UI.Page
    {
        DataTable _tabla;

        protected void Page_Load(object sender, EventArgs e)
        {
            _tabla = new DataTable();

            _tabla.Columns.Add("Nombre", typeof(string));
            _tabla.Columns.Add("Apellido", typeof(string));
            _tabla.Columns.Add("Acciones", typeof(string));

            _tabla.Rows.Add("Zuleyma", "Bustamante");
            _tabla.Rows.Add("David", "Juvinao");
            _tabla.Rows.Add("Rosario", "Vivas");

            GridViewUsuario.DataSource = _tabla;
            GridViewUsuario.DataBind();
        }

        protected void GV_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton consultar = new ImageButton();
                consultar.ID = "bConsultar";
                consultar.ImageUrl = "../../../comun/resources/img/View-128.png";
                consultar.Height = 50;
                consultar.Width = 50;
                consultar.Click += new ImageClickEventHandler(this.consultarBtn_Click);

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

                e.Row.Cells[2].Controls.Add(consultar);
                e.Row.Cells[2].Controls.Add(editar);
                e.Row.Cells[2].Controls.Add(eliminar);
            }

        }

        void consultarBtn_Click(Object sender, ImageClickEventArgs e)
        {
            Response.Redirect("web_09_consultarUsuario.aspx");
        }

        void editarBtn_Click(Object sender, ImageClickEventArgs e)
        {
            Response.Redirect("web_09_modificarUsuario.aspx");
        }

        void eliminarBtn_Click(Object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../inicio.aspx");
        }
    }
}