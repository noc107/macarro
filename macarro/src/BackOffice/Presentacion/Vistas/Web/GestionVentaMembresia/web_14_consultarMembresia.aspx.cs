using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.GestionVentaMembresia
{
    public partial class web_14_consultarMembresia : System.Web.UI.Page
    {
        //private Membresia _membresia;
        //private Persona _persona;

        /// <summary>
        /// Carga de informacion de una membresia particular al cargar la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    LogicaConsultarMembresia _consultaMembresia = new LogicaConsultarMembresia();
            //    LogicaConsultarMembresia _consultaPersona = new LogicaConsultarMembresia();
            //    _membresia = new Membresia();
            //    _persona = new Persona();
            //    _membresia = _consultaMembresia.solicitarMembresia(Convert.ToInt16(Request.QueryString["Membresia"]));
            //    _persona = _consultaPersona.solicitarPersona(Convert.ToInt16(Request.QueryString["Membresia"]));
                
            //    mostrarDatosMembresia(_membresia, _persona);

            //    ButtonRegresar.Attributes.Add("onclick", "history.back(); return false;");
            //}

        }

        /// <summary>
        /// Mostrar Membresia Solicitada en los componentes de la ventana
        /// </summary>
        /// <param name="_membresia">Membresia recibida</param>
        /// <param name="_persona">Persona recibida</param>
        //private void mostrarDatosMembresia(Membresia _membresia, Persona _persona)
        //{
        //    //llena datos de Membresia
        //    lbCarnet.Text = Convert.ToString(_membresia.Codigo);
        //    lbTelefono.Text = _membresia.Telefono;
        //    lbStatus.Text = _membresia.Estado;
        //    lbDescuento.Text = Convert.ToString(_membresia.DescAplicado);
        //    lbFechaAdm.Text = Convert.ToString(_membresia.FechaAdmision);
        //    lbFechaVen.Text = Convert.ToString(_membresia.FechaVencimiento);
        //    lbDescuento.Text = Convert.ToString(_membresia.DescAplicado) + "%";
        //    //lbDescuento.Font = Red;

        //    //llena datos de Persona
        //    lbApellido.Text = _persona.PrimerApellido;
        //    lbNombre.Text = _persona.PrimerNombre;
        //    lbCedula.Text = _persona.DocIdentidad;
        //    lbFechaNac.Text = Convert.ToString(_persona.FechaNacimiento);
        //}
        
    }
}