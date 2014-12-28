using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Vistas.Web.MenuRestaurante.componentes;


namespace BackOffice.Presentacion.Vistas.Web.MenuRestaurante
{
    public partial class web_05_modificarSeccion : System.Web.UI.Page
    {
        //LogicaSeccion _logicaSeccion = new LogicaSeccion();


        protected void Page_Load(object sender, EventArgs e)
        {
            ////Variables Locales
            //Seccion _seccion = new Seccion();
            //String operacion = "";

            //operacion = this.ObtenerOperacionSession("Operacion");

            //if (!IsPostBack)
            //{
            //    switch (operacion)
            //    {
            //        case "Modificar":
            //            _seccion = this.ObtenerPlatoSession("Seccion");
            //            this.LLenarFormulario(_seccion);
            //            break;
            //    }
            //}
            //else
            //{
                
            //}
        }



        /// <summary>
        /// Responsable de llenar formulario con data.
        /// </summary>
        /// <param name="_plato"></param>
        //public void LLenarFormulario(Seccion  _seccion)
        //{
        //    try
        //    {
        //        if (_seccion != null)
        //        {
        //            this.nombreProducto.Text = _seccion.Nombre;
        //            this.descripcionProducto.Text = _seccion.Descripcion;
                   
        //        }
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
        //public Seccion ObtenerPlatoSession(String _nombre)
        //{
        //    Seccion _seccion = new Seccion();
        //    try
        //    {
        //        _seccion = (Seccion)Session[_nombre];
        //        return _seccion;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}


        ///// <summary>
        ///// Responsable de retornar operaciones de la session de la aplicacion.
        ///// </summary>
        ///// <param name="_nombre"></param>
        ///// <param name="_valor"></param>
        //public String ObtenerOperacionSession(String _nombre)
        //{
        //    try
        //    {
        //        String _operacion = "";
        //        _operacion = (String)Session[_nombre];
        //        return _operacion;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}



        ///// <summary>
        ///// Obtiene objeto seccion con los valores modificados.
        ///// </summary>
        ///// <param name="_producto"></param>
        ///// <returns></returns>
        //public Seccion ObtenerSeccionFormulario(Seccion _seccion)
        //{
        //                try
        //    {
        //        _seccion.Nombre = this.nombreProducto.Text;
        //        _seccion.Descripcion = this.descripcionProducto.Text;
        //        _seccion.Estado = "Activado";
        //        return _seccion;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}



        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
        //    if (campoOculto.Value.Equals("1"))
        //    {
        //        LogicaSeccion _mofificar = new LogicaSeccion();
        //        Seccion _seccion = new Seccion();
        //        _seccion = _seccion = this.ObtenerPlatoSession("Seccion");
        //        _seccion = this.ObtenerSeccionFormulario(_seccion);

        //        //bool _respuesta = _mofificar.ModificarMembresia(int.Parse(lbCarnet.Text), cbStatus.Text, float.Parse(descuento1.Text));
        //        bool _respuesta = _mofificar.ModificarSeccion(_seccion);

        //        if (_respuesta)
        //        {
        //            MensajeExito.Visible = true;
        //            this.ButtonAgregar.Enabled = true;
        //            this.campoOculto.Value = "0";
        //        }
        //        else
        //        {

        //            MensajeExito.Visible = true;
        //            MensajeExito.Text = "Seccion No Modificada";
        //            MensajeExito.CssClass = "avisoMensaje MensajeError";
        //            //btnAceptar.Enabled = false;
        //        }
        //    }
        }
    }
  
}