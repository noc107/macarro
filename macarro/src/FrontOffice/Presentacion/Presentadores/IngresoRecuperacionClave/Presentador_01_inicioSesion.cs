using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontOffice.Presentacion.Contratos.IngresoRecuperacionClave;

namespace FrontOffice.Presentacion.Presentadores.IngresoRecuperacionClave
{
    public class Presentador_01_inicioSesion : PresentadorGeneral
    {
        private IContrato_01_inicioSesion _contratoInicioSesion;

        //Constructor
        public Presentador_01_inicioSesion(IContrato_01_inicioSesion _contratoInicioSesion)
            : base(_contratoInicioSesion)
        {
            this._contratoInicioSesion = _contratoInicioSesion;
        }

        //Acciones del Boton Consultar
        public void Boton_IniciarSesion()
        {
            // Se procede con el inicio de Sesión
        }

        public void BOlvidasteContrasena_Click()
        {
            // Se procede con el caso de olvido de contraseña
        }

        
    }
}