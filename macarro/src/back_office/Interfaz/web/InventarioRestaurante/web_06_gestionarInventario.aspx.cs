using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using back_office.Dominio;
using System.Data;
using System.Data.SqlClient;
using back_office.Datos;
using back_office.Logica.InventarioRestaurante;
using back_office.Excepciones.InventarioRestaurante;


namespace back_office.Interfaz.web.InventarioRestaurante
{
    public partial class web_06_gestionarInventario : System.Web.UI.Page
    {
        System.Data.DataTable _myTable = new System.Data.DataTable();
        OperacionesBD _baseDatos = new OperacionesBD();

        protected void Page_Load(object sender, EventArgs e)
        {
            _myTable.Columns.Add("Codigo", typeof(String));
            _myTable.Columns.Add("Nombre", typeof(String));
            _myTable.Columns.Add("Cantidad", typeof(String));
            _myTable.Columns.Add("Acciones", typeof(String));
            this.CargarGrid();
        }

        protected void Inventario_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton consultar = new ImageButton();
                consultar.ID = "bConsultar";
                consultar.ImageUrl = "../../../comun/resources/img/View-128.png";
                consultar.Height = 50;
                consultar.Width = 50;
               // consultar.Click += new ImageClickEventHandler(this.consultar_Click);
                consultar.ToolTip = "Ver para imprimir";
                consultar.CommandName = "Consultar";

                ImageButton editar = new ImageButton();
                editar.ID = "bEditar";
                editar.ImageUrl = "../../../comun/resources/img/Data-Edit-128.png";
                editar.Height = 50;
                editar.Width = 50;
               // editar.Click += new ImageClickEventHandler(this.modificar_Click);
                editar.ToolTip = "Editar Cuenta";
                editar.CommandName = "Modificar";

                ImageButton eliminar = new ImageButton();
                eliminar.ID = "bEliminar";
                eliminar.ImageUrl = "../../../comun/resources/img/Garbage-Closed-128.png";
                eliminar.Height = 50;
                eliminar.Width = 50;
                eliminar.Click += new ImageClickEventHandler(this.eliminar_Click);
                eliminar.CommandName = "Eliminar";
                eliminar.OnClientClick = "return confirm('¿Desea eliminar el item seleccionado?');";

                e.Row.Cells[3].Controls.Add(consultar);
                e.Row.Cells[3].Controls.Add(editar);
                e.Row.Cells[3].Controls.Add(eliminar);


            }

        }

        //Evento consulta de evento especifico
        protected void consultar_Click(Object sender, ImageClickEventArgs e)
        {

        }


        //Evento modificar de evento especifico
        protected void modificar_Click(Object sender, ImageClickEventArgs e)
        {

        }

        protected void eliminar_Click(Object sender, ImageClickEventArgs e)
        {

        }

       protected string confirmacionEliminar_Click(Object sender, ImageClickEventArgs e)
        {
            return ("confirm('seguro')");
        }


        protected void CargarGrid()
        {
            SqlDataReader _reader;
            SqlCommand _comando = new SqlCommand("Procedure_GridviewCarga", _baseDatos._cn);
            _comando.CommandType = CommandType.StoredProcedure;
            _baseDatos._cn.Open();
            _comando.ExecuteNonQuery();
            _reader = _comando.ExecuteReader();
                 while (_reader.Read())
                {
                    DataRow _dr = _myTable.NewRow();
                    _dr["Codigo"] = _reader[0];
                    _dr["Nombre"] = (string)_reader[1];
                    _dr["Cantidad"] = _reader[2];
                    _myTable.Rows.Add(_dr);
                }
            _baseDatos._cn.Close();
            gdRows.DataSource = _myTable;
            gdRows.DataBind();
        }

        protected void Inventario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void Inventario_PageIndexChanged(object sender, GridViewPageEventArgs e)
        {
            gdRows.PageIndex = e.NewPageIndex;
            this.CargarGrid();
        }




        protected void userGridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Consultar")
            {
                Response.Redirect("web_02_modificarProveedor.aspx");
            }
            if (e.CommandName == "Modificar")
            {
                Response.Redirect("web_02_modificarProveedor.aspx");
            }
            if (e.CommandName == "Eliminar")
            {
                GridViewRow rowSelect = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int index = rowSelect.RowIndex;
                eliminarItem(ObtenerIdItem(index));
            }
        }

        public int ObtenerIdItem(int index)
        {
            GridViewRow selectedRow = gdRows.Rows[index];
            TableCell codigoItem = selectedRow.Cells[0];
            return (Convert.ToInt32(codigoItem.Text));
        }


        protected void eliminarItem(int idItem)
        {
            ProcedimientosItem _procedimiento = new ProcedimientosItem();
            try
            {
                bool _exito = _procedimiento.eliminarItem(idItem);

                Response.Redirect("web_06_gestionarinventario.aspx");
                
            }
            catch (ExcepcionEliminarItem)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
          "err_msg",
          "alert('Ha ocurrido un error de base de datos, por favor intente luego)');",
          true);
            }

            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
          "err_msg",
          "alert('Dispatch assignment saved, but you forgot to click Confirm or Cancel!)');",
          true);
            }
        }

    }
}