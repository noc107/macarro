using FrontOffice.Dominio;
using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Membresia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Membresia
{
    public class ComandoConsultarTodosLosPagos : Comando<int, List<Entidad>>
    {
        public override List<Entidad> Ejecutar(int parametro)
        {
            try
            {
                IDaoPago _daoPago;
                _daoPago = FabricaDao.ObtenerDaoPagoMembresia();

                return _daoPago.ConsultarPagoXIdMembresia(parametro);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;

            }

        }

    }
}