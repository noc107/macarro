using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace back_office.Interfaz.web.RolesSeguridad
{
    public partial class web_08_gestionarRoles : System.Web.UI.Page
    {
        System.Data.DataTable mytable = new System.Data.DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            CreateGrid();
            AddRowsToGrid();
            GridView1.DataSource = mytable;
            GridView1.DataBind();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = mytable;
        }

        private void CreateGrid()
        {
            System.Data.DataColumn tColumn = null;
            tColumn = new System.Data.DataColumn("Rol", System.Type.GetType("System.String"));
            mytable.Columns.Add(tColumn);
            tColumn = new System.Data.DataColumn("Descripción", System.Type.GetType("System.String"));
            mytable.Columns.Add(tColumn);
            tColumn = new System.Data.DataColumn("Ver Editar Eliminar", System.Type.GetType("System.String"));
            mytable.Columns.Add(tColumn);
    
        }

        private void AddRowsToGrid()
        {
            mytable.Rows.Add("Administrador", "Encargado de la administracion interna");
            mytable.Rows.Add("Gerente", "Encargado de la gestion de los empleados");
            mytable.Rows.Add("Empleado", "Usuarios internos que hacen uso del sistema");
            mytable.Rows.Add("Cliente", "Usuario que disfruta de los servicios del Club");
            mytable.Rows.Add("Encargado", "Empleado que maneja el inventario");
        }

        protected void GridView_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton consultar = new ImageButton();
                consultar.ID = "bConsultar";
                consultar.ImageUrl = "../../../comun/resources/img/View-128.png";
                consultar.Height = 50;
                consultar.Width = 50;
                consultar.Click += new ImageClickEventHandler(this.consultarBtn_Click);

                ImageButton editar = new ImageButton();
                editar.ID = "bEditar";
                editar.ImageUrl = "../../../comun/resources/img/Data-Edit-128.png";
                editar.Height = 50;
                editar.Width = 50;
                editar.Click += new ImageClickEventHandler(this.editarBtn_Click);

                ImageButton eliminar = new ImageButton();
                eliminar.ID = "bEliminar";
                eliminar.ImageUrl = "../../../comun/resources/img/Garbage-Closed-128.png";
                eliminar.Height = 50;
                eliminar.Width = 50;
                eliminar.Click += new ImageClickEventHandler(this.eliminarBtn_Click);

                e.Row.Cells[2].Controls.Add(consultar);
                e.Row.Cells[2].Controls.Add(editar);
                e.Row.Cells[2].Controls.Add(eliminar);
            }

        }


        void consultarBtn_Click(Object sender, ImageClickEventArgs e)
        {
            Response.Redirect("web_08_consultarRol.aspx");
        }
        
        void editarBtn_Click(Object sender, ImageClickEventArgs e)
        {
            Response.Redirect("web_08_editarRol.aspx");
        }

        void eliminarBtn_Click(Object sender, ImageClickEventArgs e)
        {
            ImageButton b = (ImageButton)sender;
            b.OnClientClick = "return confirm('Esta acción eliminará el ítem permanentemente del sistema ¿desea continuar?')";
        }

       

    }
}