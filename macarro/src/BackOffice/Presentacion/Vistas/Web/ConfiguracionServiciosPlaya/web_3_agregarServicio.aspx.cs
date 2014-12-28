using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionServiciosPlaya
{
    public partial class web_3_agregarServicio : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //string _correoS = (string)(Session["correo"]);
            //string _docIdentidadS = (string)(Session["docIdentidad"]);
            //string _primerNombreS = (string)(Session["primerNombre"]);
            //string _primerApellidoS = (string)(Session["primerApellido"]);

            //if (!Page.IsPostBack)
            //{
            //    this.mensajeErrorAgregarHorario.Visible = false;
            //    this.mensajeErrorEliminarHorario.Visible = false;
            //    this.mensajeHorarioRepetido.Visible = false;
            //    this.llenarCategorias();
            //}
        }



        /// <summary>
        /// Llenado la lista de datos de los campos
        /// </summary>
        /// <param name="_datos">Arreglo de strings que contiene los atributos del servicio</param>
        /// <returns>Arreglo con contenido</returns>
        private string[] llenarDatos(string[] _datos)
        {
            _datos[0] = this.inputNombreServcio.Text;
            _datos[1] = this.inputDescripcion.Text;
            if (this.dropdownlistCategoria.SelectedValue != "Otro")
                _datos[5] = this.dropdownlistCategoria.SelectedValue;
            else
                _datos[5] = this.inputCategoriaOtro.Text;
            _datos[6] = this.inputLugarRetiro.Text;
            _datos[2] = this.inputCapacidad.Text;
            _datos[3] = this.inputCantidad.Text;
            _datos[4] = this.inputCosto.Text;
            
            return _datos;
        }



        /// <summary>
        /// Evento del boton de Aceptar, contiene la recolección de los datos ingresados en los campos y llenado de horarios.
        /// Crea un objeto servicio y genera los mensajes de éxito o fracaso.
        /// </summary>
        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
        //    string[] _datos = new string[7];
        //    HorarioServicio[] _horarios = new HorarioServicio[this.listboxHorario.Items.Count];
        //    int _contador = 0;
        //    string[] horas;
        //    Servicio _servicio;
        //    LogicaAgregarServicio _logicaServicio = new LogicaAgregarServicio();
            
        //    this.ButtonAgregar.Enabled = false;
        //    _datos = this.llenarDatos(_datos);
        //    foreach (ListItem item in this.listboxHorario.Items)
        //    {
        //        horas = item.Text.Split(new string[] {" a "}, StringSplitOptions.None);
        //        _horarios[_contador] = new HorarioServicio(DateTime.Parse(horas[0]),DateTime.Parse(horas[1]));
        //        _contador++;
        //    }
        //    _servicio = new Servicio(_datos,_horarios);
        //    _logicaServicio.agregarServicio(_servicio, this.LabelMensaje);
        //    this.ButtonAgregar.Enabled = true;     
        //    //this.borrarCampos();
        }



        /// <summary>
        /// Borra los campos de texto previamente ingresados
        /// </summary>
        private void borrarCampos()
        {
            this.inputNombreServcio.Text = "";
            this.inputDescripcion.Text = "";
            this.inputCantidad.Text = "";
            this.inputCapacidad.Text = "";
            this.inputCosto.Text = "";
            this.inputCategoriaOtro.Text = "";
            this.dropdownlistCategoria.SelectedIndex = 0;
            //this.listboxHorario = new ListBox();
        }

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

        /// <summary>
        /// Agregar los horarios del campo de texto a la lista de horarios.
        /// </summary>
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
        /// Remueve el horario seleccionado de la lista
        /// </summary>
        protected void removerHorarioListbox_Click(object sender, ImageClickEventArgs e)
        {
            if (this.listboxHorario.SelectedItem == null)
            {
                this.mensajeHorarioRepetido.Visible = false;
                this.mensajeErrorEliminarHorario.Visible = true;
            }
            if (this.listboxHorario.SelectedItem != null)
            {
                this.mensajeErrorEliminarHorario.Visible = false;
                this.listboxHorario.Items.Remove(this.listboxHorario.SelectedItem);
            }
        }



        /// <summary>
        /// Llena la etiqueta de Categoria con las almacenadas en base de datos
        /// </summary>
        //private void llenarCategorias()
        //{

        //    //NULL POINTER EXCEPTION
        //    Logica.ConfiguracionServiciosPlaya.LogicaModificarServicio _logicaModificarServicio = new Logica.ConfiguracionServiciosPlaya.LogicaModificarServicio();
        //    List<Categoria> _categorias = _logicaModificarServicio.obtenerCategorias(this.LabelMensaje);
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
    }
}