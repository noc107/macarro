using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.Proveedores
{
    public class ComandoEliminarProveedor : Comando<int, bool>
    {
        public override bool Ejecutar(int parametro)
        {
            try
            {
                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();

                return _daoProveedor.eliminarProveedor(parametro);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }
    }
}