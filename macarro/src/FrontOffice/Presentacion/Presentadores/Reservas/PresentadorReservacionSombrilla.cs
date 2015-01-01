
using FrontOffice.Presentacion.Contratos;
using FrontOffice.LogicaNegocio.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontOffice.Presentacion.Contratos.Reservas;
using System.Web.UI.WebControls;
using FrontOffice.Presentacion.Vistas.Web.Reservas;
using System.Drawing;
using System.Web.UI;

namespace FrontOffice.Presentacion.Presentadores.Reservas
{
    public class PresentadorReservacionSombrilla : PresentadorGeneral
    {
        private IContratoReservacionSombrilla _vista;
        //private LogicaReserva _modelo;
        const int MODIFICAR = 1;
        const int CREAR = 2;
        public int _tipo;
        public int _reserva;
        StateBag ViewState;
        DateTime _fecha;
        FrontOffice.LogicaNegocio.Reservas.LogicaReserva.Puesto[,] _puestos;
        bool _isPostBack;
        public PresentadorReservacionSombrilla(IContratoReservacionSombrilla laVistaDefault, DateTime _auxFecha, int _idplaya, string email,int _auxTipo,int _auxReserva,
            StateBag _auxViewState,bool _auxIsPostBack)
            : base(laVistaDefault)
        {
            _vista = laVistaDefault;
            //_modelo = new LogicaReserva(_auxFecha, _idplaya, email);
            _reserva = _auxReserva;
            _fecha = _auxFecha;
            _tipo = _auxTipo;
            ViewState = _auxViewState;
            _isPostBack = _auxIsPostBack;
        }
        public Color ImagenDeEstado(int _estado)
        {
            switch (_estado)
            {
                case 0:
                    return (Color.Gray);
                case 1:
                    return (Color.Blue);
                case 2:
                    return (Color.Red);
                case 3:
                    return (Color.Green);
            }
            return (Color.Gray);
        }
        private void SetMatriz(bool _activarBotones)
        {
            for (int i2 = 0; i2 < _puestos.GetLength(1); i2++)
            {
                TableRow row = new TableRow();
                for (int i = 0; i < _puestos.GetLength(0); i++)
                {
                    TableCell cell = new TableCell();
                    cell.Controls.Add(new CeldaPuesto(i, i2, this, _activarBotones));
                    row.Cells.Add(cell);
                }
                _vista._tabla.Rows.Add(row);
            }
        }
        public class CeldaPuesto : Button
        {
            int _x;
            int _y;
            bool _botonActivo;
            PresentadorReservacionSombrilla _father;
            protected override void OnClick(EventArgs e)
            {
                if (!_botonActivo)
                    return;
                base.OnClick(e);
                _father.PuestoOnClick(_x, _y);
            }
            public CeldaPuesto(int _x2, int _y2, PresentadorReservacionSombrilla _father2, bool _ba)
            {
                _x = _x2;
                _y = _y2;
                _father = _father2;
                _botonActivo = _ba;
            }
        }
        public void LoadPage()
        {
            _vista._monto.Text = "0";
            _vista._fechaReserva.Text = _fecha.ToShortDateString();
            //_puestos = _modelo.RetornarMatriz(_reserva);
            if (_tipo == MODIFICAR || _tipo == CREAR)
                SetMatriz(true);
            else
                SetMatriz(false);
            if (_isPostBack)
                LoadState();
            else
                SaveState();
            UpdateState();
        }

        public void OnClickAceptar()
        {         
            //if (_tipo == 1)
                //_modelo.ModificarReserva(_reserva, _puestos);
            //else
                //_modelo.AgregarReserva(_puestos, _fecha);
        }
        public void LoadState()
        {
            for (int i = 0; i < _puestos.GetLength(0); i++)
                for (int i2 = 0; i2 < _puestos.GetLength(1); i2++)
                    _puestos[i, i2]._estado = ((List<int>)ViewState["state"])[i * 10 + i2];
        }
        public void SaveState()
        {
            List<int> Estados = new List<int>();
            for (int i = 0; i < _puestos.GetLength(0); i++)
                for (int i2 = 0; i2 < _puestos.GetLength(1); i2++)
                    Estados.Add(_puestos[i, i2]._estado);
            ViewState["state"] = Estados;
        }
        public void UpdateState()
        {
            _vista._monto.Text = "0";
            for (int i = 0; i < _vista._tabla.Rows.Count; i++)
                for (int i2 = 0; i2 < _vista._tabla.Rows[i].Cells.Count; i2++)
                {
                    ((Button)_vista._tabla.Rows[i].Cells[i2].Controls[0]).BackColor = ImagenDeEstado(_puestos[i2, i]._estado);
                    if (_puestos[i2, i]._estado == 3)
                        _vista._monto.Text = (int.Parse(_vista._monto.Text) + _puestos[i2, i]._valor).ToString();
                }
        }

        public void PuestoOnClick(int x, int y)
        {
            if (_puestos[x, y]._estado == 1 || _puestos[x, y]._estado == 3)
                _puestos[x, y]._estado = (_puestos[x, y]._estado == 1) ? 3 : 1;
            UpdateState();
            SaveState();
        }
    }
}