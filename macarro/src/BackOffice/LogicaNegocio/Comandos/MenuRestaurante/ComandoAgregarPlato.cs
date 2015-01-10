using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.MenuRestaurante;

namespace BackOffice.LogicaNegocio.Comandos.MenuRestaurante
{
    public class ComandoAgregarPlato: Comando<Entidad, bool>
    {
        /// <summary>
        /// Metodo para ejecutar el comando para agregar un plato
        /// </summary>
        /// <param name="parametro">plato</param>
        /// <returns>bool true o false dependiendo del resultado de la operacion</returns>
        public override bool Ejecutar(Entidad parametro)
        {
           try
           {
                IDaoPlato _daoPlato;
                _daoPlato = FabricaDao.ObtenerDaoPlato();
                return _daoPlato.Agregar(parametro);
           }
           catch (Exception ex)
           {
                throw ex;
           }
        }
    }
}
