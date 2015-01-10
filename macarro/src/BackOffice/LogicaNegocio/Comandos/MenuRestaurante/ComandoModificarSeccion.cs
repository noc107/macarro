using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.MenuRestaurante;

namespace BackOffice.LogicaNegocio.Comandos.MenuRestaurante
{
    public class ComandoModificarSeccion : Comando<Entidad, bool>
    {

        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                IDaoSeccion _daoSeccion;
                _daoSeccion = FabricaDao.ObtenerDaoSeccion();
                return _daoSeccion.Modificar(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
