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


        protected void Page_Load(object sender, EventArgs e)
        {
            Fila.Enabled = false;
            Columna.Enabled = false;

        }

        #region PROPIEDADES
        
        public RadioButtonList Opciones 
        {
            get { return listaDeOpciones; }
        }

        public TextBox Fila 
        {
            get { return fila; } 
        }

        public TextBox Columna
        {
            get { return columna; }
        }

        #endregion


        #region validacion
        protected void listaDeOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Opciones.SelectedValue == "0")
            {
                Fila.Text = "";
                Fila.Enabled = false;
                Columna.Text = "";
                Columna.Enabled = false;

            }
            if (Opciones.SelectedValue == "1")
            {
                Fila.Enabled = true;
                Columna.Text = "";
                Columna.Enabled = false;
            }

            if (Opciones.SelectedValue == "2")
            {
                Fila.Text = "";
                Fila.Enabled = false;
                Columna.Enabled = true;
            }
            if (Opciones.SelectedValue == "3")
            {
                Fila.Enabled = true;
                Columna.Enabled = true;
            }

        }

        #endregion

       




    }
}