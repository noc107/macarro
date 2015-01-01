using FrontOffice.Presentacion.Contratos.Estacionamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Presentadores.Estacionamiento
{
    public class Presentador_11_consultar_Estacionamiento : PresentadorGeneral
    {
        private IContrato_11_consultar_Estacionamiento _vista;

        public Presentador_11_consultar_Estacionamiento(IContrato_11_consultar_Estacionamiento vistaEstacionamiento)
            : base(vistaEstacionamiento) 
        {

            _vista = vistaEstacionamiento;
        
        }
        //boton volver
        public void EventoClickVolver()
        {
            throw new NotImplementedException();
        }
    }
}