using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.UsuariosInternos;
using BackOffice.Presentacion.Presentadores.UsuariosInternos;

namespace BackOffice.Presentacion.Vistas.Web.UsuariosInternos
{
    public partial class web_09_gestionUsuario : System.Web.UI.Page, IContrato_09_gestionUsuario
    {

        private Presentador_09_gestionUsuario _presentador;

        public web_09_gestionUsuario() 
        {
            _presentador = new Presentador_09_gestionUsuario(this);
        }

        # region Implementación get y set de los atributos del contrato Gestión  Usuario

        TextBox IContrato_09_gestionUsuario.BusquedaUsuario 
        {
            get { return textBoxBuscar; }
            set { textBoxBuscar = value; }
        }

        GridView IContrato_09_gestionUsuario.TablaDatosUsuarios 
        {
            get { return GridViewUsuario; }
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

        //UsuariosInternosLogica _logicaUsuario = new UsuariosInternosLogica();
        //List<Empleado> _listaEmpleado = new List<Empleado>();

protected void Page_Load(object sender, EventArgs e)
        {
            //VariableSesion();
            //if ((_correoS != null) && (_docIdentidadS != null))
            //{
            //    string _campoBusqueda = textBoxBuscar.Text.ToString();
            //    string _estadoBusqueda = DropDownList1.SelectedItem.ToString();
            //    if (_campoBusqueda != "" || _estadoBusqueda != "Estatus")
            //    {
            //        LimpiarGridView();
            //        KeySearchEmpleado(_campoBusqueda, _estadoBusqueda);

            //    }
            //    ///// Si no carga todos los empleados de la BD
            //    else
            //    {
            //        _listaEmpleado = _logicaUsuario.ListaEmpleados();
            //        this.GridViewUsuario.DataSource = _listaEmpleado;
            //        this.GridViewUsuario.DataBind();

            //    }
            //}
            //else
            //    Server.Transfer("../IngresoRecuperacionClave/web_01_inicioSesionA.aspx", false);
            _presentador.PageLoad(); 
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

        protected void GV_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        ImageButton consultar = new ImageButton();
        //        consultar.ID = "bConsultar";
        //        consultar.ImageUrl = "../../../comun/resources/img/View-128.png";
        //        consultar.Height = 50;
        //        consultar.Width = 50;
        //        consultar.Click += new ImageClickEventHandler(this.consultarBtn_Click);

        //        ImageButton editar = new ImageButton();
        //        editar.ID = "bEditar";
        //        editar.ImageUrl = "../../../comun/resources/img/Data-Edit-128.png";
        //        editar.Height = 50;
        //        editar.Width = 50;
        //        editar.Click += new ImageClickEventHandler(this.editarBtn_Click);

        //        ImageButton eliminar = new ImageButton();
        //        eliminar.ID = "bEliminar";
        //        eliminar.ImageUrl = "../../../comun/resources/img/Garbage-Closed-128.png";
        //        eliminar.Height = 50;
        //        eliminar.Width = 50;
        //        eliminar.Click += new ImageClickEventHandler(this.eliminarBtn_Click);

        //        e.Row.Cells[2].Controls.Add(consultar);
        //        e.Row.Cells[2].Controls.Add(editar);
        //        e.Row.Cells[2].Controls.Add(eliminar);
                
        //    }
            
        }

        void consultarBtn_Click(Object sender, ImageClickEventArgs e)
        {
        //    ImageButton img = (ImageButton)sender;
        //    GridViewRow row = (GridViewRow)img.Parent.Parent;
        //    Empleado emp = _listaEmpleado[row.RowIndex];
        //    String id = emp.Persona.DocIdentidad.ToString();
        //    Response.Redirect("web_09_consultarUsuario.aspx?id=" + id);
           
        }


        void editarBtn_Click(Object sender, ImageClickEventArgs e)
        {
        //    ImageButton img = (ImageButton)sender;
        //    GridViewRow row = (GridViewRow)img.Parent.Parent;
            
        //    Empleado emp = _listaEmpleado[row.RowIndex];
            
        //    String id = emp.Persona.DocIdentidad.ToString();
        //    Response.Redirect("web_09_modificarUsuario.aspx?id=" + id);
        //    //Response.Redirect("web_09_modificarUsuario.aspx");
        }

        void eliminarBtn_Click(Object sender, ImageClickEventArgs e)
        {

        //    if (ControlRolAccion.listaAcciones(_correoS).Contains("Eliminar usuario interno"))
        //    {
        //        ImageButton img = (ImageButton)sender;
        //        GridViewRow row = (GridViewRow)img.Parent.Parent;
        //        Empleado emp = _listaEmpleado[row.RowIndex];

        //        _logicaUsuario.ModificarEstadoEmpleado(emp);
        //        Response.Redirect("../inicio.aspx");
        //    }
        //    else
        //    {
        //        mensajeError.Text = "No posee los perminsos para eliminar el ítem";
        //        mensajeError.Visible = true;
        //    }

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
        //    String _campoBusqueda = textBoxBuscar.Text.ToString();
        //    String _estadoBusqueda = DropDownList1.SelectedItem.ToString();
        //    try
        //    {
        //        _listaEmpleado = _logicaUsuario.ListaEmpleadosSearch(_campoBusqueda, _estadoBusqueda);
        //        this.GridViewUsuario.DataSource = _listaEmpleado;
        //        this.GridViewUsuario.DataBind();
        //    }
        //    catch (ExcepcionUsuariosInternosDatos ex)
        //    {
        //        this.mensajeError.Text = RecursosExcepcionesUsuariosInternos.mensajeDatos + "Error: " + ex.Message;
        //        this.mensajeError.Visible = true;

        //    }
        //    catch (ExcepcionUsuariosInternosLogica ex)
        //    {
        //        this.mensajeError.Text = RecursosExcepcionesUsuariosInternos.mensajeLogica + "Error: " + ex.Message;
        //        this.mensajeError.Visible = true;
        //    }

        }

        //public void KeySearchEmpleado(string _campoBusqueda, string _estadoBusqueda)
        //{

        //    if (_logicaUsuario.ListaEmpleadosSearch(_campoBusqueda, _estadoBusqueda).Count == 0)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No hay Empleados que Coincidan con la busqueda')", true);
        //        LimpiarGridView();
        //    }
        //    else
        //    {
        //        try
        //        {
        //            _listaEmpleado = _logicaUsuario.ListaEmpleadosSearch(_campoBusqueda, _estadoBusqueda);
        //            this.GridViewUsuario.DataSource = _listaEmpleado;
        //            this.GridViewUsuario.DataBind();
        //        }
        //        catch (ExcepcionUsuariosInternosDatos ex)
        //        {
        //            this.mensajeError.Text = RecursosExcepcionesUsuariosInternos.mensajeDatos + "Error: " + ex.Message;
        //            this.mensajeError.Visible = true;

        //        }
        //        catch (ExcepcionUsuariosInternosLogica ex)
        //        {
        //            this.mensajeError.Text = RecursosExcepcionesUsuariosInternos.mensajeLogica + "Error: " + ex.Message;
        //            this.mensajeError.Visible = true;
        //        }
        //    }
        //}

        //private void LimpiarGridView()
        //{

        //    this.GridViewUsuario.DataSource = null;
        //    GridViewUsuario.DataBind();

        //}

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
        //    String _campoBusqueda = textBoxBuscar.Text.ToString();
        //    String _estadoBusqueda = DropDownList1.SelectedItem.ToString();
        //    _listaEmpleado = _logicaUsuario.ListaEmpleadosSearch(_campoBusqueda, _estadoBusqueda);
        //    this.GridViewUsuario.DataSource = _listaEmpleado;
        //    this.GridViewUsuario.DataBind();
        }

        protected void ButtonBuscar_Click1(object sender, EventArgs e)
        {

        }

        protected void GridViewUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        //    GridViewUsuario.PageIndex = e.NewPageIndex;
        //    LlenarGridView();

        }


        //public void LlenarGridView()
        //{
        //    _listaEmpleado = _logicaUsuario.ListaEmpleados();
        //    this.GridViewUsuario.DataSource = _listaEmpleado;
        //    this.GridViewUsuario.DataBind();
        //}

        protected void GridViewUsuario_PageIndexChanged(object sender, EventArgs e)
        {
        //    LimpiarGridView();
        //    LlenarGridView();
        }
        #endregion

    }
}

