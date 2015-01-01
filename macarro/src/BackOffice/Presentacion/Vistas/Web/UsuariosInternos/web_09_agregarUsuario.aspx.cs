using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.UsuariosInternos;
using BackOffice.Presentacion.Presentadores.UsuariosInternos;



namespace BackOffice.Presentacion.Vistas.Web.UsuariosInternos
{
    public partial class web_09_agregarUsuario : System.Web.UI.Page,IContrato_09_AgregarUsuario
    {
       
        private Presentador_09_agregarUsuario _presentador;


        public web_09_agregarUsuario() 
        {
            _presentador = new Presentador_09_agregarUsuario(this);
        }

        # region Implementación get y set de los atributos del contrato Agregar  Usuario

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

        TextBox IContrato_09_AgregarUsuario.PrimerNombre 
        {
            get { return TextBoxNombre; }
            set { TextBoxNombre = value; }
        }

        TextBox IContrato_09_AgregarUsuario.SegundoNombre
        {
            get { return TextBoxSegNombre; }
            set { TextBoxSegNombre = value; }
        }

        TextBox IContrato_09_AgregarUsuario.PrimerApellido
        {
            get { return TextBoxApellido; }
            set { TextBoxApellido = value; }
        }

        TextBox IContrato_09_AgregarUsuario.SegundoApellido
        {
            get { return TextBoxSegApellido; }
            set { TextBoxSegApellido = value; }
        }

        DropDownList IContrato_09_AgregarUsuario.TipoDocumentacion
        {
            get { return DropDownListDocumento; }
            set { DropDownListDocumento = value; }
        }

        TextBox IContrato_09_AgregarUsuario.Cedula
        {
            get { return TextBoxCedula; }
            set { TextBoxCedula = value; }
        }

        TextBox IContrato_09_AgregarUsuario.FechaNacimiento
        {
            get { return TextBoxFechaNac; }
            set { TextBoxFechaNac = value; }
        }

        TextBox IContrato_09_AgregarUsuario.Correo
        {
            get { return TextBoxCorreo; }
            set { TextBoxCorreo = value; }
        }

        TextBox IContrato_09_AgregarUsuario.Telefono
        {
            get { return TextBoxTelefono; }
            set { TextBoxTelefono = value; }
        }

        DropDownList IContrato_09_AgregarUsuario.Pais 
        {
            get { return DropDownListPais; }
            set { DropDownListPais = value; }
        }

        DropDownList IContrato_09_AgregarUsuario.Estado
        {
            get { return DropDownListEstado; }
            set { DropDownListEstado = value; }
        }

        DropDownList IContrato_09_AgregarUsuario.Ciudad
        {
            get { return DropDownListCiudad; }
            set { DropDownListCiudad = value; }
        }

        TextBox IContrato_09_AgregarUsuario.Direccion
        {
            get { return TextBoxDireccion; }
            set { TextBoxDireccion = value; }
        }
               
        #endregion

        #region Código Anterior Usuarios Internos
        string _correoS = string.Empty;
        string _docIdentidadS = string.Empty;
        string _primerNombreS = string.Empty;
        string _primerApellidoS = string.Empty;
        string _direccion = string.Empty;

        //Empleado _empleado;
        //Hash _hash = new Hash();
        //UsuariosInternosLogica _logicaUsuario = new UsuariosInternosLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            //VariableSesion();
            //if (_correoS != null && _docIdentidadS != null)
            //{
            //    if (!IsPostBack) // verificar si la pagina se muestra por primera vez
            //    {
            //        this.llenarComboBoxPais();
            //    }
            //}
            //else
            //    Server.Transfer("../IngresoRecuperacionClave/web_01_inicioSesionA.aspx", false);
            _presentador.PageLoad(); 

        }

        private void VariableSesion()
        {
            try
            {
                _correoS = (string)(Session["correo"]);
                _docIdentidadS = (string)(Session["docIdentidad"]);
                _primerNombreS = (string)(Session["primerNombre"]);
                _primerApellidoS = (string)(Session["primerApellido"]);
            }
            catch (Exception ex)
            {
                //MensajeErrores.Text = "No se han podido cargar los datos de sesion";
                //MensajeErrores.Visible = true;
                //ex.GetType();
            }
        }

