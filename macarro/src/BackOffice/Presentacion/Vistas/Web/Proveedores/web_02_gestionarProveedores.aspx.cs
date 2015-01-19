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
            try
            {
                _presentador.BindGridProveedor();
            }
            catch (Exception ex) 
            {
            
            }
        }

        protected void gvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
	        {
	            if (e.CommandName == "Consultar")
	            {
	                Response.Redirect("web_02_consultarProveedor.aspx?r="+ _presentador.ObtenerIdProveedorSeleccionado_Click(e));
	            }
	            if (e.CommandName == "Modificar")
	            {
                    Response.Redirect("web_02_modificarProveedor.aspx?r=" + _presentador.ObtenerIdProveedorSeleccionado_Click(e));
	            }
	            if (e.CommandName == "Eliminar")
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
            Response.Redirect("../inicio.aspx");
        }

    }
}