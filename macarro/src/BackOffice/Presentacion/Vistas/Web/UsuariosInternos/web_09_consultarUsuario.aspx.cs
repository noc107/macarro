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
    public partial class web_09_consultarUsuario : System.Web.UI.Page, IContrato_09_ConsultarUsuarios
    {
        private Presentador_09_ConsultarUsuarios _presentador;

        public web_09_consultarUsuario() 
        {
            _presentador = new Presentador_09_ConsultarUsuarios(this);
        }

        #region Get y Set del Contrato ConsultarUsuario

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

        Label IContrato_09_ConsultarUsuarios.Nombre
        {
            get { return LabelNombreCons; }
            set { LabelNombreCons = value; }
        }

        Label IContrato_09_ConsultarUsuarios.SegundoNombre
        {
            get { return LabelSegNombreCons; }
            set { LabelSegNombreCons = value; }
        }

        Label IContrato_09_ConsultarUsuarios.Apellido
        {
            get { return LabelApellidoCons; }
            set { LabelApellidoCons = value; }
        }

        Label IContrato_09_ConsultarUsuarios.SegundoApellido
        {
            get { return LabelSegApellidoCons; }
            set { LabelSegApellidoCons = value; }
        }

        Label IContrato_09_ConsultarUsuarios.TipoDocumento
        {
            get { return LabelCedulaTipoCons; }
            set { LabelCedulaTipoCons = value; }
        }

        Label IContrato_09_ConsultarUsuarios.Cedula
        {
            get { return LabelCedulaCons; }
            set { LabelCedulaCons = value; }
        }

        Label IContrato_09_ConsultarUsuarios.FechaNacimiento
        {
            get { return LabelFechaNacCons; }
            set { LabelFechaNacCons = value; }
        }

        Label IContrato_09_ConsultarUsuarios.Estatus
        {
            get { return LabelEstatusCons; }
            set { LabelEstatusCons = value; }
        }

        Label IContrato_09_ConsultarUsuarios.Telefono
        {
            get { return LabelTelefonoCons; }
            set { LabelTelefonoCons = value; }
        }

        Label IContrato_09_ConsultarUsuarios.Correo
        {
            get { return LabelCorreoCons; }
            set { LabelCorreoCons = value; }
        }

        Label IContrato_09_ConsultarUsuarios.FechaIngreso
        {
            get { return LabelFechaIngCons; }
            set { LabelFechaIngCons = value; }
        }

        Label IContrato_09_ConsultarUsuarios.FechaEgreso
        {
            get { return LabelFechaEgreCons; }
            set { LabelFechaEgreCons = value; }
        }

        Label IContrato_09_ConsultarUsuarios.Direccion
        {
            get { return LabelDireccionCons; }
            set { LabelDireccionCons = value; }
        }

        ListBox IContrato_09_ConsultarUsuarios.ListaCargos 
        {
            get { return list_cargos; }
            set { list_cargos = value; }
        }

        #endregion

        #region Código Anterior Usuarios Internos
        string _correoS = string.Empty;
        string _docIdentidadS = string.Empty;
        string _primerNombreS = string.Empty;
        string _primerApellidoS = string.Empty;

        private String _id;
        private String _noTiene = " ";
        //Empleado _empleado = new Empleado();
        //UsuariosInternosLogica _logicaUsuario = new UsuariosInternosLogica();
        //List<Rol> _rolesAsignado;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //VariableSesion(); 
            //if ((_correoS != null) && (_docIdentidadS != null) && (Request.QueryString["id"] != null))
            //{
            //    ///Obtiene el ID del empleado seleccionado
            //    _id = Request.QueryString["id"];
            //    try
            //    {
            //        _empleado = _logicaUsuario.EmpleadoUnico(_id);
            //    }
            //    catch (ExcepcionUsuariosInternosDatos ex)
            //    {
            //        this.mensajeError.Text = RecursosExcepcionesUsuariosInternos.mensajeDatos + "Error: " + ex.Message.ToString();
            //    }
            //    catch (ExcepcionUsuariosInternosLogica ex)
            //    {
            //        this.mensajeError.Text = RecursosExcepcionesUsuariosInternos.mensajeDatos + "Error: " + ex.Message.ToString();
            //    }

            //    if (_empleado != null)
            //    {
            //        LabelNombreCons.Text = _empleado.Persona.PrimerNombre;

            //        if (_empleado.Persona.SegundoNombre.ToString() == "")
            //            LabelSegNombreCons.Text = _noTiene;
            //        else
            //            LabelSegNombreCons.Text = _empleado.Persona.SegundoNombre;

            //        LabelApellidoCons.Text = _empleado.Persona.PrimerApellido;

            //        if (_empleado.Persona.SegundoApellido.ToString() == "")
            //            LabelSegApellidoCons.Text = _noTiene;
            //        else
            //            LabelSegApellidoCons.Text = _empleado.Persona.SegundoApellido;

            //        LabelCedulaTipoCons.Text = _empleado.Persona.TipoDocIdentidad;
            //        LabelCedulaCons.Text = _empleado.Persona.DocIdentidad;
            //        LabelFechaNacCons.Text = _empleado.Persona.FechaNacimiento.ToString("dd/MM/yyyy");
            //        LabelEstatusCons.Text = _empleado.Usuario.EstatusUsuario;
            //        LabelFechaIngCons.Text = _empleado.Usuario.FechaIngreso.ToString("dd/MM/yyyy");
            //        LabelCorreoCons.Text = _empleado.Usuario.Correo;
            //        if (_empleado.Usuario.FechaEgreso.ToString("dd/MM/yyyy") == "01/01/2000")
            //            LabelFechaEgreCons.Text = _noTiene;
            //        else
            //            LabelFechaEgreCons.Text = _empleado.Usuario.FechaEgreso.ToString("dd/MM/yyyy");

            //        try
            //        {
            //            LabelDireccionCons.Text = _logicaUsuario.ObtenerDireccionConcatenada(_empleado.Persona.FkLugar); 
                        
            //            _rolesAsignado = _logicaUsuario.ConsultarRolesEmpleado(_empleado);
            //            list_cargos.DataSource = _rolesAsignado;
            //            list_cargos.DataTextField = "Nombre";
            //            list_cargos.DataValueField = "Id";
            //            list_cargos.DataBind();
            //        }
            //        catch (ExcepcionUsuariosInternosDatos ex)
            //        {
            //                this.mensajeError.Text = RecursosExcepcionesUsuariosInternos.mensajeDatos + "Error: " + ex.Message.ToString();
            //        }
            //        catch (ExcepcionUsuariosInternosLogica ex)
            //        {
            //            this.mensajeError.Text = RecursosExcepcionesUsuariosInternos.mensajeDatos + "Error: " + ex.Message.ToString();
            //         }

            //    }
            //    else
            //    {
            //       //no hay datos mensaje excepción lógica
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

        protected void volver_consultar(object sender, EventArgs e)
        {
            Response.Redirect("web_09_gestionUsuario.aspx");
        }
        #endregion
    }
}