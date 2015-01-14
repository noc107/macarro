using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya.componentes
{
    public partial class formularioModificarPuesto : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        #region PROPIEDADES

        public TextBox Fila
        {
            get { return fila; }
            set { fila = value; }
        }

        public TextBox Columna
        {
            get { return columna; }
            set { Columna = value; }
        }

        public TextBox Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public TextBox Precio
        {
            get { return precio; }
            set { precio = value; } 
        }

        #endregion

        public string filac()
        {

            return this.fila.Text;
        }

        public string columnac()
        {
            return this.columna.Text;
        }

        public void filas(string filapa) {

            this.fila.Text = filapa;
        }

        public void columnas(string columnapa)
        {

            this.columna.Text = columnapa;
        }

        public void descripcions(string descripcionpa)
        {
            this.descripcion.Text = descripcionpa;
        
        }

        public void montos(string montopa)
        {
            this.precio.Text = montopa;
        }

        public string descripcionc() 
        {
            return this.descripcion.Text;
        }

        public string montoc()
        {
            return this.precio.Text;
        }

    }
}