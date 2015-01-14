using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.MenuRestaurante;
using BackOffice.Presentacion.Presentadores.MenuRestaurante;


namespace BackOffice.Presentacion.Vistas.Web.MenuRestaurante
{
    public partial class web_05_agregarSeccion : System.Web.UI.Page, IContrato_05_AgregarSeccion
    {
        private Presentador_05_AgregarSeccion _presentador;

        /// <summary>
        /// Inicializacion del presentador
        /// </summary>
        public web_05_agregarSeccion()
        {
            _presentador = new Presentador_05_AgregarSeccion(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Evento que se activa cuando el usuario presiona Agregar, primero el usuario debe
        /// ingresar campos que superen las validaciones tales como: campos no vacíos, que no
        /// se ingresen campos no numéricos en numéricos, la longitud mínima y máxima de caracteres
        /// de un campo. Al superar estas validaciones, se llama al procedimiento de agregar 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void agregaSeccion(object sender, EventArgs e)
        {
            try
            {
                _presentador.EventoAceptar_Click();
                _mensajeExito.Visible = true;
                _mensajeError.Visible = false;
            }
            catch (Exception ex)
            {
                _mensajeExito.Visible = false;
                _mensajeError.Visible = true;
            }
        }

        /// <summary>
        /// Implementacion del metodo nombre
        /// </summary>
        public TextBox nombre
        {
            get { return _nombreProducto; }
            set { _nombreProducto = value; }
        }

        /// <summary>
        /// Implementacion del metodo descripcion
        /// </summary>
        public TextBox descripcion
        {
            get { return _descripcionProducto; }
            set { _descripcionProducto = value; }
        }

        /// <summary>
        /// Implementacion del metodo LabelMensajeExito
        /// </summary>
        public Label LabelMensajeExito
        {
            get { return _mensajeExito; }
            set { _mensajeExito = value; }
        }

        /// <summary>
        /// Implementacion del metodo LabelMensajeError
        /// </summary>
        public Label LabelMensajeError
        {
            get { return _mensajeError; }
            set { _mensajeError = value; }
        }     
    }
}
 /*           
        //        try
        //        {
        //            if (new LogicaSeccion().agregarNuevaSeccionMenu(this._nombreProducto.Text,
        //                this._descripcionProducto.Text))
        //            {
        //                _mensajeExitoso.Visible = true;
        //                _nombreProducto.Text = "";
        //                _descripcionProducto.Text = "";
        //                ButtonAgregar.Enabled = false;
                        
        //            }

        //            else
        //            {
        //                _mensajeExitoso.Text = "Fallo al agregar sección";
        //                _mensajeExitoso.CssClass = "avisoMensaje MensajeError";
        //                _mensajeExitoso.Visible = true;
        //                ButtonAgregar.Enabled = false;
                        
        //            }
        //        }

        //        catch (ExcepcionSeccionDatos )
        //        {
        //            throw new ExcepcionSeccionDatos("Error al conectar en la Base de Datos");
        //        }
        //        catch (ExcepcionSeccionLogica)
        //        {
        //            throw new ExcepcionSeccionLogica("Error en la capa lógica");
        //        }

        //        catch (Exception)
        //        {
        //            throw new Exception("Error");
        //        }

        }
    }
}


   
*/

