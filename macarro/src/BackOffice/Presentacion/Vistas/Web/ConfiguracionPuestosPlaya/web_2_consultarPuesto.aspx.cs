using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BackOffice.Presentacion.Contratos.ConfiguracionPuestosPlaya;
using BackOffice.Presentacion.Presentadores.ConfiguracionPuestosPlaya;


namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya
{
    public partial class web_2_consultarPuesto : System.Web.UI.Page , IContrato_2_consultarPuesto
    {
        #region Presentador
        private Presentador_2_consultarPuesto _presentador;
        #endregion

        #region Implementacion de Contrato

        public RadioButtonList RadioOpciones
        {
            get { return formularioConsultarPuesto.Opciones; }
        }

        public TextBox CampoFila
        {
            get { return formularioConsultarPuesto.Fila; }
        }

        public TextBox CampoColumna
        {
            get { return formularioConsultarPuesto.Columna; }
        }

        public Button BtnBuscar
        {
            get { return botonBuscar; }
        }

        public GridView GridPuestos
        {
            get { return GV_ConsultarPuesto; }
        }

        public Button BtnModificar
        {
            get { return Modificar; }
        }

        public Button BtnEliminar
        {
            get { return Eliminar; }
        }

        public Label LabelMensajeExito
        {
            get { return mensajeDeEstado.mensajeExito; }
            set { mensajeDeEstado.mensajeExito = value; }
        }

        public Label LabelMensajeError
        {
            get { return mensajeDeEstado.mensajeError; }
            set { mensajeDeEstado.mensajeError = value; }
        }

        #endregion

        #region constructor
        public web_2_consultarPuesto()
        {
            _presentador = new Presentador_2_consultarPuesto(this);
        }
        #endregion

        #region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Evento que activa el buscar los puestos.
        /// </summary>
        protected void botonBuscar_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickConsultarPuesto();
        }

        /// <summary>
        /// Evento que se dispara cuando se selecciona una fila.
        /// </summary>
        protected void GridView_ConsultarPuesto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            

            if (e.CommandName.Equals(RecursosInterfaz.AccionUpdate))
            {
                int idColumna;
                            int idfila;
                            int index = Convert.ToInt32(e.CommandArgument);


                            string fi = GV_ConsultarPuesto.DataKeys[index].Values[0].ToString();
                            string co = GV_ConsultarPuesto.DataKeys[index].Values[1].ToString();
                            string descripcion = GV_ConsultarPuesto.DataKeys[index].Values[2].ToString();
                            string precio = GV_ConsultarPuesto.DataKeys[index].Values[3].ToString();


                            bool parsed = Int32.TryParse(fi, out idColumna);
                            bool parseds = Int32.TryParse(co, out idfila);


                            Session[RecursosInterfaz.IdFila] = idfila.ToString();
                            Session[RecursosInterfaz.IdColumna] = idColumna.ToString();
                            Session[RecursosInterfaz.Descripcion] = descripcion;
                            Session[RecursosInterfaz.Precio] = precio;
                     

                
                Response.Redirect(_presentador.EventoModificar()); 
            }

            if (e.CommandName.Equals(RecursosInterfaz.AccionDelete))
            {
                                int idColumna;
                                int idfila;
                                int index = Convert.ToInt32(e.CommandArgument);


                                string fi = GV_ConsultarPuesto.DataKeys[index].Values[0].ToString();
                                string co = GV_ConsultarPuesto.DataKeys[index].Values[1].ToString();

                                bool parsed = Int32.TryParse(fi, out idColumna);
                                bool parseds = Int32.TryParse(co, out idfila);


                    bool flag= _presentador.EventoEliminarPuestoSeleccionado(idfila.ToString(),idColumna.ToString());
                    Response.Redirect(RecursosInterfaz.PaginaConsultarPuesto);
                    _presentador.MostrarMensajeEliminar(flag);
            }
        }

        /// <summary>
        /// Evento de paginacion.
        /// </summary>
        protected void GvPuestoPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridPuestos.PageIndex = e.NewPageIndex;
            _presentador.EventoClickConsultarPuesto();
        }

        /// <summary>
        /// Modifica todo la tabla.
        /// </summary>
        protected void Modificar_Click(object sender, EventArgs e)
        {
                    string idFila = _presentador.GetFila();
                    string idColumna = _presentador.GetColumna();
                    Session[RecursosInterfaz.IdFila] = idFila;
                    Session[RecursosInterfaz.IdColumna] = idColumna;
            Response.Redirect(_presentador.EventoModificar()); 
            
        }

        /// <summary>
        /// Elimina todo los registros.
        /// </summary>
        protected void Eliminar_Click(object sender, EventArgs e)
        {
          bool flag = _presentador.EventoEliminarFilaColumna();
         
              
              Response.Redirect(RecursosInterfaz.PaginaConsultarPuesto);
              _presentador.MostrarMensajeEliminar(flag);
         
        }



        #region CodigoAnterior
        /*
        // atributos de la clase
        #region atributos
        private string _fila;
        private string _columna;
        //protected LogicaPuesto logica;
        //private List<Puesto> listapuesto;
        #endregion


        #region propiedades
        public string Fila
        {
            get { return _fila; }
            set { _fila = value; }
        }

        public string Columna
        {
            get { return _columna; }
            set { _columna = value; }
        }

        #endregion

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
        /// Metodo de entrada de la pagina.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            variableSesion();
            this.mensajeDeEstado.OcultarMensajeDeError();            

        }

      



      
       

       

       

       




        ///// <summary>
        ///// Evento que se dispara cuando se selecciona una fila.
        ///// </summary>
        protected void GridView_ConsultarPuesto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        //    if (e.CommandName.Equals(RecursosInterfaz.AccionUpdate))
        //    {
        //        try
        //        {
        //            int idColumna;
        //            int idfila;
        //            int index = Convert.ToInt32(e.CommandArgument);


        //            string fi = GV_ConsultarPuesto.DataKeys[index].Values[0].ToString();
        //            string co = GV_ConsultarPuesto.DataKeys[index].Values[1].ToString();
        //            string descripcion = GV_ConsultarPuesto.DataKeys[index].Values[2].ToString();
        //            string precio = GV_ConsultarPuesto.DataKeys[index].Values[3].ToString();


        //            bool parsed = Int32.TryParse(fi, out idColumna);
        //            bool parseds = Int32.TryParse(co, out idfila);


        //            Session[RecursosInterfaz.IdFila] = idfila.ToString();
        //            Session[RecursosInterfaz.IdColumna] = idColumna.ToString();
        //            Session[RecursosInterfaz.Descripcion] = descripcion;
        //            Session[RecursosInterfaz.Precio] = precio;
        //          //  controladoraServicioPLaya.Filasession = idfila.ToString();
        //          // controladoraServicioPLaya.Columnasession = idColumna.ToString();

        //            Response.Redirect(RecursosInterfaz.PaginaModificarPuesto);
        //        }
        //        catch (ExcepcionPuesto ex)
        //        {
        //            this.mensajeDeEstado.MensajeDeError(ex.Message + RecursosExcepcionesPlaya.mensajeDeDatos);
        //        }
        //        catch (ExcepcionPuestoLogica exl)
        //        {
        //            this.mensajeDeEstado.MensajeDeError(exl.Message + RecursosExcepcionesPlaya.mensajeDeLogica);
        //        }
        //        catch (HttpException)
        //        {
        //            this.mensajeDeEstado.MensajeDeError(RecursosExcepcionesPlaya.mensajeFalso);
        //        }


        //    }

        //    if (e.CommandName.Equals(RecursosInterfaz.AccionDelete))
        //    {
        //        try
        //        {
        //            if (ControlRolAccion.listaAcciones(_correoS).Contains("Eliminar puesto playa"))
        //            {
        //                int idColumna;
        //                int idfila;
        //                int index = Convert.ToInt32(e.CommandArgument);


        //                string fi = GV_ConsultarPuesto.DataKeys[index].Values[0].ToString();
        //                string co = GV_ConsultarPuesto.DataKeys[index].Values[1].ToString();

        //                bool parsed = Int32.TryParse(fi, out idColumna);
        //                bool parseds = Int32.TryParse(co, out idfila);

        //                string estado = RecursosInterfaz.EstadoDesactivado;
        //                string descripcionx = string.Empty;
        //                string montox = string.Empty;

        //                LogicaPuesto logica = new LogicaPuesto();
        //                bool flag = logica.actualizacionPuesto(idfila.ToString(),
        //                                            idColumna.ToString(),
        //                                            descripcionx,
        //                                            montox,
        //                                            estado);
        //                if (flag)
        //                {
        //                    Response.Redirect(RecursosInterfaz.PaginaConsultarPuesto);
        //                }
        //            }
        //            else
        //            {
        //                //MensajeErrores.Text = "No posee los perminsos para eliminar el ítem";
        //                //MensajeErrores.Visible = true;
        //            }
        //        }
        //        catch (ExcepcionPuesto ex)
        //        {
        //            this.mensajeDeEstado.MensajeDeError(ex.Message + RecursosExcepcionesPlaya.mensajeDeDatos);
        //        }
        //        catch (ExcepcionPuestoLogica exl)
        //        {
        //            this.mensajeDeEstado.MensajeDeError(exl.Message + RecursosExcepcionesPlaya.mensajeDeLogica);
        //        }
        //        catch (HttpException)
        //        {
        //            this.mensajeDeEstado.MensajeDeError(RecursosExcepcionesPlaya.mensajeFalso);
        //        }

        //    }
        }


        ///// <summary>
        ///// Evento de paginacion.
        ///// </summary>
        protected void GvPuestoPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        //    GV_ConsultarPuesto.PageIndex = e.NewPageIndex;
        //    Buscador();
        }
        ///// <summary>
        ///// Modifica todo la tabla.
        ///// </summary>
        protected void Modificar_Click(object sender, EventArgs e)
        {
        //    try
        //    {
        //        string idFila = this.formularioConsultarPuesto.filar();
        //        string idColumna = this.formularioConsultarPuesto.columnar();
        //        Session[RecursosInterfaz.IdFila] = idFila;
        //        Session[RecursosInterfaz.IdColumna] = idColumna;
        //        Response.Redirect(RecursosInterfaz.PaginaModificarPuesto);
        //    }
        //    catch (ExcepcionPuesto ex)
        //    {
        //        this.mensajeDeEstado.MensajeDeError(ex.Message + RecursosExcepcionesPlaya.mensajeDeDatos);
        //    }
        //    catch (ExcepcionPuestoLogica exl)
        //    {
        //        this.mensajeDeEstado.MensajeDeError(exl.Message + RecursosExcepcionesPlaya.mensajeDeLogica);
        //    }
        //    catch (HttpException)
        //    {
        //        this.mensajeDeEstado.MensajeDeError(RecursosExcepcionesPlaya.mensajeFalso);
        //    }


        }




        ///// <summary>
        ///// Elimina todo los registros.
        ///// </summary>
        protected void Eliminar_Click(object sender, EventArgs e)
        {

        //    try
        //    {
        //            string idFila = this.formularioConsultarPuesto.filar();
        //            string idColumna = this.formularioConsultarPuesto.columnar();
        //            string estado = RecursosInterfaz.EstadoDesactivado;
        //            string descripcionx = string.Empty;
        //            string montox = string.Empty;
        //            LogicaPuesto logica = new LogicaPuesto();
        //            bool flag = logica.actualizacionPuesto(idFila,
        //                                        idColumna,
        //                                        descripcionx,
        //                                        montox,
        //                                        estado);
        //            if (flag)
        //            {
        //                Response.Redirect(RecursosInterfaz.PaginaConsultarPuesto);
        //            }

        //    }
        //    catch (ExcepcionPuesto ex)
        //    {
        //        this.mensajeDeEstado.MensajeDeError(ex.Message + RecursosExcepcionesPlaya.mensajeDeDatos);
        //    }
        //    catch (ExcepcionPuestoLogica exl)
        //    {
        //        this.mensajeDeEstado.MensajeDeError(exl.Message + RecursosExcepcionesPlaya.mensajeDeLogica);
        //    }
        //    catch (HttpException)
        //    {
        //        this.mensajeDeEstado.MensajeDeError(RecursosExcepcionesPlaya.mensajeFalso);
        //    }

        }

        //#endregion

       */
        #endregion        
    
    }
}