using BackOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos
{
    public class ComandoAgregarPersona : Comando<Entidad, Boolean>
    {
        public override Boolean Ejecutar(Entidad parametro)
        {
            try
            {
                // Codigo que se conecta con la capa FuenteDatos 
                // Se instancia la Fabrica DAO
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}