using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.RolesSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.RolesSeguridad
{
    public class ComandoListaAccionesUsuario : Comando<string, List<string>>
    {

        /// <summary>
        /// Metodo para ejecutar el comando para consultar la lista de acciones de un usuario
        /// </summary>
        /// <param name="parametro">correo del usuario</param>
        /// <returns>lista de string con las acciones del usuario</returns>
        public override List<string> Ejecutar(string parametro)
        {
            try
            {
                IDaoMenu _daoMenu;
                _daoMenu = FabricaDao.ObtenerDaoMenu();

                return _daoMenu.ListaAccionesUsuario(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}