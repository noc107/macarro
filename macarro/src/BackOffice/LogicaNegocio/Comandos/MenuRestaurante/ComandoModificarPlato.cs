using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.MenuRestaurante;

namespace BackOffice.LogicaNegocio.Comandos.MenuRestaurante
{
    public class ComandoModificarPlato : Comando<Entidad, bool>
    {
       
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                IDaoPlato _daoPlato;
                _daoPlato = FabricaDao.ObtenerDaoPlato();
                return _daoPlato.Modificar(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
