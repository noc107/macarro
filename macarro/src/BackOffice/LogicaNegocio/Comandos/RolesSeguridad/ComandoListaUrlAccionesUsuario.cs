using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.RolesSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.RolesSeguridad
{
    public class ComandoListaUrlAccionesUsuario : Comando<string, List<string>>
    {

        /// <summary>
        /// Metodo para ejecutar el comando para consultar la lista de URL de acciones de usuario
        /// </summary>
        /// <param name="parametro">correo del usuario</param>
        /// <returns>lista de string URL</returns>
        public override List<string> Ejecutar(string parametro)
        {
            try
            {
                IDaoMenu _daoMenu;
                _daoMenu = FabricaDao.ObtenerDaoMenu();

                return _daoMenu.ListaUrlAccionesUsuario(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}