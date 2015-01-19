using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.Proveedores;

namespace BackOffice.Presentacion.Presentadores.Proveedores
{
    public class Presentador_02_eliminarProveedor : PresentadorGeneral
    {

        private IContrato_02_eliminarProveedor _vista;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="laVistaDefault">Contrato que contiene la vista</param>
        public Presentador_02_eliminarProveedor(IContrato_02_eliminarProveedor laVistaDefault)
            :base(laVistaDefault)
        {
            _vista = laVistaDefault;
        }

        public void EventoClickBotonEliminar()
        {

        }

        public void EventoClickBotonRegresar()
        {
        }

    }
}