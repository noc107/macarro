using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.UsuariosInternos; 

namespace BackOffice.LogicaNegocio.Comandos.UsuariosInternos
{
    public class ComandoLlenarCBPaises : Comando<bool, List<Entidad>>
    {

        /// <summary>
        /// Método para ejecutar el comando para llenar el Combo Box de Paises
        /// </summary>
        /// <param name="parametro">Parametro para ejecutar</param>
        /// <returns>Lista de Paises</returns>
        public override List<Entidad> Ejecutar(bool parametro)
        {

            try
            {
                IDaoLugar _daoLugar;
                _daoLugar = FabricaDao.ObtenerDaoLugar();

                return _daoLugar.LlenarCBPaisesBD();

            }
            catch (Exception ex) 
            {
                throw ex; 
            }
        }
    }
}