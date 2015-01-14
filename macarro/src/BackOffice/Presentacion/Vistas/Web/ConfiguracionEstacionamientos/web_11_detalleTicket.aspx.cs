using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionEstacionamientos
{
    public partial class web_11_detalleTicket : System.Web.UI.Page
    {
        //List<Ticket> _listaTicket = new List<Ticket>();
        //private String id;
        protected void Page_Load(object sender, EventArgs e)
        {
            //LogicaTicket solicitudLogica = new LogicaTicket();
            //_listaTicket = solicitudLogica.solicitarServicio_ConsultarTickets();
            //if (Request.QueryString["id"] != null)
            //{
            //    id = Request.QueryString["id"];

            //    foreach (Ticket ticket in _listaTicket)
            //    {
            //        if (ticket.Id == int.Parse(id))
            //        {
            //            l_entrada.Text = ticket.HoraEntrada.ToLongDateString();
            //            l_salida.Text = ticket.HoraSalida.ToLongDateString();
            //            l_placa.Text = ticket.Placa;
            //            L_monto.Text = "precio";
            //        }
            //    }


            //}
        }

        protected void BotonAgregarEstacionamiento_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_11_ConsultarTicket.aspx");
        }
    }
}