using FrontOffice.Dominio;
using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.ConfiguracionEstacionamientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.ConfiguracionEstacionamientos
{
    public class ComandoConsultarEstacionamiento : Comando<int,Entidad>
    {
        public override Entidad Ejecutar(int parametro)
        {
            try
            {
                IDaoEstacionamiento _daoEstacionamiento;
                _daoEstacionamiento = FabricaDao.ObtenerDaoEstacionamiento();

                return _daoEstacionamiento.ConsultarXId(parametro);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }
    }
}