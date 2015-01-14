using BackOffice.Presentacion.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Presentacion.Presentadores
{
    public class PresentadorGeneral
    {
        private IContratoGeneral _vista;

        public PresentadorGeneral(IContratoGeneral ventana)
        {
            _vista = ventana;
        }

        public void MostrarMensajeExito(string mensaje)
        {
            _vista.LabelMensajeExito.Text = mensaje;
        }

        public void MostrarMensajeError(string mensaje)
        {
            _vista.LabelMensajeError.Text = mensaje;
        }
    }
}