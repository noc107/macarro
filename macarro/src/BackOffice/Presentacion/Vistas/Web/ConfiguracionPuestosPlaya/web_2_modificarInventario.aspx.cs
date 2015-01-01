using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.ConfiguracionPuestosPlaya;
using BackOffice.Presentacion.Presentadores.ConfiguracionPuestosPlaya;


namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya
{
    public partial class web_2_modificarInventario : System.Web.UI.Page , IContrato_2_modificarInventario
    {
        private object _parametroId;
        private object _parametroTipo;

        #region Presentador
        private Presentador_2_modificarInventario _presentador;
        #endregion

        #region Implementación de Contrato
        public TextBox CampoPrecio
        {
	        get { return formularioModificarInventario.Precio; }
        }

        public DropDownList DropEstado
        {
	        get { return formularioModificarInventario.Estado; }
        }

        public TextBox CampoDescripcion
        {
	        get { return formularioModificarInventario.Descripcion; }
        }

        public Button BtnAceptar
        {
	        get { return botonAceptar; }
        }

        public Button BtnCancelar
        {
	        get { return botonCancelar; }
        }

        public Label LabelMensajeExito 
        {
            get { return mensajeDeEstado.mensajeExito;}
            set { mensajeDeEstado.mensajeExito = value;}
        }

        public Label LabelMensajeError
        {
            get { return mensajeDeEstado.mensajeError; }
            set { mensajeDeEstado.mensajeError = value; }
        }
        
        #endregion

        #region constructor
        public web_2_modificarInventario()
        {
            _presentador = new Presentador_2_modificarInventario(this);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            _parametroId = Session[RecursosInterfaz.IdInventario];
            _parametroTipo = Session[RecursosInterfaz.InvTipo];
            
            if (_parametroId != null || _parametroTipo != null)
            {
                _presentador.Inicio(_parametroId);
            }
            else
            {
                Response.Redirect(RecursosInterfaz.PaginaConsultarInventario);
            }
        }

        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickAceptar(_parametroId,_parametroTipo);
        }

        protected void botonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(_presentador.EventoClickCancelar());
        }


        #region CodigoAnterior
        //private Inventario _inventario;
   /*     private object _parametroId;
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
        }*/
        #endregion
    }
}