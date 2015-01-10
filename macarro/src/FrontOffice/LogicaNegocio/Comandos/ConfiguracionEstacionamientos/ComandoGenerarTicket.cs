using FrontOffice.Dominio;
using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.ConfiguracionEstacionamientos;
using FrontOffice.FuenteDatos.IDao.ConfiguracionEstacionamientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.ConfiguracionEstacionamientos
{
    public class ComandoGenerarTicket : Comando<Entidad, Boolean>
    {
        public override Boolean Ejecutar(Entidad parametro)
        {
            try
            {
                IDaoTicket _daoTicket;
                _daoTicket = FabricaDao.ObtenerDaoTicket();

                return _daoTicket.Agregar(parametro);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

       
    }
}