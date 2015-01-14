using FrontOffice.Dominio;
using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.ConfiguracionEstacionamientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.ConfiguracionEstacionamientos
{
    public class ComandoConsultarTicket : Comando<string, Entidad>
    {

        public override Entidad Ejecutar(string parametro)
        {
            try
            {
                IDaoTicket _daoTicket;
                _daoTicket = FabricaDao.ObtenerDaoTicket();

                return _daoTicket.VerificarXplaca(parametro);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }
    }
}