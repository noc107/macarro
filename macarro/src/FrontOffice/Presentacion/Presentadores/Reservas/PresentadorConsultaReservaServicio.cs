using FrontOffice.LogicaNegocio.Reservas;
using FrontOffice.Presentacion.Contratos.Reservas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Presentadores.Reservas
{
    public class PresentadorConsultaReservaServicio: PresentadorGeneral
    {
        private IContratoConsultaReservaServicio _vista;
        //private LogicaNegocio_13_ConsultaReservaServicio _modelo;

        public HttpResponse _pageResponse;

        DataTable _tabla;


        public PresentadorConsultaReservaServicio(IContratoConsultaReservaServicio _view, HttpResponse _responseVentana)
            : base ( _view )
        {
            _vista = _view;
            //_modelo = new LogicaNegocio_13_ConsultaReservaServicio();
            _pageResponse = _responseVentana;
        }

        public void visibilidadMensajeExito(bool _visibilidad)
        {
            _vista.LabelMensajeExito.Visible = _visibilidad;
        }

        public void visibilidadMensajeError(bool _visibilidad)
        {
            _vista.LabelMensajeError.Visible = _visibilidad;
        }

        public void cargarTablaReservaServicios()
        {
            _tabla = new DataTable();
            _tabla = FrontOffice.LogicaNegocio.Reservas.LogicaNegocio_13_ConsultaReservaServicio.
                     ConsultarReservaServicioBD("marianacarol@gmail.com");

            _tabla.Columns.Add("Acciones", typeof(String));

            _vista._tablaReservaServicio.DataSource = _tabla;
            _vista._tablaReservaServicio.DataBind();
        }

        void presionarEliminar(Object sender, ImageClickEventArgs e)
        {
            visibilidadMensajeError(false);
            visibilidadMensajeExito(false);

            cargarTablaReservaServicios();
            
            ImageButton rpt = (ImageButton)sender;
            GridViewRow g = (GridViewRow)rpt.NamingContainer;


            if (_vista._tablaReservaServicio.Rows.Count > 0)
            {
                if (_vista._tablaReservaServicio.DataKeys[g.DataItemIndex]["Estado"].ToString().CompareTo("Cancelado") != 0)
                {
                    string ReservaID = _vista._tablaReservaServicio.DataKeys[g.DataItemIndex]["IDReserva"].ToString();

                    FrontOffice.LogicaNegocio.Reservas.LogicaNegocio_13_ConsultaReservaServicio.
                    EliminarServicioBD(ReservaID);

                    _pageResponse.Redirect("web_07_consultaReservaServicio.aspx");

                }
                else
                {
                    _vista.LabelMensajeError.Text = "No se puede Eliminar una Reserva CANCELADA";
                    visibilidadMensajeError(true); 

                }
            }

        }

        void presionarEditar(Object sender, ImageClickEventArgs e)
        {

            _vista.LabelMensajeError.Visible = false;
            _vista.LabelMensajeError.Visible = false;

            ImageButton rpt = (ImageButton)sender;
            GridViewRow g = (GridViewRow)rpt.NamingContainer;


            if (_vista._tablaReservaServicio.Rows.Count > 0)
            {
                cargarTablaReservaServicios();
                //cargarTablaReservaServicios();

                if (_vista._tablaReservaServicio.DataKeys[g.DataItemIndex]["Estado"].ToString().CompareTo("Cancelado") != 0)
                {
                    string _reservaID = _vista._tablaReservaServicio.DataKeys[g.DataItemIndex]["IDReserva"].ToString();
                    string _cantidad = _vista._tablaReservaServicio.DataKeys[g.DataItemIndex]["Cantidad"].ToString();
                    string _servicio = _vista._tablaReservaServicio.DataKeys[g.DataItemIndex]["Nombre"].ToString();

                    _pageResponse.Redirect("web_07_modificarReservaServicio.aspx?r=" + _reservaID + "&c=" + _cantidad + "&s=" + _servicio);

                }
                else
                {
                    _vista.LabelMensajeError.Text = "No se puede Modificar una Reserva CANCELADA";
                    _vista.LabelMensajeError.Visible = true;

                }

            }
        }


        public void _rowDataBoundTablaReservaServicio(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                ImageButton editar = new ImageButton();
                editar.ID = "bEditar";
                editar.ImageUrl = "../../../../comun/resources/img/Data-Edit-128.png";
                editar.Height = 50;
                editar.Width = 50;
                editar.Click += new ImageClickEventHandler(this.presionarEditar);
                editar.OnClientClick = "return confirm('Modificar una Reserva CONFIRMADA" +
                                    "haría que pasara a Estado EN ESPERA, Desea Continuar?')";


                ImageButton eliminar = new ImageButton();
                eliminar.ID = "bEliminar";
                eliminar.ImageUrl = "../../../../comun/resources/img/Garbage-Closed-128.png";
                eliminar.Height = 50;
                eliminar.Width = 50;
                eliminar.Click += new ImageClickEventHandler(this.presionarEliminar);
                eliminar.OnClientClick = "return confirm('Está Seguro de que desea Cancelar la Reserva?')";

                int celdas = e.Row.Cells.Count;
                e.Row.Cells[7].Controls.Add(editar);
                e.Row.Cells[7].Controls.Add(eliminar);

            }
        }

    }
}