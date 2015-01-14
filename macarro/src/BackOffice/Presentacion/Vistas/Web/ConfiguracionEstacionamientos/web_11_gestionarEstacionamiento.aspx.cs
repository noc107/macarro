using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.ConfiguracionEstacionamiento;
using BackOffice.Presentacion.Presentadores.ConfiguracionEstacionamiento;

namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionEstacionamientos
{
    public partial class web_11_gestionarEstacionamiento : System.Web.UI.Page, IContrato_11_gestionarEstacionamiento
    {

        #region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        #endregion

        private Presentador_11_gestionarEstacionamiento _presentador;

        public web_11_gestionarEstacionamiento()
        {
            _presentador = new Presentador_11_gestionarEstacionamiento(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //variableSesion();
            
               
        }

        private void variableSesion()
        {
            try
            {
                _correoS = (string)(Session["correo"]);
                _docIdentidadS = (string)(Session["docIdentidad"]);
                _primerNombreS = (string)(Session["primerNombre"]);
                _primerApellidoS = (string)(Session["primerApellido"]);
            }
            catch (Exception ex)
            {
                //Mensaje.Text = "No se han podido cargar los datos de sesion";
                //Mensaje.Visible = true;
                ex.GetType();
            }
        }

        string IContrato_11_gestionarEstacionamiento.LabelNombre
        {
            get { return _nombreEstacionamiento.Text; }
            set { _nombreEstacionamiento.Text = value; }
        }

        string IContrato_11_gestionarEstacionamiento.LabelCapacidad
        {
            get { return _capacidad.Text; }
            set { _capacidad.Text = value; }
        }

        string IContrato_11_gestionarEstacionamiento.LabelEstado
        {
            get { return _estado.Text; }
            set { _estado.Text = value; }
        }

        string IContrato_11_gestionarEstacionamiento.LabelPerdido
        {
            get { return _tarifaPerdido.Text; }
            set { _tarifaPerdido.Text = value; }
        }

        string IContrato_11_gestionarEstacionamiento.LabelTarifa
        {
            get { return _tarifa.Text; }
            set { _tarifa.Text = value; }
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

        protected void ButtonEditar_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickBoton();
        }
    }
}