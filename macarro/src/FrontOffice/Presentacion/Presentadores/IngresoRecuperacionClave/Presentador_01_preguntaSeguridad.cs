using FrontOffice.Presentacion.Contratos.IngresoRecuperacionClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Presentacion.Presentadores.IngresoRecuperacionClave
{
    public class Presentador_01_preguntaSeguridad : PresentadorGeneral
    {

        private IContrato_01_preguntaSeguridad  _contratoseguridad;

         public  Presentador_01_preguntaSeguridad(IContrato_01_preguntaSeguridad vistapregunta)
              : base( vistapregunta) {
         
         _contratoseguridad = vistapregunta;
         }

        
        public void aceptar_Click() { 

        //crear logica
        }


    }
}