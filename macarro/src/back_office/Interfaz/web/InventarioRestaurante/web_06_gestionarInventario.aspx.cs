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
        public static int idItemSeleccionado = 0;
        private static bool _tablaBuscada = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _myTable.Columns.Add("Codigo", typeof(String));
                _myTable.Columns.Add("Nombre", typeof(String));
                _myTable.Columns.Add("Cantidad", typeof(String));
                _myTable.Columns.Add("Acciones", typeof(String));
                if (!_tablaBuscada)
                    this.CargarGrid();
                else
                    this.cargarGridBusqueda();

            }
            catch (ExcepcionVerItem) 
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
          "err_msg",
          "alert('Ha ocurrido un error de base de datos, por favor intente luego)');",
          true);
            }
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
                consultar.ToolTip = "Ver para imprimir";
                consultar.CommandName = "Consultar";

                ImageButton editar = new ImageButton();
                editar.ID = "bEditar";
                editar.ImageUrl = "../../../comun/resources/img/Data-Edit-128.png";
                editar.Height = 50;
                editar.Width = 50;
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


        protected void CargarGrid()
        {
            SqlDataReader _reader;
            SqlCommand _comando = new SqlCommand("Procedure_GridviewCarga", _baseDatos._cn);
            _comando.CommandType = CommandType.StoredProcedure;
            try
            {
                _baseDatos._cn.Open();
                _comando.ExecuteNonQuery();
                _reader = _comando.ExecuteReader();
                insertarEnDataSource(_reader);
            }
            catch (Exception ex) 
            {
                throw new ExcepcionVerItem(ex.Message);
            }
            _baseDatos._cn.Close();
            gdRows.DataSource = _myTable;
            gdRows.DataBind();
        }


        protected void cargarGridBusqueda()
        {
            if (ddParametro.SelectedIndex == 0)
            {
                cargarFilasDataTable();
                this.gdRows.DataSource = null;
                gdRows.DataBind();
                SqlDataReader _reader;
                SqlCommand _comando = new SqlCommand("Procedure_buscarItemNombre", _baseDatos._cn);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add("@nombreBuscado", SqlDbType.VarChar).Value = tbBuscar.Text.ToString();
                _baseDatos._cn.Open();
                _comando.ExecuteNonQuery();
                _reader = _comando.ExecuteReader();
                insertarEnDataSource(_reader);
                _baseDatos._cn.Close();
                gdRows.DataSource = _myTable;
                gdRows.DataBind();
                _tablaBuscada = true;
            }
            else
            {
                validarBuscarItemPorCodigo();
            }
        }


        protected void Inventario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void Inventario_PageIndexChanged(object sender, GridViewPageEventArgs e)
        {
            gdRows.PageIndex = e.NewPageIndex;
            gdRows.DataBind();
        }




        protected void userGridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Consultar")
            {
                GridViewRow rowSelect = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int index = rowSelect.RowIndex;
                ObtenerIdItem(index);
                Response.Redirect("web_06_verItem.aspx");
            }
            if (e.CommandName == "Modificar")
            {
                GridViewRow rowSelect = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int index = rowSelect.RowIndex;
                ObtenerIdItem(index);
                Response.Redirect("web_06_modificarItem.aspx");
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
            idItemSeleccionado = Convert.ToInt32(codigoItem.Text);
            return (idItemSeleccionado);
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
          "alert('Lo sentimos, ha ocurrido un error, por favor intente nuevamente)');",
          true);
            }
        }

        protected void botonBuscar_Click(object sender, EventArgs e)
        {
            cargarGridBusqueda();
        }



        protected void buscarItemPorCodigo()
        {
            cargarFilasDataTable();
            this.gdRows.DataSource = null;
            gdRows.DataBind();
            SqlDataReader _reader;
            try
            {
                SqlCommand _comando = new SqlCommand("Procedure_buscarItemCodigo", _baseDatos._cn);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add("@idBuscado", SqlDbType.Int).Value = Convert.ToInt32(tbBuscar.Text.ToString());
                _baseDatos._cn.Open();
                _comando.ExecuteNonQuery();
                _reader = _comando.ExecuteReader();
                insertarEnDataSource(_reader);
                _baseDatos._cn.Close();
                gdRows.DataSource = _myTable;
                gdRows.DataBind();
            }
            catch (FormatException)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),"err_msg",
                "alert('¡Solo se aceptan números para la busqueda por código!');",true);
                tbBuscar.Text = "";
            }
            catch (OverflowException)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),"err_msg",
                "alert('¡Numero demasiado largo!');",true);
                tbBuscar.Text = "";
            }
        }

        protected void insertarEnDataSource(SqlDataReader _reader)
        {
            while (_reader.Read())
            {
                DataRow _dr = _myTable.NewRow();
                _dr["Codigo"] = _reader[0];
                _dr["Nombre"] = (string)_reader[1];
                _dr["Cantidad"] = _reader[2];
                _myTable.Rows.Add(_dr);
            }
        }

        protected void cargarFilasDataTable()
        {
            _myTable = null;
            _myTable = new System.Data.DataTable();

            _myTable.Columns.Add("Codigo", typeof(String));
            _myTable.Columns.Add("Nombre", typeof(String));
            _myTable.Columns.Add("Cantidad", typeof(String));
            _myTable.Columns.Add("Acciones", typeof(String));
        }

        protected void validarBuscarItemPorCodigo()
        {
            try
            {
                Convert.ToInt32(tbBuscar.Text.ToString());
                buscarItemPorCodigo();

            }
            catch (FormatException)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                "err_msg",
                "alert('¡Solo se aceptan números para la busqueda por código!');",
                true);
                tbBuscar.Text = "";
            }
            catch (OverflowException)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
               "err_msg",
               "alert('¡Numero demasiado largo!');",
                true);
                tbBuscar.Text = "";
            }
        }

        protected void botonCancelar_Click(object sender, ImageClickEventArgs e)
        {
            _tablaBuscada = false;
            Response.Redirect("web_06_gestionarinventario.aspx");
        }


    }
}