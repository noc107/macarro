using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Vistas.Web.MenuRestaurante.componentes;



namespace BackOffice.Presentacion.Vistas.Web.MenuRestaurante
{
    public partial class web_05_modificarProducto : System.Web.UI.Page
    {
        #region Variables_Globales
           //LogicaSeccion _logicaSeccion = new LogicaSeccion();
        #endregion
       



        protected void Page_Load(object sender, EventArgs e)
        {
            ////Variables Locales
            //Plato plato = new Plato();
            //String operacion = "";

            //operacion = this.ObtenerOperacionSession("Operacion");
       
          

            //if (!IsPostBack)
            //{
            //    switch (operacion)
            //    {
            //        case "Modificar":
            //             plato = this.ObtenerPlatoSession("Plato");
            //             this.LLenarFormulario(plato);
            //             this.LlenarDropDownListSecciones();
            //             this.SeleccionarSeleccionDropDownList(plato);
                       
            //        break;
            //    }
            //}
            //else
            //{
            //    //this.LlenarDropDownListSecciones();
            //}

        }



        //#region Metodos
        

        ///// <summary>
        ///// Seleccionar elemento de drop down list de seleccion.
        ///// </summary>
        ///// <param name="_plato"></param>
        //public void SeleccionarSeleccionDropDownList(Plato _plato)
        //{
        //    if (_plato!=null)
        //    {
        //        if (_plato.Seccion > 0)
        //        {
        //            this.SeccionDropDownList.SelectedValue = _plato.Seccion.ToString();
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(_plato.NombreSeccion))
        //            {
        //                this.SeccionDropDownList.SelectedValue = this.SeccionDropDownList.Items.FindByText(_plato.NombreSeccion).Value;
        //                this.SeccionDropDownList.Items.FindByText(_plato.NombreSeccion).Selected = true;
        //            }
        //        }

        //    }
        //}



        ///// <summary>
        ///// Responsable de retornar platos de la session de la aplicacion.
        ///// </summary>
        ///// <param name="_nombre"></param>
        ///// <param name="_valor"></param>
        //public Plato ObtenerPlatoSession(String _nombre)
        //{
        //    Plato _plato = new Plato();
        //    try
        //    {
        //        _plato = (Plato)Session[_nombre];
        //        return _plato;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}


        ///// <summary>
        ///// Responsable de retornar platos de la session de la aplicacion.
        ///// </summary>
        ///// <param name="_nombre"></param>
        ///// <param name="_valor"></param>
        //public String ObtenerOperacionSession(String _nombre)
        //{
        //    try
        //    {
        //        String _operacion = "";
        //        _operacion= (String)Session[_nombre];
        //        return _operacion;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}


        ///// <summary>
        ///// Responsable de llenar formulario con data.
        ///// </summary>
        ///// <param name="_plato"></param>
        //public void LLenarFormulario(Plato _plato)
        //{
        //    try
        //    {
        //        if (_plato != null)
        //        {
        //            this.nombreProducto.Text = _plato.Nombre;
        //            this.descripcionProducto.Text = _plato.Descripcion;
        //            this.precioProducto.Text = _plato.Precio.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        ///// <summary>
        ///// Responsable de cargar los datos en el DropDownList de Seccion
        ///// </summary>
        //public void LlenarDropDownListSecciones()
        //{
        //    try
        //    {
        //        if (this._logicaSeccion != null)
        //        {
                  
                  
        //            this.SeccionDropDownList.DataSource = this._logicaSeccion.CargarSeccionOpciones();
        //            this.SeccionDropDownList.DataValueField = "Codigo";
        //            this.SeccionDropDownList.DataTextField = "nombre";
        //            this.SeccionDropDownList.DataBind();
        //            this.SeccionDropDownList.Items.Insert(0, new ListItem("Seleccione...", "Seleccione..."));

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        ///// <summary>
        ///// Obtiene objeto plato con los valores modificados.
        ///// </summary>
        ///// <param name="_producto"></param>
        ///// <returns></returns>
        //public Plato ObtenerProductoFormulario(Plato _producto)
        //{
        //    try
        //    {
        //        _producto.Nombre = this.nombreProducto.Text;
        //        _producto.Descripcion = this.descripcionProducto.Text;
        //        _producto.Precio = float.Parse(this.precioProducto.Text);
        //        _producto.Seccion = int.Parse(this.SeccionDropDownList.SelectedItem.Value);
        //        _producto.NombreSeccion = this.SeccionDropDownList.SelectedItem.Text;
        //        _producto.Estado = "Activado";
        //        return _producto;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}


        //#endregion



        /// <summary>
        /// Responsable de ejecutar logica cuando usuario realize click en botom para modificar producto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
        //    LogicaPlato _mofificar = new LogicaPlato();
        //    Plato _plato= new Plato();
            
        //    if (campoOculto.Value.Equals("1"))
        //    {
        
        //    _plato = this.ObtenerPlatoSession("Plato");
        //    _plato = this.ObtenerProductoFormulario(_plato);

        //    bool _respuesta = _mofificar.ModificarProducto(_plato); 

        //    if (_respuesta) 
        //    {
        //        MensajeExito.Visible = true;
        //        this.campoOculto.Value = "0";
        //        this.ButtonAgregar.Enabled = false;
        //    }
        //    else
        //    {
        //        MensajeExito.Visible = true;
        //        MensajeExito.Text = "Producto no modificado";
        //        MensajeExito.CssClass = "avisoMensaje MensajeError";
        //        //btnAceptar.Enabled = false;
        //    }
        //  }
        }
    }
}