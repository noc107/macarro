using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.MenuRestaurante;
//using BackOffice.FuenteDatos.IDao.MenuRestaurante;

namespace BackOffice.LogicaNegocio.Comandos.MenuRestaurante
{
    public class ComandoConsultarSeccion:Comando<int, Entidad>
    {

        /// <summary>
        ///  Metodo para ejecutar el comando para obtener el rol actual
        /// </summary>
        /// <param name="parametro">indice del rol</param>
        /// <returns>rol actual</returns>
        public override Entidad Ejecutar(int parametro)
        {
            try
            {
                IDaoSeccion _daoSeccion;
                _daoSeccion = FabricaDao.ObtenerDaoSeccion();

                return _daoSeccion.ConsultarSeccion(parametro);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

    }
}