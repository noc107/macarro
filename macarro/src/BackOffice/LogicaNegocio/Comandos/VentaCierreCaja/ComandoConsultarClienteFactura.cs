using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.VentaCierreCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.VentaCierreCaja
{
    public class ComandoConsultarClienteFactura : Comando<int, Entidad>
    {

        /// <summary>
        /// Metodo para ejecutar el comando para la consulta de los datos del cliente de la factura
        /// </summary>
        /// <param name="parametro">Factura a obtener el cliente</param>
        /// <returns>Entidad persona</returns>
        public override Entidad Ejecutar(int _parametro)
        {
            Entidad _cliente;

            IDaoImprimirFactura _daoImprimirFactura = FabricaDao.obtenerDaoImprimirFactura();

            _cliente = _daoImprimirFactura.obtenerDatosClienteFactura(_parametro);

            return _cliente;
        }
    }
}