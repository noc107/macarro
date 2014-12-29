using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BackOffice.Presentacion.Presentadores.Proveedores;
using BackOffice.Presentacion.Contratos;
using BackOffice.Presentacion.Contratos.Proveedores;

namespace BackOffice.Presentacion.Vistas.Web.Proveedores
{
    public partial class web_02_gestionarProveedores : System.Web.UI.Page , IContratoGeneral, IContrato_02_gestionarProveedor
    {
        //LogicaProveedor auxLogica = new LogicaProveedor();
        
        Presentador_02_gestionarProveedor _presentador;
        public web_02_gestionarProveedores() 
        {
            _presentador = new Presentador_02_gestionarProveedor(this);
        }


        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Metodo por defecto / estandar , se ejecuta al cargarse la pagina
        /// </summary>
        /// <param name= sender> Objeto</param>
        /// <param name= e> Argumento</param>
         
        protected void Page_Load(object sender, EventArgs e)
        {
            //LlenarGridViewProveedores(GridView1);
        }

        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Metodo que llena el GridView de Proveedores.
        /// </summary>
        /// <param name= sender> Objeto</param>
        /// <param name= e> Argumento</param>


        GridView IContrato_02_consultarProveedor.Items
        {
            set { GridView1 = value; }
        }

        public Label LabelMensajeExito
        {
            get { return Label13; }
            set { Label13 = value; }
        }

        public Label LabelMensajeError
        {
            get { return Label13; }
            set { Label13 = value; }
        }






        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        //    GridView1.PageIndex = e.NewPageIndex;
        //    LlenarGridViewProveedores(GridView1);

        }

        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Evento, cuya funcion se realiza al clickear el boton especificado, Regresa al menu anterior
        /// </summary>
        /// <param name= sender> Objeto </param>
        /// <param name= e> Argumento </param>
  
        protected void Button1_Click(object sender, EventArgs e)
        {
            //regreso al menu anterior
        }

        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Metodo que redirecciona a la pagina correspondiente segun el boton que se haya clickeado (Agregar, Modificar, Eliminar, Consultar)
        /// </summary>
        /// <param name= sender> Objeto</param>
        /// <param name= e> Argumento del gridview</param>
        /// <exception> Exception , Param = ex </exception>

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        //        string auxString = "";

        //        if (e.CommandName == "Consultar")
        //        {
        //            auxString = ObtenerRifProveedor(e);
        //            e.Handled = true;
        //            Response.Redirect("web_02_consultarProveedor.aspx?p=" + auxString);
        //        }
        //        //if (e.CommandName == "Modificar")
        //        //{
        //        //    Response.Redirect("web_02_modificarProveedor.aspx");
        //        //}
        //        if (e.CommandName == "Eliminar")
        //        {
        //            auxString = ObtenerRifProveedor(e);
        //            e.Handled = true;
        //            Response.Redirect("web_02_eliminarProveedor.aspx?p=" + auxString);
        }
            
            
        //}
        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Metodo que obtiene el rif del proveedor seleccionado en el GridView
        /// </summary>
        /// <param name= e>  Argumento del GridView</param>
        /// <exception> Exception , Param = ex</exception>
        /// <returns> String, Devuelve una cadena de caracteres = RIF</returns>

        
        //public string ObtenerRifProveedor(GridViewCommandEventArgs e) 
        //{
        //    int index = Convert.ToInt32(e.CommandArgument);

        //    GridViewRow selectedRow = GridView1.Rows[index];

        //    TableCell rifProveedor = selectedRow.Cells[0];

        //    string idProveedor = rifProveedor.Text;

        //    return idProveedor;
        //}

        /// <author> Grupo 2: OrianaSantana, GinaGonzález, JesúsGrazziani</author> 
        /// <summary>
        /// Metodo que llena el GridView con toda la informacion contenida en proveedores
        /// </summary>
        /// <param name= g >  GridView donde se guarda la informacion </param>
        /// <exception> Exception, Param = ex </exception>
        
        //public void LlenarGridViewProveedores(GridView g)
        //{
        //    ProveedorBD _auxBD = new ProveedorBD();

        //    DataTable t = _auxBD.consultarTodosProveedoresBD();
        //    g.DataSource = t;
        //    g.DataBind();
        //}



    }
}