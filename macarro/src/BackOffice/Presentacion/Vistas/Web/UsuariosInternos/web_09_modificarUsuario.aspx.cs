﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.UsuariosInternos;
using BackOffice.Presentacion.Presentadores.UsuariosInternos;


namespace BackOffice.Presentacion.Vistas.Web.UsuariosInternos
{
    public partial class web_09_modificarUsuario : System.Web.UI.Page, IContrato_09_modificarUsuario
    {
        private Presentador_09_modificarUsuario _presentador;


         public web_09_modificarUsuario() 
        {
            _presentador = new Presentador_09_modificarUsuario(this);
        }

        # region Implementación get y set de los atributos del contrato Modificar  Usuario

         TextBox IContrato_09_modificarUsuario.Nombre 
        {
            get { return TextBoxNombre; }
            set { TextBoxNombre = value; }
        }

         TextBox IContrato_09_modificarUsuario.SegundoNombre
        {
            get { return TextBoxSegNombre; }
            set { TextBoxSegNombre = value; }
        }

         TextBox IContrato_09_modificarUsuario.Apellido
        {
            get { return TextBoxApellido; }
            set { TextBoxApellido = value; }
        }

         TextBox IContrato_09_modificarUsuario.SegundoApellido
        {
            get { return TextBoxSegApellido; }
            set { TextBoxSegApellido = value; }
        }

         DropDownList IContrato_09_modificarUsuario.TipoDocumento 
        {
            get { return DropDownListCedula; }
            set { DropDownListCedula = value; }
        }

         TextBox IContrato_09_modificarUsuario.Cedula 
        {
            get { return TextBoxCedula ; }
            set { TextBoxCedula = value; }
        }

         TextBox IContrato_09_modificarUsuario.FechaNacimiento 
        {
            get { return TextBoxFechaNac; }
            set { TextBoxFechaNac = value; }
        }

         TextBox IContrato_09_modificarUsuario.Correo
        {
            get { return TextBoxCorreo; }
            set { TextBoxCorreo = value; }
        }

         TextBox IContrato_09_modificarUsuario.Contrasena
        {
            get { return TextBoxContraseña; }
            set { TextBoxContraseña = value; }
        }

         TextBox IContrato_09_modificarUsuario.VerificarContrasena
        {
            get { return TextBoxVerifContraseña; }
            set { TextBoxVerifContraseña = value; }
        }

         DropDownList IContrato_09_modificarUsuario.Estatus
        {
            get { return CBlistaEstatus; }
            set { CBlistaEstatus = value; }
        }

         TextBox IContrato_09_modificarUsuario.Telefono
        {
            get { return Telefono; }
            set { Telefono = value; }
        }

         DropDownList IContrato_09_modificarUsuario.Pais
        {
            get { return DropDownListPais; }
            set { DropDownListPais = value; }
        }

         DropDownList IContrato_09_modificarUsuario.Estado
        {
            get { return DropDownListEstado; }
            set { DropDownListEstado = value; }
        }

         DropDownList IContrato_09_modificarUsuario.Ciudad
        {
            get { return DropDownListCiudad; }
            set { DropDownListCiudad = value; }
        }

