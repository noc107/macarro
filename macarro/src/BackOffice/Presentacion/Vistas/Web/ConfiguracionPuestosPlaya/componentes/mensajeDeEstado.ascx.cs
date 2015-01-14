using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya.componentes
{
    public partial class mensajeDeError : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region PROPIEDADES
        public Label mensajeExito
        {
            get { return MensajeExito; }
            set { MensajeExito = value; }
        }

        public Label mensajeError
        {
            get { return MensajeExcepcion; }
            set { MensajeExcepcion = value; }
        }

        #endregion

        #region MANEJO DE LOS LABEL DE MENSAJE
        public void MensajeDeExito(string mensaje)
        {
            this.MensajeExito.Text = mensaje;
            this.MensajeExito.Visible = true;
        }

        public void OcultarMensajeDeExito()
        {
            this.MensajeExito.Visible = false;
        }

        public void MensajeDeError(string mensaje)
        {
            this.MensajeExcepcion.Text = mensaje;
            this.MensajeExcepcion.Visible = true;
        }

        public void OcultarMensajeDeError()
        {
            this.MensajeExcepcion.Visible = false;
        }
        #endregion
    }
}