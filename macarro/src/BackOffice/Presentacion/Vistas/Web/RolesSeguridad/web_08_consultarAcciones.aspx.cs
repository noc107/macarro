using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.Data.SqlClient;

namespace BackOffice.Presentacion.Vistas.Web.RolesSeguridad
{
    public partial class web_08_consultarAcciones : System.Web.UI.Page
    {
        DataTable mytable = new DataTable();
        #region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //loadDataTable();
            //variableSesion();
        }

        /// <summary>
        /// Metodo para cargar las variables de sesion
        /// </summary>
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
                MensajeErrores.Text = "No se han podido cargar los datos de sesion";
                MensajeErrores.Visible = true;
                ex.GetType();
            }
        }

        //private void loadDataTable()
        //{
        //    DataSet ds = new DataSet();
        //    DataTable dt = new DataTable();
        //    DataRow dr;
        //    DataColumn accion;
        //    DataColumn descripcion;

        //    dt = new DataTable();
        //    accion = new DataColumn("Acción", Type.GetType("System.String"));
        //    descripcion = new DataColumn("Descripción", Type.GetType("System.String"));
        //    dt.Columns.Add(accion);
        //    dt.Columns.Add(descripcion);
        //    dr = dt.NewRow();
        //    dr["Acción"] = "Agregar servicio de playa";
        //    dr["Descripción"] = "Con esta acción podra agregar un nuevo servicio de playa con todas sus descripciones";
        //    dt.Rows.Add(dr);
        //    dr = dt.NewRow();
        //    dr["Acción"] = "Modificar servicio de playa";
        //    dr["Descripción"] = "Con esta acción podra modificar un servicio de playa y todas sus descripciones";
        //    dt.Rows.Add(dr);
        //    dr = dt.NewRow();
        //    dr["Acción"] = "Eliminar servicio de playa";
        //    dr["Descripción"] = "Con esta acción podra eliminar un servicio de playa";
        //    dt.Rows.Add(dr);
        //    dr = dt.NewRow();
        //    dr["Acción"] = "Agregar Rol";
        //    dr["Descripción"] = "Con esta acción podra agregar un nuevo Rol";
        //    dt.Rows.Add(dr);
        //    dr = dt.NewRow();
        //    dr["Acción"] = "Modificar Rol";
        //    dr["Descripción"] = "Con esta acción podra modificar un Rol";
        //    dt.Rows.Add(dr);
        //    dr = dt.NewRow();
        //    dr["Acción"] = "Eliminar Rol";
        //    dr["Descripción"] = "Con esta acción podra eliminar un Rol";
        //    dt.Rows.Add(dr);
        //    dr = dt.NewRow();
        //    dr["Acción"] = "Agregar platos";
        //    dr["Descripción"] = "Con esta acción podra agregar un nuevo plato y su descripción";
        //    dt.Rows.Add(dr);
        //    dr = dt.NewRow();
        //    dr["Acción"] = "Modificar plato";
        //    dr["Descripción"] = "Con esta acción podra modificar un plato y su descripción";
        //    dt.Rows.Add(dr);
        //    dr = dt.NewRow();
        //    dr["Acción"] = "Eliminar plato";
        //    dr["Descripción"] = "Con esta acción podra eliminar un plato";
        //    dt.Rows.Add(dr);
        //    dr = dt.NewRow();
        //    dr["Acción"] = "Modificar menu de restaurante";
        //    dr["Descripción"] = "Con esta acción podra agregar y/o eliminar platos del menu del restaurante";
        //    dt.Rows.Add(dr);
        //    dr = dt.NewRow();
        //    dr["Acción"] = "Agregar usuario interno";
        //    dr["Descripción"] = "Con esta acción podra agregar un nuevo usuario interno";
        //    dt.Rows.Add(dr);
        //    dr = dt.NewRow();
        //    dr["Acción"] = "Modificar usuario interno";
        //    dr["Descripción"] = "Con esta acción podra modificar un usuario interno";
        //    dt.Rows.Add(dr);
        //    dr = dt.NewRow();
        //    dr["Acción"] = "Eliminar usuario interno";
        //    dr["Descripción"] = "Con esta acción podra eliminar un usuario interno";
        //    dt.Rows.Add(dr);
        //    dr = dt.NewRow();
        //    dr["Acción"] = "Agregar proveedor";
        //    dr["Descripción"] = "Con esta acción podra agregar un nuevo proveedor";
        //    dt.Rows.Add(dr);
        //    dr = dt.NewRow();
        //    dr["Acción"] = "Modificar proveedor";
        //    dr["Descripción"] = "Con esta acción podra modificar un proveedor";
        //    dt.Rows.Add(dr);
        //    dr = dt.NewRow();
        //    dr["Acción"] = "Eliminar proveedor";
        //    dr["Descripción"] = "Con esta acción podra eliminar un proveedor";
        //    dt.Rows.Add(dr);
        //    dr = dt.NewRow();

        //    ds.Tables.Add(dt);
        //    mytable = ds.Tables[0];
        //    GridView1.DataSource = mytable;
        //    GridView1.DataBind();
        //}

        /// <summary>
        /// Metodo para cargar la informacion del GridView
        /// </summary>
        //private void loadDataTable()
        //{
        //    try
        //    {
        //        ControlRolAccion cRA = new ControlRolAccion();
        //        mytable = cRA.llenarGridAcciones();
        //        GVAccion.DataSource = mytable;
        //        GVAccion.DataBind();
        //    }
        //    catch (SqlException ex)
        //    {
        //        MensajeErrores.Text = "No se han podido cargar los datos debido a que existe un conflicto con la conexión a la base de datos";
        //        MensajeErrores.Visible = true;
        //        ex.GetType();
        //    }
        //    catch (Exception ex)
        //    {
        //        MensajeErrores.Text = "No se han podido cargar los datos. Error " + ex.GetType().ToString();
        //        MensajeErrores.Visible = true;
        //    }
        //}

        /// <summary>
        /// Metodo para manejar el evento de cambio de la paginacion del GridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GVAccion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GVAccion.PageIndex = e.NewPageIndex;
                GVAccion.DataSource = mytable;
            }
            catch (SqlException ex)
            {
                MensajeErrores.Text = "No se han podido cargar los datos debido a que existe un conflicto con la conexión a la base de datos";
                MensajeErrores.Visible = true;
                ex.GetType();
            }
            catch (Exception ex)
            {
                MensajeErrores.Text = "No se han podido cargar los datos. Error " + ex.GetType().ToString();
                MensajeErrores.Visible = true;
            }
        }

    }
}