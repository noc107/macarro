using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Presentadores.InventarioRestaurante;
using BackOffice.Presentacion.Contratos.InventarioRestaurante;
using BackOffice.Presentacion.Vistas.Web.InventarioRestaurante.Recursos;

namespace BackOffice.Presentacion.Vistas.Web.InventarioRestaurante
{
    public partial class web_06_agregarItem : System.Web.UI.Page, IContrato_06_agregarItem
    {
        Presentador_06_agregarItem _presentador;

        #region Constructor
        public web_06_agregarItem()
        {
            this._presentador = new Presentador_06_agregarItem(this);
        }
        #endregion

        #region Implementación de Contrato
        public TextBox CantidadMinima
        {
            get
            {
                return this._cantidadMinima;
            }

        }

        public TextBox Nombre
        {
            get
            {
                return this._nombre;
            }
        }

        public TextBox Cantidad
        {
            get
            {
                return this._cantidad;
            }
        }

        public TextBox Descripcion
        {
            get
            {
                return this._descripcion;
            }
        }

        public TextBox PrecioVenta
        {
            get
            {
                return this._precioVenta;
            }
        }

        public TextBox PrecioCompra
        {
            get
            {
                return this._precioCompra;

            }
        }

        public DropDownList Proveedor
        {
            get
            {
                return this._proveedor;
            }

            set
            {
                this._proveedor = value;
            }

        }

        public Label LabelMensajeExito
        {
            get
            {
                return this._mensajeExito;
            }
            set
            {
                this._mensajeExito = value;
            }
        }

        public Label LabelMensajeError
        {
            get
            {
                return this._mensajeError;
            }
            set
            {
                this._mensajeError = value;
            }
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            _presentador.llenarListaRazonSocial();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (_presentador.EventoAceptar(_proveedor.SelectedIndex))
            {
                _presentador.MostrarMensajeExito(RecursosInventario.MensajeDeExitoAgregarItem);
                LabelMensajeExito.Visible = true;
            }
        }
    }
}