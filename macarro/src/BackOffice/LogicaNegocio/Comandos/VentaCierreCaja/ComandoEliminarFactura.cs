using BackOffice.FuenteDatos.Dao;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.VentaCierreCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.VentaCierreCaja
{
    public class ComandoEliminarFactura : Comando<string, int>
    {

        /// <summary>
        /// Metodo para ejecutar el comando para eliminar facturas
        /// </summary>
        /// <param name="parametro">Nro de la factura a eliminar</param>
        /// <returns>boolean indicando si la eliminacion se realizo correctamente</returns>
        public override int Ejecutar(string parametro)
        {
            IDaoGestionarVenta _daoGestionarVenta = FabricaDao.obtenerDaoGestionarVenta();

            return _daoGestionarVenta.EliminarFacturas(parametro);

        }

    }
}