using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.Proveedores;
using BackOffice.Presentacion.Contratos;
using BackOffice.Presentacion.Presentadores.Proveedores;
using BackOffice.Presentacion.Vistas.Web.Proveedores.Recursos;

namespace BackOffice.Presentacion.Vistas.Web.Proveedores
{
    public partial class web_02_consultarProveedor : System.Web.UI.Page , IContrato_02_consultarProveedor
    {
        Presentador_02_consultarProveedor _presentador;
        public web_02_consultarProveedor() 
        {
            _presentador = new Presentador_02_consultarProveedor(this);
        }

         
        /// <summary>
        /// Metodo por defecto / estandar , se ejecuta al cargase la pagina
        /// </summary>
        /// <param name= sender> Objeto</param>
        /// <param name= e> Argumento</param>
        /// <exception> Exception , Param = ex </exception>
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                _presentador.cargarItems(Convert.ToInt32(Request.QueryString[RecursosVistaProveedor.r]));
            }
            _presentador.EventoBotonConsultar(Convert.ToInt32(Request.QueryString[RecursosVistaProveedor.r]));
        }

         
        /// <summary>
        /// Evento, cuya funcion se realiza al clickear el boton especificado
        /// Regresa al menu anterior 'Gestionar Proveedores'
        /// </summary>
        /// <param name= sender> Objeto </param>
        /// <param name= e> Argumento </param>  
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(RecursosVistaProveedor.webGestionarProv);
        }

        Label IContrato_02_consultarProveedor.Rif
        {
            get {return Rif; }
            set { Rif = value; }
        }

        Label IContrato_02_consultarProveedor.RazonSocial
        {
            get { return RazonSocial; }
            set { RazonSocial = value; }
        }

        Label IContrato_02_consultarProveedor.Correo
        {
            get { return Correo; }
            set { Correo = value; }
        }

        Label IContrato_02_consultarProveedor.PaginaWeb
        {
            get { return PaginaWeb; }
            set { PaginaWeb = value; }
        }

        Label IContrato_02_consultarProveedor.Telefono
        {
            get { return Telefono; }
            set { Telefono = value; }
        }

        Label IContrato_02_consultarProveedor.FechaContrato
        {
            get { return FechaContrato; }
            set { FechaContrato = value; }
        }

        Label IContrato_02_consultarProveedor.Estado
        {
            get { return Estado; }
            set { Estado = value; }
        }

        Label IContrato_02_consultarProveedor.Pais
        {
            get { return Pais; }
            set { Pais = value; }
        }

        ListBox IContrato_02_consultarProveedor.Items
        {
            get { return ListItem; }
            set { ListItem = value; }
        }

        public Label LabelMensajeExito
        {
            get { return Label23; }
            set { Label23 = value; }
        }

        public Label LabelMensajeError
        {
            get { return Label23; }
            set { Label23 = value; }
        }

    }
}