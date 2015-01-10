using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.GestionVentaMembresia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.GestionVentaMembresia
{
    public class ComandoModificarMembresia : Comando<Entidad, bool>
    {
        /// <summary>
        /// Metodo para ejecutar el comando para modificar una membresia
        /// </summary>
        /// <param name="parametro">membresia a modificar</param>
        /// <returns>true si realizo la modificacion</returns>
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                IDaoMembresia _daoMembresia;
                _daoMembresia = FabricaDao.ObtenerDaoMembresia();
                return _daoMembresia.Modificar(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}