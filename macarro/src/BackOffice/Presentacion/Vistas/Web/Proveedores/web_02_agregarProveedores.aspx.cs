using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BackOffice.Presentacion.Contratos.Proveedores;
using BackOffice.Presentacion.Contratos;
using BackOffice.Presentacion.Presentadores.Proveedores;

namespace BackOffice.Presentacion.Vistas.Web.Proveedores
{
    public partial class web_02_agregarProveedores : System.Web.UI.Page, IContrato_02_agregarProveedores
    {
        //LogicaProveedor _auxLogica = new LogicaProveedor();
        //ProveedorBD auxDatos = new ProveedorBD();
        Presentador_02_agregarProveedores _presentador;
        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Metodo por defecto / estandar , se ejecuta al cargase la pagina
        /// </summary>
        /// <param name= sender> Objeto</param>
        /// <param name= e> Argumento</param>
        public web_02_agregarProveedores() 
        {
            _presentador = new Presentador_02_agregarProveedores(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //_auxLogica.InicializarMensaje(Mensaje);
            //LlenarGridViewItems(GridItems);
            //LlenarDropDownList(_Pais);
        }

        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Evento, le da funcionalidad al boton de regresar al hacer un click en el mismo
        /// </summary>
        /// <param name= sender> Objeto </param>
        /// <param name= e> Argumento </param>

        protected void Regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_02_gestionarProveedores.aspx");
        }
        /*
        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Metodo que llena el GridView de Proveedores.
        /// </summary>
        /// <param name= sender> Objeto</param>
        /// <param name= e> Argumento</param>
        /// 
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridItems.PageIndex = e.NewPageIndex;
            LlenarGridViewItems(GridItems);

        }
        */
        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Evento, le da funcionalidad al boton de aceptar al hacer un click en el mismo
        /// </summary>
        /// <param name= sender> Objeto </param>
        /// <param name= e> Argumento </param>
        /// 
        protected void Aceptar_Click(object sender, EventArgs e)
        {
        //    //Tomar valores de los textbox para asignarselos al proveedor
        //    if (TomarValoresTexbox())
        //    {
        //        _auxLogica.MensajeExitoAgregar(Mensaje);
        //    }
        }

        TextBox IContrato_02_agregarProveedores.Rif
        {
            get { return Rif; }
        }

        TextBox IContrato_02_agregarProveedores.RazonSocial 
        {
            get { return RazonSocial; }
        }

        TextBox IContrato_02_agregarProveedores.Correo 
        {
            get { return Correo; }
        }

        TextBox IContrato_02_agregarProveedores.PaginaWeb 
        {
            get { return PaginaWeb; }
        }

        TextBox IContrato_02_agregarProveedores.Telefono 
        {
            get { return Telefono; }
        }

        TextBox IContrato_02_agregarProveedores.FechaContrato 
        {
            get { return FechaContrato; }
        }

        TextBox IContrato_02_agregarProveedores.Direccion 
        {
            get { return Direccion; }
        }

        DropDownList IContrato_02_agregarProveedores.Pais 
        {
            get { return _Pais; }
        }

        DropDownList IContrato_02_agregarProveedores.Estado 
        {
            get { return _Estado; }
        }

        DropDownList IContrato_02_agregarProveedores.Ciudad 
        {
            get { return _Ciudad; }
        }

        GridView IContrato_02_agregarProveedores.Items 
        {
            get { return GridItems; }
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
        /// <exception> Exception , Param = e </exception>
        /// <exception> ExcepcionAgregarProveedor</exception>
        /// <returns> True or False de acuerdo a si se tomo o no correctamente el / los valores</returns>

        //private bool TomarValoresTexbox()
        //{
        //    string rif = this.Rif.Text;
        //    string razonSocial = this.RazonSocial.Text;
        //    string correo = this.Correo.Text;
        //    string paginaWeb = this.PaginaWeb.Text;
        //    string telefono = this.Telefono.Text;
        //    DateTime fechaContrato = Convert.ToDateTime(this.FechaContrato.Text);
        //    try
        //    {
        //        Proveedor prov = _auxLogica.CrearProveedor(rif, razonSocial, correo, paginaWeb, telefono, fechaContrato);

        //        //TomarValoresGridviewAgregar(prov);

        //        auxDatos.agregarProveedorBD(prov);

        //        return true;

        //    }
        //    catch (ExcepcionAgregarProveedor)
        //    {
        //        Mensaje.Text = "El ítem no ha podido ser creado debido a que existe una condición de fracaso";
        //        Mensaje.Attributes["style"] = "color:red; font-weight:bold;";
        //        Mensaje.Visible = true;
                
        //        return false;
        //    }
        //    catch (Exception e)
        //    {
        //        Mensaje.Text = "El ítem no ha podido ser creado debido a que existe una condición de fracaso";
        //        Mensaje.Attributes["style"] = "color:red; font-weight:bold;";
        //        Mensaje.Visible = true;
        //        return false;
        //        throw e;
        //    }
        //}

        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Metodo que se encarga de tomar los valores dentro del GridView para asignarselos al proveedor
        /// Toma los items que estan marcados dentro de la lista y se los asigna al proveedor
        /// </summary>
        /// <param name= p> Objeto de tipo proveedor a quien se le asignan los items </param>
        /*
        private void TomarValoresGridviewAgregar(Proveedor p)
        {
            //Agregar items seleccionados a la lista de items del proveedor
            foreach (GridViewRow row in GridItems.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox aux = (row.Cells[2].FindControl("aux") as CheckBox);
                    if (aux.Checked)
                    {
                        //Agregar a la lista de items del proveedor
                        string x = row.Cells[0].Text;
                        int i = Convert.ToInt16(x);
                        _auxLogica.AgregarItemLista(p, i);

                    }
                }
            }
        }// Fin de TomarValoresGridviewAgregar
   
        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Metodo que se encarga de tomar los valores de la BD de los items y cargarlos en el GridView
        /// </summary>
        /// <param name= g> GridView donde se carga la informacion de los items </param>

        public void LlenarGridViewItems(GridView g)
        {
            DataTable t = auxDatos.consultarItemsBD();
            g.DataSource = t;
            g.DataBind();

        }*/
        /*
        public void LlenarDropDownList(DropDownList d)
        {
            // Hace el enlace al DataTable contenido en el DataSet
            d.DataSource = auxDatos.consultarPaisesBD();
            // Hace el enlace del campo au_id para el valor
            d.DataValueField = "idLugar";
           // Hace el enlace del campo au_fname para el texto
            d.DataTextField = "nombreLugar";
        //    // Llena el DropDownList con los datos de la fuente de datos
            d.DataBind();
        }
        
        protected void _Pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDropDownListEstados(_Estado);
        }

        public void LlenarDropDownListEstados(DropDownList d)
        {   
            int i = Convert.ToInt16(_Pais.SelectedValue);
            // Hace el enlace al DataTable contenido en el DataSet
            d.DataSource = auxDatos.consultarEstadosBD(i);
            // Hace el enlace del campo au_id para el valor
            d.DataValueField = "idLugar";
            // Hace el enlace del campo au_fname para el texto
            d.DataTextField = "nombreLugar";
            //    // Llena el DropDownList con los datos de la fuente de datos
            d.DataBind();
             
        }*/
    }
}