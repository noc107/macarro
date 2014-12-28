using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BackOffice.Presentacion.Vistas.Web.MenuRestaurante
{
    public partial class web_05_agregarSeccion : System.Web.UI.Page
    {





        protected void Page_Load(object sender, EventArgs e)
        {

        }
    

        
        /// <summary>
        /// Evento generado al darle click a agregar en la ventana para luego subirlo a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void agregaSeccion(object sender, EventArgs e)
        {
            
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


   


