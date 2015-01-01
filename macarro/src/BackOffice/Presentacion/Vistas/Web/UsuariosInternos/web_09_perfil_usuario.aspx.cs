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
    public partial class web_09_perfil_usuario : System.Web.UI.Page, IContrato_09_PerfilUsuario
    {
        private Presentador_09_PerfilUsuario _presentador;

        public web_09_perfil_usuario() 
        {
            this._presentador = new Presentador_09_PerfilUsuario(this);
        }


        #region Get y Set del Contrato PerfilUsuario


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
       

        TextBox IContrato_09_PerfilUsuario.Nombre
        {
            get { return TextBoxNombre; }
            set { TextBoxNombre = value; }
        }

        

        TextBox IContrato_09_PerfilUsuario.SegundoNombre
        {
            get { return TextBoxSegNombre; }
            set { TextBoxSegNombre = value; }
        }

       

        TextBox IContrato_09_PerfilUsuario.Apellido
        {
            get { return TextBoxApellido; }
            set { TextBoxApellido = value; }
        }

        

        TextBox IContrato_09_PerfilUsuario.SegundoApellido
        {
            get { return TextBoxSegApellido; }
            set { TextBoxSegApellido = value; }
        }

        

        TextBox IContrato_09_PerfilUsuario.Cedula
        {
            get { return TextBoxCedula; }
            set { TextBoxCedula = value; }
        }

        

        TextBox IContrato_09_PerfilUsuario.Correo
        {
            get { return TextBoxCorreo; }
            set { TextBoxCorreo = value; }
        }

       
        TextBox IContrato_09_PerfilUsuario.NuevaContrasena
        {
            get { return TextBoxContra; }
            set { TextBoxContra = value; }
        }



        TextBox IContrato_09_PerfilUsuario.VerificarContrasena
        {
            get { return TextBoxVerfContr; }
            set { TextBoxVerfContr = value; }
        }

        
        TextBox IContrato_09_PerfilUsuario.FechaNacimiento
        {
            get { return TextBoxFechaNac; }
            set { TextBoxFechaNac = value; }
        }
            
        
        DropDownList IContrato_09_PerfilUsuario.Pais
        {
            get { return DropDownListPais; }
            set { DropDownListPais = value; }
        }

        
        TextBox IContrato_09_PerfilUsuario.Direccion
        {
            get { return TextBoxDireccion; }
            set { TextBoxDireccion = value; }
        }

       

        DropDownList IContrato_09_PerfilUsuario.Estado
        {
            get { return DropDownListEstado; }
            set { DropDownListEstado = value; }
        }

        
        DropDownList IContrato_09_PerfilUsuario.Ciudad
        {
            get { return DropDownListCiudad; }
            set { DropDownListCiudad = value; }
        }


        TextBox IContrato_09_PerfilUsuario.Telefono
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        #endregion

        # region Codigo Anterior Usuarios Internos
        string _correoS = string.Empty;
        string _docIdentidadS = string.Empty;
        string _primerNombreS = string.Empty;
        string _primerApellidoS = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
          /*  VariableSesion();
            if ((_correoS != null) && (_docIdentidadS != null))
            {
            }
            else
                Server.Transfer("../IngresoRecuperacionClave/web_01_inicioSesionA.aspx", false);*/
            _presentador.PageLoad(); 
        }
/*
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
        } */

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_09_perfilUsuario.aspx"); 
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            validatorfechanac.MinimumValue = DateTime.Now.AddYears(-65).ToString("dd/MM/yyyy");
            validatorfechanac.MaximumValue = DateTime.Now.AddYears(-18).ToString("dd/MM/yyyy");
        }
        #endregion

    }
}