         TextBox IContrato_09_modificarUsuario.Direccion
        {
            get { return TextBoxDireccion; }
            set { TextBoxDireccion = value; }
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

        #region Código Anterior Usuarios Internos
        string _correoS = string.Empty;
        string _docIdentidadS = string.Empty;
        string _primerNombreS = string.Empty;
        string _primerApellidoS = string.Empty;

        int _idCiudad;
        string _nombreDireccion = string.Empty;
        //Hash _hash = new Hash();
        //Empleado _empleado;
        //UsuariosInternosLogica _logicaUsuarioInterno = new UsuariosInternosLogica();

        private string _idEmpleado = string.Empty;
        private string _noTiene = " ";

        protected void Page_Load(object sender, EventArgs e)
        {
            //VariableSesion();
            //if ((_correoS != null) && (_docIdentidadS != null))
            //{
            //    if (Request.QueryString["id"] != null)
            //    {
            //        //Obtiene el ID del empleado seleccionado
            //        _idEmpleado = Request.QueryString["id"];
            //        if (!IsPostBack)
            //        {
            //            CargarDatosEmpleado(_idEmpleado);
            //        }
            //    }
            //}
            //else
            //    Server.Transfer("../IngresoRecuperacionClave/web_01_inicioSesionA.aspx", false);

            if (!IsPostBack)
            {
                _presentador.PageLoad();
            }
        }

        //private void VariableSesion()
        //{
        //    try
        //    {
        //        _correoS = (string)(Session["correo"]);
        //        _docIdentidadS = (string)(Session["docIdentidad"]);
        //        _primerNombreS = (string)(Session["primerNombre"]);
        //        _primerApellidoS = (string)(Session["primerApellido"]);
        //    }
        //    catch (ExcepcionUsuariosInternosDatos ex)
        //    {
        //        this.mensajeError.Text = RecursosExcepcionesUsuariosInternos.mensajeDatos + "Error: " + ex.Message.ToString();
        //    }
        //    catch (ExcepcionUsuariosInternosLogica ex)
        //    {
        //        this.mensajeError.Text = RecursosExcepcionesUsuariosInternos.mensajeDatos + "Error: " + ex.Message.ToString();
        //    }
        //}

        protected void cbEstado_SelectionChangeCommitted(object sender, EventArgs e)
        {
        //    this.DropDownListEstado.Items.Clear();
        //    this.DropDownListCiudad.Items.Clear();
        //    this.TextBoxDireccion.Text = "";
        //    int _idPais = Convert.ToInt32(this.DropDownListPais.SelectedValue);
        //    llenarComboBoxEstado(_idPais);
            _presentador.cbEstado_SelectionChangeCommitted(); 
        }

        protected void cbCiudad_SelectionChangeCommitted(object sender, EventArgs e)
        {
          
        //        int _idEstado = Convert.ToInt32(this.DropDownListEstado.SelectedValue);
        //        llenarComboBoxCiudad(_idEstado);
            _presentador.cbCiudad_SelectionChangeCommitted(); 

        }

        //private void llenarComboBoxEstado(int idPais)
        //{
        //    try
        //    {
        //        Logica.UsuariosInternos.UsuariosInternosLogica _logicaUsuarioInterno = new Logica.UsuariosInternos.UsuariosInternosLogica();
        //        List<Lugar> _estados = _logicaUsuarioInterno.LlenarCBEstado(idPais);
        //        ListItem _itemEstado;

        //        this.DropDownListEstado.Items.Clear();

        //        _itemEstado = new ListItem();
        //        _itemEstado.Text = "Seleccione Estado";
        //        _itemEstado.Value = "0";
        //        this.DropDownListEstado.Items.Add(_itemEstado);

        //        foreach (Lugar _itemEstados in _estados)
        //        {
        //            _itemEstado = new ListItem();
        //            _itemEstado.Text = _itemEstados.NombreLugar;
        //            _itemEstado.Value = _itemEstados.IdLugar.ToString();
        //            this.DropDownListEstado.Items.Add(_itemEstado);
        //        }
        //    }
        //    catch (ExcepcionUsuariosInternosDatos ex)
        //    {
        //        this.mensajeError.Text = RecursosExcepcionesUsuariosInternos.mensajeDatos + "Error: " + ex.Message.ToString();
        //    }
        //    catch (ExcepcionUsuariosInternosLogica ex)
        //    {
        //        this.mensajeError.Text = RecursosExcepcionesUsuariosInternos.mensajeDatos + "Error: " + ex.Message.ToString();
        //    }
        //}

        //private void llenarComboBoxCiudad(int idEstado)
        //{
        //    try
        //    {
        //        Logica.UsuariosInternos.UsuariosInternosLogica _logicaUsuarioInterno = new Logica.UsuariosInternos.UsuariosInternosLogica();
        //        List<Lugar> _ciudades = _logicaUsuarioInterno.LlenarCBCiudad(idEstado);
        //        ListItem _itemCiudad;

        //        this.DropDownListCiudad.Items.Clear();

        //        _itemCiudad = new ListItem();
        //        _itemCiudad.Text = "Seleccione Ciudad";
        //        _itemCiudad.Value = "0";
        //        this.DropDownListCiudad.Items.Add(_itemCiudad);

        //        foreach (Lugar _itemCiudades in _ciudades)
        //        {
        //            _itemCiudad = new ListItem();
        //            _itemCiudad.Text = _itemCiudades.NombreLugar;
        //            _itemCiudad.Value = _itemCiudades.IdLugar.ToString();
        //            this.DropDownListCiudad.Items.Add(_itemCiudad);
        //        }
        //    }
        //    catch (ExcepcionUsuariosInternosDatos ex)
        //    {
        //        this.mensajeError.Text = RecursosExcepcionesUsuariosInternos.mensajeDatos + "Error: " + ex.Message.ToString();
        //    }
        //    catch (ExcepcionUsuariosInternosLogica ex)
        //    {
        //        this.mensajeError.Text = RecursosExcepcionesUsuariosInternos.mensajeDatos + "Error: " + ex.Message.ToString();
        //    }
        //}

        ///* Cargar datos empleado */

        //private void CargarDatosEmpleado(string id)
        //{
        //    _empleado = new Empleado();
        //    _empleado = _logicaUsuarioInterno.EmpleadoUnico(_idEmpleado);
        //    if (_empleado != null)
        //    {
        //        TextBoxNombre.Text = _empleado.Persona.PrimerNombre;

        //        if (_empleado.Persona.SegundoNombre.ToString() == "")
        //            TextBoxSegNombre.Text = _noTiene;
        //        else
        //            TextBoxSegNombre.Text = _empleado.Persona.SegundoNombre;

        //        TextBoxApellido.Text = _empleado.Persona.PrimerApellido;

        //        if (_empleado.Persona.SegundoApellido.ToString() == "")
        //            TextBoxSegApellido.Text = _noTiene;
        //        else
        //            TextBoxSegApellido.Text = _empleado.Persona.SegundoApellido;

        //        TextBoxCedula.Text = _empleado.Persona.DocIdentidad;
        //        TextBoxFechaNac.Text = _empleado.Persona.FechaNacimiento.ToString("yyyy-MM-dd");
        //        TextBoxCorreo.Text = _empleado.Usuario.Correo;

        //        DropDownListCedula.Items.FindByValue(_empleado.Persona.TipoDocIdentidad).Selected = true;

        //        CargarDireccionEmpleado();
        //    }
        //}

        //private void CargarDireccionEmpleado()
        //{
        //    this.DropDownListPais.DataSource = _logicaUsuarioInterno.LlenarCBPaises();
        //    this.DropDownListPais.DataTextField = "NombreLugar";
        //    this.DropDownListPais.DataValueField = "IdLugar";
        //    this.DropDownListPais.DataBind();

        //    this.DropDownListPais.Items.FindByValue(_logicaUsuarioInterno.ConsultarDireccionCompleta(_empleado.Persona.FkLugar).ElementAt(0).ToString()).Selected = true;

        //    this.DropDownListEstado.DataSource = _logicaUsuarioInterno.LlenarCBEstado(_logicaUsuarioInterno.ConsultarDireccionCompleta(_empleado.Persona.FkLugar).ElementAt(0));
        //    this.DropDownListEstado.DataTextField = "NombreLugar";
        //    this.DropDownListEstado.DataValueField = "IdLugar";
        //    this.DropDownListEstado.DataBind();

        //    this.DropDownListEstado.Items.FindByValue(_logicaUsuarioInterno.ConsultarDireccionCompleta(_empleado.Persona.FkLugar).ElementAt(1).ToString()).Selected = true;

        //    this.DropDownListCiudad.DataSource = _logicaUsuarioInterno.LlenarCBCiudad(_logicaUsuarioInterno.ConsultarDireccionCompleta(_empleado.Persona.FkLugar).ElementAt(1));
        //    this.DropDownListCiudad.DataTextField = "NombreLugar";
        //    this.DropDownListCiudad.DataValueField = "IdLugar";
        //    this.DropDownListCiudad.DataBind();

        //    this.DropDownListCiudad.Items.FindByValue(_logicaUsuarioInterno.ConsultarDireccionCompleta(_empleado.Persona.FkLugar).ElementAt(2).ToString()).Selected = true;

        //    this.TextBoxDireccion.Text = _logicaUsuarioInterno.ObtenerDireccion(_empleado.Persona.FkLugar);
        //}

        ///* Creando datos empleado */

        //private  Empleado CreandoEmpleado()
        //{
        //    _empleado = new Empleado();
        //    _empleado.Persona.PrimerNombre = TextBoxNombre.Text;
        //    _empleado.Persona.SegundoNombre = TextBoxSegNombre.Text;
        //    _empleado.Persona.PrimerApellido = TextBoxApellido.Text;
        //    _empleado.Persona.SegundoApellido = TextBoxSegApellido.Text;
        //    _empleado.Persona.TipoDocIdentidad = DropDownListCedula.SelectedItem.ToString();
        //    _empleado.Persona.DocIdentidad = TextBoxCedula.Text;

        //    //_empleado.Persona.FechaNacimiento = DateTime.Parse(TextBoxFechaNac.Text);
        //    _empleado.Persona.FechaNacimientoS = TextBoxFechaNac.Text;

        //    _empleado.Usuario.Correo = TextBoxCorreo.Text;
        //    _empleado.Usuario.Contrasena = _hash.ObtenerMd5Hash(TextBoxContraseña.Text);

        //    //_empleado.Usuario.FechaIngreso = DateTime.Now;
        //    //_empleado.Usuario.FechaEgreso = DateTime.MinValue;
        //    _empleado.Usuario.FechaIngresoS = DateTime.Now.ToString("MM/dd/yyyy");
        //    _empleado.Usuario.FechaEgresoS = DateTime.MinValue.ToString("MM/dd/yyyy");

        //    _empleado.Usuario.EstatusUsuario = "Activado";
        //    _empleado.Usuario.TipoUsuario = "Empleado";
        //    _idCiudad = Convert.ToInt16(DropDownListCiudad.SelectedItem.Value);
        //    _nombreDireccion = TextBoxDireccion.Text;
        //    return _empleado;
        //}

        //private bool ModificarEmpleado(Empleado empleado)
        //{
        //    bool resultado = false;
        //    if (_logicaUsuarioInterno.ModificarEmpleado(empleado,_idCiudad,_nombreDireccion))
        //        resultado = true;
        //    return resultado;
        //}



        protected void Siguiente(object sender, EventArgs e)
        {
            if (_presentador.ModificarEmpleado())
                Response.Redirect("web_09_asignarRoles.aspx");
            else
                Response.Redirect(RecursosPresentadorUsuariosInternos.PaginaGestionUsuario);


        //    _empleado = CreandoEmpleado();
        //    if (ModificarEmpleado(CreandoEmpleado()))
        //        Response.Redirect("web_09_asignarRoles.aspx?id=" + _empleado.Usuario.Correo);
        //    else
        //        Response.Redirect("web_09_gestionUsuario.aspx");
        }

        protected void Regresar(object sender, EventArgs e)
        {
           Response.Redirect(_presentador.BotonRegresar());
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
           validatorfechanac.MinimumValue = DateTime.Now.AddYears(-65).ToString("dd/MM/yyyy");
            validatorfechanac.MaximumValue = DateTime.Now.AddYears(-18).ToString("dd/MM/yyyy");
        }
        #endregion
       
        


    }
}