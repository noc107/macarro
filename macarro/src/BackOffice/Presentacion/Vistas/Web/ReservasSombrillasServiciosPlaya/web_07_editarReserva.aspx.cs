using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BackOffice.Presentacion.Vistas.Web.ReservasSombrillasServiciosPlaya
{
    public partial class web_07_editarReserva : System.Web.UI.Page
    {
        string _idReserva;
        string _idServicio;
        //Reserva res = new Reserva();
        protected void Page_Load(object sender, EventArgs e)
        {
            //string _nombre = Request.QueryString["Servicio"];
            //string[] puesto = _nombre.Split('?','=');
            //_idServicio = puesto[0];
            //_idReserva = puesto[2];
            //ConfigurarReserva _consulta = new ConfigurarReserva();
            //res = _consulta.buscarReserva(Convert.ToInt32(_idServicio), Convert.ToInt32(_idReserva));
            //llenarComboNombre();
            //tb_cantidad.Text = res.Ser.Cantidad.ToString();
            //tb_costo.Text = res.Ser.Servicio.Costo.ToString();
            //tb_horaI.Text = res.Ser.Hora_inicio.ToShortTimeString();
            //tb_horaF.Text = res.Ser.Hora_fin.ToShortTimeString();
        }

        //public void llenarComboNombre()
        //{
        //    //OperacionesBD _conexionBD = new OperacionesBD();
        //    SqlCommand _cmd;

        //    try
        //    {
        //        _conexionBD._cn.Open();
        //        _cmd = new SqlCommand("Procedure_consultarInformacionServicios", _conexionBD._cn);
        //        _cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataReader ddlValues;
        //        ddlValues = _cmd.ExecuteReader();
        //        ddlNombre.DataSource = ddlValues;
        //        ddlNombre.DataValueField = "SER_id";
        //        ddlNombre.DataTextField = "SER_nombre";
        //        ddlNombre.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        _conexionBD.DesconectarBD();
        //    }

        //}


        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_07_confirmacionReserva.aspx");
        }

        protected void botonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_07_confirmacionReserva.aspx");
        }
    }
}


