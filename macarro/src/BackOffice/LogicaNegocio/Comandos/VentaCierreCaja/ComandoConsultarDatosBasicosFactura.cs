using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.VentaCierreCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.VentaCierreCaja
{
    public class ComandoConsultarDatosBasicosFactura : Comando<int, Entidad>
    {

        /// <summary>
        /// Metodo para ejecutar el comando para la consulta del detalle de factura
        /// </summary>
        /// <param name="parametro">Factura a buscar</param>
        /// <returns>Entidad Factura</returns>
        public override Entidad Ejecutar(int _parametro)
        {
            Entidad _factura;

            IDaoImprimirFactura _daoImprimirFactura = FabricaDao.obtenerDaoImprimirFactura();

            _factura = _daoImprimirFactura.obtenerDatosBasicosFactura(_parametro); 
            
            return _factura;
        }

    }
}