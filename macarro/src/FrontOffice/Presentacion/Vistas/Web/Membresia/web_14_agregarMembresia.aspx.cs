using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Vistas.Web.Membresia
{
    public partial class web_14_agregarMembresia : System.Web.UI.Page
    {
        private float _costo;
        bool _respuestaPago;
        bool _respuestaMembresia;
        int _respuestaIdMembresia;

        /// <summary>
        /// Crea objeto para para invocar a métodos de Lógica para consultar costo de membresía
        /// </summary>
        /// <param name="object sender">parámetros por defecto</param>      
        /// <param name="EventArgs e">parámetros por defecto</param>   
        protected void Page_Load(object sender, EventArgs e)
        {
            //LogicaConsultarMembresiaCosto _consultarCosto = new LogicaConsultarMembresiaCosto();
            //_costo = _consultarCosto.solicitarCosto();
            //tbtotal.Text = Convert.ToString(_costo);

            //CancelarBoton.Attributes.Add("onclick", "history.back(); return false");
        }

        /// <summary>
        /// Crea objeto para para invocar a métodos de Lógica para insertar membresía y pago de membresía
        /// </summary>
        /// <param name="object sender">parámetros por defecto</param>      
        /// <param name="EventArgs e">parámetros por defecto</param>   
        protected void AceptarBoton_Click(object sender, EventArgs e)
        {
            //string _usuario = (string)(Session["correo"]);
            //LogicaInsertarMembresia _insertarMembresia = new LogicaInsertarMembresia();
            //_respuestaMembresia = _insertarMembresia.InsertarMembresia(tbtelefono.Text, _costo, _usuario);
            //if (_respuestaMembresia)
            //{
            //    LogicaConsultarMembresia _consultarIdMembresia = new LogicaConsultarMembresia();
            //    _respuestaIdMembresia = _consultarIdMembresia.solicitarIdMembresia();

            //    LogicaInsertarPago _insertarPago = new LogicaInsertarPago();
            //    _respuestaPago = _insertarPago.InsertarPago(_costo, _respuestaIdMembresia);
            //}

            //if ((_respuestaMembresia) && (_respuestaPago))
            //{
            //    lexito.Visible = true;
            //}
            //else
            //{
            //    lexito.Visible = true;
            //    lexito.Text = "Membresia no agregada";
            //    lexito.CssClass = "aMensaje aMensajeError";
            //    AceptarBoton.Enabled = false;
            //}               
         }
    }
}