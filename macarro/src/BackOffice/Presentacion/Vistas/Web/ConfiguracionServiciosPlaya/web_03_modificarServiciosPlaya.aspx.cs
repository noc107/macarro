using BackOffice.Presentacion.Contratos.ConfiguracionServiciosPlaya;
using BackOffice.Presentacion.Presentadores.ConfiguracionServiciosPlaya;
using BackOffice.Presentacion.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionServiciosPlaya
{
    public partial class web_03_modificarServiciosPlaya : System.Web.UI.Page, IContrato_3_modificarServiciosPlaya
    {
        private Presentador_3_modificarServiciosPlaya _presentadorModificarServicio;

        #region Implementa el contrato, IContrato_3_modificarServicio

        public Label lNombreServicio
        {
            set { labelNombreServicio = value; }
        }

        public TextBox NombreServicio
        {
            get { return inputNombreServcio; }
        }

        public Label lDescripcion
        {
            set { labelDescripcion = value; }
        }

        public TextBox Descripcion
        {
            get { return inputDescripcion; }
        }

        public Label lCategoria
        {
            set { labelCategoria = value; }
        }

        public DropDownList ListaCategoria
        {
            get { return dropdownlistCategoria; }
        }

        public Label lOtraCategoria
        {
            set { LabelCategoriaOtro = value; }
        }

        public TextBox OtraCategoria
        {
            get { return inputCategoriaOtro; }
        }

        public Label lLugarRetiro
        {
            set { labelLugarRetiro = value; }
        }

        public TextBox LugarRetiro
        {
            get { return inputLugarRetiro; }
        }

        public Label lCantidad
        {
            set { labelCantidad = value; }
        }

        public TextBox Cantidad
        {
            get { return inputCantidad; }
        }

        public Label lCapacidad
        {
            set { labelCapacidad = value; }
        }

        public TextBox Capacidad
        {
            get { return inputCapacidad; }
        }

        public Label lCosto
        {
            set { labelCosto = value; }
        }

        public TextBox Costo
        {
            get { return inputCosto; }
        }

        public Label TituloHorario
        {
            set { ltituloHorario = value; }
        }

        public Label NotaHorario
        {
            set { notaHorario = value; }
        }

        public Label lHoraInicio
        {
            set { labelHoraInicio = value; }
        }

        public TextBox HoraInicio
        {
            get { return timePickerInicio; }
        }

        public Label ErrorAgregarHorario
        {
            set { mensajeErrorAgregarHorario = value; }
        }

        public Label lHoraFin
        {
            set { labelHoraFin = value; }
        }

        public TextBox HoraFin
        {
            get { return timePickerFin; }
        }

        public Label ErrorEliminarHorario
        {
            set { mensajeErrorEliminarHorario = value; }
        }

        public Label HorarioRepetido
        {
            set { mensajeHorarioRepetido = value; }
        }

        public Label HorarioOcupado
        {
            set { mensajeHorarioOcupado = value; }
        }

        public Label lHorario
        {
            set { labelHorario = value; }
        }

        public ListBox ListaHorario
        {
            get { return listboxHorario; }
        }

        public Label lEstado
        {
            set { labelEstado = value; }
        }

        public DropDownList ListaEstado
        {
            get { return dropdownlistEstado; }
        }

        public Label lNombreOriginal
        {
            set { nombreOriginal = value; }
        }

        public Label lCategoriaNueva
        {
            set { categoriaNueva = value; }
        }

        public Label LabelMensajeExito
        {
            get { return _mensajeExito; }
            set { _mensajeExito = value; }
        }

        public Label LabelMensajeError
        {
            get { return _mensajeError; }
            set { _mensajeError = value; }
        }

        #endregion

        #region Constructor

        public web_03_modificarServiciosPlaya()
        {
            this._presentadorModificarServicio = new Presentador_3_modificarServiciosPlaya(this);
        }

        #endregion

        #region _2daEntrega
        //private Logica.ConfiguracionServiciosPlaya.LogicaModificarServicio _logicaModificarServicio;

        /// <summary>
        /// Inicializa los valores en la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //Servicio _servicio;
            //string _correoS = (string)(Session["correo"]);
            //string _docIdentidadS = (string)(Session["docIdentidad"]);
            //string _primerNombreS = (string)(Session["primerNombre"]);
            //string _primerApellidoS = (string)(Session["primerApellido"]);
            //LabelMensaje.Visible = true;

            //if (!Page.IsPostBack)
            //{

            //    if (Request.QueryString["Servicio"] == null)
            //        Response.Redirect("web_03_consultaServicio.aspx");

            //    _servicio = new Servicio();                

            //    this.inicializarMensajes();                 
            //    this.llenarCategorias();

            //    this._logicaModificarServicio = new Logica.ConfiguracionServiciosPlaya.LogicaModificarServicio();
            //    _servicio.Nombre = Request.QueryString["Servicio"]; 
            //    _servicio = this._logicaModificarServicio.solicitarServicio(_servicio,this.LabelMensaje);

            //    this.inicializarCampos(_servicio);

            //}
        }

        /// <summary>
        /// Inicializa los mensajes de error
        /// </summary>
        private void inicializarMensajes()
        {

            this.mensajeHorarioOcupado.Visible = false;
            this.mensajeErrorAgregarHorario.Visible = false;
            this.mensajeErrorEliminarHorario.Visible = false;
            this.mensajeHorarioRepetido.Visible = false;

        }

        /// <summary>
        /// Constructur página incializa comunicación
        /// </summary>
        //public web_03_modificarServiciosPlaya() 
        //{

        //    this._logicaModificarServicio = new Logica.ConfiguracionServiciosPlaya.LogicaModificarServicio();

        //}

        /// <summary>
        /// Inicializa los campos coloca el valor del servicio solicitado
        /// </summary>
        /// <param name="servicio">Los valores del servicio en un objeto servicio</param>
        //private void inicializarCampos(Servicio _servicio)
        //{

        //    inputNombreServcio.Text = _servicio.Nombre;
        //    this.nombreOriginal.Text = _servicio.Nombre;
        //    inputDescripcion.Text = _servicio.Descripcion;
        //    inputCosto.Text = _servicio.Costo.ToString("0.00", CultureInfo.InvariantCulture);
        //    inputLugarRetiro.Text = _servicio.LugarRetiro;
        //    inputCantidad.Text = _servicio.Cantidad.ToString();
        //    inputCapacidad.Text = _servicio.Capacidad.ToString();

        //    //Coloca el estado(en selected) del servicio en el Dropdown listEstado
        //    foreach (ListItem _estado in this.dropdownlistEstado.Items)
        //    {         

        //        if (_estado.Value.Equals("true") == _servicio.Estado)
        //            _estado.Selected = true;

        //    }

        //    foreach (ListItem _categoria in this.dropdownlistCategoria.Items)
        //    {

        //        if (_categoria.Text.Equals(_servicio.Categoria))
        //            _categoria.Selected = true;

        //    }

        //    this.agregarHorarioListBox(_servicio);
        //}


        /// <summary>
        /// Inicializa el ListBox de Horarios traidos del Servicio
        /// </summary>
        /// <param name="_servicio">El servicio de donde obtendran los horarios</param>
        //private void agregarHorarioListBox(Servicio _servicio)
        //{
        //    ListItem _itemHorario;
        //    string _horaInicio;
        //    string _horaFin;

        //    foreach (HorarioServicio _itemHora in _servicio.obtenerListaHorario())
        //    {

        //        _itemHorario = new ListItem();                

        //        _horaInicio = this.obtenerHoraString(_itemHora.HoraInicio);
        //        _horaFin = this.obtenerHoraString(_itemHora.HoraFin);

        //        //Agregar al ListBox
        //        _itemHorario.Text = _horaInicio + " a " + _horaFin;
        //        _itemHorario.Value = _itemHora.IdHorario.ToString();
        //        this.listboxHorario.Items.Add(_itemHorario);

        //    }

        //}

        /// <summary>
        /// Dado un DateTime permite conocer el string que se mostrará en pantalla al usuario
        /// </summary>
        /// <param name="_itemHora">El DateTime que se pasará al formato a mostrar por pantalla</param>
        /// <returns>El string con el formato a mostrar</returns>
        private string obtenerHoraString(DateTime _itemHora)
        {
            int _horaTempInicio = 0;
            string _horaInicio;
            bool _esTarde = false;

            if (_itemHora.Hour >= 12)
            {
                _horaTempInicio = _itemHora.Hour - 12;
                if (_horaTempInicio == 0)
                    _horaTempInicio = 12;
                _esTarde = true;
            }
            else
                _horaTempInicio = _itemHora.Hour;

            if (_horaTempInicio <= 9)
                _horaInicio = "0" + _horaTempInicio.ToString();
            else
                _horaInicio = _horaTempInicio.ToString();

            if (_itemHora.Minute <= 9)
                _horaInicio = _horaInicio + ":0" + _itemHora.Minute.ToString();
            else
                _horaInicio = _horaInicio + ":" + _itemHora.Minute.ToString();

            if (_esTarde)
                _horaInicio = _horaInicio + " pm";
            else
                _horaInicio = _horaInicio + " am";

            return _horaInicio;
        }

        /// <summary>
        /// Inicializa el dropdown list categoria con todas las categorias almacenadas
        /// </summary>
        //private void llenarCategorias()
        //{

        //    //NULL POINTER EXCEPTION
        //    this._logicaModificarServicio = new Logica.ConfiguracionServiciosPlaya.LogicaModificarServicio();
        //    List<Categoria> _categorias = this._logicaModificarServicio.obtenerCategorias(this.LabelMensaje);
        //    ListItem _itemCat;

        //    if (_categorias != null)
        //    {
        //        this.dropdownlistCategoria.Items.Clear();

        //        _itemCat = new ListItem();
        //        _itemCat.Text = "Seleccione una categoría";
        //        _itemCat.Value = "0";
        //        this.dropdownlistCategoria.Items.Add(_itemCat);

        //        foreach (Categoria _itemCategoria in _categorias)
        //        {
        //            _itemCat = new ListItem();
        //            _itemCat.Text = _itemCategoria.NombreCategoria;
        //            _itemCat.Value = _itemCategoria.NombreCategoria;
        //            this.dropdownlistCategoria.Items.Add(_itemCat);
        //        }

        //        _itemCat = new ListItem();
        //        _itemCat.Text = "Otro...";
        //        _itemCat.Value = "Otro";
        //        this.dropdownlistCategoria.Items.Add(_itemCat);
        //    }
        //}

        /// <summary>
        /// Valida que el horario no coincida con alguno ya insertado
        /// </summary>
        /// <param name="_horaInicio">Hora inicio del Horario</param>
        /// <param name="_horaFinal">Hora Fin del horario</param>
        /// <returns>True si es valido insertarlo, False en caso que coincida con alguno ya insertado</returns>
        private bool validarHorario(string _horaInicio, string _horaFinal)
        {
            DateTime _horaIni = DateTime.Parse(_horaInicio);
            DateTime _horaFin = DateTime.Parse(_horaFinal);
            string[] _horas;
            DateTime _horaIniItem;
            DateTime _horaFinItem;

            foreach (ListItem _itemHorario in this.listboxHorario.Items)
            {
                _horas = _itemHorario.Text.Split(new string[] { " a " }, StringSplitOptions.None);
                _horaIniItem = DateTime.Parse(_horas[0]);
                _horaFinItem = DateTime.Parse(_horas[1]);

                if (_horaIni.TimeOfDay == _horaIniItem.TimeOfDay)
                    return false;
                if (_horaIni.TimeOfDay < _horaFinItem.TimeOfDay && _horaIni.TimeOfDay >= _horaIniItem.TimeOfDay)
                    return false;

                if (_horaFin.TimeOfDay == _horaFinItem.TimeOfDay)
                    return false;
                if (_horaFin.TimeOfDay > _horaIniItem.TimeOfDay && _horaFin.TimeOfDay <= _horaFinItem.TimeOfDay)
                    return false;
            }

            return true;
        }

        protected void AceptarBoton_Click(object sender, EventArgs e)
        {
            //    int _contador = 0;
            //    string[] _datos = new string[7];
            //    string[] horas;
            //    Servicio _servicio;

            //    if (Page.IsValid)
            //    {
            //        this.AceptarBoton.Enabled = false;

            //        this._logicaModificarServicio = new Logica.ConfiguracionServiciosPlaya.LogicaModificarServicio();                                
            //        HorarioServicio[] _horarios = new HorarioServicio[this.listboxHorario.Items.Count];                


            //        //this.ButtonAgregar.Enabled = false;
            //        _datos[0] = this.inputNombreServcio.Text;
            //        _datos[1] = this.inputDescripcion.Text;

            //        if (this.dropdownlistCategoria.SelectedValue != "Otro")
            //            _datos[5] = this.dropdownlistCategoria.SelectedValue;
            //        else
            //            _datos[5] = this.inputCategoriaOtro.Text;

            //        _datos[6] = this.inputLugarRetiro.Text;
            //        _datos[2] = this.inputCapacidad.Text;
            //        _datos[3] = this.inputCantidad.Text;
            //        _datos[4] = this.inputCosto.Text;

            //        foreach (ListItem item in this.listboxHorario.Items)
            //        {

            //            horas = item.Text.Split(new string[] { " a " }, StringSplitOptions.None);                    
            //            _horarios[_contador] = new HorarioServicio(DateTime.Parse(horas[0]), DateTime.Parse(horas[1]));

            //            if (item.Value.Equals("1"))
            //                _horarios[_contador].Nuevo = true;

            //            _contador++;

            //        }

            //        _servicio = new Servicio(_datos, _horarios);

            //        if (this.dropdownlistEstado.SelectedValue.Equals("true"))
            //            _servicio.Estado = true;
            //        else
            //            _servicio.Estado = false;

            //        if (_servicio.Nombre.Equals(this.nombreOriginal.Text))
            //            this._logicaModificarServicio.actualizarServicio(_servicio,false,this.nombreOriginal.Text,this.LabelMensaje);
            //        else
            //            this._logicaModificarServicio.actualizarServicio(_servicio, true, this.nombreOriginal.Text,this.LabelMensaje);

            //        if (this.dropdownlistCategoria.SelectedValue == "Otro")
            //        {
            //            this.llenarCategorias();
            //            foreach (ListItem _categoria in this.dropdownlistCategoria.Items)
            //            {

            //                if (_categoria.Text.Equals(this.inputCategoriaOtro.Text))
            //                    _categoria.Selected = true;

            //            }
            //            this.inputCategoriaOtro.Text = "";

            //        }
            //        this.AceptarBoton.Enabled = true;
            //        Response.Redirect("web_03_consultaServicio.aspx?Mensaje=" + LabelMensaje.Text);

            //    }

        }

        /// <summary>
        /// Evento que se ejecuta cuando el usuario le da al botón mas del ListBoxHorarios en la interfaz
        /// Permite Agregar Horarios al Listbox (válida primero que sea posible).
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Eventos</param>
        protected void agregarHorarioListbox_Click(object sender, ImageClickEventArgs e)
        {
            ListItem _itemHorario;
            if (!this.timePickerInicio.Text.Equals("-- : --") && !this.timePickerFin.Text.Equals("-- : --"))
            {
                if (validarHorario(this.timePickerInicio.Text, this.timePickerFin.Text))
                {
                    this.mensajeHorarioRepetido.Visible = false;
                    this.mensajeErrorAgregarHorario.Visible = false;
                    _itemHorario = new ListItem();
                    _itemHorario.Text = this.timePickerInicio.Text + " a " + this.timePickerFin.Text;
                    _itemHorario.Value = "1";
                    this.listboxHorario.Items.Add(_itemHorario);
                    this.timePickerInicio.Text = "--:--";
                    this.timePickerFin.Text = "--:--";
                }
                else
                {
                    this.mensajeErrorEliminarHorario.Visible = false;
                    this.mensajeHorarioRepetido.Visible = true;
                }
            }
            else
            {
                this.mensajeErrorAgregarHorario.Visible = true;
            }
        }

        /// <summary>
        /// Evento al presionar boton menos, permite remover horarios del listbox
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Evento</param>
        protected void removerHorarioListbox_Click(object sender, ImageClickEventArgs e)
        {
            //    Servicio _servicio = new Servicio();
            //    HorarioServicio _horario = new HorarioServicio();
            //    string[] _horas;


            //    if (this.listboxHorario.SelectedItem == null)
            //    {
            //        this.mensajeHorarioOcupado.Visible = false;                     
            //        this.mensajeHorarioRepetido.Visible = false;
            //        this.mensajeErrorEliminarHorario.Visible = true;

            //    }

            //    if (this.listboxHorario.SelectedItem != null)
            //    {
            //        _servicio.Nombre=this.nombreOriginal.Text;                          
            //        _horas = this.listboxHorario.SelectedItem.Text.Split(new string[] { " a " }, StringSplitOptions.None);
            //        _horario.HoraInicio = DateTime.Parse(_horas[0]);
            //        _horario.HoraInicio.AddYears(1000);
            //        _horario.HoraFin = DateTime.Parse(_horas[1]);
            //        _horario.HoraFin.AddYears(1000);

            //        if (this._logicaModificarServicio.validarEliminarServicio(_servicio, _horario, this.LabelMensaje))
            //        {

            //            this.mensajeErrorEliminarHorario.Visible = false;
            //            this.mensajeHorarioRepetido.Visible = false;
            //            this.mensajeHorarioOcupado.Visible = true;                    

            //        }
            //        else
            //        {

            //            this.mensajeErrorEliminarHorario.Visible = false;
            //            this.listboxHorario.Items.Remove(this.listboxHorario.SelectedItem);

            //        }

            //    }

        }

        protected void CancelarBoton_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_03_consultaServicio.aspx");
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
        }

        #endregion
    }

}