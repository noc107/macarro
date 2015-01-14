using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.GestionVentaMembresia
{
    public partial class web_14_gestionPrecioMembresia : System.Web.UI.Page
    {
        double _costo;


        /// <summary>
        /// Solicita datos para cargar Costo de Membresia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    LogicaCostoMembresia _logicaCosto = new LogicaCostoMembresia();
            //    _costo = _logicaCosto.solicitarCostoMembresia(1);
            //    mostrarCostosMembresia(_costo);
                
            //}

        }
        /// <summary>
        /// Mostrar el Costo de la Membresia en el componente de la ventana
        /// </summary>
        /// <param name="_costo">costo recibida</param>
        private void mostrarCostosMembresia(double _costo)
        {
            //llena datos del Costo solicitado
            Costo.Text = Convert.ToString(_costo);
        }


        /// <summary>
        /// Modifica Datos delcosto
        /// </summary>
        /// <param name="sender">boton</param>
        /// <param name="e">eventos del boton</param>
        protected void btnModificar_Click(object sender, EventArgs e)
        {
        //    LogicaCostoMembresia _modificar = new LogicaCostoMembresia();
        //    bool _respuesta = _modificar.ModificarCostoMembresia(1,float.Parse(Costo.Text));

        //    if (_respuesta)
        //    {
        //        MensajeExito.Visible = true;
        //    }
        //    else
        //    {
        //        MensajeExito.Visible = true;
        //        MensajeExito.Text = "Costo no pudo ser modificado";
        //        MensajeExito.CssClass = "avisoMensaje MensajeError";
        //        ///btnAceptar.Enabled = false;
        //    }

        }
    }
}