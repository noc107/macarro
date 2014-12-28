using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya
{
    public partial class web_2_modificarInventario : System.Web.UI.Page
    {
        //private Inventario _inventario;
        private object _parametroId;
        private object _parametroTipo;

        protected void Page_Load(object sender, EventArgs e)
        {
            
                //_parametroId = Session[RecursosInterfaz.IdInventario];
                //_parametroTipo = Session[RecursosInterfaz.InvTipo];
                //if (_parametroId != null || _parametroTipo != null)
                //{                    
                //    Inicio();
                //}
                //else
                //{
                //    Response.Redirect(RecursosInterfaz.PaginaConsultarInventario);
                //}

        }

        /// <summary>
        /// Inicia valores por defecto en la pagina
        /// </summary>
        //private void Inicio()
        //{
        //    if (_parametroId != null)
        //    {
                        
        //        int parametro;
        //        parametro = (int)_parametroId;
        //        try
        //        {
        //            _inventario = (new LogicaInventario()).ConsultarInventarioId(parametro);
        //        }
        //        catch (ExceptionDatos ex)
        //        {
        //            this.mensajeDeEstado.MensajeDeError(ex.Message + RecursosExcepciones.mensajeDeDatos);
        //        }
        //        catch (ExceptionLogica ex)
        //        {
        //            this.mensajeDeEstado.MensajeDeError(ex.Message + RecursosExcepciones.mensajeDeLogica);
        //        }
        //        catch (Exception)
        //        {
        //            this.mensajeDeEstado.MensajeDeError(RecursosExcepciones.mensajeFalso);
        //        }

        //        if (!IsPostBack)
        //        {
        //            this.formularioModificarInventario.setPrecio(Convert.ToString(_inventario.Precio));
        //            this.formularioModificarInventario.setDescripcion(_inventario.Descripcion);
        //            this.formularioModificarInventario.setEstado(_inventario.Estado);
        //            (this.formularioModificarInventario.getDescripcion()).Enabled = true;
        //            (this.formularioModificarInventario.getEstado()).Enabled = true;   
        //        }
        //    }
        //    else
        //    {
        //        (this.formularioModificarInventario.getDescripcion()).Enabled = false;
        //        (this.formularioModificarInventario.getDescripcion()).Enabled = false;
        //        (this.formularioModificarInventario.getEstado()).Enabled = false;
        //    }

        //}

        ///// <summary>
        ///// Evento llamado al presionar el boton aceptar que llama a la capa logica para 
        ///// actualizar el inventario con los valores deseados 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        protected void botonAceptar_Click(object sender, EventArgs e)
        {
        //    this.mensajeDeEstado.OcultarMensajeDeExito();
        //    this.mensajeDeEstado.OcultarMensajeDeError();
        //    if (_parametroId != null)
        //    {
        //        _inventario.Precio = float.Parse((this.formularioModificarInventario.getPrecio()).Text);
        //        _inventario.Estado = (this.formularioModificarInventario.getEstado()).Text;
        //        _inventario.Descripcion = (this.formularioModificarInventario.getDescripcion()).Text;
        //        try
        //        {
        //            LogicaInventario actualizar = new LogicaInventario();

        //            if (actualizar.ActualizarInventario(_inventario, _parametroId))
        //            {
        //                this.mensajeDeEstado.MensajeDeExito(RecursosInterfaz.mensajeDeExitoModificarInventario);
        //            }
        //            else
        //            {
        //                this.mensajeDeEstado.MensajeDeError(RecursosInterfaz.mensajeDeErrorModificarInventario);
        //            }
        //        }
        //        catch (ExceptionDatos ex)
        //        {
        //            this.mensajeDeEstado.MensajeDeError(ex.Message + RecursosExcepciones.mensajeDeDatos);
        //        }
        //        catch (ExceptionLogica ex)
        //        {
        //            this.mensajeDeEstado.MensajeDeError(ex.Message + RecursosExcepciones.mensajeDeLogica);
        //        }
        //        catch (Exception)
        //        {
        //            this.mensajeDeEstado.MensajeDeError(RecursosExcepciones.mensajeFalso);
        //        }
        //        finally
        //        {
        //            this.botonAceptar.Enabled = false;
        //        }
            
        //    }
        //    else
        //    {
        //        _inventario = new Inventario();                
        //        _inventario.Precio = float.Parse((this.formularioModificarInventario.getPrecio()).Text);
        //        _inventario.Tipo = (string)_parametroTipo;
        //        try
        //        {
        //            LogicaInventario actualizar = new LogicaInventario();

        //            if (actualizar.ActualizarInventario(_inventario, _parametroId))
        //            {
        //                this.mensajeDeEstado.MensajeDeExito(RecursosInterfaz.mensajeDeExitoModificarInventario);
        //            }
        //            else
        //            {
        //                this.mensajeDeEstado.MensajeDeError(RecursosInterfaz.mensajeDeErrorModificarInventario);
        //            }
        //        }
        //        catch (ExceptionDatos ex)
        //        {
        //            this.mensajeDeEstado.MensajeDeError(ex.Message + RecursosExcepciones.mensajeDeDatos);
        //        }
        //        catch (ExceptionLogica ex)
        //        {
        //            this.mensajeDeEstado.MensajeDeError(ex.Message + RecursosExcepciones.mensajeDeLogica);
        //        }
        //        catch (Exception)
        //        {
        //            this.mensajeDeEstado.MensajeDeError(RecursosExcepciones.mensajeFalso);
        //        }
        //        finally
        //        {
        //            this.botonAceptar.Enabled = false;
        //        }
        //    }

        }



        protected void botonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(RecursosInterfaz.PaginaConsultarInventario);
        }
    }
}