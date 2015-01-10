using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.MenuRestaurante;

namespace BackOffice.LogicaNegocio.Comandos.MenuRestaurante
{
    public class ComandoConsultarPlato:Comando<int, Entidad>
    {

        public override Entidad Ejecutar(int parametro)
        {
            
            try
            {
                IDaoPlato _daoPlato = null;
                _daoPlato = FabricaDao.ObtenerDaoPlato();
                return _daoPlato.ConsultarPlato(parametro);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }           
            return null;
        }

    }
}