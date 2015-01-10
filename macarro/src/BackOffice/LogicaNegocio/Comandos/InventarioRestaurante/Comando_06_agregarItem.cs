using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.InventarioRestaurante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.InventarioRestaurante
{
    public class Comando_06_agregarItem : Comando<Entidad, bool>
    {
        public override bool Ejecutar(Entidad parametro)
        {
            bool _exito;
            try
            {
                IDao_06_inventarioRestaurante _daoInventario;
                _daoInventario = FabricaDao.ObtenerDaoInventarioRestaurante();

                _exito =  _daoInventario.Agregar(parametro);
            }
            catch (Exception ex)
            {
                _exito = false;
                Console.WriteLine(ex.ToString());
            }
            return _exito;
        }
    }
}