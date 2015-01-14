using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.Proveedores
{
    public class ComandoCargarGVProveedores : Comando<string, List<Entidad>>
    {
        public override List<Entidad> Ejecutar(string parametro)
        {
            try
            {
                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();

                return _daoProveedor.ConsultarTodosBusq(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}