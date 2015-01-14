using FrontOffice.Dominio;
using FrontOffice.Dominio.Entidades;
using FrontOffice.Dominio.Fabrica;
using FrontOffice.LogicaNegocio;
using FrontOffice.LogicaNegocio.Fabrica;
using FrontOffice.Presentacion.Contratos.Reservas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Presentadores.Reservas
{
    public class PresentadorConsultaReservaServicio: PresentadorGeneral
    {
        private IContratoConsultaReservaServicio _vista;

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

            List<Entidad> _listaReservaServicio = new List<Entidad>();
            List<Entidad> _listaReserva = new List<Entidad>();
            Entidad _reservaServicio;
            Entidad _reserva;

            Comando<string, List<Entidad>> comandoConsultarServicio;
            Comando<string, Entidad> comandoConsultarReservaXID;

            _reservaServicio = FabricaEntidad.ObtenerReservaServicio();


            comandoConsultarServicio = FabricaComando.ObtenerComandoConsultarReservaServicio();
            comandoConsultarReservaXID = FabricaComando.ObtenerComandoConsultarReservaXID();

            _listaReservaServicio = comandoConsultarServicio.Ejecutar("marianacarol@gmail.com");

            if (_listaReservaServicio != null)
            {

                foreach (Entidad j in _listaReservaServicio)
                {
                    ReservaServicio s = (ReservaServicio)j;
                    _reserva = comandoConsultarReservaXID.Ejecutar(Convert.ToString(s.reservaServicio_FK_Reserva));
                    
                    Reserva _r = (Reserva)_reserva;
                    _r.reserva_Servicio = s;

                    _listaReserva.Add(_r);

                }
            }
            else
            {
                _listaReservaServicio = comandoConsultarServicio.Ejecutar("marianacarol@gmail.com");
                if (_listaReservaServicio != null)
                {

                    foreach (Entidad j in _listaReservaServicio)
                    {
                        ReservaServicio s = (ReservaServicio)j;
                        _reserva = comandoConsultarReservaXID.Ejecutar(Convert.ToString(s.reservaServicio_FK_Reserva));
                        Reserva _r = (Reserva)_reserva;
                        _r.reserva_Servicio = s;

                        _listaReserva.Add(_r);

                    }
                }
                else
                {
                    _vista.LabelMensajeError.Visible = true;
                    _vista.LabelMensajeError.Text = "No Posee Ninguna Reserva de Servicio";
                }
            }

                DataRow _row;


                _tabla = crearColumnaDataTable(_tabla, "IDReserva", "System.String");
                _tabla = crearColumnaDataTable(_tabla, "Inicio", "System.String");
                _tabla = crearColumnaDataTable(_tabla, "Fin", "System.String");
                _tabla = crearColumnaDataTable(_tabla, "Nombre", "System.String");
                _tabla = crearColumnaDataTable(_tabla, "Cantidad", "System.String");
                _tabla = crearColumnaDataTable(_tabla, "Total", "System.String");
                _tabla = crearColumnaDataTable(_tabla, "Estado", "System.String");
                _tabla.Columns.Add("Acciones", typeof(String));

                if (_listaReservaServicio != null)
                {

                    foreach (Entidad j in _listaReserva)
                    {
                        Reserva s = (Reserva)j;
                        _row = _tabla.NewRow();
                        _row["IDReserva"] = s.reserva_id.ToString();
                        _row["Inicio"] = s.reserva_Servicio.reservaServicio_HoraInicio.ToString();
                        _row["Fin"] = s.reserva_Servicio.reservaServicio_HoraFin.ToString();
                        _row["Nombre"] = s.reserva_Servicio.reservaServicio_Nombre.ToString();
                        _row["Cantidad"] = s.reserva_Servicio.reservaServicio_Cantidad.ToString();
                        _row["Total"] = s.reserva_Servicio.reservaServicio_Total.ToString();
                        _row["Estado"] = s.fK_estado.ToString();
                        _tabla.Rows.Add(_row);
                    }
                }


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
                    string _reservaID = _vista._tablaReservaServicio.DataKeys[g.DataItemIndex]["IDReserva"].ToString();
                    int _reserva_id = Convert.ToInt32(_reservaID);
                    Comando<Entidad, bool> comandoModificarStatusReserva;
                    comandoModificarStatusReserva = FabricaComando.ObtenerComandoModificarStatusReserva();

                    Reserva _r = (Reserva) FabricaEntidad.ObtenerReserva();

                    _r.reserva_id = _reserva_id;
                    _r.fK_estado = "Cancelado";

                    if (comandoModificarStatusReserva.Ejecutar(_r))
                    {
                        cargarTablaReservaServicios();
                        _vista.LabelMensajeExito.Text = "Su Reserva Ha sido Cancelada Exitosamente";
                        _vista.LabelMensajeExito.Visible = true;
                    }
                    else
                    {
                        cargarTablaReservaServicios();
                        _vista.LabelMensajeError.Text = "Su Reserva NO Ha sido Cancelada Exitosamente";
                        _vista.LabelMensajeError.Visible = false;

                    }


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

        public DataTable crearColumnaDataTable(DataTable _tabla, string _nombreColumna, string _tipoColumna)
        {
            DataColumn _column = new DataColumn();
            _column.DataType = System.Type.GetType(_tipoColumna);
            _column.ColumnName = _nombreColumna;
            _tabla.Columns.Add(_column);

            return _tabla;
        }



    }
}