using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.GestionVentaMembresia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.GestionVentaMembresia
{
    public class ComandoConsultarGVPagos : Comando<string, List<Entidad>>
    {
        /// <summary>
        /// Metodo para ejecutar el comando para filtrar los pagos
        /// </summary>
        /// <param name="generica">busqueda generica</param>
        /// <returns>lista de pagos filtrados</returns>
        public override List<Entidad> Ejecutar(string generica)
        {
            try
            {
                IDaoPago _daoPago;
                _daoPago = FabricaDao.ObtenerDaoPago();

                return _daoPago.ConsultarPagos(generica);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}