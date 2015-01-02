using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.Proveedores
{
    public class ComandoConsultarProveedor:Comando<int, Entidad>
    {
        public override Entidad Ejecutar(int parametro)
        {
            try
            {
                IDaoProveedor _daoEjemplo;
                _daoEjemplo = FabricaDao.ObtenerDaoProveedor();

                return _daoEjemplo.ConsultarXId(parametro);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }
    }
}