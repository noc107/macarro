using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.Proveedores;

namespace BackOffice.Presentacion.Presentadores.Proveedores
{
    public class Presentador_02_gestionarProveedor : PresentadorGeneral
    {
        private IContrato_02_gestionarProveedor _vista;


        public Presentador_02_gestionarProveedor(IContrato_02_gestionarProveedor laVistaDefault)
            : base(laVistaDefault)
        {
            _vista = laVistaDefault;

        }
    
        public void EventoClickBotonVolver()
        {

        }
    }
}