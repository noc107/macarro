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
    public class ComandoModificarPerfilEmpleado : Comando<Entidad,bool>
    {

        public override bool Ejecutar(Entidad parametro)
        {
            IDaoEmpleado _daoEmpleado;

            _daoEmpleado = FabricaDao.ObtenerDaoEmpleado();

            return _daoEmpleado.ModificarPerfilEmpleado(parametro);
        }
    }
}