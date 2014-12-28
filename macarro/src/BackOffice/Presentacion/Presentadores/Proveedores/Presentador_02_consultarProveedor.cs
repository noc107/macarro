using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.Proveedores;

namespace BackOffice.Presentacion.Presentadores.Proveedores
{
    public class Presentador_02_consultarProveedor : PresentadorGeneral
    {
        private IContrato_02_consultarProveedor _vista;

        public Presentador_02_consultarProveedor(IContrato_02_consultarProveedor laVistaDefault)
            : base(laVistaDefault)
        {
            _vista = laVistaDefault;
            
        }

        public void EventoClickVolver() 
        {
        
        }
    }
}