using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace back_office.Interfaz.temp
{
    public partial class back_office_temp : System.Web.UI.MasterPage
    {
        #region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
           

            //if (Session["correo"] == null)
            //{
            //    Response.Redirect("/Presentacion/Vistas/Web/IngresoRecuperacionClave/web_01_inicioSesionA.aspx");
            //}
            //else
            //{ 
            //    variableSesion();
            //    if (ControlRolAccion.listaUrlMenu(_correoS).Contains(Request.Url.AbsolutePath))
            //    {
                    
            //        if (!IsPostBack)
            //        {
            //            GetMenuData();
            //        }
            //    }
            //    else
            //    {
            //        Response.Redirect("/Presentacion/Vistas/Web/inicio.aspx");
            //    }

            //}
        }

       


        private void variableSesion()
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
                ex.GetType();
            }
        }

        protected void Cerrar_Sesion(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/Presentacion/Vistas/Web/IngresoRecuperacionClave/web_01_inicioSesionA.aspx");
        }


        //private void GetMenuData()
        //{


        //    OperacionesBD oBD = new OperacionesBD();
        //    DataTable table = new DataTable();

        //    try
        //    {

        //        oBD._cn.Open();
        //        string sql = "select * from MENU_MASTER WHERE MEN_MAS_id_padre IS NULL or MEN_MAS_id_accion in (" + ControlRolAccion.listaIdMenu(_correoS) + ")";
        //        oBD._comando = new SqlCommand(sql, oBD._cn);
        //        oBD._da = new SqlDataAdapter(oBD._comando);
        //        oBD._da.Fill(table);

        //        DataView view = new DataView(table);


        //        view.RowFilter = "MEN_MAS_id_padre is NULL";
        //        foreach (DataRowView row in view)
        //        {
        //            MenuItem menuItem = new MenuItem(row["MEN_MAS_texto"].ToString(),
        //            row["MEN_MAS_id"].ToString());
        //            menuItem.NavigateUrl = row["MEN_MAS_url"].ToString();
        //            menuItem.ImageUrl = "/comun/resources/img/dropdown.png";
        //            menuBar.Items.Add(menuItem);
        //            AddChildItems(table, menuItem);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.GetType();
        //    }
        //    finally
        //    {
        //        oBD.DesconectarBD();
        //    }
        //}


        //private void AddChildItems(DataTable table, MenuItem menuItem)
        //{
        //    DataView viewItem = new DataView(table);
        //    viewItem.RowFilter = "MEN_MAS_id_padre=" + menuItem.Value;
        //    foreach (DataRowView childView in viewItem)
        //    {
        //        MenuItem childItem = new MenuItem(childView["MEN_MAS_texto"].ToString(),
        //        childView["MEN_MAS_id"].ToString());
        //        childItem.NavigateUrl = childView["MEN_MAS_url"].ToString();
        //        menuItem.ChildItems.Add(childItem);
        //        AddChildItems(table, childItem);
        //    }
        //}
    }
}