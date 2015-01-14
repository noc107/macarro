using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Comandos.ReservasSombrillasServiciosPlaya;
using BackOffice.Presentacion.Contratos.ReservasSombrillasServiciosPlaya;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Presentadores.ReservasSombrillasServiciosPlaya
{
    public class presentador_07_confirmacionReserva : PresentadorGeneral
    {
        private IContrato_07_confirmacionReserva _vista;
        private List<Entidad> _reservas;
        private Entidad _reserva;
        private Reserva _reservaAux;
        private ReservaServicio _reservaServicioAux;
        private ReservaReserva_Puesto _reservaPuestoAux;
        Comando<Entidad, List<Entidad>> ComandoConsultarReserva;
        Comando<int, Entidad> ComandoConsultarReservaServicio;
        Comando<int, List<Entidad>> ComandoConsultarReservaPuesto;
        Comando<int, Entidad> ComandoConsultarReservaX;
        Comando<Entidad, Boolean> ComandoModificarReserva;

        public presentador_07_confirmacionReserva(IContrato_07_confirmacionReserva _view)
            : base(_view)
        {
            _vista = _view;

        }

        public void consultarReserva()
        {
            DataTable _dt = new DataTable();
            ComandoConsultarReservaPuesto = BackOffice.LogicaNegocio.Fabrica.FabricaComando.ObtenerComandoConsultarReservaPuesto();
            _reservas = ComandoConsultarReservaPuesto.Ejecutar(Convert.ToInt32(_vista._idReserva));
            if (_reservas.Count != 0)
            {
                _dt.Columns.Add("ID");
                _dt.Columns.Add("Fecha");
                _dt.Columns.Add("Fila");
                _dt.Columns.Add("Columna");
                foreach (var item in _reservas)
                {
                    _reservaPuestoAux = (ReservaReserva_Puesto)item;
                    _dt.Rows.Add(_reservaPuestoAux.reservaPuesto_id, _reservaPuestoAux.reservaPuesto_fecha,
                                 _reservaPuestoAux.reservaPuesto_FK_puestoFila, _reservaPuestoAux.reservaPuesto_FK_puestoColumna);
                }
                _vista._tablePuesto.DataSource = _dt;
                _vista._tablePuesto.DataBind();
            }
            else
            {
                ComandoConsultarReservaServicio = BackOffice.LogicaNegocio.Fabrica.FabricaComando.ObtenerComandoConsultarReservaServicio();
                _reserva = ComandoConsultarReservaServicio.Ejecutar(Convert.ToInt32(_vista._idReserva));
                _dt.Columns.Add("ID");
                _dt.Columns.Add("Servicio");
                _dt.Columns.Add("Cantidad");
                _dt.Columns.Add("Inicio");
                _dt.Columns.Add("Fin");

                _reservaServicioAux = (ReservaServicio)_reserva;
                _dt.Rows.Add(_reservaServicioAux.reservaServicio_id, _reservaServicioAux.reservaServicio_Nombre,
                             _reservaServicioAux.reservaServicio_Cantidad, _reservaServicioAux.reservaServicio_HoraInicio
                             , _reservaServicioAux.reservaServicio_HoraFin);

                _vista._tableServicio.DataSource = _dt;
                _vista._tableServicio.DataBind();
            }
        }

        public void consultar()
        {
            string _aux = "";
            DateTime _fecha = System.DateTime.Now;
            DataTable _dt = new DataTable();
            ComandoConsultarReservaX = BackOffice.LogicaNegocio.Fabrica.FabricaComando.ObtenerComandoConsultarReservaX();
            _reserva = ComandoConsultarReservaX.Ejecutar(Convert.ToInt32(_vista._idReserva));
            _aux = ((Reserva)_reserva).fK_estado;
            _vista._combo.Text = _aux;
            if (_aux.CompareTo("En espera") == 0)
            {
                _fecha = ((Reserva)_reserva).reserva_fecha;
                if (_fecha > System.DateTime.Now)
                {
                    _vista._combo.Items.Add("En espera");
                    _vista._combo.Items.Add("Cancelado");
                    _vista._combo.Items.Add("Confirmado");

                }
                else
                {
                    _vista._combo.Items.Add("En espera");
                    _vista._combo.Items.Add("Cancelado");

                }
            }
            else
            {
                _vista._combo.Items.Add(_aux);
            }
        }

        public void actualizarEstado()
        {
            string _aux = _vista._combo.Text;
            Reserva _reservaaux = (Reserva)BackOffice.Dominio.Fabrica.FabricaEntidad.ObtenerReserva();
            _reservaaux.reserva_id = Convert.ToInt32(_vista._idReserva);
            _reservaaux.fK_estado = _aux;
            _reserva = _reservaaux;
            ComandoModificarReserva = BackOffice.LogicaNegocio.Fabrica.FabricaComando.ObtenerComandoModificarReserva();
            ComandoModificarReserva.Ejecutar(_reserva);
        }

        public void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable _dt = new DataTable();
            //_dt = _consultar.GetReservas ();

            _vista._tablePuesto.PageIndex = e.NewPageIndex;
            _vista._tablePuesto.DataSource = _dt;
        }

        public void grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Int16 _Index;
            DataTable _dt = new DataTable();
            // _dt = _consultar.GetReservas ();

            _Index = Convert.ToInt16(e.CommandArgument);
            _vista._idReserva = _vista._tablePuesto.Rows[_Index].Cells[0].Text;

        }
    }
}