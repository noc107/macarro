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
    public class ComandoConsultarEmpleadoXId : Comando<int,Entidad> 
    {
        public override Entidad Ejecutar(int parametro)
        {
            try
            {
                IDaoEmpleado _daoEmpleado;
                _daoEmpleado = FabricaDao.ObtenerDaoEmpleado();

                return _daoEmpleado.ConsultarXId(parametro);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); 
            }
            return null; 
        }
    }
}