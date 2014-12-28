using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.Proveedores;

namespace BackOffice.Presentacion.Presentadores.Proveedores
{
    public class Presentador_02_modificarProveedor : PresentadorGeneral
    {
        private IContrato_02_modificarProveedor _vista;
       
        public Presentador_02_modificarProveedor(IContrato_02_modificarProveedor laVistaDefault)
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

        public void EventoClickBotonMas() 
        {
        
        }

        public void EventoClickBotonMenos() 
        {
        
        }
    }
}