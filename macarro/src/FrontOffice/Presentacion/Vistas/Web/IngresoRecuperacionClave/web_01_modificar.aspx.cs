using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FrontOffice.Presentacion.Vistas.Web.IngresoRecuperacionClave
{
    public partial class web_01_modificar : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
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
    }
}