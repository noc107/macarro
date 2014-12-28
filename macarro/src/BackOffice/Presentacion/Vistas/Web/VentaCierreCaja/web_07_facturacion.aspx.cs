/*using back_office.Datos.VentaCierreCaja;
using back_office.Logica.VentaCierreCaja;
using back_office.Excepciones.RolesSeguridad;
using back_office.Logica.RolesSeguridad;*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BackOffice.Presentacion.Contratos;
using BackOffice.Presentacion.Contratos.VentaCierreCaja;
using BackOffice.Presentacion.Presentadores.VentaCierreCaja;

namespace back_office.Interfaz.web.VentaCierreCaja
{
    public partial class web_07_facturacion : System.Web.UI.Page, IContrato_07_Facturacion, IHttpHandler
    {
            
        private Presentador_07_Facturacion _presentadorFacturacion;

        public web_07_facturacion()
        {
            this._presentadorFacturacion = new Presentador_07_Facturacion(this);
        }

 
        [System.Web.Services.WebMethod]
 
        public static string LoadData()
        {
            Presentador_07_Facturacion _presentadorFacturacionCorreo = new Presentador_07_Facturacion(null);
            return _presentadorFacturacionCorreo.CargarBuscadorCorreos();
        }

        
        protected void Page_Load(object sender, EventArgs e) 
        {
            this._presentadorFacturacion.Page_Load(Request.QueryString["Modificar"]);
        }
       
        protected void Page_PreRender(object sender, EventArgs e)
        {

        }


        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {


        }


        protected void botonAgregarServicio_Click(object sender, EventArgs e) 
        {


        }

        protected void botonDeshacerServicio_Click(object sender, ImageClickEventArgs e)
        {
           
  
        }


        protected void CheckBoxTicket_CheckedChanged(object sender, EventArgs e)
        {


        }

        protected void botonFacturar_Click(object sender, EventArgs e)
        {     
            
        }

        protected void botonGuardar_Click(object sender, EventArgs e)
        {
            
        }

        protected void botonCrearFactura_Click(object sender, EventArgs e)
        {
            this._presentadorFacturacion.botonCrearFactura();
        }

        protected void botonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_07_gestionarVenta.aspx");
        }





        public DropDownList listaFiltroBuscador
        {
            get
            {
                return this._listaFiltro;            
            }
            set
            {
                this._listaFiltro = value;
            }
        }

        public GridView gridServicio
        {
            get 
            {
                return this._gridServicios;
            }
        }

        public GridView gridFactura
        {
            get 
            {
                return this._gridDetalleFactura;
            }
        }

        public string labelTotal
        {
            set 
            {
                this._labelTotal.Text = value;
            }
        }

        public string labelNombreCliente
        {
            set 
            {
                this._labelNombreIntroducir.Text = value;
            }
        }

        public string labelDocumento
        {
            set 
            {
                this._labelDocumentoIntroducir.Text = value;
            }
        }

        public TextBox textBoxCorreoCliente
        {
            get 
            {
                return this._textBoxCorreoCliente;
            }
        }

        public TextBox textBoxBuscador
        {
            get 
            {
                return this._textBoxBuscar;
            }
        }

        public Label LabelMensajeExito
        {
            get
            {
                return this.MensajeExito;
            }
            set
            {
                this.MensajeExito = value;
            }
        }

        public Label LabelMensajeError
        {
            get
            {
                return this.MensajeErrorLista;
            }
            set
            {
                this.MensajeErrorLista = value;
            }
        }

        public Panel panelBloques
        {
            get
            {
                return this._bloquesFacturas;
            }
        }

        public Panel panelBloqueNuevo
        {
            get
            {
                return this._bloquesNuevaFactura;
            }
        }
    }
}