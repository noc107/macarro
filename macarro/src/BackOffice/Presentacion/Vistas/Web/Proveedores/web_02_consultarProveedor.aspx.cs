using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.Proveedores;
using BackOffice.Presentacion.Contratos;
using BackOffice.Presentacion.Presentadores.Proveedores;

namespace BackOffice.Presentacion.Vistas.Web.Proveedores
{
    public partial class web_02_consultarProveedor : System.Web.UI.Page , IContrato_02_consultarProveedor
    {
        //ProveedorBD auxBD = new ProveedorBD();
        Presentador_02_consultarProveedor _presentador;
        public web_02_consultarProveedor() 
        {
            _presentador = new Presentador_02_consultarProveedor(this);
        }

        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Metodo por defecto / estandar , se ejecuta al cargase la pagina
        /// </summary>
        /// <param name= sender> Objeto</param>
        /// <param name= e> Argumento</param>
        /// <exception> Exception , Param = ex </exception>
         
        protected void Page_Load(object sender, EventArgs e)
        {
            _presentador.EventoBotonConsultar(Convert.ToInt32(Request.QueryString["r"]));
        }

        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Evento, cuya funcion se realiza al clickear el boton especificado
        /// Regresa al menu anterior 'Gestionar Proveedores'
        /// </summary>
        /// <param name= sender> Objeto </param>
        /// <param name= e> Argumento </param>
  
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_02_gestionarProveedores.aspx");
           // _presentador.EventoBotonConsultar();   //Este metodo debe ser invocado desde el gestionar boton consultar
        }

        Label IContrato_02_consultarProveedor.Rif
        {
            get {return Rif; }
            set { Rif = value; }
        }

        Label IContrato_02_consultarProveedor.RazonSocial
        {
            get { return RazonSocial; }
            set { RazonSocial = value; }
        }

        Label IContrato_02_consultarProveedor.Correo
        {
            get { return Correo; }
            set { Correo = value; }
        }

        Label IContrato_02_consultarProveedor.PaginaWeb
        {
            get { return PaginaWeb; }
            set { PaginaWeb = value; }
        }

        Label IContrato_02_consultarProveedor.Telefono
        {
            get { return Telefono; }
            set { Telefono = value; }
        }

        Label IContrato_02_consultarProveedor.FechaContrato
        {
            get { return FechaContrato; }
            set { FechaContrato = value; }
        }

        Label IContrato_02_consultarProveedor.Estado
        {
            get { return Estado; }
            set { Estado = value; }
        }

        //Label IContrato_02_consultarProveedor.Direccion
        //{
        //    get { return Direccion; }
        //    set { Direccion = value; }
        //}

        Label IContrato_02_consultarProveedor.Pais
        {
            get { return Pais; }
            set { Pais = value; }
        }

        //Label IContrato_02_consultarProveedor.Estado
        //{
        //    get { return Estado; }
        //    set { Estado = value; }
        //}

        //Label IContrato_02_consultarProveedor.Ciudad
        //{
        //    get { return Ciudad; }
        //    set { Ciudad = value; }
        //}

        ListBox IContrato_02_consultarProveedor.Items
        {
            get { return ListItem; }
            set { ListItem = value; }
        }

        public Label LabelMensajeExito
        {
            get { return Label23; }
            set { Label23 = value; }
        }

        public Label LabelMensajeError
        {
            get { return Label23; }
            set { Label23 = value; }
        }



        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Metodo que carga la informacion del proveedor dentro de la pagina
        /// </summary>
        /// <param name= p> Objeto de tipo proveedor, contiene todos los campos que existen para un proveedor</param>
        /// <exception> Exception, Param = e</exception>
        
        //private void CargarProveedor(Proveedor p)
        //{
        //    List<string> lugar = auxBD.ConsultarDireccionProveedorBD(p.Lugar);

        //    try
        //    {
        //        this.Rif.Text = p.Rif;
        //        this.RazonSocial.Text = p.RazonSocial;
        //        this.Correo.Text = p.Correo;
        //        this.PaginaWeb.Text = p.PaginaWeb;
        //        this.Telefono.Text = p.Telefono;
        //        this.FechaContrato.Text = p.FechaContrato.ToString();
        //        this.Pais.Text = lugar[0];
        //        this.Estado.Text = lugar[1];
        //        this.Ciudad.Text = lugar[2];
        //        this.Direccion.Text = lugar[3];                
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}

        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Metodo que carga la informacion de la lista de items dentro de la pagina
        /// </summary>
        /// <param name= Items> Lista de tipo Item con el nombre de cada Item</param>
        /// <exception> Exception , Param = e </exception>
        /// <exception> ExcepcionConsultarProveedor , Param = ex </exception>

        //private void CargarItems(List<Item> Items)
        //{   
        //    GridView1.DataSource = Items;
        //    GridView1.DataBind();
        //}

    }
}