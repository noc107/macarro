using FrontOffice.Dominio;
using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Membresia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Membresia
{
    public class ComandoConsultarPagosPorIdYFecha : Comando<List<Object>, List<Entidad>>
    {
        public override List<Entidad> Ejecutar(List<Object> parametro)
        {
            try
            {
                IDaoPago _daoPago;
                _daoPago = FabricaDao.ObtenerDaoPagoMembresia();

                return _daoPago.ConsultarPagoXIdMembresiaYFechaPago((int)parametro.ElementAt(0),(DateTime)parametro.ElementAt(1));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;

            }

        }

    }
}