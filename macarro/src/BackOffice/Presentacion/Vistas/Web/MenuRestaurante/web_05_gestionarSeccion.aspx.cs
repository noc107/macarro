using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Vistas.Web.MenuRestaurante.componentes;
using System.Data;


/*******************************************/
//Tipo: Modificación
//Descripcion: Desarrollo del evento Page_Load
//Fecha: 6/12/2014
/*******************************************/

namespace BackOffice.Presentacion.Vistas.Web.MenuRestaurante
{
    
    public partial class web_05_gestionarSeccion : System.Web.UI.Page
    {

        //Variables Globales
        //#region Variables_Globales
        //private LogicaSeccion _cargarDatos;
        //private LogicaSeccion _mofificarDatos;
        //#endregion

        #region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        #endregion


        private void variableSesion()
        {
            try
            {
                _correoS = (string)(Session["correo"]);
                _docIdentidadS = (string)(Session["docIdentidad"]);
                _primerNombreS = (string)(Session["primerNombre"]);
                _primerApellidoS = (string)(Session["primerApellido"]);
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        } 


        /// <summary>
        /// Responsable de verificar las actualizaciones y la carga de datos de la página actual.
        /// Date by: 6/12/2014
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Objeto quien origino o disparó el evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ////Variables locales
            //DataTable _datos;
            //variableSesion();
            ////Verificar si request es no postback y se esta cargando por primera vez la página.
            //if (!IsPostBack)
            //{
            //    this._cargarDatos = new LogicaSeccion();
            //    this._mofificarDatos = new LogicaSeccion();
            //    _datos = new DataTable();
            //    _datos = _cargarDatos.CargarSeccion();
            //    this.AsignarFuentesDatos(_datos);
            //    this.EnlazarFuentesDatos();


            //}
            ////Verificar si request es postback y se intenta actualiza la página.
            //else
            //{
            //    this._cargarDatos = new LogicaSeccion();
            //    this._mofificarDatos = new LogicaSeccion();
            //    _datos = new DataTable();
            //    _datos = _cargarDatos.CargarSeccion();
            //    this.AsignarFuentesDatos(_datos);

            //}

        }
    

        /*********************************************METODOS***********************************/
    //#region Metodos

    //    /// <summary>
    //    /// Responsable de asignar fuentes de datos al grid view
    //    /// Date by:6/12/2014
    //    /// </summary>
    //    /// <param name="_datos"> Variable con la data </param>
    //    public void AsignarFuentesDatos(DataTable _datos)
    //    {
    //        try
    //        {
    //            this._gvSeccion.DataSource = _datos;
    //        }
    //        catch (Exception e)
    //        {

    //        }

    //    }


    //    /// <summary>
    //    /// Responsable de  enlazar fuentes de datos al grid view
    //    /// Date by:6/12/2014
    //    /// </summary>
    //    /// <param name="_datos"> Variable con la data </param>
    //    public void EnlazarFuentesDatos()
    //    {
    //        try
    //        {
    //            this._gvSeccion.DataBind();
    //        }
    //        catch (Exception e)
    //        {

    //        }

    //    }


    //    /// <summary>
    //    /// Responsable de la instanciación de objetos tipo Seccion.
    //    /// </summary>
    //    /// <param name="codigo"></param>
    //    /// <param name="nombre"></param>
    //    /// <param name="descripcion"></param>
    //    /// <param name="estado"></param>
    //    /// <returns></returns>
    //    public Seccion CrearObjetoSeccion(int codigo, String nombre, String descripcion, String estado)
    //    {
    //        Seccion seccion = new Seccion();
    //        seccion.Codigo = codigo;
    //        seccion.Nombre = nombre;
    //        seccion.Descripcion = descripcion;
    //        seccion.Estado = estado;
    //        return seccion;
    //    }


    //    #endregion
   

        /**********************************************EVENTOS*********************************/
  
        //#region Eventos
        ///// <summary>
        ///// Evento ejecutado al realizar click sobre cualquier control asp dentro del grid view.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        protected void gridviewSeccion_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
        //    try
        //    {
        //        String _parametros;
        //        String[] _parametrosArray;
        //        Seccion _seccion;
        //        this._mofificarDatos = new LogicaSeccion();
        //        this._cargarDatos = new LogicaSeccion();

              
        //        switch (e.CommandName)
        //        {
        //            case "Eliminar":
        //                if (ControlRolAccion.listaAcciones(_correoS).Contains("Eliminar seccion"))
        //                {
        //                    if (campoOculto.Value.Equals("1"))
        //                    {

        //                        //Obtenemos parametros de la fila seleccionada donde se ejecuto evento.
        //                        _parametros = e.CommandArgument.ToString();
        //                        if (!String.IsNullOrEmpty(_parametros))
        //                        {
        //                            _seccion = this.CrearObjetoSeccion(int.Parse(_parametros), "", "", "Desactivado");
        //                            this._mofificarDatos.EliminarSeccion(_seccion);
        //                            this.AsignarFuentesDatos(this._cargarDatos.CargarSeccion());
        //                            this.EnlazarFuentesDatos();
        //                            MensajeExito.Visible = true;
        //                            this.campoOculto.Value = "0";
        //                        }
        //                        else
        //                        {
        //                            MensajeExito.Visible = true;
        //                            MensajeExito.Text = "Seccion no Eliminada";
        //                            MensajeExito.CssClass = "avisoMensaje MensajeError";
        //                        }

        //                    }
        //                }
        //                else
        //                {
        //                    MensajeExito.Text = "No posee los perminsos para eliminar el ítem";
        //                    MensajeExito.Visible = true;
        //                }
        //            break;
        //            case "Modificar":
        //                _parametros = e.CommandArgument.ToString();
        //               _parametrosArray = _parametros.Split('|');
        //               if (_parametrosArray.Length > 0)
        //               {
        //                   _seccion = new Seccion();
        //                   _seccion.Codigo = int.Parse(_parametrosArray[0].ToString());
        //                   _seccion.Nombre = _parametrosArray[1].ToString();
        //                   _seccion.Descripcion = _parametrosArray[2].ToString();
        //                   _seccion.Estado = _parametrosArray[3].ToString();


        //                   this.RegistrarSeccionSession("Seccion", _seccion);
        //                   this.RegistrarOperacionSession("Operacion","Modificar");
        //                   Response.Redirect("~/Presentacion/Vistas/Web/MenuRestaurante/web_05_modificarSeccion.aspx");
        //               }
                        
        //            break;
        //        }

             

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        }



        ///// <summary>
        ///// Responsable de guardar objetos en la session de la aplicacion.
        ///// </summary>
        ///// <param name="_nombre"></param>
        ///// <param name="_valor"></param>
        //public void RegistrarSeccionSession(String _nombre, Seccion _valor)
        //{
        //    try
        //    {
        //        Session[_nombre] = _valor;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        ///// <summary>
        ///// Responsable de guardar los tipos de operaciones CRUD en la session de la aplicacion.
        ///// </summary>
        ///// <param name="_nombre"></param>
        ///// <param name="_valor"></param>
        //public void RegistrarOperacionSession(String _nombre, String _valor)
        //{
        //    try
        //    {
        //        Session[_nombre] = _valor;
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
        //public Seccion ObtenerSeccionSession(String _nombre)
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

        //#endregion

    }
   
}