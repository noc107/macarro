using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace BackOffice.Presentacion.Vistas.Web.GestionVentaMembresia
{
    public partial class web_14_buscarMembresia : System.Web.UI.Page
    {

        //System.Data.DataTable _myTable = new System.Data.DataTable();
        //OperacionesBD _baseDatos = new OperacionesBD();



        /// <summary>
        /// Define columnas de la tabla a mostrar
        /// </summary>
        /// <param name="sender"></param>
        /// <return name="CargarGrid"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //_myTable.Columns.Add("Codigo", typeof(int));
            //_myTable.Columns.Add("Cedula", typeof(string));
            //_myTable.Columns.Add("ApellidoNombre", typeof(string));
            //_myTable.Columns.Add("Estado", typeof(string));
            //_myTable.Columns.Add("Acciones", typeof(string));
            //this.CargarGrid();
        }


        /// <summary>
        /// Carga los botones de acciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Membresia_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        ImageButton consultar = new ImageButton();
        //        consultar.ID = "bConsultar";
        //        consultar.ImageUrl = "../../../comun/resources/img/View-128.png";
        //        consultar.Height = 50;
        //        consultar.Width = 50;
        //        // consultar.Click += new ImageClickEventHandler(this.consultar_Click);
        //        consultar.ToolTip = "Ver membresia completa";
        //        consultar.CommandName = "Consultar";

        //        ImageButton editar = new ImageButton();
        //        editar.ID = "bEditar";
        //        editar.ImageUrl = "../../../comun/resources/img/Data-Edit-128.png";
        //        editar.Height = 50;
        //        editar.Width = 50;
        //        // editar.Click += new ImageClickEventHandler(this.modificar_Click);
        //        editar.ToolTip = "Modificar Membresia";
        //        editar.CommandName = "Modificar";



        //        e.Row.Cells[4].Controls.Add(consultar);
        //        e.Row.Cells[4].Controls.Add(editar);


        //    }

        }


        ///// <summary>
        ///// Carga la tabla
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        protected void CargarGrid()
        {
        //    SqlDataReader _reader;
        //    //SqlDataAdapter da;
        //    SqlCommand _comando = new SqlCommand("Procedure_consultarMembresiaGeneral", _baseDatos._cn);
        //    try
        //    {
        //        _comando.CommandType = CommandType.StoredProcedure;
        //        _baseDatos._cn.Open();
        //        _comando.ExecuteNonQuery();
        //        _reader = _comando.ExecuteReader();
        //        //foreach (DataColumn _colum in _myTable.Columns)
                
        //        while (_reader.Read())
        //        {
        //            DataRow _dr = _myTable.NewRow();
        //            _dr["Codigo"] = _reader[0];
        //            _dr["Cedula"] = (string)_reader[1];
        //            _dr["ApellidoNombre"] = (string)_reader[2] + ", " + (string)_reader[3];
        //            _dr["Estado"] = (string)_reader[4];
        //            _myTable.Rows.Add(_dr);
        //        }
        //    }
        //     catch (SqlException ex)
        //    {
        //        string _mensaje = "Se Perdió Conexión con la Base de Datos - Intentelo Más Tarde";
        //        back_office.Excepciones.
        //        GestionVentaMembresia.ExcepcionMembresiaDatos

        //        _excepcion = new back_office.Excepciones.
        //                         GestionVentaMembresia.ExcepcionMembresiaDatos(_mensaje);
        //        throw _excepcion;
        //    }
        //    catch (IOException ex)
        //    {
        //        string _mensaje = "Problemas con archivos  - Intentelo Más Tarde";
        //        back_office.Excepciones.
        //        GestionVentaMembresia.ExcepcionMembresiaDatos

        //        _excepcion = new back_office.Excepciones.
        //                         GestionVentaMembresia.ExcepcionMembresiaDatos(_mensaje);
        //        throw _excepcion;
        //    }
        //    catch (ObjectDisposedException ex)
        //    {
        //        string _mensaje = "Problemas de comunicacion  - Intentelo Más Tarde";
        //        back_office.Excepciones.
        //        GestionVentaMembresia.ExcepcionMembresiaDatos

        //        _excepcion = new back_office.Excepciones.
        //                         GestionVentaMembresia.ExcepcionMembresiaDatos(_mensaje);
        //        throw _excepcion;
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        string _mensaje = "Problemas de operacion  - Intentelo Más Tarde";
        //        back_office.Excepciones.
        //        GestionVentaMembresia.ExcepcionMembresiaDatos

        //        _excepcion = new back_office.Excepciones.
        //                         GestionVentaMembresia.ExcepcionMembresiaDatos(_mensaje);
        //        throw _excepcion;
        //    }
        //    catch (Exception ex)
        //    {
        //        string _mensaje = "Intentelo Más Tarde";
        //        back_office.Excepciones.
        //        GestionVentaMembresia.ExcepcionMembresiaDatos
                
        //        _excepcion = new back_office.Excepciones.
        //                         GestionVentaMembresia.ExcepcionMembresiaDatos(_mensaje);
        //        throw _excepcion;
        //    }
        //    _baseDatos._cn.Close();
        //    TablaMembresia.DataSource = this._myTable;
        //    TablaMembresia.DataBind();

        }

        protected void Membresia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        ///// <summary>
        ///// Paginacion de la tabla
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        protected void Membresia_PageIndexChanged(object sender, GridViewPageEventArgs e)
        {
        //    TablaMembresia.PageIndex = e.NewPageIndex;
        //    this.CargarGrid();
        }



        ///// <summary>
        ///// Convoca eventos identificados
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        protected void Membresia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        //    GridViewRow rowSelect = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
        //    int index = rowSelect.RowIndex;

        //    //Consultar a la membresia selecciona por el evento Consultar
        //    if (e.CommandName == "Consultar")
        //    {
        //        Response.Redirect("web_14_consultarMembresia.aspx?Membresia=" + TablaMembresia.Rows[index].Cells[0].Text);
        //    }
        //    //Modificar a la membresia selecciona por el evento Modificar 
        //    if (e.CommandName == "Modificar")
        //    {
        //        Response.Redirect("web_14_modificarMembresia.aspx?Membresia=" + TablaMembresia.Rows[index].Cells[0].Text);
        //    }

        }


        ///// <summary>
        ///// Obtiene la posicion en la fila seleccionada
        ///// </summary>
        ///// <param name="index"></param>
        ///// <return name="ObtenerIdMembresia"></param>
        //public int ObtenerIdMembresia(int index)
        //{
        //    GridViewRow selectedRow = TablaMembresia.Rows[index];
        //    TableCell codigoMembresia = selectedRow.Cells[0];
        //    return (Convert.ToInt32(codigoMembresia.Text));
        //}


    }
}



