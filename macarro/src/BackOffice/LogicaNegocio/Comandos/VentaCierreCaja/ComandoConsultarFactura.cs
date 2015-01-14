using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.VentaCierreCaja;
using System.Data;

namespace BackOffice.LogicaNegocio.Comandos.VentaCierreCaja
{
    public class ComandoConsultarFactura : Comando<string[],DataTable>
    {
        DataTable _dt;

        /// <summary>
        /// Metodo para ejecutar el comando para cla consulta de facturas
        /// </summary>
        /// <param name="parametro">Factura a buscar</param>
        /// <returns>DataTable con las facturas que coincidan con la busqueda</returns>
        public override DataTable Ejecutar(string[] parametro)
        {
            IDaoGestionarVenta _daoGestionarVenta = FabricaDao.obtenerDaoGestionarVenta();

            _dt = new DataTable();

            _dt = _daoGestionarVenta.ConsultarFacturas(parametro);
           
            return _dt;
        }


    }
}