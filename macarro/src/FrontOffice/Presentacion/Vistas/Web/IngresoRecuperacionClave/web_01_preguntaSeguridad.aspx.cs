using FrontOffice.Presentacion.Contratos.IngresoRecuperacionClave;
using FrontOffice.Presentacion.Presentadores.IngresoRecuperacionClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Vistas.Web.IngresoRecuperacionClave
{
    public partial class web_01_preguntaSeguridad : System.Web.UI.Page, IContrato_01_preguntaSeguridad
    {

        private Presentador_01_preguntaSeguridad _presentador;


        protected void Page_Load(object sender, EventArgs e)
        {
            // CARGA DE DATOS

            //string _correoS = (string)(Session["correo"]);
            //LogicaLogin _preguntaSeguridad = new LogicaLogin();
            //Lpregunta.Text = _preguntaSeguridad.obtenerPreguntaL(_correoS);
        }


        string IContrato_01_preguntaSeguridad.Respuesta
        {

            get { return Respuesta.Text; }
            set { Respuesta.Text = value; }
        }


        string IContrato_01_preguntaSeguridad.Lpregunta
        {

            get { return Lpregunta.Text; }
            set { Lpregunta.Text = value; }
        } 



        /// <summary>
        /// Se redirecciona a la página para cambiar la contraseña en caso de que la respuesta de 
        /// seguridad sea la correcta
        /// </summary>
        protected void Siguiente_Click(object sender, EventArgs e)
        {

            _presentador.aceptar_Click();
            //LogicaLogin _respuestaCorrecta = new LogicaLogin();
            //string _correoS = (string)(Session["correo"]);
            
            //if (_respuestaCorrecta.comparar(_correoS, Respuesta.Text))
            //{
            //    Response.Redirect("/Interfaz/web/IngresoRecuperacionClave/web_01_recuperarContrasena.aspx");
            //}
            //else
            //{
            //    Response.Write("Respuesta invalida");
            //}

        
        
        }

        public Label LabelMensajeExito
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Label LabelMensajeError
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}