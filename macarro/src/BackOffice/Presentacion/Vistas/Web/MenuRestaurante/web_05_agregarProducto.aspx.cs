using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.MenuRestaurante
{
    public partial class web_05_agregarProducto : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    this.llenarSecciones();
            //}

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
                
        
    

