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
    public class ComandoConsultarDireccionCompleta : Comando <int,List<int>> 
    {
        public override List<int> Ejecutar(int parametro)
        {
            try
            {
                IDaoLugar _daoLugar;
                _daoLugar = FabricaDao.ObtenerDaoLugar();

                return _daoLugar.ConsultarDireccionCompleta(parametro);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }
    }
}