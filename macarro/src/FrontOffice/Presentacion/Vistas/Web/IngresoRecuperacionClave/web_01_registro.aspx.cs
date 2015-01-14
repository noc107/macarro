using FrontOffice.Presentacion.Contratos.IngresoRecuperacionClave;
using FrontOffice.Presentacion.Presentadores.IngresoRecuperacionClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Vistas.Web.IngresoRecuperacionClave
{
    public partial class web_01_registro : System.Web.UI.Page , IContrato_01_registro
    {


        private Presentador_01_registro _presentador;

        public web_01_registro()
        {
            _presentador = new Presentador_01_registro(this);
    
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        TextBox IContrato_01_registro.PriNombre
        {

            get { return PriNombre;}
            set { PriNombre = value; }

        }

        TextBox IContrato_01_registro.PriApellido
        {

            get { return PriApellido; }
            set { PriApellido = value; } }

        TextBox IContrato_01_registro.SegNombre
        {
        
            get { return SegNombre;}
            set{SegNombre =value;}
        }

        TextBox IContrato_01_registro.SegApellido
        {        
             get{return SegApellido;}
             set{SegApellido=value;}
        }

        DropDownList IContrato_01_registro.TipoDocIdentidad
        {
             get{return TipoDocIdentidad;}
             set { TipoDocIdentidad = value; }
        }

        TextBox IContrato_01_registro.NumeroDocumento
        {       
             get{return NumeroDocumento;}
             set{NumeroDocumento=value;}        
        }

        TextBox IContrato_01_registro.Correo
        {       
             get{return Correo;}
             set{Correo=value;}        
        }

        TextBox IContrato_01_registro.FechaNac
        {
            get { return FechaNac; }
            set{FechaNac=value;}      
        }

        TextBox IContrato_01_registro.Contrasena
        {        
             get{return Contrasena;}
             set{Contrasena=value;}        
        }

        TextBox IContrato_01_registro.RContrasena
        {
            get { return RContrasena; }
            set { RContrasena = value; }        
        }

        TextBox IContrato_01_registro.Direccion1
        {        
             get{return Direccion1;}
             set{Direccion1=value;}        
        }

        DropDownList IContrato_01_registro.PreSeguridad
        {        
             get{return PreSeguridad;}
             set{PreSeguridad=value;}        
        }

        TextBox IContrato_01_registro.RespSeguridad
        {        
             get{return RespSeguridad;}
             set{RespSeguridad=value;}        
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
 
        protected void aceptar_Click(object sender, EventArgs e)
        {

            _presentador.aceptar_Click();

           // if (SegNombre.Text == "")
           //     SegNombre.Text = null;
           // if (SegApellido.Text == "")
           //     SegApellido.Text = null;

           //// FechaNac.Text = Convert.ToDateTime(FechaNac.Text).ToString("dd/MM/yyyy");

           // LogicaLogin _pasoParametros = new LogicaLogin();
           // bool _resp;
           // string _estaCorreo;
           // string _estaDocIdentificacion;

           // _estaCorreo = _pasoParametros.verificoCorreo(Correo.Text);
           // _estaDocIdentificacion = _pasoParametros.verificoDocIdentificacion(TipoDocIdentidad.Text, TipoDocIdentidad.Text);

           // if ((_estaCorreo != " ") && (_estaDocIdentificacion != " "))
           // {
           //     Response.Write("Lo siento ya hay un cliente registrado con el mismo Doc de Identificación y/o Correo");
           // }
           // else
           // {
           //     _resp = _pasoParametros.registroCliente(Direccion1.Text, NumeroDocumento.Text, TipoDocIdentidad.Text, PriNombre.Text,
           //         SegNombre.Text, PriApellido.Text, SegApellido.Text, FechaNac.Text, Correo.Text, Contrasena.Text, PreSeguridad.Text,
           //         RespSeguridad.Text);

           //     if (_resp == true)
           //     {
           //         //   Response.Write("Se ha registrado con éxito");
           //         Response.Redirect("/Interfaz/web/IngresoRecuperacionClave/web_01_bienvenido.aspx");
           //     }
           //     else
           //         Response.Write("No se pudo procesar su solicitud");
           // }
        }

    }
}