using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Comandos.ReservasSombrillasServiciosPlaya;
using BackOffice.Presentacion.Contratos;
using BackOffice.Presentacion.Contratos.ReservasSombrillasServiciosPlaya;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Presentadores.ReservasSombrillasServiciosPlaya
{
    public class presentador_07_listaReservas : PresentadorGeneral
    {
        private IContrato_07_listaReserva _vista;
        private List<Entidad> _reservas;
        private Entidad _reserva;
        private Reserva _reservaAux;

        public presentador_07_listaReservas(IContrato_07_listaReserva _view)
            : base(_view)
        {
            _vista = _view;

        }

        public void Cargar_Reservas()
        {
            Comando<Entidad, List<Entidad>> ComandoConsultarReserva;
            ComandoConsultarReserva = BackOffice.LogicaNegocio.Fabrica.FabricaComando.ObtenerComandoConsultarReserva();

            _reservas = ComandoConsultarReserva.Ejecutar(_reserva);
            DataTable _dt = new DataTable();
            _dt.Columns.Add("ID");
            _dt.Columns.Add("Fecha");
            _dt.Columns.Add("Usuario");
            _dt.Columns.Add("Estado");
            foreach (var item in _reservas)
            {
                _reservaAux = (Reserva)item;
                _dt.Rows.Add(_reservaAux.reserva_id, _reservaAux.reserva_fecha,
                             _reservaAux.fK__usuario, _reservaAux.fK_estado);
            }
            _vista._table.DataSource = _dt;
            _vista._table.DataBind();

        }

        public void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable _dt = new DataTable();
            //_dt = _consultar.GetReservas ();

            _vista._table.PageIndex = e.NewPageIndex;
            _vista._table.DataSource = _dt;
        }

        public void grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Int16 _Index;
            DataTable _dt = new DataTable();
            //_dt = _consultar.GetReservas ();

            _Index = Convert.ToInt16(e.CommandArgument);
            _vista._idReserva = _vista._table.Rows[_Index].Cells[0].Text;

        }

        public void grid_RowEditing()
        {

        }



        public object Comando { get; set; }
    }
}