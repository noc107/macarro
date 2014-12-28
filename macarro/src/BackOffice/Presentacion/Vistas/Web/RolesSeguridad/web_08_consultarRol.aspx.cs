using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace BackOffice.Presentacion.Vistas.Web.RolesSeguridad
{
    public partial class web_08_consultarRol : System.Web.UI.Page
    {
        #region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (ControlRolAccion.RolActual != null)
            //{
            //    cargarInfo();
            //    variableSesion();
            //}
            //else
            //{
            //    Response.Redirect("web_08_gestionarRoles.aspx");
            //}
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

        /// <summary>
        /// Metodo para cargar la informacion del rol seleccionado
        /// </summary>
        ///
        //private void cargarInfo()
        //{
        //    try
        //    {
        //        lNombre.Text = ControlRolAccion.RolActual.Nombre;
        //        lDescripcion.Text = ControlRolAccion.RolActual.Descripcion;

        //        foreach (Accion a in ControlRolAccion.RolActual.Acciones)
        //        {
        //            ListAcciones.Items.Add(a.Nombre);
        //        }
        //    }
        //    catch (NullReferenceException ex)
        //    {
        //        MensajeErrores.Text = "No se han podido cargar los datos debido a que no hay un item seleccionado";
        //        MensajeErrores.Visible = true;
        //        ex.GetType();
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
        /// Metodo para manejar el evento del boton de regresar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_08_gestionarRoles.aspx");
        }
    }
}