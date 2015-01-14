using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.GestionVentaMembresia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.GestionVentaMembresia
{
    public class ComandoConsultarGVMembresias : Comando<string, List<Entidad>>
    {
        /// <summary>
        /// Metodo para ejecutar el comando para filtrar las membresias
        /// </summary>
        /// <param name="generica">busqueda generica</param>
        /// <returns>lista de membresias filtradas</returns>
        public override List<Entidad> Ejecutar(string generica)
        {
            try
            {
                IDaoMembresia _daoMembresia;
                _daoMembresia = FabricaDao.ObtenerDaoMembresia();

                return _daoMembresia.ConsultarMembresias(generica);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}