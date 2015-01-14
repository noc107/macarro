using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.Proveedores;

namespace BackOffice.LogicaNegocio.Comandos.Proveedores
{
    public class ComandoCambioEstado : Comando<string,List<string>>
    {
        public override List<string> Ejecutar(string parametro)
        {
            List<string> _ciudades;
            try
            {
                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();
                _ciudades = _daoProveedor.CiudadesDeEstado(parametro);
                return _ciudades;

            }
            catch (Exception ex) 
            {
                throw (ex);    
            }

        } 

    }
}