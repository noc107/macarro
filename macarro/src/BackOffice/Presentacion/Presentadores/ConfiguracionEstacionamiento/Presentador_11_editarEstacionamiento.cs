using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.ConfiguracionEstacionamiento;

namespace BackOffice.Presentacion.Presentadores.ConfiguracionEstacionamiento
{
    public class Presentador_11_editarEstacionamiento : PresentadorGeneral
    {
        private IContrato_11_editarEstacionamiento _vista;
        //private ModeloIntegrador _comando; //Comando

        public Presentador_11_editarEstacionamiento(IContrato_11_editarEstacionamiento laVistaEstacionamiento)
            : base(laVistaEstacionamiento)
        {
            _vista = laVistaEstacionamiento;
            //_comando = new Fabricacomando.Estacionamiento(); //Algo asi
        }

        public void EventoClickBoton() 
        {
            //acciones del evento editar con la logica
        }
    }
}