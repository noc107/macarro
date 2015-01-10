using BackOffice.Dominio;
using BackOffice.FuenteDatos.Dao;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.VentaCierreCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.VentaCierreCaja
{
    public class ComandoCerrarCajaMensual : Comando<string[], Entidad>
    {

        public override Entidad Ejecutar(string[] parametro)
        {
            IDaoCierreCaja _daoCierreCaja;
            _daoCierreCaja = FabricaDao.obtenerDaoCierreCaja();

            return _daoCierreCaja.consultarCierreCajaMes(parametro);
        }
    }
}