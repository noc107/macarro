using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.ReservasSombrillasServiciosPlaya
{
    public partial class web_07_gestionarReservas : System.Web.UI.Page
    {
        DataTable _dt;
        string _nombreReserva;
        string _exito = "El servicio fue eliminado sactifactoriamente";
        string _error = "Error al eliminar el servicio";

        protected void Page_Load(object sender, EventArgs e)
        {
            /*ConfigurarReserva _consulta;

            _consulta = new ConfigurarReserva();
            _dt = _consulta.ListarPersonas();
            GridView.DataSource = _dt;
            GridView.DataBind();*/
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
            this._nombreReserva = GridView.Rows[_Index].Cells[1].Text;
        }

        protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("web_07_listaReservas.aspx?Reserva=" + this._nombreReserva);
        }

    }
}