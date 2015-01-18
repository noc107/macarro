﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Vistas.Web.MenuRestaurante.componentes;
using System.Data;
using BackOffice.Presentacion.Contratos.MenuRestaurante;
using BackOffice.Presentacion.Presentadores.MenuRestaurante;
using System.Data.SqlClient;


namespace BackOffice.Presentacion.Vistas.Web.MenuRestaurante
{
    public partial class web_05_gestionarProducto : System.Web.UI.Page, IContrato_05_GestionarPlato
    {
        private Presentador_05_GestionarProducto _presentador;

        /// <summary>
        /// Inicializacion del presentador
        /// </summary>
        public web_05_gestionarProducto()
        {
            _presentador = new Presentador_05_GestionarProducto(this);
        }

        /// <summary>
        /// Metodo que se ejecuta al cargar la página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _presentador.GridViewPlatos();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Metodo para cargar los datos en el GridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GVPlatos_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ImageButton consultar = _presentador.Consultar();
                    consultar.Click += new ImageClickEventHandler(this.consultarBtn_Click);

                    ImageButton editar = _presentador.Editar();
                    editar.Click += new ImageClickEventHandler(this.editarBtn_Click);

                    ImageButton eliminar = _presentador.Eliminar();
                    eliminar.Click += new ImageClickEventHandler(this.eliminarBtn_Click);

                    e.Row.Cells[4].Controls.Add(consultar);
                    e.Row.Cells[4].Controls.Add(editar);
                    e.Row.Cells[4].Controls.Add(eliminar);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para el manejo de la paginacion del GridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GVPlatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                _gvPlatos.PageIndex = e.NewPageIndex;
                _presentador.GridViewPlatos();
                LabelMensajeError.Visible = false;
            }
            catch (SqlException)
            {

                LabelMensajeError.Visible = true;
            }
            catch (Exception)
            {

                LabelMensajeError.Visible = true;
            }
        }

        /// <summary>
        /// Metodo para manejar el boton consultar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void consultarBtn_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("web_05_consultarPlato.aspx?r=" + _presentador.EventoConsultarBtn_Click(sender), false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para manejar el boton editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void editarBtn_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("web_05_editarPlato.aspx?r=" + _presentador.EventoConsultarBtn_Click(sender), false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para manejar el boton eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void eliminarBtn_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                _presentador.EventoEliminarBtn_Click(sender);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        /// <summary>
        /// Implementacion del metodo GVRoles
        /// </summary>
        public GridView GVPlatos
        {
            get { return _gvPlatos; }
            set { _gvPlatos = value; }
        }

    }
}











///*
//        //Variables Globales
//        //#region Variables_Globales
//        //    private LogicaPlato _cargarDatos;
//        //    private LogicaPlato _mofificarDatos;
//        //#endregion

//            #region Variables de Sesion
//            string _correoS;
//            string _docIdentidadS;
//            string _primerNombreS;
//            string _primerApellidoS;
//            #endregion


//            private void variableSesion()
//            {
//                try
//                {
//                    _correoS = (string)(Session["correo"]);
//                    _docIdentidadS = (string)(Session["docIdentidad"]);
//                    _primerNombreS = (string)(Session["primerNombre"]);
//                    _primerApellidoS = (string)(Session["primerApellido"]);
//                }
//                catch (Exception ex)
//                {
//                    ex.GetType();
//                }
//            } 


//        /// <summary>
//        /// Responsable de verificar las actualizaciones y la carga de datos de la página actual.
//        /// Date by: 6/12/2014
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e">Objeto quien origino o disparó el evento.</param>
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            ////Variables locales
//            //DataTable _datos;
//            //variableSesion();
//            ////Verificar si request es no postback y se esta cargando por primera vez la página.
//            //if (!IsPostBack)
//            //{
               
//            //    this._cargarDatos = new LogicaPlato();
//            //    this._mofificarDatos = new LogicaPlato();
//            //    _datos = new DataTable();
//            //    _datos = _cargarDatos.CargarProducto();
//            //    this.AsignarFuentesDatos(_datos);
//            //    this.EnlazarFuentesDatos();

                
//            //}
//            ////Verificar si request es postback y se intenta actualiza la página.
//            //else
//            //{
//            //    this._cargarDatos = new LogicaPlato();
//            //    this._mofificarDatos = new LogicaPlato();
//            //    _datos = new DataTable();
//            //    _datos = _cargarDatos.CargarProducto();
//            //    this.AsignarFuentesDatos(_datos);
              
//            //}

//        }

//        /*********************************************METODOS***********************************/
//        //#region Metodos

//        ///// <summary>
//        ///// Responsable de guardar objetos en la session de la aplicacion.
//        ///// </summary>
//        ///// <param name="_nombre"></param>
//        ///// <param name="_valor"></param>
//        //public void RegistrarPlatoSession(String _nombre, Plato _valor)
//        //{
//        //    try
//        //    {
//        //        Session[_nombre] = _valor;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        throw ex;
//        //    }
//        //}



//        ///// <summary>
//        ///// Responsable de guardar los tipos de operaciones CRUD en la session de la aplicacion.
//        ///// </summary>
//        ///// <param name="_nombre"></param>
//        ///// <param name="_valor"></param>
//        //public void RegistrarOperacionSession(String _nombre, String _valor)
//        //{
//        //    try
//        //    {
//        //        Session[_nombre] = _valor;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        throw ex;
//        //    }
//        //}

