using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using back_office.Dominio;
using System.Data;

namespace back_office.Interfaz.web.InventarioRestaurante
{
    public partial class web_06_gestionarInventario : System.Web.UI.Page
    {
        System.Data.DataTable mytable = new System.Data.DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Codigo", typeof(String));
            dt.Columns.Add("Nombre", typeof(String));
            dt.Columns.Add("Cantidad", typeof(String));
            dt.Columns.Add("Acciones", typeof(String));

            dt.Rows.Add("00021", "Pan", "15");
            dt.Rows.Add("00345", "Salsa de Tomate", "20");
            dt.Rows.Add("00455", "Tomate", "35");

            Inventario.DataSource = dt;
            Inventario.DataBind();
        }

        protected void Inventario_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton consultar = new ImageButton();
                consultar.ID = "bConsultar";
                consultar.ImageUrl = "../../../comun/resources/img/View-128.png";
                consultar.Height = 50;
                consultar.Width = 50;
                consultar.Click += new ImageClickEventHandler(this.consultar_Click);
                consultar.ToolTip = "Ver para imprimir";

                ImageButton editar = new ImageButton();
                editar.ID = "bEditar";
                editar.ImageUrl = "../../../comun/resources/img/Data-Edit-128.png";
                editar.Height = 50;
                editar.Width = 50;
                editar.Click += new ImageClickEventHandler(this.modificar_Click);
                editar.ToolTip = "Editar Cuenta";

                ImageButton eliminar = new ImageButton();
                eliminar.ID = "bEliminar";
                eliminar.ImageUrl = "../../../comun/resources/img/Garbage-Closed-128.png";
                eliminar.Height = 50;
                eliminar.Width = 50;
                eliminar.Click += new ImageClickEventHandler(this.eliminar_Click);

                e.Row.Cells[3].Controls.Add(consultar);
                e.Row.Cells[3].Controls.Add(editar);
                e.Row.Cells[3].Controls.Add(eliminar);


            }

        }

        //Evento consulta de evento especifico
        void consultar_Click(Object sender, ImageClickEventArgs e)
        {
            Response.Redirect("web_06_verItem.aspx");
        }


        //Evento modificar de evento especifico
        void modificar_Click(Object sender, ImageClickEventArgs e)
        {
            Response.Redirect("web_06_modificarItem.aspx");
        }

        void eliminar_Click(Object sender, ImageClickEventArgs e)
        {
            Response.Redirect("web_06_gestionarInventario.aspx");
        }
    }
}