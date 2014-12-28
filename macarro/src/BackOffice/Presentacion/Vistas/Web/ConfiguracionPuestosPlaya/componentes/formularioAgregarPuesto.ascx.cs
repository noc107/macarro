using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya.componentes
{
    public partial class formularioAgregarPuesto : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            fila.Enabled = false;
            columna.Enabled = false;
        }

        protected void listaDeOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaDeOpciones.SelectedValue == "0")
            {
                fila.Enabled = false;
                columna.Enabled = false;
            }
            if (listaDeOpciones.SelectedValue == "1")
            {
                fila.Enabled = true;
                columna.Enabled = false;
            }
            if (listaDeOpciones.SelectedValue == "2")
            {
                fila.Enabled = false;
                columna.Enabled = true;
            }
            if (listaDeOpciones.SelectedValue == "3")
            {
                fila.Enabled = true;
                columna.Enabled = true;
            }
        }

        #region PROPIEDADES
        public string Fila()
        {
            return this.fila.Text;
        }
        public string Columna()
        {
            return this.columna.Text;
        }
        public string Descripcion()
        {
            return this.descripcion.Text;
        }
        public string Precio()
        {
            return this.precio.Text;
        }
        public string Tipo()
        {
            return this.listaDeOpciones.SelectedValue;
        }
        #endregion


        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (fila.Enabled == false)
            {
                foreach (BaseValidator val in Page.Validators)
                {
                    if (val.ControlToValidate == "fila")
                    {
                        val.Enabled = false;
                    }
                }
            }

            if (columna.Enabled == false)
            {
                foreach (BaseValidator val in Page.Validators)
                {
                    if (val.ControlToValidate == "columna")
                    {
                        val.Enabled = false;
                    }
                }
            }
        }

    }
}