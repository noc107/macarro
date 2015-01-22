using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BackOffice.Presentacion.Contratos.Proveedores;
using BackOffice.Presentacion.Contratos;
using BackOffice.Presentacion.Presentadores.Proveedores;
using BackOffice.Presentacion.Vistas.Web.Proveedores.Recursos;

namespace BackOffice.Presentacion.Vistas.Web.Proveedores
{
    public partial class web_02_agregarProveedores : System.Web.UI.Page, IContrato_02_agregarProveedores
    {
        Presentador_02_agregarProveedores _presentador;


        /// <summary>
        /// Metodo por defecto / estandar , se ejecuta al cargase la pagina
        /// </summary>
        /// <param name= sender> Objeto</param>
        /// <param name= e> Argumento</param>
        public web_02_agregarProveedores() 
        {
            _presentador = new Presentador_02_agregarProveedores(this);
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {   
                _presentador.cargarPaises();
                _presentador.cargarEstados();
                _presentador.cargarCiudades();
            }
        }



        /// <summary>
        /// Evento, le da funcionalidad al boton de aceptar al hacer un click en el mismo
        /// </summary>
        /// <param name= sender> Objeto </param>
        /// <param name= e> Argumento </param>
        /// 
        protected void Aceptar_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickBotonAceptar();
        }

       

        TextBox IContrato_02_agregarProveedores.Rif
        {
            get { return Rif; }
        }

        TextBox IContrato_02_agregarProveedores.RazonSocial 
        {
            get { return RazonSocial; }
        }

        TextBox IContrato_02_agregarProveedores.Correo 
        {
            get { return Correo; }
        }

        TextBox IContrato_02_agregarProveedores.PaginaWeb 
        {
            get { return PaginaWeb; }
        }

        TextBox IContrato_02_agregarProveedores.Telefono 
        {
            get { return Telefono; }
        }

        TextBox IContrato_02_agregarProveedores.FechaContrato 
        {
            get { return FechaContrato; }
        }

        TextBox IContrato_02_agregarProveedores.Direccion 
        {
            get { return Direccion; }
        }

        DropDownList IContrato_02_agregarProveedores.Pais 
        {
            get { return _Pais; }
        }

        DropDownList IContrato_02_agregarProveedores.Estado 
        {
            get { return _Estado; }
        }

        DropDownList IContrato_02_agregarProveedores.Ciudad 
        {
            get { return _Ciudad; }
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

        protected void _Pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presentador.EventoCambioPais();
        }

        protected void _Ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void _Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presentador.EventoCambioEstado();
        }
    }
}