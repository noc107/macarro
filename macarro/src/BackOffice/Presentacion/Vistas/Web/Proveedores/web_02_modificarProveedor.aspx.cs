using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BackOffice.Presentacion.Contratos;
using BackOffice.Presentacion.Contratos.Proveedores;
using BackOffice.Presentacion.Presentadores.Proveedores;

namespace BackOffice.Presentacion.Vistas.Web.Proveedores
{
    public partial class web_02_modificarProveedor : System.Web.UI.Page , IContratoGeneral , IContrato_02_modificarProveedor
    {
        //LogicaProveedor _auxLogica = new LogicaProveedor();
        //ProveedorBD auxDatos = new ProveedorBD();
        Presentador_02_modificarProveedor _presentador;

        public web_02_modificarProveedor() 
        {
            _presentador = new Presentador_02_modificarProveedor(this);
        }

        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Metodo por defecto / estandar , se ejecuta al cargase la pagina.
        /// Inicializa el Mensaje y llena el GridView con los items del proveedor.
        /// </summary>
        /// <param name= sender> Objeto</param>
        /// <param name= e> Argumento</param>
        /// 
        protected void Page_Load(object sender, EventArgs e)
        {
            //_auxLogica.InicializarMensaje(Mensaje);
            //LlenarGridViewItems(GridItems);
        }

        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Evento, redirecciona la pagina, vuelve al menu
        /// </summary>
        /// <param name= sender> Objeto </param>
        /// <param name= e> Argumento </param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_02_gestionarProveedores.aspx");
        }

        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Evento, al hacer click en boton de imagen, Toma los valores del GridView para Agregar
        /// </summary>
        /// <param name= sender> Objeto </param>
        /// <param name= e> Argumento </param>

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //TomarValoresGridviewAgregar();
        }

        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Evento, al hacer click en boton de imagen, Toma los valores del GridView para Eliminar
        /// </summary>
        /// <param name= sender> Objeto </param>
        /// <param name= e> Argumento </param>
        /// 
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
           //Eliminar items seleccionados de la lista de items del proveedor
           //TomarValoresGridviewEliminar();
           //Mensaje de aviso
        }

        TextBox IContrato_02_modificarProveedor.Rif
        {
            get { return Rif; }
            set { Rif = value; }
        }

        TextBox IContrato_02_modificarProveedor.RazonSocial
        {
            get { return RazonSocial; }
            set { RazonSocial = value; }
        }

        TextBox IContrato_02_modificarProveedor.Correo
        {
            get { return Correo; }
            set { Correo = value; }
        }

        TextBox IContrato_02_modificarProveedor.PaginaWeb
        {
            get { return PaginaWeb; }
            set { PaginaWeb = value; }
        }

        TextBox IContrato_02_modificarProveedor.Telefono
        {
            get { return Telefono; }
            set { Telefono = value; }
        }

        TextBox IContrato_02_modificarProveedor.FechaContrato
        {
            get { return FechaContrato; }
            set { FechaContrato = value; }
        }

        TextBox IContrato_02_modificarProveedor.Direccion
        {
            get { return Direccion; }
            set { Direccion = value; }
        }

        DropDownList IContrato_02_modificarProveedor.Pais
        {
            get { return Pais; }
            set { Pais = value; }
        }

        DropDownList IContrato_02_modificarProveedor.Estado
        {
            get { return Estado; }
            set { Estado = value; }
        }

        DropDownList IContrato_02_modificarProveedor.Ciudad
        {
            get { return Ciudad; }
            set { Ciudad = value; }
        }

        GridView IContrato_02_modificarProveedor.Items
        {
            get { return GridItems; }
            set { GridItems = value; }
        }

        public Label LabelMensajeExito
        {
            get { return Mensaje; }
            set { Mensaje = value; }
        }

        public Label LabelMensajeError
        {
            get { return Mensaje; }
            set { Mensaje = value; }
        }
        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Metodo que se encarga de tomar los valores escritos dentro del textbox para asignarselos al proveedor
        /// </summary>
        /// <returns> True or False de acuerdo a si se tomo o no correctamente el / los valores</returns>
        //private bool TomarValoresTexbox()
        //{
        //    string rif = this.Rif.Text;
        //    string razonSocial = this.RazonSocial.Text;
        //    string correo = this.Correo.Text;
        //    string paginaWeb = this.PaginaWeb.Text;
        //    string telefono = this.Telefono.Text;
        //    DateTime fechaContrato = Convert.ToDateTime(this.FechaContrato.Text);

        //    Proveedor prov = _auxLogica.CrearProveedor(rif, razonSocial, correo, paginaWeb, telefono, fechaContrato);

        //    TomarValoresGridviewAgregar(prov);

        //    auxDatos.agregarProveedorBD(prov);

        //    return true;
        //}



        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Metodo que se encarga de tomar los valores de la BD de los items y cargarlos en el GridView
        /// </summary>
        /// <param name= g> GridView donde se cargan los valores </param>

        //public void LlenarGridViewItems(GridView g)
        //{
        //    DataTable t = auxDatos.consultarItemsBD();
        //    g.DataSource = t;
        //    g.DataBind();

        //}

        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Metodo que toma los valores del GridView y los agrega a su respectivo proveedor
        /// </summary>
        /// <param name= p> Objeto de tipo proveedor al que se le agregaran sus items </param>
        
        //private void TomarValoresGridviewAgregar(Proveedor p)
        //{
        //    //Agregar items seleccionados a la lista de items del proveedor
        //    foreach (GridViewRow row in GridItems.Rows)
        //    {
        //        if (row.RowType == DataControlRowType.DataRow)
        //        {
        //            CheckBox aux = (row.Cells[1].FindControl("aux") as CheckBox);
        //            if (aux.Checked)
        //            {
        //                //Agregar a la lista de items del proveedor
        //                string x = row.Cells[0].Text;
        //                int i = Convert.ToInt16(x);
        //                _auxLogica.AgregarItemLista(p, i);

        //            }
        //        }
        //    }
        //}// Fin de TomarValoresGridviewAgregar

        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Metodo que toma los valores del GridView y los elimina de la lista de items de un proveedor
        /// </summary>

        //private void TomarValoresGridviewEliminar()
        //{
        //    //Eliminar items seleccionados de la lista de items del proveedor
        //    foreach (GridViewRow row in GridItems.Rows)
        //    {
        //        if (row.RowType == DataControlRowType.DataRow)
        //        {
        //            CheckBox aux = (row.Cells[1].FindControl("aux") as CheckBox);
        //            if (aux.Checked)
        //            {
        //                //Verificar si existe en la lista de items del provedor

        //                //Eliminar de la lista de items del proveedor
        //            }
        //        }

        //    }
        //}// Fin de TomarValoresGridviewEliminar

        

        

    }
}