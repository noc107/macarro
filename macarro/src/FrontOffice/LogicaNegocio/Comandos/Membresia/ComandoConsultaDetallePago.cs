using FrontOffice.Dominio;
using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Membresia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Membresia
{
    public class ComandoConsultaDetallePago : Comando<List<Object>, Entidad>
    {
        public override Entidad Ejecutar(List<Object> parametro)
        {
            try
            {
                IDaoPago _daoPago;
                _daoPago = FabricaDao.ObtenerDaoPagoMembresia();

                return _daoPago.ConsultarDetallePago(int.Parse(parametro.ElementAt(0).ToString()), int.Parse(parametro.ElementAt(1).ToString()));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;

            }

        }

    }
}