        protected void asignarRol(object sender, EventArgs e)
        {
        //    try
        //    {
        //        _empleado = CreandoEmpleado();
        //        if (_logicaUsuario.VerificarCorreo(_empleado) == 0 && _logicaUsuario.VerificarDocIdentidad(_empleado) == 0)
        //        {
        //            if (_logicaUsuario.AgregarEmpleado(_empleado, _empleado.Persona.FkLugar, _direccion))
        //                Response.Redirect("web_09_asignarRoles.aspx?id=" + _empleado.Usuario.Correo);
        //            else
        //                this.mensajeError.Text = "Documento de identidad o correo ya existente";
        //        }
        //        //Puede ser el else - Con mensaje
        //    }
        //    catch (ExcepcionUsuariosInternosLogica ex)
        //    {
        //        this.mensajeError.Text = RecursosExcepcionesUsuariosInternos.mensajeDatos + "Error: " + ex.Message.ToString();
        //    }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            validatorfechanac.MinimumValue = DateTime.Now.AddYears(-65).ToString("dd/MM/yyyy");
            validatorfechanac.MaximumValue = DateTime.Now.AddYears(-18).ToString("dd/MM/yyyy");
        }

        protected void cbEstado_SelectionChangeCommitted(object sender, EventArgs e)
        {
        //    this.DropDownListEstado.Items.Clear();
        //    this.DropDownListCiudad.Items.Clear();
        //    int _idPais = Convert.ToInt32(this.DropDownListPais.SelectedValue);
        //    llenarComboBoxEstado(_idPais);
        }

        protected void cbCiudad_SelectionChangeCommitted(object sender, EventArgs e)
        {
        //    int _idEstado = Convert.ToInt32(this.DropDownListEstado.SelectedValue);
        //    llenarComboBoxCiudad(_idEstado);
        }

        //private void llenarComboBoxPais()
        //{
        //    try
        //    {

        //        Logica.UsuariosInternos.UsuariosInternosLogica _logicaUsuarioInterno = new Logica.UsuariosInternos.UsuariosInternosLogica();
        //        List<Lugar> _paises = _logicaUsuarioInterno.LlenarCBPaises();
        //        ListItem _itemPais;

        //        this.DropDownListPais.Items.Clear();

        //        _itemPais = new ListItem();
        //        _itemPais.Text = "Seleccione Pais";
        //        _itemPais.Value = "0";
        //        this.DropDownListPais.Items.Add(_itemPais);

        //        foreach (Lugar _itemPaises in _paises)
        //        {
        //            _itemPais = new ListItem();
        //            _itemPais.Text = _itemPaises.NombreLugar;
        //            _itemPais.Value = _itemPaises.IdLugar.ToString();
        //            this.DropDownListPais.Items.Add(_itemPais);
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

        //public Empleado CreandoEmpleado()
        //{
        //    Random passwordGenerado = new Random();
        //    string[] _caracteres = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", 
        //                             "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", 
        //                             "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
        //    string _clave = "";
        //    int _caracter = 0;
        //    for (int i = 1; i <= 12; i++)
        //    {
        //        _caracter = passwordGenerado.Next(1, 62);
        //        _clave = _clave + _caracteres[_caracter];
        //    }

        //    _empleado = new Empleado();
        //    _empleado.Persona.PrimerNombre = TextBoxNombre.Text;
        //    _empleado.Persona.SegundoNombre = TextBoxSegNombre.Text;
        //    _empleado.Persona.PrimerApellido = TextBoxApellido.Text;
        //    _empleado.Persona.SegundoApellido = TextBoxSegApellido.Text;
        //    _empleado.Persona.TipoDocIdentidad = DropDownListDocumento.SelectedItem.ToString();
        //    _empleado.Persona.DocIdentidad = TextBoxCedula.Text;
        //    _empleado.Persona.FechaNacimientoS = TextBoxFechaNac.Text;
        //    _empleado.Usuario.Correo = TextBoxCorreo.Text;
        //    //_empleado.Usuario.Contrasena = _hash.ObtenerMd5Hash(MetodoGeneraContrasena);
        //    _empleado.Usuario.Contrasena = _hash.ObtenerMd5Hash(_clave);
        //    _empleado.Usuario.FechaIngresoS = DateTime.Now.ToString("MM/dd/yyyy"); ;
        //    _empleado.Usuario.FechaEgresoS = DateTime.MinValue.ToString("MM/dd/yyyy"); ;
        //    _empleado.Usuario.EstatusUsuario = "Activado";
        //    _empleado.Usuario.TipoUsuario = "Empleado";
        //    _empleado.Persona.FkLugar = Convert.ToInt32(DropDownListCiudad.SelectedItem.Value);
        //    _direccion = TextBoxDireccion.Text;
        //    return _empleado;
        //}
        #endregion
    }
}