using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.RolesSeguridad;
using BackOffice.Presentacion.Presentadores.RolesSeguridad;


namespace BackOffice.Presentacion.Vistas.Temp
{
    public partial class back_office_temp : System.Web.UI.MasterPage, IContrato_08_Master
    {
        #region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        Menu _menuAux;
        List<string> _acciones;
        List<string> _urls;
        #endregion

        Label _mensajeExito;
        Label _mensajeError;

        private Presentador_08_Master _presentador;

        /// <summary>
        /// Constructor de la interfaz e inicializacion del presentador
        /// </summary>
        public back_office_temp()
        {
            _presentador = new Presentador_08_Master(this);
        }


        /// <summary>
        /// Implementacion del metodo menuMaster
        /// </summary>
        public Menu menuMaster
        {
            get { return menuBar; }
            set { menuBar = value; }
        } 

        
        /// <summary>
        /// Implementacion del metodo LabelMensajeExito
        /// </summary>
        public Label LabelMensajeExito
        {
            get { return _mensajeExito; }
            set { _mensajeExito = value; }
        }


        /// <summary>
        /// Implementacion del metodo LabelMensajeError
        /// </summary>
        public Label LabelMensajeError
        {
            get { return _mensajeError; }
            set { _mensajeError = value; }
        }

        /// <summary>
        /// Metodo que inicia al cargar la interfaz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {                 
            if (Session["correo"] != null)
            {
                variableSesion();  
                if (!IsPostBack)
                {
                    _presentador.ConstruirMenu(_menuAux);
                    
                }
            }
            //if (Session["correo"] == null)
            //{
            //    Response.Redirect("/Presentacion/Vistas/Web/inicio.aspx");
            //}
            //else
            //{ 
            //    variableSesion();
            //    if (_urls.Contains(Request.Url.AbsolutePath))
            //    {                
            //        if (!IsPostBack)
            //        {
            //            _presentador.ConstruirMenu(_menuAux);
            //        }
            //    }
            //    else
            //    {
            //        Response.Redirect("/Presentacion/Vistas/Web/inicio.aspx");
            //    }
            //}

        }

        /// <summary>
        /// Metodo para cargar las variables de sesion
        /// </summary>
        private void variableSesion()
        {
            _correoS = (string)(Session["correo"]);
            _docIdentidadS = (string)(Session["docIdentidad"]);
            _primerNombreS = (string)(Session["primerNombre"]);
            _primerApellidoS = (string)(Session["primerApellido"]);
            _menuAux = (Menu)(Session["menu"]);
            _acciones = (List<string>)(Session["acciones"]);
            _urls = (List<string>)(Session["urls"]);
        }

        /// <summary>
        /// Metodo para cerrar la sesion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Cerrar_Sesion(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/Presentacion/Vistas/Web/IngresoRecuperacionClave/web_01_inicioSesionA.aspx");
        }

        /// <summary>
        /// Metodo para ver el perfil del usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Perfil(object sender, EventArgs e)
        {
            Response.Redirect("/Presentacion/Vistas/Web/UsuariosInternos/web_09_perfil_usuario.aspx");
        }


       
    }
}