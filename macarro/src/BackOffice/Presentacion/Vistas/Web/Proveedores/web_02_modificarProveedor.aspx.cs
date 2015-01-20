using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BackOffice.Presentacion.Contratos;
using BackOffice.Presentacion.Contratos.Proveedores;
using BackOffice.Presentacion.Presentadores.Proveedores;
using BackOffice.Presentacion.Vistas.Web.Proveedores.Recursos;

namespace BackOffice.Presentacion.Vistas.Web.Proveedores
{
    public partial class web_02_modificarProveedor : System.Web.UI.Page , IContrato_02_modificarProveedor
    {
        Presentador_02_modificarProveedor _presentador;

        public web_02_modificarProveedor() 
        {
            _presentador = new Presentador_02_modificarProveedor(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                _presentador.cargarPaises();
                _presentador.cargarEstados();
                _presentador.cargarCiudades();
                _presentador.EventoBotonConsultar(Convert.ToInt32(Request.QueryString[RecursosVistaProveedor.r]));   
            }
        }

        /// <summary>
        /// Metodo que redirecciona al menu de gestionar
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Evento</param>
        protected void Regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect(RecursosVistaProveedor.webGestionarProv);
        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }


        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

        }

        TextBox IContrato_02_modificarProveedor.Rif
        {
            get { return Rif; }
            set { Rif = value; }
        }

        TextBox IContrato_02_modificarProveedor.Correo
        {
            get { return Correo; }
            set { Correo = value; }
        }

        TextBox IContrato_02_modificarProveedor.RazonS
        {
            get { return RazonS; }
            set { RazonS = value; }
        }

        TextBox IContrato_02_modificarProveedor.PaginaWeb
        {
            get { return PaginaWeb; }
            set { PaginaWeb = value; }
        }

        TextBox IContrato_02_modificarProveedor.Telefono
        {
            get { return Telefono; }
            set { Telefono = value; }
        }

        TextBox IContrato_02_modificarProveedor.FechaContrato
        {
            get { return FechaContrato; }
            set { FechaContrato = value; }
        }

        TextBox IContrato_02_modificarProveedor.Direccion
        {
            get { return Direccion; }
            set { Direccion = value; }
        }

        DropDownList IContrato_02_modificarProveedor.Pais
        {
            get { return Pais; }
            set { Pais = value; }
        }

        DropDownList IContrato_02_modificarProveedor.Estado
        {
            get { return Estado; }
            set { Estado = value; }
        }

        DropDownList IContrato_02_modificarProveedor.Ciudad
        {
            get { return Ciudad; }
            set { Ciudad = value; }
        }

        DropDownList IContrato_02_modificarProveedor.Status
        {
            get { return Status; }
            set { Status = value; }
        }

        public Label LabelMensajeExito
        {
            get { return Mensaje; }
            set { Mensaje = value; }
        }

        public Label LabelMensajeError
        {
            get { return Mensaje; }
            set { Mensaje = value; }
        }


        /// <summary>
        /// Metodo que ejecuta el presentador para modificar
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Evento</param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickBotonAceptar();
        }

    }
}