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
    public class ComandoLlenarCBCiudad:Comando<int,List<Entidad>>
    {
        public override List<Entidad> Ejecutar(int parametro)
        {

            try
            {
                IDaoLugar _daoLugar;
                _daoLugar = FabricaDao.ObtenerDaoLugar();

                return _daoLugar.LlenarCBCiudadBD(parametro);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}