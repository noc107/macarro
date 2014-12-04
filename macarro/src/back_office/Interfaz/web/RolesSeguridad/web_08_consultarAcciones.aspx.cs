using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;

namespace back_office.Interfaz.web.RolesSeguridad
{
    public partial class web_08_consultarAcciones : System.Web.UI.Page
    {
        System.Data.DataTable mytable = new System.Data.DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

            loadDataTable();
        }

        private void loadDataTable()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr;
            DataColumn accion;
            DataColumn descripcion;

            dt = new DataTable();
            accion = new DataColumn("Acción", Type.GetType("System.String"));
            descripcion = new DataColumn("Descripción", Type.GetType("System.String"));
            dt.Columns.Add(accion);
            dt.Columns.Add(descripcion);
            dr = dt.NewRow();
            dr["Acción"] = "Agregar servicio de playa";
            dr["Descripción"] = "Con esta acción podra agregar un nuevo servicio de playa con todas sus descripciones";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Acción"] = "Modificar servicio de playa";
            dr["Descripción"] = "Con esta acción podra modificar un servicio de playa y todas sus descripciones";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Acción"] = "Eliminar servicio de playa";
            dr["Descripción"] = "Con esta acción podra eliminar un servicio de playa";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Acción"] = "Agregar Rol";
            dr["Descripción"] = "Con esta acción podra agregar un nuevo Rol";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Acción"] = "Modificar Rol";
            dr["Descripción"] = "Con esta acción podra modificar un Rol";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Acción"] = "Eliminar Rol";
            dr["Descripción"] = "Con esta acción podra eliminar un Rol";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Acción"] = "Agregar platos";
            dr["Descripción"] = "Con esta acción podra agregar un nuevo plato y su descripción";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Acción"] = "Modificar plato";
            dr["Descripción"] = "Con esta acción podra modificar un plato y su descripción";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Acción"] = "Eliminar plato";
            dr["Descripción"] = "Con esta acción podra eliminar un plato";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Acción"] = "Modificar menu de restaurante";
            dr["Descripción"] = "Con esta acción podra agregar y/o eliminar platos del menu del restaurante";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Acción"] = "Agregar usuario interno";
            dr["Descripción"] = "Con esta acción podra agregar un nuevo usuario interno";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Acción"] = "Modificar usuario interno";
            dr["Descripción"] = "Con esta acción podra modificar un usuario interno";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Acción"] = "Eliminar usuario interno";
            dr["Descripción"] = "Con esta acción podra eliminar un usuario interno";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Acción"] = "Agregar proveedor";
            dr["Descripción"] = "Con esta acción podra agregar un nuevo proveedor";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Acción"] = "Modificar proveedor";
            dr["Descripción"] = "Con esta acción podra modificar un proveedor";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Acción"] = "Eliminar proveedor";
            dr["Descripción"] = "Con esta acción podra eliminar un proveedor";
            dt.Rows.Add(dr);
            dr = dt.NewRow();


            ds.Tables.Add(dt);
            mytable = ds.Tables[0];
            GridView1.DataSource = mytable;
            GridView1.DataBind();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = mytable;
        }
    }
}