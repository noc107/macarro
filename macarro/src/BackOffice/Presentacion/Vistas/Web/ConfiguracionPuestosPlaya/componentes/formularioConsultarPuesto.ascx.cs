using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya.componentes
{
    public partial class formularioConsultarPuesto : System.Web.UI.UserControl
    {


        #region validacion
        protected void listaDeOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaDeOpciones.SelectedValue == "0")
            {
                fila.Text = "";
                columna.Text = "";
                fila.Enabled = false;
                columna.Enabled = false;

            }
            if (listaDeOpciones.SelectedValue == "1")
            {
                columna.Text = "";
                fila.Enabled = true;
                columna.Enabled = false;
            }
            
            if (listaDeOpciones.SelectedValue == "2")
            {
                fila.Text = "";
                fila.Enabled = false;
                columna.Enabled = true;

            }
            if (listaDeOpciones.SelectedValue == "3")
            {
                fila.Enabled = true;
                columna.Enabled = true;

            }


        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            fila.Enabled = false;
            columna.Enabled = false;

        }

        public string filar()
        {

            return this.fila.Text;
        }

        
        public string radio()
        {
            return listaDeOpciones.SelectedValue.ToString();
        }


        public void pintar(String e)
        {
            this.fila.Enabled = true;
            this.fila.Text=e;
        }

        public string columnar()
        {
            return this.columna.Text;
        }


    }
}