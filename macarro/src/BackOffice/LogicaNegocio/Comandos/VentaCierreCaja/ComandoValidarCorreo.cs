using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.VentaCierreCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.VentaCierreCaja
{
    public class ComandoValidarCorreo : Comando<string, Entidad>
    {

        public override Entidad Ejecutar(string parametro)
        {
            
            IDaoFacturacion _daoFacturacion = FabricaDao.ObtenerDaoFacturacion();          
            return _daoFacturacion.VerificarCorreo(parametro);

        }
    }
}