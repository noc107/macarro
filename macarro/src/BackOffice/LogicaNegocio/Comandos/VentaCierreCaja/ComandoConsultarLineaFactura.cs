using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.VentaCierreCaja;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.VentaCierreCaja
{
    public class ComandoConsultarLineaFactura : Comando<int,DataTable>
    {

        DataTable _dt;

        /// <summary>
        /// Metodo para ejecutar el comando para de la consulta de lineas facturas
        /// </summary>
        /// <param name="parametro">Factura a buscar</param>
        /// <returns>DataTable con las lineas facturas</returns>
        public override DataTable Ejecutar(int parametro)
        {
            IDaoImprimirFactura _daoGestionarVenta = FabricaDao.obtenerDaoImprimirFactura();

            _dt = new DataTable();

            _dt = _daoGestionarVenta.obtenerLineasFactura(parametro);

            return _dt;
        }

    }
}