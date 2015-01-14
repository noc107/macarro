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
    public class ComandoLlenarCBEstatusUsuario : Comando<bool, List<Entidad>>
    {
        public override List<Entidad> Ejecutar(bool parametro) 
        {
            try
            {
                IDaoEmpleado _daoEmpleado;
                _daoEmpleado = FabricaDao.ObtenerDaoEmpleado();

                return _daoEmpleado.LlenarCBEstatusUsuario();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }
    }
}