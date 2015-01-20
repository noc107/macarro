using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BackOffice.Presentacion.Presentadores.Proveedores;
using BackOffice.Presentacion.Contratos;
using BackOffice.Presentacion.Contratos.Proveedores;
using System.Data.SqlClient;
using BackOffice.Presentacion.Vistas.Web.Proveedores.Recursos;

namespace BackOffice.Presentacion.Vistas.Web.Proveedores
{
    public partial class web_02_gestionarProveedores : System.Web.UI.Page , IContrato_02_gestionarProveedor
    {
        
        Presentador_02_gestionarProveedor _presentador;
        public web_02_gestionarProveedores() 
        {
            _presentador = new Presentador_02_gestionarProveedor(this);
        }



        protected void Page_Load(object sender, EventArgs e)
        {
                _presentador.BindGridProveedor();
        }

        protected void gvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
	        {
	            if (e.CommandName == RecursosVistaProveedor.Consultar)
	            {
	                Response.Redirect(RecursosVistaProveedor.webConsultarProv + _presentador.ObtenerIdProveedorSeleccionado_Click(e));
	            }
	            if (e.CommandName == RecursosVistaProveedor.Modificar)
	            {
                    Response.Redirect(RecursosVistaProveedor.webModificarProv + _presentador.ObtenerIdProveedorSeleccionado_Click(e));
	            }
	            if (e.CommandName == RecursosVistaProveedor.Eliminar)
	            {
                    _presentador.EventoBotonEliminar(_presentador.ObtenerIdProveedorSeleccionado_Click(e));
	            }
	        }


        GridView IContrato_02_gestionarProveedor.GVProveedores
        {
            get { return GVProveedores; }
            set { GVProveedores = value; }
        }

        public Label LabelMensajeExito
        {
            get { return Label13; }
            set { Label13 = value; }
        }

        public Label LabelMensajeError
        {
            get { return Label13; }
            set { Label13 = value; }
        }

        DropDownList IContrato_02_gestionarProveedor.comboEstado
        {
            get { return comboEstado;}
            set { comboEstado = value; }
        }

        TextBox IContrato_02_gestionarProveedor.textboxBuscar
        {
            get { return textboxBuscar; }
            set { textboxBuscar = value; }
        }

        /// <summary>
        /// Metodo que se usa para cambiar la pagina del grid view
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Evento</param>
        protected void GVProveedores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Falta try/ catch
            GVProveedores.PageIndex = e.NewPageIndex;
            _presentador.BindGridProveedor();
            LabelMensajeError.Visible = false;
        }
        /// <summary>
        /// Metodo que agrega la data a la fila
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Event</param>
        protected void GVProveedores_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ImageButton consultar = _presentador.Consultar();

                    ImageButton editar = _presentador.Editar();

                    ImageButton eliminar = _presentador.Eliminar();

                    e.Row.Cells[4].Controls.Add(consultar);
                    e.Row.Cells[4].Controls.Add(editar);
                    e.Row.Cells[4].Controls.Add(eliminar);
                }
        }




        /// <summary>
        /// Metodo que redirecciona al inicio
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Evento</param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Boton Regresar
            Response.Redirect(RecursosVistaProveedor.webInicio);
        }

    }
}