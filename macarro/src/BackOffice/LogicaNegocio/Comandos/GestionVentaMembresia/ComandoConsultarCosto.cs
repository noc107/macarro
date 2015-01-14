using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.GestionVentaMembresia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.GestionVentaMembresia
{
    public class ComandoConsultarCosto : Comando<int, Entidad>
    {
        /// <summary>
        /// Metodo para ejecutar el comando para consultar el costo actual de las membresias
        /// </summary>
        /// <returns>el costo</returns>
        public override Entidad Ejecutar(int parametro)
        {
            try
            {
                IDaoCosto _daoCosto;
                _daoCosto = FabricaDao.ObtenerDaoCosto();

                return _daoCosto.ConsultarCosto();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}