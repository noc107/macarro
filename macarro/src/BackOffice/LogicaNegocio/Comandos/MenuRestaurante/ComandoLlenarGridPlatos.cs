using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.MenuRestaurante;

namespace BackOffice.LogicaNegocio.Comandos.MenuRestaurante
{
    public class ComandoLlenarGridPlatos : Comando<bool, List<Entidad>>
    {
        /// <summary>
        ///  Metodo para ejecutar el comando para llenar el grid de menu de restaurant
        /// </summary>
        /// <param name="parametro">bool de ejecucion</param>
        /// <returns>lista de menu</returns>
        public override List<Entidad> Ejecutar(bool parametro)
        {
            try
            {
                IDaoPlato _daoPlato;
                _daoPlato = FabricaDao.ObtenerDaoPlato();

                return _daoPlato.ConsultarTodos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}