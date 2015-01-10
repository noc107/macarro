using FrontOffice.Dominio;
using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Membresia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Membresia
{
    public class ComandoConsultarMembresia : Comando<int, Entidad>
    {
        public override Entidad Ejecutar(int parametro)
        {
            try
            {
                IDaoMembresia _daoMembresia;
                _daoMembresia = FabricaDao.ObtenerDaoMembresia();

                return _daoMembresia.ConsultarMembresiaXIdUsuario(parametro);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
                
            }
           
        }

    }
}