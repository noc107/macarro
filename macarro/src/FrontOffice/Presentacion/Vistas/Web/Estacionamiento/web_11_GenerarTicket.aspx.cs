using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FrontOffice.Presentacion.Vistas.Web.Estacionamiento
{
    public partial class web_5_GenerarTicket : System.Web.UI.Page
    {
        //List<Dominio.Estacionamiento> _listaEstacionamiento = new List<Dominio.Estacionamiento>();
        //LogicaEstacionamiento logica = new LogicaEstacionamiento();
        //int _idEstacionamiento;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //DateTime diaActual = DateTime.Today;
            //DateTime horaActual = DateTime.Now;

            //this.tb_fechaEntrada.Text = diaActual.ToString("d");
            //this.tb_horaEntrada.Text = horaActual.ToString("hh:mm:ss tt");
            //if (!IsPostBack)
            //{
            //    llenarComboBoxEstacionamiento();
            //}

        }


        private void llenarComboBoxEstacionamiento()
        {
            
            //List < Dominio.Estacionamiento > _listaEstacionamientos = logica.solicitarServicio_ConsultarEstacionamiento();
            //ListItem _itemTicket;

            //this.DropDown_estacionamiento.Items.Clear();

            //_itemTicket = new ListItem();
            //_itemTicket.Text = "Seleccione Estacionamiento";
            //_itemTicket.Value = "0";
            //this.DropDown_estacionamiento.Items.Add(_itemTicket);

            //foreach (Dominio.Estacionamiento _itemTickets in _listaEstacionamientos)
            //{
            //    _itemTicket = new ListItem();
            //    _itemTicket.Text = _itemTickets.Nombre;
            //    _itemTicket.Value = _itemTickets.Id.ToString();
            //    this.DropDown_estacionamiento.Items.Add(_itemTicket);
            //}
        }


        protected void comboEstacionamientoSelector(object sender, EventArgs e)
        {
            //if(DropDown_estacionamiento.SelectedValue !="0")
            //{
            //    _idEstacionamiento = Convert.ToInt32(this.DropDown_estacionamiento.SelectedValue);
            //}
            
        }

        protected void BotonGenerarTicket_Click(object sender, EventArgs e)
        {
            //LogicaTicket solicitudLogica = new LogicaTicket();
            //String fechaEntrada = convierteteEnDateFormat(tb_fechaEntrada.Text) + convierteteEnTimeFormat(tb_horaEntrada.Text);

            //try
            //{


            //    if (solicitudLogica.solicitarServicio_agregarTicketSinSalida(fechaEntrada, tb_placa.Text, Convert.ToInt32(this.DropDown_estacionamiento.SelectedValue)) == true)
            //    {
            //        // solicitudLogica.solicitarServicio_AgregarEstacionamiento(tb_nombre.Text, Convert.ToInt32(tb_Capacidad.Text), Convert.ToSingle(tb_Tarifa.Text), Convert.ToSingle(tb_tarifaTicketPerdido.Text), DropDown_estatus.SelectedValue.ToString());
            //        LabelMensajeExito.Visible = true;
            //    }
            //    else
            //    {
            //        LabelMensajeError.Visible = true;
            //    }
            //}
            //catch (Exception ex)
            //{
               
            //    // Hay que definir nueva excepeción (errores de entrada)
            //    throw new ExcepcionEstacionamientoLogica(ex.Message);
            //}

             
        }

        //String convierteteEnDateFormat(String parametro)
        //{
        //    //string[] words = parametro.Split('/');
        //    //String dia = words[0];
        //    //String mes = words[1];
        //    //String ano = words[2];
        //    //String formatAno = ano.Substring(2, 2);
        //    //string DateTime = dia + '-' + mes + '-' + formatAno +" ";
        //    //return DateTime;
        //}

        //String convierteteEnTimeFormat(String parametro)
        //{
            //string[] words = parametro.Split(' ');
            //String time = words[0];
            //String basura = words[1];

            //String local =" AM";

            //if (basura == "a.m")
            //{
            //    local = " AM";
            //}
            //if (basura == "p.m")
            //{
            //    local = " PM";
            //}

            //string DateTime = time + local;
            //return DateTime;
        //}



    }
}