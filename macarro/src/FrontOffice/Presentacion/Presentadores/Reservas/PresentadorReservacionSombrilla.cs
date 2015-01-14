
using FrontOffice.Presentacion.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontOffice.Presentacion.Contratos.Reservas;
using System.Web.UI.WebControls;
using FrontOffice.Presentacion.Vistas.Web.Reservas;
using System.Drawing;
using System.Web.UI;
using FrontOffice.Dominio.Entidades;
using FrontOffice.Dominio;
using FrontOffice.LogicaNegocio;
using FrontOffice.LogicaNegocio.Fabrica;

namespace FrontOffice.Presentacion.Presentadores.Reservas
{
    public class LogicaReserva
    {
        const int PUESTO_SELECCIONADO = 3;
        const int PUESTO_OCUPADO = 2;
        const int PUESTO_ACTIVO = 1;
        const int PUESTO_INACTIVO = 0;
        public class Puesto
        {
            public int _estado;
            public float _valor;
            public Puesto()
            {
                _estado = 0;
                _valor = 0;
            }
            public Puesto(int estado, float valor)
            {
                _estado = estado;
                _valor = valor;
            }
        }
        public DateTime _fecha;
        public int _idPlaya;
        public string _usuario;
        public LogicaReserva(DateTime _f, int _idplaya, string _auxUsuario)
        {
            _fecha = _f;
            _idPlaya = _idplaya;
            _usuario = _auxUsuario;
        }
        public bool EliminarReserva_Puesto(int _reservaID, int _columna, int _fila)
        {
            Comando<int[], bool> com = FabricaComando.ObtenerComandoEliminarReservaReserva_PuestoFactores();
            return com.Ejecutar(new int[3] { _reservaID, _columna, _fila });
        }
        public bool AgregarReserva_Puesto(int _reservaID, int _columna, int _fila)
        {
            Comando<ReservaReserva_Puesto, bool> com = FabricaComando.ObtenerInsertarSinInventario();
            return com.Ejecutar(new ReservaReserva_Puesto(0, _fecha, _reservaID, _fila, _columna, 0, _idPlaya));
        }
        public bool Existe(int[] _item, List<int[]> _target)
        {
            for (int i = 0; i < _target.Count; i++)
                if (_target[i][0] == _item[0] && _target[i][1] == _item[1])
                    return (true);
            return (false);
        }
        public List<int[]> ModificarReserva(int _reservaID, Puesto[,] _puestos)
        {
            List<int[]> _coordenadas = new List<int[]>();
            for (int i = 0; i < _puestos.GetLength(1); i++)
                for (int i2 = 0; i2 < _puestos.GetLength(0); i2++)
                    if (_puestos[i2, i]._estado == 3)
                        _coordenadas.Add(new int[] { i2 + 1, i + 1 });
            List<Entidad> puestos;
            Comando<int[], List<Entidad>> puestoComando;
            puestoComando = FabricaComando.ObtenerComandoConsultarReseservaReserva_PuestoPorPlaya_Reserva();
            puestos = puestoComando.Ejecutar(new int[2] { _idPlaya, _reservaID });

            List<int[]> _pCoordenadas = new List<int[]>();
            for (int i = 0; i < puestos.Count; i++)
                _pCoordenadas.Add(new int[] { ((ReservaReserva_Puesto)puestos[i]).reservaPuesto_FK_puestoColumna, ((ReservaReserva_Puesto)puestos[i]).reservaPuesto_FK_puestoFila });
            List<int[]> Errores = new List<int[]>();

            for (int i = 0; i < _coordenadas.Count; i++)
                if (!Existe(_coordenadas[i], _pCoordenadas))
                    if (!AgregarReserva_Puesto(_reservaID, _coordenadas[i][0], _coordenadas[i][1]))
                        Errores.Add(new int[3] { 1, _coordenadas[i][0], _coordenadas[i][1] });

            for (int i = 0; i < _pCoordenadas.Count; i++)
                if (!Existe(_pCoordenadas[i], _coordenadas))
                    if (!EliminarReserva_Puesto(_reservaID, _pCoordenadas[i][0], _pCoordenadas[i][1]))
                        Errores.Add(new int[3] { -1, _pCoordenadas[i][0], _pCoordenadas[i][1] });
            return (Errores);
        }
        public List<int[]> AgregarReserva(Puesto[,] _puestos, DateTime _fecha)
        {
            List<int[]> Errores = new List<int[]>();
            List<int[]> _coordenadas = new List<int[]>();
            for (int i = 0; i < _puestos.GetLength(1); i++)
                for (int i2 = 0; i2 < _puestos.GetLength(0); i2++)
                    if (_puestos[i, i2]._estado == 3)
                        _coordenadas.Add(new int[] { i, i2 });

            Comando<bool, int> com = FabricaComando.ObtenerReservaSecuencia();
            int n = com.Ejecutar(true);
            Comando<string[], bool> com2 = FabricaComando.ObtenerInsertarReservaSinSecuencia();
            if (!com2.Ejecutar(new string[3] { n.ToString(), _fecha.ToShortDateString(), _usuario }))
                Errores.Add(new int[2] {1,_idPlaya });
            for (int i = 0; i < _coordenadas.Count; i++)
                if (!AgregarReserva_Puesto(n, _coordenadas[i][0] + 1, _coordenadas[i][1] + 1))
                    Errores.Add(new int[3] { 1, _coordenadas[i][0], _coordenadas[i][1] });

            return Errores;
        }
        public int[] DimensionPlaya()
        {
            Comando<int, Entidad> playaComando = FabricaComando.ObtenerComandoConsultarReservaPlaya();
            ReservaPlaya _playa = (ReservaPlaya)playaComando.Ejecutar(_idPlaya);
            int[] _dimension = new int[2];
            _dimension[0] = _playa.reservaPlaya_Columna;
            _dimension[1] = _playa.reservaPlaya_Fila;
            return (_dimension);
        }
        public List<Entidad> PuestoDePlaya()
        {
            Comando<int, List<Entidad>> puestoComando = FabricaComando.ObtenerComandoConsultarReservaPuesto();
            return (puestoComando.Ejecutar(_idPlaya));
        }


