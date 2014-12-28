using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Vistas.Web.Reservas
{
    public partial class web_07_reservacionSombrilla1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //LogicaReservaSombrilla _log = new LogicaReservaSombrilla();
            //string _correo = Session["correo"].ToString();
            //string _fecha = this.tb_fecha.Text;
            //Session["horaI"] = this.tb_hora_i.Text;
            //Session["horaF"] = this.dd_hora_f.Text;
            //if (_log.agregarReservaP(_fecha, _correo))
            //{
            //    MensajeExito.Text = "Reserva Apartada Exitosamente";
            //    Response.Redirect("web_07_reservacionSombrilla.aspx");
            //}
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../inicio.aspx");
        }
    }
}