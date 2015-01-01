using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.ConfiguracionEstacionamiento;
using BackOffice.Presentacion.Presentadores.ConfiguracionEstacionamiento;


namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionEstacionamientos
{
    public partial class web_5_editarEstacionamiento : System.Web.UI.Page, IContrato_5_editarEstacionamiento
    {
        //List<Estacionamiento> _listaEstacionamiento = new List<Estacionamiento>();
        //private String id;

        private Presentador_5_editarEstacionamiento _presentador;

        public web_5_editarEstacionamiento()
        {
            _presentador = new Presentador_5_editarEstacionamiento(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //LogicaEstacionamiento solicitudLogica = new LogicaEstacionamiento();
            //_listaEstacionamiento = solicitudLogica.solicitarServicio_ConsultarEstacionamiento();
            //if (Request.QueryString["id"] != null)
            //{
            //    id = Request.QueryString["id"];
            //}
            //if (!IsPostBack)
            //{
            
            //    if (id != null)
            //    {
            //        id = Request.QueryString["id"];

            //        foreach (Estacionamiento estacionamiento in _listaEstacionamiento)
            //        {
            //            if (estacionamiento.Id == int.Parse(id))
            //            {
            //                tb_nombre.Text = estacionamiento.Nombre;
            //                tb_Capacidad.Text = estacionamiento.Capacidad.ToString();
            //                tb_Tarifa.Text = estacionamiento.Tarifa.ToString();
            //                tb_tarifaTicketPerdido.Text = estacionamiento.Tarifa_ticketPerdido.ToString();

            //                if (estacionamiento.Estado == "Activado")
            //                {
            //                    DropDown_estatus.SelectedIndex = 1;
            //                }
            //                else if (estacionamiento.Estado == "Desactivado")
            //                {
            //                    DropDown_estatus.SelectedIndex = 2;
            //                }

            //            }
            //        }
            //    }
            //}
        }

        string IContrato_5_editarEstacionamiento.TextboxNombre
        {
            get { return tb_nombre.Text; }
            set { tb_nombre.Text = value; }
        }

        string IContrato_5_editarEstacionamiento.TextboxCapacidad
        {
            get { return tb_Capacidad.Text; }
            set { tb_Capacidad.Text = value; }
        }

        string IContrato_5_editarEstacionamiento.TextboxTarifa
        {
            get { return tb_Tarifa.Text; }
            set { tb_Tarifa.Text = value; }
        }

        string IContrato_5_editarEstacionamiento.TextboxPerdido
        {
            get { return tb_tarifaTicketPerdido.Text; }
            set { tb_tarifaTicketPerdido.Text = value; }
        }

        int IContrato_5_editarEstacionamiento.TextboxEstado
        {
            get { return DropDown_estatus.SelectedIndex; }
            set { DropDown_estatus.SelectedIndex = value; }
        }


        public Label LabelMensajeExito
        {
            get { return _mensajeExito; }
            set { _mensajeExito = value; }
        }

        public Label LabelMensajeError
        {
            get { return _mensajeError; }
            set { _mensajeError = value; }
        }

        protected void BotonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_5_gestionarEstacionamiento.aspx");

        }

        protected void BotonAceptar_Click(object sender, EventArgs e)
        {
        //    LogicaEstacionamiento solicitudLogica = new LogicaEstacionamiento();
        //    try
        //    {
        //        if (solicitudLogica.solicitarServicio_modificarEstacionamiento(int.Parse(id), tb_nombre.Text, Convert.ToInt32(tb_Capacidad.Text), Convert.ToSingle(tb_Tarifa.Text), Convert.ToSingle(tb_tarifaTicketPerdido.Text), DropDown_estatus.SelectedValue.ToString()) == true)
        //        {
        //            LabelMensajeExito.Visible = true;
        //            solicitudLogica.solicitarServicio_modificarEstacionamiento(int.Parse(id), tb_nombre.Text, Convert.ToInt32(tb_Capacidad.Text), Convert.ToSingle(tb_Tarifa.Text), Convert.ToSingle(tb_tarifaTicketPerdido.Text), DropDown_estatus.SelectedValue.ToString());
        //        }
        //        else 
        //        {
        //            LabelMensajeError.Visible = true;
        //        }
        //        Thread.Sleep(2000);
                
        //    }
        //    catch (Exception ex)
        //    {
        //        // Hay que definir nueva excepeción (errores de entrada)
        //        throw new ExcepcionEstacionamientoLogica(ex.Message);
        //    }
            
            
        //    //  Seguro que quiere?
        //    Response.Redirect("web_5_gestionarEstacionamiento.aspx");

            _presentador.EventoClickBoton();

        }
    }
}