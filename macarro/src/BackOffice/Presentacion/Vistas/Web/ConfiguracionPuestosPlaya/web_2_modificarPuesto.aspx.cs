using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya
{
    public partial class web_2_modificarPuesto : System.Web.UI.Page
    {
        private string paginaBuscar = RecursosInterfaz.PaginaConsultarPuesto;       
        private object _fila;
        private object _columna;
        private object _descripcion;
        private object _monto;

        /// <summary>
        /// Metodo de entrada de la pagina.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {

          _fila = Session[RecursosInterfaz.IdFila];
           _columna = Session[RecursosInterfaz.IdColumna];
            _descripcion = Session[RecursosInterfaz.Descripcion];
             _monto = Session[RecursosInterfaz.Precio];
             Inicio();
        
        }

        /// <summary>
        /// Metodo que llena el formulario.
        /// </summary>
        private void Inicio()
        {
            string fila = (string)_fila;
            string columna = (string)_columna;
            string descripcion = (string)_descripcion;
            string monto = (string)_monto;
           
            if (!IsPostBack)
            {
               

                // seteo los campos del componentes!
                this.formularioModificarPuesto.filas(fila);
                this.formularioModificarPuesto.columnas(columna);
                this.formularioModificarPuesto.descripcions(descripcion);
                this.formularioModificarPuesto.montos(monto);

            
            
            }
        
        
        }
        
        /// <summary>
        /// Metodo de evento del boton para actualizar el puesto.
        /// </summary>
        protected void botonAceptar_Click(object sender, EventArgs e)
        {
        //    try{
        //    string estado=string.Empty;
        //    string filax = this.formularioModificarPuesto.filac();
        //    string columnax= this.formularioModificarPuesto.columnac();
        //    string descripcionx=this.formularioModificarPuesto.descripcionc();
        //    string montox=this.formularioModificarPuesto.montoc();

        //    LogicaPuesto logica = new LogicaPuesto();
        //    bool flag = logica.actualizacionPuesto(filax,
        //                                columnax,
        //                                descripcionx,
        //                                montox,
        //                                estado);
        //    if (flag)
        //    {
               
        //        this.mensajeDeEstado.MensajeDeExito(RecursosInterfaz.mensajeDeExitoModificarPuesto);
        //    }
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
        /// <summary>
        /// Metodo que regresa al regresar puesto.
        /// </summary>
        protected void botonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(RecursosInterfaz.PaginaConsultarPuesto);
        }
            
        }
    }
