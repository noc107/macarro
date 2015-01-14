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
    public partial class web_05_agregarProducto : System.Web.UI.Page, IContrato_05_AgregarPlato
    {
        private Presentador_05_AgregarProducto _presentador;

        /// <summary>
        /// Inicializacion del presentador
        /// </summary>
        public web_05_agregarProducto()
        {
            _presentador = new Presentador_05_AgregarProducto(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                _presentador.llenarInfo();
            }

        }

        /// <summary>
        /// Evento que se activa cuando el usuario presiona Agregar, primero el usuario debe
        /// ingresar campos que superen las validaciones tales como: campos no vacíos, que no
        /// se ingresen campos no numéricos en numéricos, la longitud mínima y máxima de caracteres
        /// de un campo. Al superar estas validaciones, se llama al procedimiento de agregar 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void agregaPlato(object sender, EventArgs e)
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
        /// Implementacion del metodo precio
        /// </summary>
        public TextBox precio
        {
            get { return _precioProducto; }
            set { _precioProducto = value; }
        }

        /// <summary>
        /// Implementacion del metodo seccion
        /// </summary>
        public DropDownList seccion
        {
            get { return _seccion; }
            set { _seccion = value; }
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
        //    try
        //    {
        //        if (new LogicaPlato().insertaNuevoPlato(this._nombreProducto.Text, Convert.ToSingle(this._precioProducto.Text),
        //                                               this._descripcionProducto.Text, this._seccion.SelectedItem.Text))
        //        {

        //            _mensajeExito.Visible = true;
        //            _nombreProducto.Text = "";
        //            _descripcionProducto.Text = "";
        //            _precioProducto.Text = "";
        //            ButtonAgregar.Enabled = false; 
        //        }
        //        else
        //        {
        //            _mensajeExito.Text = "Fallo al agregar plato";
        //            _mensajeExito.CssClass = "avisoMensaje MensajeError";
        //            _mensajeExito.Visible = true;
        //            ButtonAgregar.Enabled = false;
        //        }

        //    }

        //    catch (ExcepcionPlatoDatos)
        //    {
        //        throw new ExcepcionPlatoDatos("Error al conectar en la Base de Datos");
        //    }
        //    catch (ExcepcionPlatoLogica)
        //    {
        //        throw new ExcepcionPlatoLogica("Error en la capa lógica");
        //    }
        //    catch (ArgumentOutOfRangeException)
        //    {
        //        throw new ExcepcionPlatoLogica("Número fuera del rango");
        //    }

        //    catch (Exception)
        //    {
        //        throw new ExcepcionPlatoLogica("Error");
        //    }
        }


        ///// <summary>
        ///// Método que se encarga de agregar el nombre de las secciones en el 
        ///// DropDown List. 
        ///// </summary>
        //private void llenarSecciones()
        //{

            
        //    LogicaSeccion _logicaSecciones = new LogicaSeccion(); 
        //    List<Seccion> _secciones = _logicaSecciones.obtenerSecciones();
        //    ListItem _itemCat;

        //    this._seccion.Items.Clear();

        //    _itemCat = new ListItem();
        //    _itemCat.Text = "Seleccione una sección";
        //    _itemCat.Value = "0";
        //    this._seccion.Items.Add(_itemCat);

        //    foreach (Seccion _itemCategoria in _secciones)
        //    {
        //        _itemCat = new ListItem();
        //        _itemCat.Text = _itemCategoria.Nombre;
        //        _itemCat.Value = _itemCategoria.Nombre;
        //        this._seccion.Items.Add(_itemCat); 
        //    }

            
        //}
        
    }
}
                
   */     
    

