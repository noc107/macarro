using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionEstacionamientos
{
    public partial class asp_web_5_agregarEstacionamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // tb_nombre.Text = string.Empty;

        }

        protected void BotonAgregarEstacionamiento_Click(object sender, EventArgs e)
        {
        //    LogicaEstacionamiento solicitudLogica = new LogicaEstacionamiento();

        //    try
        //    {
        //        if (solicitudLogica.solicitarServicio_AgregarEstacionamiento(tb_nombre.Text, Convert.ToInt32(tb_Capacidad.Text), Convert.ToSingle(tb_Tarifa.Text), Convert.ToSingle(tb_tarifaTicketPerdido.Text), DropDown_estatus.SelectedValue.ToString()) == true)
        //        {
        //           // solicitudLogica.solicitarServicio_AgregarEstacionamiento(tb_nombre.Text, Convert.ToInt32(tb_Capacidad.Text), Convert.ToSingle(tb_Tarifa.Text), Convert.ToSingle(tb_tarifaTicketPerdido.Text), DropDown_estatus.SelectedValue.ToString());
        //            LabelMensajeExito.Visible = true;
        //        }
        //        else
        //        {
        //            LabelMensajeError.Visible = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Hay que definir nueva excepeción (errores de entrada)
        //        throw new ExcepcionEstacionamientoLogica(ex.Message);
        //    }
            
        }
    }
}