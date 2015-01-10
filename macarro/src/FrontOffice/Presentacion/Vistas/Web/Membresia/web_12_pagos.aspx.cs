using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web.UI.HtmlControls;
using FrontOffice.Presentacion.Presentadores.Membresia;
using FrontOffice.Presentacion.Contratos.Membresia;


namespace FrontOffice.Presentacion.Vistas.Web.Membresia
{
    public partial class web_12_pagos : System.Web.UI.Page,IContrato_12_pagos
    {

        private Presentador_12_pagos _presentador;

        public web_12_pagos() {

            _presentador = new Presentador_12_pagos(this);

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

        public GridView gridPagosHechos
        {
            get { return _gridPagosHechos; }
            set { _gridPagosHechos = value; }
        }

        public ImageButton buscar
        {
            get { return busqueda; }
            set { busqueda = value; }
        }

        public TextBox fechabusqueda
        {
            get { return busquedaPorFecha; }
            set { busquedaPorFecha = value; }
        }


        public Button volver
        {
            get { return _volver; }
            set { _volver = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
           // System.Threading.Thread x = new System.Threading.Thread( new System.Threading.ThreadStart(_presentador.Page_Load));
            //x.Start();
            _presentador.Page_Load();
        }
        protected void _volver_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickVolver("/Presentacion/Vistas/Web/Membresia/web_12_consultarMembresia.aspx");
        }

        protected void _gridPagosHechos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _presentador._gridPagosHechos_PageIndexChanging(sender,e);
        }

        protected void _gridPagosHechos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName){
                case "Ver":
                    _presentador.EventoClickDetallePago(sender,e);
                    break;
            }
            
        }

        protected void busqueda_Click(object sender, ImageClickEventArgs e)
        {
            _presentador.BusquedaClick();
        }

       



       
    }
}