﻿using System;
//using back_office.Excepciones.RolesSeguridad;
//using back_office.Logica.RolesSeguridad;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//using back_office.Dominio;
//using back_office.Logica.VentaCierreCaja;

namespace back_office.Interfaz.web.VentaCierreCaja
{


    public partial class WebForm3 : System.Web.UI.Page
    {
        #region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        #endregion

       /* public static List<Factura> _listaFactura;
        private Factura _selectedFactura;*/

        protected void Page_Load(object sender, EventArgs e)
        {
       /*     LogicaFactura logica = new LogicaFactura();
            _listaFactura = logica.ConsultarFacturas();         

            this.Ventas.DataSource = _listaFactura;
            this.Ventas.DataBind();

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
            /*try
            {
                _correoS = (string)(Session["correo"]);
                _docIdentidadS = (string)(Session["docIdentidad"]);
                _primerNombreS = (string)(Session["primerNombre"]);
                _primerApellidoS = (string)(Session["primerApellido"]);
            }
            catch (Exception ex)
            {
                MensajeError.Text = "No se han podido cargar los datos de sesion";
                MensajeError.Visible = true;
                ex.GetType();
            }*/
        }

        protected void Ventas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            /*
            Ventas.PageIndex = e.NewPageIndex;
            Ventas.DataSource = _listaFactura;
            Ventas.DataBind();*/
        }
        

        protected void Ventas_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
           /* if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton consultar = new ImageButton();
                consultar.ID = "botonConsultar";
                consultar.ImageUrl = "../../../comun/resources/img/View-128.png";
                consultar.Height = 50;
                consultar.Width = 50;
                consultar.Click += new ImageClickEventHandler(this.consultar_Click);
                consultar.ToolTip = "Ver para imprimir";

                ImageButton editar = new ImageButton();
                editar.ID = "botonEditar";
                editar.ImageUrl = "../../../comun/resources/img/Data-Edit-128.png";
                editar.Height = 50;
                editar.Width = 50;
                editar.Click += new ImageClickEventHandler(this.modificar_Click);
                editar.ToolTip = "Editar Cuenta";


                e.Row.Cells[4].Controls.Add(consultar);
            //    e.Row.Cells[6].Controls.Add(editar);
            
            }*/

        }

        //Evento consulta de evento especifico
        void consultar_Click(Object sender, ImageClickEventArgs e)
        {
/*
            ImageButton img = (ImageButton)sender;
            GridViewRow row = (GridViewRow)img.Parent.Parent;

            //Le agregamos a la propiedad el valor del id de la fila seleccionada
            //_selectedFactura = row.Cells[0].Text;
            _selectedFactura = _listaFactura[row.RowIndex];

            //Ir a la siguiente pagina manteniendo vivo el form para no perder las propiedades
            Server.Transfer("web_07_imprimirFactura.aspx", true);*/
        }



        //Evento modificar de evento especifico
        void modificar_Click(Object sender, ImageClickEventArgs e)
        {
            /*
            ImageButton img = (ImageButton)sender;
            GridViewRow row = (GridViewRow)img.Parent.Parent;

            if (row.Cells[4].Text != "Si")
            {

                //_selectedFactura = row.Cells[0].Text;
                _selectedFactura = _listaFactura[row.RowIndex];

                //Server.Transfer("web_07_agregarVenta.aspx", true);
            }
            else
                this.MensajeError.Visible = true;
                */
        }
        /*
        public Factura Factura
        {
            get { return _selectedFactura; }
        }*/

        protected void ButtonCierreDiario_Click(object sender, EventArgs e)
        {
         //   Response.Redirect("web_07_cerrarCajaDiario.aspx");
        }

        protected void ButtonCierreMensual_Click(object sender, EventArgs e)
        {
        //    Response.Redirect("web_07_cerrarCajaMensual.aspx");
        }
    }
}