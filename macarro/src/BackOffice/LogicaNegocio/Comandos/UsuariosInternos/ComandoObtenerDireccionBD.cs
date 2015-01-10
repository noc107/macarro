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
    public class ComandoObtenerDireccionBD : Comando<int,string>
    {
        public override string Ejecutar(int parametro)
        {

            try
            {
                IDaoLugar _daoLugar;
                _daoLugar = FabricaDao.ObtenerDaoLugar();

                return _daoLugar.ObtenerDireccionBD(parametro);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}