using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya.componentes
{
    public partial class formularioAgregarItem : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region PROPIEDADES
        
        public DropDownList TipoDeItem
        {
            get { return tipoDeItem; }
        }

        public TextBox Precio
        {
            get { return precio; }
        }

        public TextBox CantidadItem
        {
            get { return cantidad; }
        }

        #endregion
        /*
        public string Precio()
        {
            return this.precio.Text;
        }
        public string Cantidad()
        {
            return this.cantidad.Text;
        }
        public string Tipo()
        {
            return this.tipoDeItem.SelectedValue;
        }
         */
    }
}