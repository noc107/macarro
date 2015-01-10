using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.RolesSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BackOffice.LogicaNegocio.Comandos.RolesSeguridad
{
    public class ComandoObtenerMenuMaster : Comando<string, Menu>
    {

        /// <summary>
        /// Metodo para ejecutar el comando para consultar los ids de acciones de usuario
        /// </summary>
        /// <param name="parametro">correo del usuario</param>
        /// <returns>string con los ids de acciones para usar en la consulta SQL</returns>
        public override Menu Ejecutar(string parametro)
        {
            try
            {
                IDaoMenu _daoMenu;
                _daoMenu = FabricaDao.ObtenerDaoMenu();

                return _daoMenu.ConsultarMenuMaster(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}