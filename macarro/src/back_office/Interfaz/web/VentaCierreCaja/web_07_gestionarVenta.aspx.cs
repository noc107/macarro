using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace back_office.Interfaz.web.VentaCierreCaja
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NroFactura", typeof(String));
            dt.Columns.Add("Cliente", typeof(String));
            dt.Columns.Add("Fecha", typeof(String));
            dt.Columns.Add("Monto", typeof(String));
            dt.Columns.Add("Facturado", typeof(String));
            dt.Columns.Add("Acciones", typeof(String));

            dt.Rows.Add("3546785", "Jorge Perez", "00/00/0000", "0.00", "si");
            dt.Rows.Add("1123458", "Jorge Perez", "00/00/0000", "0.00", "si");
            dt.Rows.Add("1234487", "Jorge Perez", "00/00/0000", "0.00", "si");
            dt.Rows.Add("1458787", "Jorge Perez", "00/00/0000", "0.00", "si");
            dt.Rows.Add("3546785", "Jorge Perez", "00/00/0000", "0.00", "si");
            dt.Rows.Add("1123458", "Jorge Perez", "00/00/0000", "0.00", "si");
            dt.Rows.Add("1234487", "Jorge Perez", "00/00/0000", "0.00", "si");
            dt.Rows.Add("1458787", "Jorge Perez", "00/00/0000", "0.00", "si");
            dt.Rows.Add("3546785", "Jorge Perez", "00/00/0000", "0.00", "si");
            dt.Rows.Add("1123458", "Jorge Perez", "00/00/0000", "0.00", "si");
            dt.Rows.Add("1234487", "Jorge Perez", "00/00/0000", "0.00", "si");
            dt.Rows.Add("1458787", "Jorge Perez", "00/00/0000", "0.00", "si");

            Ventas.DataSource = dt;
            Ventas.DataBind();
        }

        protected void Ventas_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton consultar = new ImageButton();
                consultar.ID = "botonConsultar";
                consultar.ImageUrl = "../../../comun/resources/img/View-128.png";
                consultar.Height = 50;
                consultar.Width = 50;
                consultar.Click += new ImageClickEventHandler(this.consultar_Click);
                consultar.ToolTip = "Ver para imprimir";

                ImageButton editar = new ImageButton();
                editar.ID = "botonEditar";
                editar.ImageUrl = "../../../comun/resources/img/Data-Edit-128.png";
                editar.Height = 50;
                editar.Width = 50;
                editar.Click += new ImageClickEventHandler(this.modificar_Click);
                editar.ToolTip = "Editar Cuenta";


                e.Row.Cells[5].Controls.Add(consultar);
                e.Row.Cells[5].Controls.Add(editar);
            
            }

        }

        //Evento consulta de evento especifico
        void consultar_Click(Object sender, ImageClickEventArgs e)
        {
            Response.Redirect("web_07_imprimirFactura.aspx");
        }


        //Evento modificar de evento especifico
        void modificar_Click(Object sender, ImageClickEventArgs e)
        {
            Response.Redirect("web_07_agregarVenta.aspx");
        }
    }
}