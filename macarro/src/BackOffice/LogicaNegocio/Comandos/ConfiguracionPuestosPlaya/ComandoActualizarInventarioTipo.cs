using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;

namespace BackOffice.LogicaNegocio.Comandos.ConfiguracionPuestosPlaya
{
    public class ComandoActualizarInventarioTipo : Comando<Entidad, bool>
    {
        public override bool Ejecutar(Entidad parametro)
        {
            return true;
        }
    }
}