using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.Proveedores;

namespace BackOffice.LogicaNegocio.Comandos.Proveedores
{
    public class ComandoObtenerTodosLosEstados : Comando<string,List<string>>
    {
        public override List<string> Ejecutar(string parametro)
        {
            
            List<string> _estados;
            try
            {
                IDaoProveedor _daoProveedor;
                _daoProveedor = FabricaDao.ObtenerDaoProveedor();
                _estados = _daoProveedor.ConsultarTodosEstados(parametro);
                return _estados;

            }
            catch (Exception ex) 
            {
                throw (ex);    
            }

        } 
        
    }
}