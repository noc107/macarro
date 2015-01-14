using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya.componentes
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region PROPIEDADES
        
        public TextBox AnchoDePlaya
        {
            get { return anchoDeLaPlaya; }
        }

        public TextBox LargoDePlaya
        {
            get { return largoDeLaPlaya; }
        }

        #endregion

        /*
        public string Ancho()
        {
            return this.anchoDeLaPlaya.Text;
        }

        public string Largo()
        {
            return this.largoDeLaPlaya.Text;
        }
         */
    }
}