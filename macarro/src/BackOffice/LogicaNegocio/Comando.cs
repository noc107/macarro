using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio
{
    public abstract class Comando<Entrada, Resultado>
    {
        public abstract Resultado Ejecutar(Entrada parametro);
    }
}