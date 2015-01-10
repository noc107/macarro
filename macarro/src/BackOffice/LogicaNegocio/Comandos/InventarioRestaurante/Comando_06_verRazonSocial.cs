using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.InventarioRestaurante;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.InventarioRestaurante
{
    public class Comando_06_verRazonSocial : Comando<int, DataTable>
    {
        public override DataTable Ejecutar(int parametro)
        {
            try
            {
                IDao_06_inventarioRestaurante _daoInventario;
                _daoInventario = FabricaDao.ObtenerDaoInventarioRestaurante();

                return _daoInventario.VerRazonesSocialesBD();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }
    }
}