        public Puesto[,] RetornarMatriz(int _previaReserva)
        {
            int[] dimensionplaya = DimensionPlaya();
            Puesto[,] puestosPlaya = new Puesto[dimensionplaya[0], dimensionplaya[1]];

            for (int x = 0; x < puestosPlaya.GetLength(0); x++)
                for (int y = 0; y < puestosPlaya.GetLength(1); y++)
                    puestosPlaya[x, y] = new Puesto();


            List<Entidad> Puestos = PuestoDePlaya();
            for (int i = 0; i < Puestos.Count; i++)
            {
                puestosPlaya[((ReservaPuesto)Puestos.ElementAt(i)).reservaPuesto_puestoColumna - 1,
                    ((ReservaPuesto)Puestos.ElementAt(i)).reservaPuesto_puestoFila - 1]._estado = PUESTO_ACTIVO;
                puestosPlaya[((ReservaPuesto)Puestos.ElementAt(i)).reservaPuesto_puestoColumna - 1,
                    ((ReservaPuesto)Puestos.ElementAt(i)).reservaPuesto_puestoFila - 1]._valor = ((ReservaPuesto)Puestos.ElementAt(i)).reservaPuesto_precio;
            }
            Comando<string[], List<Entidad>> puestoComando;
            puestoComando = FabricaComando.ObtenerComandoConsultarReseservaReserva_PuestoPorPlaya_Inicio_Fin();
            List<Entidad> rslist = new List<Entidad>();
            string[] parameters;
            parameters = new string[3] { _idPlaya.ToString(), _fecha.ToString(), (_fecha.AddDays(1).AddSeconds(-1)).ToString() };
            rslist = puestoComando.Ejecutar(parameters);
            for (int i = 0; i < rslist.Count; i++)
                puestosPlaya[((ReservaReserva_Puesto)rslist.ElementAt(i)).reservaPuesto_FK_puestoColumna - 1, ((ReservaReserva_Puesto)rslist.ElementAt(i)).reservaPuesto_FK_puestoFila - 1]._estado = PUESTO_OCUPADO;


            if (_previaReserva != 0)
            {
                Comando<int[], List<Entidad>> com = FabricaComando.ObtenerComandoConsultarReseservaReserva_PuestoPorPlaya_Reserva();
                int[] parameters2 = new int[2] { _idPlaya, _previaReserva };
                rslist = com.Ejecutar(parameters2);
                for (int i = 0; i < rslist.Count; i++)
                    puestosPlaya[((ReservaReserva_Puesto)rslist.ElementAt(i)).reservaPuesto_FK_puestoColumna - 1, ((ReservaReserva_Puesto)rslist.ElementAt(i)).reservaPuesto_FK_puestoFila - 1]._estado = PUESTO_SELECCIONADO;
            }
            return (puestosPlaya);
        }
    }
    public class PresentadorReservacionSombrilla : PresentadorGeneral
    {
        private IContratoReservacionSombrilla _vista;
        private LogicaReserva _modelo;
        const int MODIFICAR = 1;
        const int CREAR = 2;
        public int _tipo;
        public int _reserva;
        StateBag ViewState;
        DateTime _fecha;
        LogicaReserva.Puesto[,] _puestos;
        bool _isPostBack;
        public PresentadorReservacionSombrilla(IContratoReservacionSombrilla laVistaDefault, DateTime _auxFecha, int _idplaya, string email,int _auxTipo,int _auxReserva,
            StateBag _auxViewState,bool _auxIsPostBack)
            : base(laVistaDefault)
        {
            _vista = laVistaDefault;
            _modelo = new LogicaReserva(_auxFecha, _idplaya, email);
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
            _puestos = _modelo.RetornarMatriz(_reserva);
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
        const int MODIFICAR_RESERVA = 1;
        const int AGREGAR_RESERVA = 2;
        public void OnClickAceptar(HttpResponse redirect)
        {
            _vista.LabelMensajeExito.Visible = false;
            _vista.LabelMensajeError.Visible = false;
            if (_tipo == MODIFICAR_RESERVA)
            {
                List<int[]> Errores = _modelo.ModificarReserva(_reserva, _puestos);
                _vista.LabelMensajeError.Text = "";
                for (int i = 0; i < Errores.Count;i++)
                {
                    _vista.LabelMensajeError.Text+= "Error al ";
                    _vista.LabelMensajeError.Text+= (Errores[i][0]==1)?"AGREGAR ":"ELIMINAR ";
                    _vista.LabelMensajeError.Text+="el puesto de la Columna: "+Errores[i][1].ToString()+" Fila: "+Errores[i][2].ToString()+"<br>";
                }
                if (Errores.Count==0)
                {
                    _vista.LabelMensajeExito.Text = "Modificacion Exitosa de la Reserva";
                    _vista.LabelMensajeExito.Visible = true;
                    _vista._botonAceptar.Visible = false;
                    _vista._botonCancelarRegresar.Text = "Regresar";
                    _vista._botonCancelarRegresar.OnClientClick = "";
                }
                else
                    _vista.LabelMensajeError.Visible = true;
            }
            else
            {
                List<int[]> Errores = _modelo.AgregarReserva(_puestos, _fecha);
                _vista.LabelMensajeError.Text = "";
                if (Errores[0].Length==2)
                {
                    _vista.LabelMensajeError.Text += "Error al AGREGAR la Reserva al sistema";
                }
                for (int i = 0 + ((Errores[0].Length==2)?1:0); i < Errores.Count; i++)
                {
                    _vista.LabelMensajeError.Text += "Error al ";
                    _vista.LabelMensajeError.Text += (Errores[i][0] == 1) ? "AGREGAR " : "ELIMINAR ";
                    _vista.LabelMensajeError.Text += "el puesto de la Columna: " + Errores[i][1].ToString() + " Fila: " + Errores[i][2].ToString() + "\n";
                }
                if (Errores.Count == 0)
                {
                    _vista.LabelMensajeExito.Text = "Exito al Agregar la Reserva";
                    _vista.LabelMensajeExito.Visible = true;
                    _vista._botonAceptar.Visible = false;
                    _vista._botonCancelarRegresar.Text = "Regresar";
                    _vista._botonCancelarRegresar.OnClientClick = "";
                }
                else
                    _vista.LabelMensajeError.Visible = true;
            }
            
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