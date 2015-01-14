using FrontOffice.Dominio;
using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Membresia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Membresia
{
    public class ComandoConsultaTarjeta : Comando<int, List<Entidad>>
    {
        public override List<Entidad> Ejecutar(int parametro)
        {
            try
            {
                IDaoTarjeta _daoTarjeta;
                _daoTarjeta = FabricaDao.ObtenerDaoTarjetaMembresia();

                return _daoTarjeta.ConsultarTarjetaXIdUsuario(parametro);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;

            }

        }

    }
}