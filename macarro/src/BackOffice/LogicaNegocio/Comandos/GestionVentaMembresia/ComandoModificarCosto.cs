using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.GestionVentaMembresia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BackOffice.LogicaNegocio.Comandos.GestionVentaMembresia
{
    public class ComandoModificarCosto : Comando<Entidad, bool>
    {
        /// <summary>
        /// Metodo para ejecutar el comando para modificar un costo
        /// </summary>        
        /// <returns>true si realizo la modificacion del costo</returns>
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                IDaoCosto _daoCosto;
                _daoCosto = FabricaDao.ObtenerDaoCosto();
                return _daoCosto.Modificar(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}