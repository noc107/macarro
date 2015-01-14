using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.Proveedores;

namespace BackOffice.LogicaNegocio.Comandos.Proveedores
{
    public class ComandoAgregarProveedor : Comando<Entidad,bool>
    {
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();
                return _daoProveedor.Agregar(parametro);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }
    }
}