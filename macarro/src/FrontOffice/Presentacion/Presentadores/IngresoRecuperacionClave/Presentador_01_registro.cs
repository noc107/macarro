using FrontOffice.Presentacion.Contratos.IngresoRecuperacionClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Presentacion.Presentadores.IngresoRecuperacionClave
{
    public class Presentador_01_registro : PresentadorGeneral
    {

        private IContrato_01_registro _contratoRegistrar;

        public Presentador_01_registro(IContrato_01_registro vistacontrato)
            : base(vistacontrato)
        {

            _contratoRegistrar = vistacontrato;
        
        
        }


        public void aceptar_Click() { 
        
        
        //crear logica
        }
             
    }
}