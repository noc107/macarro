using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionEstacionamientos
{
    public partial class web_5_consultarEstacionamiento : System.Web.UI.Page
    {
        //List<Estacionamiento> _listaEstacionamiento = new List<Estacionamiento>();
        //private String id;
        protected void Page_Load(object sender, EventArgs e)
        {
            //LogicaEstacionamiento solicitudLogica = new LogicaEstacionamiento();
            //_listaEstacionamiento = solicitudLogica.solicitarServicio_ConsultarEstacionamiento();
            //if(Request.QueryString["id"]!=null)
            //{
            //    id= Request.QueryString["id"];

            //    foreach (Estacionamiento estacionamiento in _listaEstacionamiento)
            //    {
            //        if (estacionamiento.Id == int.Parse(id))
            //        {
            //            l_nombre.Text = estacionamiento.Nombre;
            //            l_capacidad.Text = estacionamiento.Capacidad.ToString();
            //            l_tarifa.Text = estacionamiento.Tarifa.ToString();
            //            l_tarifaTicketPerdido.Text = estacionamiento.Tarifa_ticketPerdido.ToString();
            //            l_estatus.Text = estacionamiento.Estado;
            //        }
            //    }

                
            //}
        }

        protected void BotonAgregarEstacionamiento_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_5_gestionarEstacionamiento.aspx");
        }
    }
}