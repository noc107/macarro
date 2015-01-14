using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio
{
    public abstract class Comando<Parametro, Resultado>
    {
        public abstract Resultado Ejecutar(Parametro parametro);
    }
}