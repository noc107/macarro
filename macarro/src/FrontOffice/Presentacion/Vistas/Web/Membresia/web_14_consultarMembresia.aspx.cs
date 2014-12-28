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
using System.Drawing;
using System.Web.UI.HtmlControls;


namespace FrontOffice.Presentacion.Vistas.Web.Membresia
{
    public partial class web_14_consultarMembresia : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //string _correo = (string)(Session["correo"]);
            ////string _correo = "andreaPaola@gmail.com";
            //if (!Page.IsPostBack)
            //{    
            //    LogicaConsultarMembresia _consultarMembresia = new LogicaConsultarMembresia();
            //    LogicaConsultarMembresia _consultarPersona = new LogicaConsultarMembresia();

            //    Membre _membresia = new Membre();
            //    Persona _persona = new Persona();

            //    if (_correo != null)
            //    {
                    
            //        _membresia = _consultarMembresia.solicitarMembresia(_correo);
            //        _persona = _consultarPersona.solicitarPersona(_correo);
            //        if (_persona.PrimerNombre != "")
            //        {

            //            this.mostrarDatosMembresia(_membresia, _persona);
            //        }
            //        else
            //        {
            //            lexito.Visible = true;
            //            lexito.Text = "No tiene membresia";
            //            lexito.CssClass = "aMensaje aMensajeError";

            //        }
            //    }
            //    else
            //    {
            //        lexito.Visible = true;
            //        lexito.Text = "Debe iniciar sesión";
            //        lexito.CssClass = "aMensaje aMensajeError";
                    
            //    }
                
            //}

            //Button1.Attributes.Add("onclick", "history.back(); return false");
        }

        //private void mostrarDatosMembresia(Membre _membresia, Persona _persona)
        private void mostrarDatosMembresia()
        {
            ////llena datos de Membresia
            //lcarnet.Text = Convert.ToString(_membresia.Codigo);
            //ltelefono.Text = _membresia.Telefono;
            //lstatus.Text = _membresia.Estado;
            //ldescuento.Text = Convert.ToString(_membresia.DescAplicado) + "%";
            //lfAdm.Text = Convert.ToString(_membresia.FechaAdmision.ToShortDateString());
            //lfVen.Text = Convert.ToString(_membresia.FechaVencimiento.ToShortDateString());
       
            ////llena datos de Persona     
            //lnombre.Text = _persona.PrimerNombre + _persona.PrimerApellido;
            //lcedula.Text = Convert.ToString(_persona.DocIdentidad);
            //lfechanacimiento.Text = Convert.ToString(_persona.FechaNacimiento);           
        }        
    }
}