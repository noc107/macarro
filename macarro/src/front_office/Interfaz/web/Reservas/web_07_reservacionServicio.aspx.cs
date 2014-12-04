using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace front_office.Interfaz.web.Reservas
{

    public partial class web_07_reservacionServicio : System.Web.UI.Page
    {
        DataTable _tabla;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            _tabla = new DataTable();

            _tabla.Columns.Add("Reserva", typeof(string));
            _tabla.Columns.Add("Servicio", typeof(string));
            _tabla.Columns.Add("Costo", typeof(string));
            _tabla.Columns.Add("Cantidad Disponible", typeof(string));
            _tabla.Columns.Add("Fecha", typeof(string));
            _tabla.Columns.Add("Hora Inicio", typeof(string));
            _tabla.Columns.Add("Hora Fin", typeof(string));
            _tabla.Columns.Add("Cantidad", typeof(string));
         

            _tabla.Rows.Add("","Moto de Agua", "30$", "23");
            _tabla.Rows.Add("", "Tumbona", "10$", "3");
            _tabla.Rows.Add("", "Banana", "15$", "1");
            _tabla.Rows.Add("", "Raquetas de Playa", "4$", "2");
            _tabla.Rows.Add("", "Lancha", "100$", "3");
            _tabla.Rows.Add("", "Pelota", "3$", "23");

            GridViewUsuario2.DataSource = _tabla;
            GridViewUsuario2.DataBind();
           

            
            
        }

        protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox calendario = new TextBox();
                calendario.TextMode = TextBoxMode.Date;
                calendario.CssClass = "textbox1";
                calendario.Enabled = false;
                calendario.ID = "fechaT";

             

                DropDownList hora_i = new DropDownList();
                hora_i.CssClass = "textbox2";
                hora_i.Items.Add("hora1");
                hora_i.Items.Add("hora1");
                hora_i.Items.Add("hora1");
                hora_i.Items.Add("hora1");
                hora_i.Enabled = false;
                hora_i.ID = "horaI";

                DropDownList hora_f = new DropDownList();
                hora_f.CssClass = "textbox2";
                hora_f.Items.Add("Hora2");
                hora_f.Items.Add("Hora2");
                hora_f.Items.Add("Hora2");
                hora_f.Items.Add("Hora2");
                hora_f.Enabled = false;
                hora_f.ID = "horaF";

                TextBox cantidad = new TextBox();
                cantidad.TextMode = TextBoxMode.Number;
                cantidad.CssClass = "textbox3";
                cantidad.Enabled = false;
                cantidad.Text = "30";
                cantidad.ID = "cantidad";

         

                e.Row.Cells[4].Controls.Add(calendario);
                e.Row.Cells[5].Controls.Add(hora_i);
                e.Row.Cells[6].Controls.Add(hora_f);
                e.Row.Cells[7].Controls.Add(cantidad);

                

            }
        }

  
 

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("../inicio.aspx");
        }

   
 
      
    }
}