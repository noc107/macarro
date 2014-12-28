using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.Proveedores;

namespace BackOffice.Presentacion.Presentadores.Proveedores
{
    public class Presentador_02_agregarProveedores : PresentadorGeneral
    {
        private IContrato_02_agregarProveedores _vista;
        

        public Presentador_02_agregarProveedores(IContrato_02_agregarProveedores laVistaDefault)
            : base(laVistaDefault)
        {
            _vista = laVistaDefault;
            
        }

        public void EventoClickBotonAceptar() 
        {
        
        }

        public void EventoClickBotonVolver() 
        {
        
        }
    }
}