﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.ConfiguracionEstacionamiento;

namespace BackOffice.Presentacion.Presentadores.ConfiguracionEstacionamiento
{
    public class Presentador_5_gestionarEstacionamiento : PresentadorGeneral
    {
        private IContrato_5_gestionarEstacionamiento _vista;
        //private ModeloIntegrador _comando; //Comando

        public Presentador_5_gestionarEstacionamiento(IContrato_5_gestionarEstacionamiento laVistaEstacionamiento)
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