using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.UsuariosInternos; 

namespace BackOffice.LogicaNegocio.Comandos.UsuariosInternos
{
    public class ComandoConsultarRolesEmpleado : Comando<int, List<string>>
    {
        public override List<string> Ejecutar(int parametro)
        {
            IDaoEmpleado _daoRoles;

            _daoRoles = FabricaDao.ObtenerDaoEmpleado();

            return _daoRoles.ConsultarRolesEmpleado(parametro);
        }
    }
}