using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using FrontOffice.Presentacion.Contratos.Membresia;

namespace FrontOffice.Presentacion.Presentadores.Membresia
{
    public class Presentador_12_reactivarMembresia : PresentadorGeneral
    {

        #region Parametros

        private IContrato_12_reactivarMembresia _vista;

        #endregion

        #region Constructor

        public Presentador_12_reactivarMembresia(IContrato_12_reactivarMembresia reactivarMembresia)
            : base(reactivarMembresia) 
        {

            _vista = reactivarMembresia;
        
        }

        #endregion

        #region Metodos

        public void EventoClickCambiarFoto()
        {
            throw new NotImplementedException();
        }

        public void EventoClickAgregarTarjeta()
        {
            if (!this._vista.formulariosM.Visible)
            {
                this._vista.agregarTarjeta.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundImage, "url(/comun/resources/img/menos.png)");
                this._vista.agregarTarjeta.Text = "Ocultar";
            }
            else
            {
                this._vista.agregarTarjeta.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundImage, "url(/comun/resources/img/agregar.png)");
                this._vista.agregarTarjeta.Text = "Usar otra tarjeta";
            }

            this._vista.formulariosM.Visible = !this._vista.formulariosM.Visible;
        }

        public void EventoClickAceptar()
        {
            throw new NotImplementedException();
        }

        public void EventoClickCancelar()
        {
            throw new NotImplementedException();
        }

        public void QuitarCheckALosDemas()
        {
            throw new NotImplementedException();
        }
        //puede que falten metodos

        #endregion

    }
    
}