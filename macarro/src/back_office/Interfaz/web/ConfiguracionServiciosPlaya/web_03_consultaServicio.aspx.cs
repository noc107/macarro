using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Text;
	
namespace back_office.Interfaz.web.ConfiguracionServiciosPlaya
{
    public partial class web_03_consultaServicio : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("NombreServicio", typeof(String));
            dt.Columns.Add("Descripcion", typeof(String));

            dt.Rows.Add("Moto de Agua", "Disfruta un paseo por nuestra playa junto a un acompañante y vive la mejor experiencia");
            dt.Rows.Add("Snorkel", "Disfruta de nuestras cristalinas aguas");
            dt.Rows.Add("Kit de arena para niños", "El mejor Kit para el disfrute de los más pequeños");
            dt.Rows.Add("Tabla Surf", "Disfruta de las olas");
            
            Servicios.DataSource = dt;
            Servicios.DataBind();

        }


        protected void Servicio_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton consultar = new ImageButton();
                consultar.ID = "botonConsultar";
                consultar.ImageUrl = "../../../comun/resources/img/View-128.png";
                consultar.Height = 50;
                consultar.Width = 50;
                consultar.Click += new ImageClickEventHandler(this.consultar_Click);

                ImageButton editar = new ImageButton();
                editar.ID = "botonEditar";
                editar.ImageUrl = "../../../comun/resources/img/Data-Edit-128.png";
                editar.Height = 50;
                editar.Width = 50;
                editar.Click += new ImageClickEventHandler(this.modificar_Click);

                ImageButton eliminar = new ImageButton();
                eliminar.ID = "botonEliminar";
                eliminar.ImageUrl = "../../../comun/resources/img/Garbage-Closed-128.png";
                eliminar.Height = 50;
                eliminar.Width = 50;
                eliminar.OnClientClick = "return confirm('Esta acción eliminará el ítem permanentemente del sistema ¿desea continuar?')";
                

                eliminar.Click += new ImageClickEventHandler(this.eliminar_Click);

                e.Row.Cells[2].Controls.Add(consultar);
                e.Row.Cells[2].Controls.Add(editar);
                e.Row.Cells[2].Controls.Add(eliminar);
            }

        }

        //Evento consulta de evento especifico
        void consultar_Click(Object sender, ImageClickEventArgs e)
        {
            Response.Redirect("web_03_consultaServicioCompleta.aspx");
        }


        //Evento modificar de evento especifico
        void modificar_Click(Object sender, ImageClickEventArgs e)
        {
            Response.Redirect("web_03_modificarServiciosPlaya.aspx");
        }


        //Evento eliminar de evento especifico
        void eliminar_Click(Object sender, ImageClickEventArgs e)
        {
         
        }
       
    }
}