//        ///// <summary>
//        ///// Responsable de retornar platos de la session de la aplicacion.
//        ///// </summary>
//        ///// <param name="_nombre"></param>
//        ///// <param name="_valor"></param>
//        //public Plato ObtenerPlatoSession(String _nombre)
//        //{
//        //    Plato _plato = new Plato();
//        //    try
//        //    {
//        //        _plato = (Plato)Session[_nombre];
//        //        return _plato;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        throw ex;
//        //    }
            
//        //}





//        ///// <summary>
//        ///// Responsable de asignar fuentes de datos al grid view
//        ///// Date by:6/12/2014
//        ///// </summary>
//        ///// <param name="_datos"> Variable con la data </param>
//        //public void AsignarFuentesDatos(DataTable _datos){
//        //    try
//        //    {
//        //        this._gvPlatos.DataSource = _datos;
//        //    }
//        //    catch (Exception e)
//        //    {

//        //    }

//        //}


//        ///// <summary>
//        ///// Responsable de  enlazar fuentes de datos al grid view
//        ///// Date by:6/12/2014
//        ///// </summary>
//        ///// <param name="_datos"> Variable con la data </param>
//        //public void EnlazarFuentesDatos()
//        //{
//        //    try
//        //    {
//        //        this._gvPlatos.DataBind();
//        //    }
//        //    catch (Exception e)
//        //    {

//        //    }

//        //}


//        ///// <summary>
//        ///// Responsable de la instanciación de objetos tipo platos.
//        ///// </summary>
//        ///// <param name="codigo"></param>
//        ///// <param name="nombre"></param>
//        ///// <param name="descripcion"></param>
//        ///// <param name="precio"></param>
//        ///// <param name="estado"></param>
//        ///// <param name="seccion"></param>
//        ///// <returns></returns>
//        //public Plato CrearObjetoPlato(int codigo,String nombre,String descripcion,float precio,String estado,int seccion)
//        //{
//        //     Plato plato = new Plato();
//        //     plato.Codigo = codigo;
//        //     plato.Nombre = nombre;
//        //     plato.Descripcion = descripcion;
//        //     plato.Precio = precio;
//        //     plato.Estado = estado;
//        //     if (seccion>0)
//        //     {
//        //       plato.Seccion = seccion;
//        //     }
//        //    return plato;
//        //}
        
        
//        //#endregion


//        /**********************************************EVENTOS*********************************/

//        //#region Eventos
//        ///// <summary>
//        ///// Evento ejecutado al realizar click sobre cualquier control asp dentro del grid view.
//        ///// </summary>
//        ///// <param name="sender"></param>
//        ///// <param name="e"></param>
//        protected void gridviewPlatos_RowCommand(Object sender, GridViewCommandEventArgs e)
//        {
//        //    try
//        //    {
//        //        String _parametros;
//        //        Plato _plato;
//        //        this._mofificarDatos = new LogicaPlato();
//        //        this._cargarDatos = new LogicaPlato();
//        //        String[] _parametrosArray;
                

//        //        switch (e.CommandName)
//        //        {

//        //            case "Eliminar":
//        //                if (ControlRolAccion.listaAcciones(_correoS).Contains("Eliminar producto"))
//        //                {
//        //                    if (campoOculto.Value.Equals("1"))
//        //                    {
//        //                        //Obtenemos parametros de la fila seleccionada donde se ejecuto evento.
//        //                        _parametros = e.CommandArgument.ToString();
//        //                        if (!String.IsNullOrEmpty(_parametros))
//        //                        {
//        //                            _plato = this.CrearObjetoPlato(int.Parse(_parametros), "", "", 0, "Desactivado", 0);
//        //                            this._mofificarDatos.EliminarProducto(_plato);
//        //                            this.AsignarFuentesDatos(this._cargarDatos.CargarProducto());
//        //                            this.EnlazarFuentesDatos();
//        //                            MensajeExito.Visible = true;
//        //                            campoOculto.Value = "0";
//        //                        }
//        //                        else
//        //                        {
//        //                            MensajeExito.Visible = true;
//        //                            MensajeExito.Text = "Producto no Eliminado";
//        //                            MensajeExito.CssClass = "avisoMensaje MensajeError";
//        //                        }
//        //                    }
//        //                }
//        //                else
//        //                {
//        //                    MensajeExito.Text = "No posee los perminsos para eliminar el ítem";
//        //                    MensajeExito.Visible = true;
//        //                }
//        //            break;
//        //            case "Modificar":
//        //               //Obtenemos parametros de la fila seleccionada donde se ejecuto evento.
//        //               _parametros = e.CommandArgument.ToString();
//        //               _parametrosArray = _parametros.Split('|');
//        //               if (_parametrosArray.Length > 0)
//        //               {
//        //                   _plato = new Plato();
//        //                   _plato.Codigo = int.Parse(_parametrosArray[0].ToString());
//        //                   _plato.Nombre = _parametrosArray[1].ToString();
//        //                   _plato.Descripcion = _parametrosArray[2].ToString();
//        //                   _plato.Precio = float.Parse(_parametrosArray[3].ToString());
//        //                   _plato.NombreSeccion = _parametrosArray[4].ToString();
                           
//        //                   this.RegistrarPlatoSession("Plato", _plato);
//        //                   this.RegistrarOperacionSession("Operacion","Modificar");
//        //                   Response.Redirect("~/Presentacion/Vistas/Web/MenuRestaurante/web_05_modificarProducto.aspx");
//        //               }



                   



//        //            break;


//        //        }



           
                
//        //    }
//        //    catch(Exception ex)
//        //    {
//        //        throw ex;
//        //    }
//        }
//        //#endregion
       
  

//    }
//}
//*/