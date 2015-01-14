using BackOffice.Dominio;
using BackOffice.Excepciones;
using BackOffice.Excepciones.ExcepcionesDao;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.MenuRestaurante;
using BackOffice.LogicaNegocio.Comandos.MenuRestaurante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace BackOffice.LogicaNegocio.Comandos.MenuRestaurante
{
    public class ComandoLlenarSecciones : Comando<bool, List<Entidad>>
    {

        
        public override List<Entidad> Ejecutar(bool parametro)
        {
               try
               {
                   IDaoSeccion _daoSeccion;
                   _daoSeccion = FabricaDao.ObtenerDaoSeccion();

                   return _daoSeccion.ConsultarTodos();
               }
            
               catch (ExcepcionDao e)
               {
                
               }
               return null;
        }

    }
}