using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.Proveedores;

namespace BackOffice.LogicaNegocio.Comandos.Proveedores
{
    public class ComandoObtenerPaisesTodos : Comando<string,List<string>>
    {
        public override List<string> Ejecutar(string parametro)
        {
            List<string> Paises;
            try
            {
                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();
                Paises = _daoProveedor.ConsultarTodosPaises(parametro);
                return Paises;
            }
            catch(Exception e) 
            {
                throw (e);
            }
        }
    }
}