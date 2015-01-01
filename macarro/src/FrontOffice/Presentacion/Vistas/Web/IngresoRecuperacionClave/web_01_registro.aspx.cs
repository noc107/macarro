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

        string IContrato_01_registro.PriNombre {

            get { return PriNombre.Text;}
            set { PriNombre.Text = value; }

        }

        string IContrato_01_registro.PriApellido {

            get { return PriApellido.Text; }
            set { PriApellido.Text = value; } }

        string IContrato_01_registro.SegNombre {
        
             get { return SegNombre.Text;}
            set{SegNombre.Text =value;}
        }



        string IContrato_01_registro.SegApellido{
        
               get{return SegApellido.Text;}
             set{SegApellido.Text=value;}
        
        }

        
        string IContrato_01_registro.TipoDocIdentidad{
        
               get{return TipoDocIdentidad.Text;}
        
        }


        string IContrato_01_registro.NumeroDocumento{
        
               get{return NumeroDocumento.Text;}
             set{NumeroDocumento.Text=value;}
        
        }


     
        string IContrato_01_registro.Correo{
        
               get{return Correo.Text;}
             set{Correo.Text=value;}
        
        }


        
        DateTime IContrato_01_registro.FechaNac{

            get { return Convert.ToDateTime(FechaNac.Text); }
            set{FechaNac.Text=value.ToShortDateString();}
        
        }


         
        string IContrato_01_registro.Contrasena{
        
             get{return Contrasena.Text;}
             set{Contrasena.Text=value;}
        
        }


        
         
        string IContrato_01_registro.Direccion1{
        
             get{return Direccion1.Text;}
             set{Direccion1.Text=value;}
        
        }


         
        string IContrato_01_registro.PreSeguridad{
        
             get{return PreSeguridad.Text;}
             set{PreSeguridad.Text=value;}
        
        }


        
        string IContrato_01_registro.RespSeguridad{
        
             get{return RespSeguridad.Text;}
             set{RespSeguridad.Text=value;}
        
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