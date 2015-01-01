using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;

namespace BackOffice.LogicaNegocio.Comandos.ConfiguracionPuestosPlaya
{
    public class ComandoConsultarEstadosInventario : Comando<int, List<Entidad>>
    {
        public override List<Entidad> Ejecutar(int parametro)
        {
            throw new NotImplementedException();
        }
    }
}