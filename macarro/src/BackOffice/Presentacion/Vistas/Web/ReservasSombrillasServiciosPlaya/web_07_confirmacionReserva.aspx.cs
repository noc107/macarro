using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.ReservasSombrillasServiciosPlaya
{
    public partial class web_07_confirmacionReserva : System.Web.UI.Page
    {
        DataTable _dt;
        string _idReserva;
        string _nombreServicio;
        protected void Page_Load(object sender, EventArgs e)
        {
            //_idReserva = Request.QueryString["Reserva"];
            //ConfigurarReserva _consulta;

            //_consulta = new ConfigurarReserva();
            //_dt = _consulta.ListarServicios(_idReserva);
            //GridView.DataSource = _dt;
            //GridView.DataBind();
        }

        protected void botonAceptar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("web_07_confirmacionReserva.aspx");
        }

        protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView.PageIndex = e.NewPageIndex;
            GridView.DataSource = _dt;
        }

        protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Int16 _Index;

            _Index = Convert.ToInt16(e.CommandArgument);
            this._nombreServicio = GridView.Rows[_Index].Cells[0].Text;
        }

        protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
        {
        //    GestionarReservaBD _gest = new GestionarReservaBD();
        //    string _idServicio = _gest.idServicio(_nombreServicio, Convert.ToInt32(_idReserva)); 
        //    Response.Redirect("web_07_editarReserva.aspx?Servicio=" + _idServicio + "?Reserva=" + _idReserva);
        }


    }
}