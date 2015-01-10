using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.Proveedores
{
    public class ComandoCargarGVProveedores : Comando<bool, List<Entidad>>
    {
        public override List<Entidad> Ejecutar(bool parametro)
        {
            try
            {
                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();

                return _daoProveedor.ConsultarTodos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}