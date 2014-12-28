using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya.componentes
{
    public partial class formularioModificarInventario : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        #region PROPIEDADES
        
        public TextBox getPrecio()
        {
            return this.precio;                   
        }

        public void setPrecio(string valor) 
        {
            this.precio.Text = valor;
        }

        public DropDownList getEstado()
        {
            return this.estadoDelItem;
        }

        public void setEstado(string valor)
        {
            this.estadoDelItem.Text = valor;
        }

        public TextBox getDescripcion()
        {
            return this.descripcion;
        }

        public void setDescripcion(string valor)
        {
            this.descripcion.Text = valor;
        }

        #endregion

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (estadoDelItem.Enabled == false)
            { 
                foreach (BaseValidator val in Page.Validators)
                {
                    if (val.ControlToValidate == "estadoDelItem")
                    {
                        val.Enabled = false;
                    }
                }
            }

            if (descripcion.Enabled == false)
            {
                foreach (BaseValidator val in Page.Validators)
                {
                    if (val.ControlToValidate == "descripcion")
                    {
                        val.Enabled = false;
                    }
                }
            }
        }
    }
}