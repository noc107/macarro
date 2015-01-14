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
        public TextBox txt_Precio
        {
            get { return precio; }
        }

        public DropDownList Estado
        {
            get { return estadoDelItem; }
        }        

        public TextBox txt_Descripcion
        {
           get { return descripcion; }
        }

        #endregion

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Estado.Enabled == false)
            { 
                foreach (BaseValidator val in Page.Validators)
                {
                    if (val.ControlToValidate == "estadoDelItem")
                    {
                        val.Enabled = false;
                    }
                }
            }

            if (txt_Descripcion.Enabled == false)
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

        protected void estadoDelItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }        
    }
}