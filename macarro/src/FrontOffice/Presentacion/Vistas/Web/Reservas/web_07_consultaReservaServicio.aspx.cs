using FrontOffice.Presentacion.Contratos;
using FrontOffice.Presentacion.Contratos.Reservas;
using FrontOffice.Presentacion.Presentadores.Reservas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Vistas.Web.Reservas
{

    public partial class web_07_consultaReserva : System.Web.UI.Page,IContratoConsultaReservaServicio
    {
        PresentadorConsultaReservaServicio _presentador;
        bool IsPageRefresh;

        public web_07_consultaReserva()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _presentador = new PresentadorConsultaReservaServicio(this, Response);
            _presentador.cargarTablaReservaServicios();

            if (!IsPostBack)
            {
                _presentador.visibilidadMensajeError(false);
                _presentador.visibilidadMensajeExito(false);
                ViewState["postids"] = System.Guid.NewGuid().ToString();
                Session["postid"] = ViewState["postids"].ToString();

            }
            else
            {

                if (ViewState["postids"].ToString() != Session["postid"].ToString())
                {
                    IsPageRefresh = true;
                }
                Session["postid"] = System.Guid.NewGuid().ToString();
                ViewState["postids"] = Session["postid"];
            }


            if (IsPageRefresh)
            {
                Response.Redirect("web_07_consultaReservaServicio.aspx");
                
            }
          
            

        }

        protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            _presentador._rowDataBoundTablaReservaServicio(sender, e);

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //    ImageButton editar = new ImageButton();
            //    editar.ID = "bEditar";
            //    editar.ImageUrl = "../../../../comun/resources/img/Data-Edit-128.png";
            //    editar.Height = 50;
            //    editar.Width = 50;
            //    editar.Click += new ImageClickEventHandler(this.editarBtn_Click);
            //    editar.OnClientClick = "return confirm('Modificar una Reserva CONFIRMADA" +
            //                        "haría que pasara a Estado EN ESPERA, Desea Continuar?')";
                    

            //    ImageButton eliminar = new ImageButton();
            //    eliminar.ID = "bEliminar";
            //    eliminar.ImageUrl = "../../../../comun/resources/img/Garbage-Closed-128.png";
            //    eliminar.Height = 50;
            //    eliminar.Width = 50;
            //    eliminar.Click += new ImageClickEventHandler(this.eliminarBtn_Click);
            //    eliminar.OnClientClick ="return confirm('Está Seguro de que desea Cancelar la Reserva?')";

            //    int celdas = e.Row.Cells.Count;
            //    e.Row.Cells[7].Controls.Add(editar);
            //    e.Row.Cells[7].Controls.Add(eliminar);

            //}
        }


        void eliminarBtn_Click(Object sender, ImageClickEventArgs e)
        {

            //_presentador.presionarEliminar(sender, e);

            //ImageButton rpt = (ImageButton)sender;
            //GridViewRow g = (GridViewRow)rpt.NamingContainer;


            //if (GridViewUsuario1.Rows.Count > 0)
            //{
            //    if (GridViewUsuario1.DataKeys[g.DataItemIndex]["Estado"].ToString().CompareTo("Cancelado") != 0)
            //    {
            //        string ReservaID = GridViewUsuario1.DataKeys[g.DataItemIndex]["IDReserva"].ToString();

            //        FrontOffice.LogicaNegocio.Reservas.LogicaNegocio_13_ConsultaReservaServicio.
            //        EliminarServicioBD(ReservaID);

            //        Response.Redirect("web_07_consultaReservaServicio.aspx");
            //    }
            //    else
            //    {
            //        MensajeError.Text = "No se puede Eliminar una Reserva CANCELADA";
            //        MensajeError.Visible = true;

            //    }
            //}
        }

        
        void editarBtn_Click(Object sender, ImageClickEventArgs e)
        {
            //MensajeError.Visible = false;
            //MensajeExito.Visible = false;

            //ImageButton rpt = (ImageButton)sender;
            //GridViewRow g = (GridViewRow)rpt.NamingContainer;


            //if (GridViewUsuario1.Rows.Count > 0)
            //{
            //    _presentador.cargarTablaReservaServicios();
            //    //cargarTablaReservaServicios();

            //    if (GridViewUsuario1.DataKeys[g.DataItemIndex]["Estado"].ToString().CompareTo("Cancelado") != 0)
            //    {
            //        string _reservaID = GridViewUsuario1.DataKeys[g.DataItemIndex]["IDReserva"].ToString();
            //        string _cantidad = GridViewUsuario1.DataKeys[g.DataItemIndex]["Cantidad"].ToString();
            //        string _servicio = GridViewUsuario1.DataKeys[g.DataItemIndex]["Nombre"].ToString();

            //        Response.Redirect("web_07_modificarReservaServicio.aspx?r=" + _reservaID + "&c=" + _cantidad + "&s=" + _servicio );

            //    }
            //    else
            //    {
            //        MensajeError.Text = "No se puede Modificar una Reserva CANCELADA";
            //        MensajeError.Visible = true;

            //    }

            //}

        }

        //void cargarTablaReservaServicios()
        //{
        //    _tabla = new DataTable();
        //    _tabla = FrontOffice.LogicaNegocio.Reservas.LogicaNegocio_13_ConsultaReservaServicio.
        //             ConsultarReservaServicioBD("marianacarol@gmail.com");

        //    _tabla.Columns.Add("Acciones", typeof(String));

        //    GridViewUsuario1.DataSource = _tabla;
        //    GridViewUsuario1.DataBind();
        //}


        public GridView _tablaReservaServicio
        {
            get { return GridViewUsuario1; }
            set { GridViewUsuario1 = value; }
        }

        public Label LabelMensajeExito
        {
            get { return MensajeExito; }
            set { MensajeExito = value; }
        }

        public Label LabelMensajeError
        {
            get { return MensajeError; }
            set { MensajeError = value; }
        }

    }
}