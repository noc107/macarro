using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.GestionVentaMembresia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.GestionVentaMembresia
{
    public class ComandoConsultarMembresia:Comando<int, Entidad>
    {
        /// <summary>
        /// Metodo para ejecutar el comando para consultar una membresia
        /// </summary>
        /// <param name="parametro">membresia a buscar</param>
        /// <returns>la membresia</returns>
        public override Entidad Ejecutar(int parametro)
        {
            try
            {
                IDaoMembresia _daoMembresia;
                _daoMembresia = FabricaDao.ObtenerDaoMembresia();

                return _daoMembresia.ConsultarXId(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

    }
}