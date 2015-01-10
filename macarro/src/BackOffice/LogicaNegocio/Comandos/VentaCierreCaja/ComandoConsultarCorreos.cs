using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.VentaCierreCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.VentaCierreCaja
{
    public class ComandoConsultarCorreos:Comando<int,string>
    {
        public override string Ejecutar(int parametro)
        {
            IDaoFacturacion _daoFacturacion = FabricaDao.ObtenerDaoFacturacion();
            
            return _daoFacturacion.ConsultarCorreos();            
        }
    }
}