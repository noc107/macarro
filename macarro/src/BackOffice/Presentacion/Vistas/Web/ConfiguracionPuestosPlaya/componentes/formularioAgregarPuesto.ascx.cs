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
            Fila.Enabled = false;
            Columna.Enabled = false;
        }

        protected void listaDeOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListaDeOpciones.SelectedValue == "0")
            {
                Fila.Enabled = false;
                Columna.Enabled = false;
            }
            if (ListaDeOpciones.SelectedValue == "1")
            {
                Fila.Enabled = true;
                Columna.Enabled = false;
            }
            if (ListaDeOpciones.SelectedValue == "2")
            {
                Fila.Enabled = false;
                Columna.Enabled = true;
            }
            if (ListaDeOpciones.SelectedValue == "3")
            {
                Fila.Enabled = true;
                Columna.Enabled = true;
            }
        }

        #region PROPIEDADES
        
        public RadioButtonList ListaDeOpciones
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

        public TextBox Descripcion
        {
            get { return descripcion; }
        }

        public TextBox Precio
        {
            get { return precio; }
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


/*
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
        */
    }
}