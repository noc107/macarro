using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.IngresoRecuperacionClave;

namespace BackOffice.Presentacion.Presentadores.IngresoRecuperacionClave
{
    public class Presentador_01_inicioSesionA : PresentadorGeneral
    {
        private IContrato_01_inicioSesionA _contratoInicioSesion;

        //Constructor
        public Presentador_01_inicioSesionA(IContrato_01_inicioSesionA _contratoInicioSesion)
            : base(_contratoInicioSesion)
        {
            this._contratoInicioSesion = _contratoInicioSesion;
            // aquí se fabrica la instanciación
        }

        public void Boton_IniciarSesion()
        {
            // Se procede con el inicio de Sesión
        }
    }
}