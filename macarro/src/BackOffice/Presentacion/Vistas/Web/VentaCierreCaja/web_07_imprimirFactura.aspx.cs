﻿using System;
//using back_office.Excepciones.RolesSeguridad;
//using back_office.Logica.RolesSeguridad;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using back_office.Dominio;
//using back_office.Logica.VentaCierreCaja;

namespace back_office.Interfaz.web.VentaCierreCaja
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        #region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        #endregion

      /*  private List<LineaFactura> _listaLineas = new List<LineaFactura>();
        private LogicaFactura _logica = new LogicaFactura();
        private List<string> _datosPersona = new List<string>();*/

        protected void Page_Load(object sender, EventArgs e)
        {
          /*  if (Page.PreviousPage != null)
            {
                this.cargarFactura();
            }
            else
                this.ultimaFactura();

            if (!Page.IsPostBack)
            {
                variableSesion();
            }*/
        }

        /// <summary>
        /// Metodo para cargar las variables de sesion
        /// </summary>
        private void variableSesion()
        {
           /* try
            {
                _correoS = (string)(Session["correo"]);
                _docIdentidadS = (string)(Session["docIdentidad"]);
                _primerNombreS = (string)(Session["primerNombre"]);
                _primerApellidoS = (string)(Session["primerApellido"]);
            }
            catch (Exception ex)
            {
                MensajeErrores.Text = "No se han podido cargar los datos de sesion";
                MensajeErrores.Visible = true;
                ex.GetType();
            }*/
        }

        protected void cargarFactura()
        {
            //cargar factura solicitada desde el gestionarVenta
          /*  Factura _factura = new Factura();
            _factura = PreviousPage.Factura;
            
            this.Fecha.Text = _factura.Fecha.Date.ToString("d");

            LogicaLineaFactura lineas = new LogicaLineaFactura();
            _listaLineas = lineas.consultarLineas(_factura.Codigo);

            this.gridFactura.DataSource = _listaLineas;
            this.gridFactura.DataBind();

            _datosPersona = _logica.consultarDatosPersona(_factura.FkUsuario);

            this.DocIdentidad.Text = _datosPersona[0];
            this.Nombres.Text = _datosPersona[1];
            this.Apellidos.Text = _datosPersona[2];

            if (_datosPersona.Count > 3)
            {
                this.labelMiembro.Visible = true;
                this.Miembro.Text = _datosPersona[3];
                this.labelDescuento.Visible = true;
                this.montoDescuento.Text = _datosPersona[4];
            }

            this.subTotal.Text = _factura.SubTotal.ToString();
            this.montoIva.Text = (_logica.CalcularMontoIva(_factura.SubTotal, _factura.Total)).ToString();
            this.total.Text = _factura.Total.ToString();*/

        }

        protected void Ventas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            /*

            gridFactura.PageIndex = e.NewPageIndex;
            gridFactura.DataSource = _listaLineas;
            gridFactura.DataBind();*/
        }

        protected void ultimaFactura()
        {
          /*  Factura _factura = new Factura();
            LogicaFactura logica = new LogicaFactura();

            _factura = logica.consultarUltimaFactura();

            this.Fecha.Text = _factura.Fecha.Date.ToString("d");

            LogicaLineaFactura lineas = new LogicaLineaFactura();
            _listaLineas = lineas.consultarLineas(_factura.Codigo);

            this.gridFactura.DataSource = _listaLineas;
            this.gridFactura.DataBind();

            _datosPersona = _logica.consultarDatosPersona(_factura.FkUsuario);

            this.DocIdentidad.Text = _datosPersona[0];
            this.Nombres.Text = _datosPersona[1];
            this.Apellidos.Text = _datosPersona[2];

            if (_datosPersona.Count > 3)
            {
                this.TableRow4.Visible = true;
                this.Miembro.Text = _datosPersona[3];
                this.labelDescuento.Visible = true;
                this.montoDescuento.Text = _datosPersona[4];
            }

            this.subTotal.Text = _factura.SubTotal.ToString();
            this.montoIva.Text = (_logica.CalcularMontoIva(_factura.SubTotal, _factura.Total)).ToString();
            this.total.Text = _factura.Total.ToString();*/
        }

        protected void BotonRegresarFactura_Click(object sender, EventArgs e)
        {
         //   Response.Redirect("web_07_gestionarVenta.aspx");
        }


    }
}