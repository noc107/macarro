using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.Dominio.Fabrica;

namespace BackOffice.LogicaNegocio.Comandos.ConfiguracionPuestosPlaya
{
    public class ComandoConsultarInventario : Comando<string,List<Entidad>>
    {
        public override List<Entidad> Ejecutar(string parametro)
        {
            List<Entidad> lista = new List<Entidad>();
            #region prueba
            for (int i = 1; i <= 50; i++)
            {
                Entidad item = FabricaEntidad.ObtenerInventarioPlaya(i, i * 10, "activo", parametro, "probando", "codigo-" + i);
                lista.Add(item);
            }
            #endregion
            return lista;
        }
    }
}