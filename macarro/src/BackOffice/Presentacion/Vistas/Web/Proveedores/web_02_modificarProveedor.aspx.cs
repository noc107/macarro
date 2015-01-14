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

namespace BackOffice.Presentacion.Vistas.Web.Proveedores
{
    public partial class web_02_modificarProveedor : System.Web.UI.Page , IContrato_02_modificarProveedor
    {
        //LogicaProveedor _auxLogica = new LogicaProveedor();
        //ProveedorBD auxDatos = new ProveedorBD();
        Presentador_02_modificarProveedor _presentador;

        public web_02_modificarProveedor() 
        {
            _presentador = new Presentador_02_modificarProveedor(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_02_gestionarProveedores.aspx");
        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //TomarValoresGridviewAgregar();
        }


        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
           //Eliminar items seleccionados de la lista de items del proveedor
           //TomarValoresGridviewEliminar();
           //Mensaje de aviso
        }

        TextBox IContrato_02_modificarProveedor.Rif
        {
            get { return Rif; }
            set { Rif = value; }
        }

        TextBox IContrato_02_modificarProveedor.RazonSocial
        {
            get { return RazonSocial; }
            set { RazonSocial = value; }
        }

        TextBox IContrato_02_modificarProveedor.Correo
        {
            get { return Correo; }
            set { Correo = value; }
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

        GridView IContrato_02_modificarProveedor.Items
        {
            get { return GridItems; }
            set { GridItems = value; }
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
    }
}