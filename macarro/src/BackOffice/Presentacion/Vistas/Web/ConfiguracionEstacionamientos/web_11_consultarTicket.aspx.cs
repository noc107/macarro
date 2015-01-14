using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionEstacionamientos
{
    public partial class web_11_ConsultarTicket : System.Web.UI.Page
    {
        //List<Ticket> _listaTicket = new List<Ticket>();

        protected void Page_Load(object sender, EventArgs e)
        {

            //String _campoPlaca = textbox_placa.Text.ToString();
            //String _fechaEntrada = TextBoxFechaEntrada.Text.ToString();
            //String _fechaSalida = TextBoxFechaSalida.Text.ToString();
            //if (_campoPlaca != "" && (_fechaEntrada =="" || _fechaSalida==""))
            //{
            //    LimpiarGridView();
            //    busquedaPorPlaca(_campoPlaca);

            //}

            //else if ((_fechaEntrada != "" && _fechaSalida != "") && _campoPlaca != "")
            //{
            //    LimpiarGridView();
            //    busquedaPorEstatus(convierteteEnDateTimeFormat(TextBoxFechaEntrada.Text),convierteteEnDateTimeFormat(TextBoxFechaSalida.Text));
            //}
            //else if (_campoPlaca == "" && _fechaEntrada == "" && _fechaSalida=="")
            //{
            //    LogicaTicket solicitudLogica = new LogicaTicket();
            //    _listaTicket = solicitudLogica.solicitarServicio_ConsultarTickets();

            //    this.My_GV.DataSource = _listaTicket;
            //    this.My_GV.DataBind();
            //}

        }

        protected void My_GV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        ImageButton consultar = new ImageButton();
        //        consultar.ID = "bConsultar";
        //        consultar.ImageUrl = "../../../comun/resources/img/View-128.png";
        //        consultar.Height = 50;
        //        consultar.Width = 50;
        //        consultar.Click += new ImageClickEventHandler(this.consultarBtn_Click);
        //        e.Row.Cells[4].Controls.Add(consultar);
        //    }
        //}

        //private void LimpiarGridView()
        //{

        //    this.My_GV.DataSource = null;
        //    My_GV.DataBind();

        }

        //public void busquedaPorPlaca(string _campoBusqueda)
        //{
        //    LogicaTicket solicitudLogica = new LogicaTicket();

        //    if (solicitudLogica.solicitarServicio_ConsultarTicketsPorPlaca(_campoBusqueda).Count == 0)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('La placa insertada no está relacionada con ningun ticket')", true);
        //        LimpiarGridView();
        //    }
        //    else
        //    {
        //        _listaTicket = solicitudLogica.solicitarServicio_ConsultarTicketsPorPlaca(_campoBusqueda);
        //        this.My_GV.DataSource = _listaTicket;
        //        this.My_GV.DataBind();
        //    }
        //}

        //public void busquedaPorEstatus(string fecha_Entrada, string fechaSalida)
        //{
        //    LogicaTicket solicitudLogica = new LogicaTicket();

        //    if (solicitudLogica.solicitarServicio_ConsultarEstacionamientoPorFecha(fecha_Entrada,fechaSalida).Count == 0)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El rango de fechas utilizado no generó resultados')", true);
        //        LimpiarGridView();
        //    }
        //    else
        //    {
        //        _listaTicket = solicitudLogica.solicitarServicio_ConsultarEstacionamientoPorFecha(fecha_Entrada, fechaSalida);
        //        this.My_GV.DataSource = _listaTicket;
        //        this.My_GV.DataBind();
        //    }
        //}

        //void consultarBtn_Click(Object sender, ImageClickEventArgs e)
        //{
        //    ImageButton img = (ImageButton)sender;
        //    GridViewRow row = (GridViewRow)img.Parent.Parent;

        //    Ticket ticket = _listaTicket[row.RowIndex];
        //    String id = ticket.Id.ToString();
        //    Response.Redirect("web_5_detalleTicket.aspx?id=" + id);
            
        //}

        protected void validar_entrada(object sender, EventArgs e)
        {
        //    if (listaDeOpciones.SelectedValue == "0")
        //    {
        //        porFecha.Visible = false;
        //        porPlaca.Visible = false;

        //    }

        //    if (listaDeOpciones.SelectedValue == "1")
        //    {
        //        porFecha.Visible = false;
        //        porPlaca.Visible = true; 

        //    }

        //    if (listaDeOpciones.SelectedValue == "2")
        //    {
        //        porFecha.Visible = true;
        //        porPlaca.Visible = false;

        //    }

        }

        protected void BotonAgregarEstacionamiento_Click(object sender, EventArgs e)
        {
        //    if (listaDeOpciones.SelectedValue == "0")
        //    {
        //        //  TODO
        //    }

        //    if (listaDeOpciones.SelectedValue == "1")
        //    {
        //        //  FILTRO POR PLACA
        //        LogicaTicket solicitudLogica = new LogicaTicket();
        //        _listaTicket = solicitudLogica.solicitarServicio_ConsultarTicketsPorPlaca(textbox_placa.Text);
                
        //    }
            
        //    if (listaDeOpciones.SelectedValue == "2")
        //    {
        //        //  FILTRO POR FECHA [DropDown_estatus]
        //        LogicaTicket solicitudLogica = new LogicaTicket();

        //        if (TextBoxFechaEntrada.Text != "" && TextBoxFechaSalida.Text != "")
        //        {
        //            _listaTicket = solicitudLogica.solicitarServicio_ConsultarEstacionamientoPorFecha(convierteteEnDateTimeFormat(TextBoxFechaEntrada.Text), convierteteEnDateTimeFormat(TextBoxFechaSalida.Text));
        //        }
                              
        //    }

        //    this.My_GV.DataSource = _listaTicket;
        //    this.My_GV.DataBind();

        }

        //String convierteteEnDateTimeFormat(String parametro)
        //    {
        //        string[] words = parametro.Split('-');
        //        String ano = words[0];
        //        String mes = words[1];
        //        String dia = words[2];
        //        String formatAno = ano.Substring(2,2);
        //        string DateTime = dia + '-' + mes + '-' + formatAno + " 01:00:00 AM";
        //        return DateTime;
        //    }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        //    this.My_GV.PageIndex = e.NewPageIndex;
        //    this.My_GV.DataSource = _listaTicket;
        }
    }
}