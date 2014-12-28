using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya
{
    public partial class web_2_consultarInventario : System.Web.UI.Page
    {

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


        protected void Page_Load(object sender, EventArgs e)
        {
            variableSesion();
        }

        /// <summary>
        /// Buscador que se activa al presionar el boton de aceptar
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Evento</param>
        protected void ConsultarListaInventario(object sender, EventArgs e)
        {
        //    this.mensajeDeEstado.OcultarMensajeDeExito();
        //    this.mensajeDeEstado.OcultarMensajeDeError();
        //    try
        //    {                  
        //        Buscardor();
        //    }
        //    catch (ExceptionDatos ex)
        //    {
        //        this.mensajeDeEstado.MensajeDeError(ex.Message + RecursosExcepciones.mensajeDeDatos);
        //    }
        //    catch (ExceptionLogica ex)
        //    {
        //        this.mensajeDeEstado.MensajeDeError(ex.Message + RecursosExcepciones.mensajeDeLogica);
        //    }
        //    catch (Exception)
        //    {
        //        this.mensajeDeEstado.MensajeDeError(RecursosExcepciones.mensajeFalso);
        //    }
        }

        ///// <summary>
        ///// Buscador de Inventario según tipo de Inventario
        ///// </summary>
        //private void Buscardor()
        //{
        //        string tipo = this.comboConsultarInventario.TipoItem();
        //        LlenarGVInventario(ConsultarInventario(tipo));
        //}

        ///// <summary>
        ///// Busqueda de inventario segun tipo específico
        ///// </summary>
        ///// <param name="parametro">Parametro a buscar</param>
        ///// <returns>Lista de inventario bajo cierto parametro</returns>
        //private List<Inventario> ConsultarInventario(string parametro)
        //{
        //    return (new LogicaInventario()).ConsultarInventario(parametro);
        //}

        ///// <summary>
        ///// Método que llena el GridView con el Inventario consultado
        ///// </summary>
        //private void LlenarGVInventario(List<Inventario> lista)
        //{
        //    LiberarGVInventario();
        //        if (lista != null)
        //        {
        //            if (lista.Count > 0)
        //            {                        
        //                GvInventario.DataSource = lista;
        //                GvInventario.DataBind();
        //                Btn_Modificar.Visible = true;
        //            }
        //            else 
        //            {
        //                Btn_Modificar.Visible = false;
        //                this.mensajeDeEstado.MensajeDeError(RecursosInterfaz.RegistrosVacios);  
        //            }
                    
        //        }
        //        else
        //        {
        //            Btn_Modificar.Visible = false;
        //            this.mensajeDeEstado.MensajeDeError(RecursosInterfaz.RegistrosVacios);  
        //        }
        //}

        ///// <summary>
        ///// Método que libera el GridView del ConsultarTours.aspx
        ///// </summary>
        //private void LiberarGVInventario()
        //{
        //        GvInventario.DataSource = null;
        //        GvInventario.DataBind();
        //}

        ///// <summary>
        ///// Acciones que se pueden ejecutar en el GridView
        ///// </summary>
        protected void GvInventarioRowCommand(object sender, GridViewCommandEventArgs e)
        {
        //    string redireccion = string.Empty;

        //    if (e.CommandName == RecursosInterfaz.ComandoModificar)
        //    {

        //        redireccion = RecursosInterfaz.PaginaModificarInventario;
        //        RedireccionamientoDeComandos(redireccion, e);
        //    }

        //    if (e.CommandName == RecursosInterfaz.ComandoEliminar)
        //    {
        //        try 
        //        {
        //            if (ControlRolAccion.listaAcciones(_correoS).Contains("Eliminar inventario playa"))
        //            {
        //                if (EliminarInventario(e))
        //                {
        //                    this.mensajeDeEstado.MensajeDeExito(RecursosInterfaz.mensajeDeExitoModificarInventario);
        //                    Buscardor();
        //                }
        //                else 
        //                {
        //                    this.mensajeDeEstado.MensajeDeError(RecursosInterfaz.mensajeDeErrorModificarInventario);
        //                }
        //            } 
        //            else
        //            {
        //            //MensajeErrores.Text = "No posee los perminsos para eliminar el ítem";
        //            //MensajeErrores.Visible = true;
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
                
        //    }

        }

        ///// <summary>
        ///// Elimina o bloquea un inventario seleccionado
        ///// </summary>
        ///// <param name="e">El evento de seleccion dentro del GridView</param>
        ///// <returns>True en caso de exito o false en caso de error</returns>
        //private bool EliminarInventario(GridViewCommandEventArgs e)
        //{
        //    int indiceSeleccionado;
        //    int idInventario;
        //    string idValue;
        //    bool parsed = false;

        //    indiceSeleccionado = Convert.ToInt32(e.CommandArgument);
        //    idValue = GvInventario.DataKeys[indiceSeleccionado].Value.ToString();
        //    parsed = Int32.TryParse(idValue, out idInventario);
        //    return (new LogicaInventario()).EliminatInventario(idInventario);
        //}

        ///// <summary>
        ///// Método que es llamado al seleccionarse
        ///// el cambio de la página.
        ///// Paginación de la tabla
        ///// </summary>
        ///// <param name="sender">Objeto</param>
        ///// <param name="e">Evento</param>
        protected void GvInventarioPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        //    GvInventario.PageIndex = e.NewPageIndex;
        //    Buscardor();
        }

        ///// <summary>
        ///// Método que es llamado al momento de modificar
        ///// para redireccionar a la pagina correspondiente
        ///// </summary>
        ///// <param name="url">Pagina a donde se redirecciona</param>
        ///// <param name="e">Evento</param>
        //private void RedireccionamientoDeComandos(string url, GridViewCommandEventArgs e)
        //{
        //    int indiceSeleccionado;
        //    int idInventario;
        //    string idValue;
        //    bool parsed = false;

        //    indiceSeleccionado = Convert.ToInt32(e.CommandArgument);
        //    idValue = GvInventario.DataKeys[indiceSeleccionado].Value.ToString();
        //    parsed = Int32.TryParse(idValue, out idInventario);
        //    Session[RecursosInterfaz.IdInventario] = idInventario;
             
        //    Response.Redirect(url);
            
        //}

        ///// <summary>
        ///// Metodo que redirecciona a la Pantalla Modificar
        ///// pero envia solo el valor del tipo de inventario
        ///// para modificar todos los items
        ///// </summary>
        ///// <param name="url">Pagina Modificars</param>
        //private void ModificarTodos(string url)
        //{
        //    Session[RecursosInterfaz.IdInventario] = null;
        //    Session[RecursosInterfaz.InvTipo] = this.comboConsultarInventario.TipoItem();
        //    Response.Redirect(url);

        //}

        ///// <summary>
        ///// Método que es llamado al darle al boton de modificar todos
        ///// </summary>
        ///// <param name="sender">Objeto</param>
        ///// <param name="e">Evento</param>
        protected void Btn_Modificar_Click(object sender, EventArgs e)
        {
        //    string redireccion = string.Empty;
        //    redireccion = RecursosInterfaz.PaginaModificarInventario;
        //    ModificarTodos(redireccion);
        }
        
    }
}