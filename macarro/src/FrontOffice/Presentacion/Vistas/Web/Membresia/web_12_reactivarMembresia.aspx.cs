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
    public partial class web_12_reactivarMembresia : System.Web.UI.Page, IContrato_12_reactivarMembresia
    {

        Presentador_12_reactivarMembresia _presentador;

        public web_12_reactivarMembresia() 
        {

            _presentador = new Presentador_12_reactivarMembresia(this);
        
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
        public Label numeroCarnet
        {
            get { return _numeroCarnet; }
            set { _numeroCarnet = value; }
        }
        public Label fechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }
        public Panel formulariosM
        {
            get { return formularios; }
            set { formularios= value;}
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
        public Image foto
        {
            get { return _foto; }
            set { _foto = value; }
        }
        public Button aceptar
        {
            get { return _aceptar; }
            set { _aceptar = value; }
        }
        public Button cancelar
        {
            get { return _cancelar; }
            set { _cancelar = value; }
        }
        //public Button cambiarFoto
        //{
        //    get { return _cambiarFoto; }
        //    set { _cambiarFoto = value; }
        //}
        //public TextBox FotoPath
        //{
        //    get { return _pathImagen; }
        //    set { _pathImagen = value; }
        //}
        public TextBox numeroTarjeta
        {
            get { return _numeroTarjeta; }
            set { _numeroTarjeta = value; }
        }
        public TextBox nombreImpresoEnTarjeta
        {
            get { return _nombreImpresoEnTarjeta; }
            set { _nombreImpresoEnTarjeta = value; }
        }
        public TextBox cvv
        {
            get { return _cvv; }
            set { _cvv = value; }
        }
        public DropDownList anoVencimiento
        {
            get { return _anoVencimiento; }
            set { _anoVencimiento = value; }
        }
        public DropDownList mesVencimiento
        {
            get { return _mesVencimiento; }
            set { _mesVencimiento = value; }
        }
        public Label montoTotal
        {
            get { return _montoTotal; }
            set { _montoTotal = value; }
        }
        public GridView gridTarjetasUsadas
        {
            get { return _gridTarjetasUsadas; }
            set { _gridTarjetasUsadas = value; }
        }
        public Button agregarTarjeta
        {
            get { return _agregarTarjeta; }
            set { _agregarTarjeta = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presentador.Page_Load();
            }
            else
            {
                    this.FileUpload1.DataBind();
            }
        }

        protected void _cambiarFoto_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickCambiarFoto();
        }

        protected void _aceptar_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickAceptar();
        }

        protected void _cancelar_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickCancelar();
        }

        protected void _agregarTarjeta_Click(object sender, EventArgs e)
        {
            
            _presentador.EventoClickAgregarTarjeta();
        }


        protected void _gridTarjetasUsadas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _presentador._gridTarjetasUsadas_PageIndexChanging(sender, e);
        }

        protected void _tarjetaElegidaEnGrid_CheckedChanged(object sender, System.EventArgs e)
        {
            _presentador.QuitarCheckALosDemas(sender, e);  
        }

        protected void CancelarUpload_Click(object sender, EventArgs e)
        {
            this.FileUpload1.Dispose();
        }


    }
}