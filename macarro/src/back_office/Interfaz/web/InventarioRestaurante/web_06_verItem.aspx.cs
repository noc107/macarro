using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using back_office.Logica.InventarioRestaurante;
using back_office.Excepciones.InventarioRestaurante;

namespace back_office.Interfaz.web.InventarioRestaurante
{
    public partial class web_06_verItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idItem = web_06_gestionarInventario.idItemSeleccionado;   //id del item seleccionado en la ventana gestion
            try
            {
                ProcedimientosItem _procedimiento = new ProcedimientosItem();
                string[] _mostrar = _procedimiento.verItem(10);

                lbNombreVer.Text = _mostrar[0];
                lbPrecio2.Text = _mostrar[1];
                lbProveedor.Text = _mostrar[2];
                lbCantidadVer.Text = _mostrar[3];
                lbDescripcionVer.Text = _mostrar[4];
                lbPrecio.Text = _mostrar[5];

                for (int _contador = 6; _contador < _mostrar.Length; _contador= _contador+2)
                {
                    ListItem list = new ListItem("Cantidad: " + _mostrar[_contador] + "Fecha: " + _mostrar[_contador+1]);
                    ListBox1.Items.Add(list);
                }

            }
            catch (ExcepcionVerItem)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
          "err_msg",
          "alert('Ha ocurrido un error de base de datos, por favor intente luego');",
          true);
                Response.Redirect("web_06_gestionarInventario.aspx");
            }
            catch (Exception) 
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
          "err_msg",
          "alert('Su solicitud no pudo ser procesada');",
          true);
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_06_gestionarInventario.aspx");
        }
    }
}