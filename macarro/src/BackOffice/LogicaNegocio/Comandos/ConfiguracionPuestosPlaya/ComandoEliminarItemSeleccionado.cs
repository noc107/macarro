using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;

namespace BackOffice.LogicaNegocio.Comandos.ConfiguracionPuestosPlaya
{
    public class ComandoEliminarItemSeleccionado : Comando<int, bool>
    {
        public override bool Ejecutar(int parametro)
        {
            return true;
        }
    }
}