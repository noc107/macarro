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
using System.Web.UI.HtmlControls;
using FrontOffice.Presentacion.Contratos.Membresia;
using FrontOffice.Presentacion.Presentadores.Membresia;

namespace FrontOffice.Presentacion.Vistas.Web.Membresia
{
    public partial class web_12_detallePago : System.Web.UI.Page, IContrato_12_detallePago
    {

        private Presentador_12_detallePago _presentador;
        
        public string ObtenerId()
        {
            string[] ID;

            ID = HttpContext.Current.Request.QueryString.GetValues(0);
            return ID.ElementAt(0);
        }

        public web_12_detallePago()
        {

            _presentador = new Presentador_12_detallePago(this);

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

        public Image tipoTarjeta
        {
            get { return _tipoTarjeta; }
            set { _tipoTarjeta = value; }
        }

        public Label numeroTarjeta
        {
            get { return _numeroTarjeta; }
            set { _numeroTarjeta = value; }
        }
        public Label nombreImpresoEnTarjeta
        {
            get { return _nombreImpresoEnTarjeta; }
            set { _nombreImpresoEnTarjeta = value; }
        }
        public Label fechaPago
        {
            get { return _fechaPago; }
            set { _fechaPago = value; }
        }
        public Label montoTotal
        {
            get { return _montoTotal; }
            set { _montoTotal = value; }
        }
        public Button volver
        {
            get { return _volver; }
            set { _volver = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            _presentador.CargarDatos();
        }

        protected void volver_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickVolver("/Presentacion/Vistas/Web/Membresia/web_12_pagos.aspx");
        }        
    }
}