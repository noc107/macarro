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
using FrontOffice.Dominio;



namespace FrontOffice.Presentacion.Vistas.Web.Membresia
{
    public partial class web_12_consultarMembresia : System.Web.UI.Page, IContrato_12_consultarMembresia
    {
       
        private Presentador_12_consultarMembresia _presentador;


        public web_12_consultarMembresia()
        {
            //falta la fabrica
            _presentador = new Presentador_12_consultarMembresia(this);
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

        public Label nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public Label apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public Label fechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }
        public Label fechaVencimiento
        {
            get { return _fechaVencimiento; }
            set { _fechaVencimiento = value; }
        }
        public Label tipoDocumentoIdentidad
        {
            get { return _tipoDocumentoIdentidad; }
            set { _tipoDocumentoIdentidad = value; }
        }
        public Label numeroDocumentoIdentidad
        {
            get { return _numeroDocumentoIdentidad; }
            set { _numeroDocumentoIdentidad = value; }
        }
        public Label numeroTelefono
        {
            get { return _numeroTelefono; }
            set { _numeroTelefono = value; }
        }
        public Label numeroCarnet
        {
            get { return _numeroCarnet; }
            set { _numeroCarnet = value; }
        }
        public Image foto
        {
            get { return _foto; }
            set { _foto = value; }
        }
        public Image logo
        {
            get { return headerCarnetLogo; }
            set { headerCarnetLogo = value; }
        }
        public Button descargarPDF
        {
            get { return _descargarPDF; }
            set { _descargarPDF = value; }
        }
        public Button verPagos
        {
            get { return _verPagos; }
            set { _verPagos = value; }
        }
        public Panel carnet
        {
            get { return Carnet; }
            set { Carnet = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            _presentador.Page_Load();
            //FrontOffice.Dominio.Entidades.Membresia z = new FrontOffice.Dominio.Entidades.Membresia(null,0,DateTime.Now,DateTime.Now,"PRUEBA.jpg",0,0,"",0);
            //_foto.ImageUrl = z.Imagen; 
        }

        protected void _descargarPDF_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickDescargarPDF();
        }

        protected void _verPagos_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickVerPagos("/Presentacion/Vistas/Web/Membresia/web_12_pagos.aspx");
        } 
              
    }
}