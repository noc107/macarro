using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontOffice.Presentacion.Contratos.IngresoRecuperacionClave;
using FrontOffice.Presentacion.Presentadores.IngresoRecuperacionClave;


namespace FrontOffice.Presentacion.Vistas.Web.IngresoRecuperacionClave
{
    public partial class web_01_modificar : System.Web.UI.Page, IContrato_01_modificar
    {
        private Presentador_01_modificar _presentador;

        public web_01_modificar()
        {
            _presentador = new Presentador_01_modificar(this);
        }

        string IContrato_01_modificar.PriNombre
        {
            get { return PriNombre.Text; }
            set { PriNombre.Text = value; }
        }

        string IContrato_01_modificar.SegNombre
        {
            get { return SegNombre.Text; }
            set { SegNombre.Text = value; }
        }

        string IContrato_01_modificar.PriApellido
        {
            get { return PriApellido.Text; }
            set { PriApellido.Text = value; }
        }

        string IContrato_01_modificar.SegApellido
        {
            get { return SegApellido.Text; }
            set { SegApellido.Text = value; }
        }

        string IContrato_01_modificar.TipoDocIdentidad
        {
            get { return this.TipoDocIdentidad.SelectedValue; }
        }

        string IContrato_01_modificar.NumeroDocumento
        {
            get { return NumeroDocumento.Text; }
            set { NumeroDocumento.Text = value; }
        }

        string IContrato_01_modificar.Correo
        {
            get { return Correo.Text; }
            set { Correo.Text = value; }
        }

        DateTime IContrato_01_modificar.FechaNac
        {
            get { return Convert.ToDateTime(FechaNac.Text); }
            set { FechaNac.Text = value.ToShortDateString(); }
        }

        string IContrato_01_modificar.Contrasena
        {
            get { return Contrasena.Text; }
            set { Contrasena.Text = value; }
        }

        string IContrato_01_modificar.RContrasena
        {
            get { return RContrasena.Text; }
            set { RContrasena.Text = value; }
        }

        string IContrato_01_modificar.PreSeguridad
        {
            get { return PreSeguridad.Text; }
            set { PreSeguridad.Text = value; }
        }

        string IContrato_01_modificar.RespSeguridad
        {
            get { return RespSeguridad.Text; }
            set { RespSeguridad.Text = value; }
        }

        string IContrato_01_modificar.Direccion1
        {
            get { return Direccion1.Text; }
            set { Direccion1.Text = value; }
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //Se cargar los datos

            //string _correoCliente = (string)(Session["correo"]);
            //string _docIdentidadS = (string)(Session["docIdentidad"]);
            //string _primerNombreS = (string)(Session["primerNombre"]);
            //string _primerApellidoS = (string)(Session["primerApellido"]);

            //LogicaLogin _informacion = new LogicaLogin();
            //if (_correoCliente != null)
            //{
            //    if (!IsPostBack)
            //    {
            //        OperacionesCliente _datos = new OperacionesCliente();
            //        _datos = _informacion.consultaC(_correoCliente);
            //        PriNombre.Text = _datos.Persona.PrimerNombre;
            //        SegNombre.Text = _datos.Persona.SegundoNombre;
            //        PriApellido.Text = _datos.Persona.PrimerApellido;
            //        SegApellido.Text = _datos.Persona.SegundoApellido;
            //        TipoDocIdentidad.Text = _datos.Persona.TipoDocIdentidad;
            //        FechaNac.Text = _datos.Persona.FechaNacimiento;
            //        NumeroDocumento.Text = _datos.Persona.DocIdentidad;
            //        Correo.Text = _datos.Usuario.Correo;
            //        PreSeguridad.SelectedItem.Text = _datos.Usuario.PreguntaSecreta;
            //        RespSeguridad.Text = _datos.Usuario.RespuestaSecreta;
            //        Direccion1.Text = _datos.Direccion.Nombre;
            //    }
            //}

        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Interfaz/web/IngresoRecuperacionClave/web_01_bienvenido.aspx");
        }

        protected void aceptar_Click(object sender, EventArgs e)
        {
            _presentador.aceptar_Click();

            //ClienteCM _modificar = new ClienteCM();

            //_modificar.Usuario.Correo = Correo.Text;
            //_modificar.Persona.DocIdentidad = NumeroDocumento.Text;
            //_modificar.Persona.PrimerNombre = PriNombre.Text;
            //_modificar.Persona.PrimerApellido = PriApellido.Text;
            //_modificar.Persona.SegundoNombre = SegNombre.Text;
            //_modificar.Persona.SegundoApellido = SegApellido.Text;
            //_modificar.Persona.FechaNacimiento = FechaNac.Text;
            //_modificar.Usuario.PreguntaSecreta = PreSeguridad.Text;
            //_modificar.Usuario.RespuestaSecreta = RespSeguridad.Text;
            //_modificar.Direccion.Nombre = Direccion1.Text;

            //if (string.IsNullOrEmpty(Contrasena.Text) && string.IsNullOrEmpty(RContrasena.Text))
            //{
            //    LogicaLogin _pasoParametros = new LogicaLogin();
            //    string _contrasena = _pasoParametros.obtenerContrasenaC(_modificar.Usuario.Correo);

            //    _modificar.Usuario.Contrasena = _contrasena;
            //}

            //if (!(string.IsNullOrWhiteSpace(Contrasena.Text)) && !(string.IsNullOrWhiteSpace(RContrasena.Text)))
            //{
            //    Hash hash = new Hash();
            //    string _contrasenaHash = hash.ObtenerMd5Hash(Contrasena.Text);

            //    _modificar.Usuario.Contrasena = _contrasenaHash;

            //}

            //LogicaLogin _parametros = new LogicaLogin();
            //int _direccion = _parametros.obtenerDirecionC(_modificar.Persona.DocIdentidad);
            //_modificar.Direccion.Id = _direccion;

            //LogicaLogin _info = new LogicaLogin();
            //bool _modificoInformacion = _info.modificarCliente(_modificar);
            //if (_modificoInformacion)
            //    Response.Redirect("/Interfaz/web/IngresoRecuperacionClave/web_01_bienvenido.aspx");
            //else
            //    if (_modificoInformacion == false)
            //        Response.Write("No se pudo procesar su solicitud");
        }

        public Label LabelMensajeExito
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Label LabelMensajeError
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}