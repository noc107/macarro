using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.UsuariosInternos
{
    public partial class web_09_asignarRoles : System.Web.UI.Page
    {
        string _correoS = string.Empty;
        string _docIdentidadS = string.Empty;
        string _primerNombreS = string.Empty;
        string _primerApellidoS = string.Empty;
        private string _idEmpleado = string.Empty;
        private bool _usuarioNuevo = false;
        //EmpleadoBD _operaciones = new EmpleadoBD();
        //UsuariosInternosLogica _logicaUsuarioInternos = new UsuariosInternosLogica();
        //List<Rol> _rolesAsignado;
        //List<Rol> _rolesSinAsignar;


        protected void Page_Load(object sender, EventArgs e)
        {
            //VariableSesion();
            //if ((_correoS != null) && (_docIdentidadS != null) && (Request.QueryString["id"] != null))
            //{
            //    //Obtiene el ID del empleado seleccionado
            //    _idEmpleado = Request.QueryString["id"];
            //    if (!IsPostBack)
            //    {
            //        this.cargarListas();
            //    }
            //}
            //else
            //    Server.Transfer("../IngresoRecuperacionClave/web_01_inicioSesionA.aspx", false);
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
             
        protected void cargarListas()
        {

        //    _rolesAsignado = new List<Rol>();
        //    _rolesSinAsignar = new List<Rol>();
        //    _rolesAsignado = _operaciones.ConsultarRolesEmpleadoBD(_idEmpleado);

        //    if (_rolesAsignado.Count == 0)
        //        _usuarioNuevo = true;

        //    lstboxListaAsignado.DataSource = _rolesAsignado;
        //    lstboxListaAsignado.DataTextField = "Nombre";
        //    lstboxListaAsignado.DataValueField = "Id";
        //    lstboxListaAsignado.DataBind();

        //    _rolesSinAsignar = _operaciones.ConsultarRolesDisponiblesBD(_idEmpleado);

        //    lstboxListaSinAsignar.DataSource = _rolesSinAsignar;
        //    lstboxListaSinAsignar.DataTextField = "Nombre";
        //    lstboxListaSinAsignar.DataValueField = "Id";
        //    lstboxListaSinAsignar.DataBind();
        }

        protected void agregarRolClick(object sender, ImageClickEventArgs e)
        {
        //    if (lstboxListaSinAsignar.SelectedIndex != -1)
        //    {
        //        //MensajeErrores.Visible = false;
        //        lstboxListaAsignado.Items.Add(lstboxListaSinAsignar.SelectedItem);
        //        lstboxListaSinAsignar.Items.RemoveAt(lstboxListaSinAsignar.SelectedIndex);
        //        lstboxListaSinAsignar.ClearSelection();
        //        lstboxListaAsignado.ClearSelection();
        //    }
        //    else
        //    {
        //        //MensajeErrores.Text = "Seleccione un elemento a agregar";
        //        //MensajeErrores.Visible = true;
        //    }

        }

        protected void eliminarRolClick(object sender, ImageClickEventArgs e)
        {
        //    if (lstboxListaAsignado.SelectedIndex != -1)
        //    {
        //        //MensajeErrores.Visible = false;
        //        lstboxListaSinAsignar.Items.Add(lstboxListaAsignado.SelectedItem);
        //        lstboxListaAsignado.Items.RemoveAt(lstboxListaAsignado.SelectedIndex);
        //        lstboxListaAsignado.ClearSelection();
        //        lstboxListaSinAsignar.ClearSelection();
        //    }
        //    else
        //    {
        //        //MensajeErrores.Text = "Seleccione un elemento a eliminar";
        //        //MensajeErrores.Visible = true;
        //    }
        }

        //private List<Rol> ListaRolesAsignados()
        //{
        //    _rolesAsignado = new List<Rol>();
        //    Rol rol;

        //    foreach (ListItem li in lstboxListaAsignado.Items)
        //    {
        //        rol = new Rol();
        //        rol.Id = Convert.ToInt32(li.Value);
        //        rol.Nombre = li.Text;
        //        _rolesAsignado.Add(rol);
        //    }
        //    return _rolesAsignado;
        //}

        //private List<Rol> ListaRolesSinAsignar()
        //{
        //    _rolesSinAsignar = new List<Rol>();
        //    Rol rol;

        //    foreach (ListItem li in lstboxListaSinAsignar.Items)
        //    {
        //        rol = new Rol();
        //        rol.Id = Convert.ToInt32(li.Value);
        //        rol.Nombre = li.Text;
        //        _rolesSinAsignar.Add(rol);
        //    }
        //    return _rolesSinAsignar;
        //}

        protected void aceptarClick(object sender, EventArgs e)
        {
        //    _rolesAsignado = new List<Rol>();
        //    _rolesSinAsignar = new List<Rol>();

        //    _rolesAsignado = ListaRolesAsignados();
        //    _rolesSinAsignar = ListaRolesSinAsignar();

        //    if (_rolesAsignado.Count != 0)
        //    {

        //        _logicaUsuarioInternos.AgregarListaRolesEmpleado(_idEmpleado, _rolesAsignado);
        //        _logicaUsuarioInternos.EliminarListaRolesEmpleado(_idEmpleado, _rolesSinAsignar);

        //        Response.Redirect("web_09_gestionUsuario.aspx");
        //    }
        //    //else
        //    //    Error no puede quedar sin roles
        }

        protected void cancelarClick(object sender, EventArgs e)
        {
        //    if (_usuarioNuevo)
        //        _logicaUsuarioInternos.EliminarEmpleadoNuevo(_idEmpleado);
        //    Response.Redirect("web_09_gestionUsuario.aspx");
        }
    }
}