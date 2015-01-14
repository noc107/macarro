using FrontOffice.Dominio;
using FrontOffice.Dominio.Entidades;
using FrontOffice.LogicaNegocio;
using FrontOffice.LogicaNegocio.Fabrica;
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
    public class LogicaConsultaReserva
    {
        string _usuarioEmail;

        public LogicaConsultaReserva(string _email)
        {
            _usuarioEmail = _email;
        }
        public void EliminarReserva(int _reservaId)
        {
            Comando<int, bool> com = FabricaComando.ObtenerComandoEliminarReservaReserva_Puesto();
            com.Ejecutar(_reservaId);
            com = FabricaComando.ObtenerComandoEliminarReserva();
            com.Ejecutar(_reservaId);
        }
        public DataTable LlenarTabla()
        {
            DataTable _tabla = new DataTable();
            List<Entidad> reservas;
            Comando<string, List<Entidad>> com = FabricaComando.ObtenerComandoConsultarReservaMayorAHoy();
            reservas = com.Ejecutar(_usuarioEmail);
            _tabla.Columns.Add("Reserva", typeof(string));
            _tabla.Columns.Add("Fecha", typeof(string));
            _tabla.Columns.Add("Acciones", typeof(string));
            for (int i = 0; i < reservas.Count; i++)
                _tabla.Rows.Add(((Reserva)reservas[i]).reserva_id, ((Reserva)reservas[i]).reserva_fecha.ToShortDateString());

            return (_tabla);
        }
    }
    public class PresentadorConsultaSombrilla : PresentadorGeneral
    {
        private IContratoConsultaSombrilla _vista;
        private LogicaConsultaReserva _modelo;
        public HttpResponse _pageResponse;
        public class ReservaData : ImageButton
        {
            int _id;
            DateTime _fecha;
            PresentadorConsultaSombrilla _father;
            public ReservaData(int _auxid, DateTime _auxfecha, int _tipo, PresentadorConsultaSombrilla _auxfather)
            {
                _father = _auxfather;
                _id = _auxid;
                _fecha = _auxfecha;
                this.Height = 50;
                this.Width = 50;
                if (_tipo == 1)
                {
                    this.ID = "bEditar";
                    this.ImageUrl = "../../../../comun/resources/img/Data-Edit-128.png";
                    this.Click += new ImageClickEventHandler(this.OnClickModificar);
                    this.OnClientClick = "return confirm('¿Está seguro de que desea Modifcar la Reserva?')";
                }
                else
                {
                    this.ID = "bEliminar";
                    this.ImageUrl = "../../../../comun/resources/img/Garbage-Closed-128.png";
                    this.Click += new ImageClickEventHandler(this.OnClickEliminar);
                    this.OnClientClick = "return confirm('Esta acción eliminará el ítem permanentemente del sistema ¿desea continuar?')";
                }
                
            }
            void OnClickModificar(Object sender, ImageClickEventArgs e)
            {
                _father._pageResponse.Redirect("web_07_reservacionSombrilla.aspx?tipo=1&reserva=" + _id + "&fecha=" + _fecha.ToShortDateString());
            }
            void OnClickEliminar(Object sender, ImageClickEventArgs e)
            {
                _father._modelo.EliminarReserva(_id);
                _father._pageResponse.Redirect("web_07_consultaSombrilla.aspx");
            }
        }
        public PresentadorConsultaSombrilla(IContratoConsultaSombrilla laVistaDefault, string _email, HttpResponse _source)
            : base(laVistaDefault)
        {
            _vista = laVistaDefault;
            _modelo = new LogicaConsultaReserva(_email);
            _pageResponse = _source;
        }

        public DataTable LlenarConsultaReserva()
        {
            return (_modelo.LlenarTabla());
        }
        public void SetRow(GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ReservaData editar = new ReservaData(int.Parse(e.Row.Cells[0].Text), DateTime.Parse(e.Row.Cells[1].Text), 1, this);
                ReservaData eliminar = new ReservaData(int.Parse(e.Row.Cells[0].Text), DateTime.Parse(e.Row.Cells[1].Text), 2, this);
                e.Row.Cells[2].Controls.Add(editar);
                e.Row.Cells[2].Controls.Add(eliminar);
            }
        }
        public void databind ()
        {
            _vista._tabla.DataSource = LlenarConsultaReserva ();
            _vista._tabla.DataBind ();

        }
    }
}