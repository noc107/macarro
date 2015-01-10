using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.RolesSeguridad
{
    public class ComandoListaString : Comando<List<Entidad>, List<string>>
    {
        
        /// <summary>
        ///  Metodo para ejecutar el comando para convertir una lista de entidad en string
        /// </summary>
        /// <param name="parametro">lista de entidad</param>
        /// <returns>la lista de string</returns>
        public override List<string> Ejecutar(List<Entidad> parametro)
        {
            try
            {
                List<string> lista = new List<string>();

                foreach (Accion a in parametro)
                {
                    lista.Add(a.Nombre);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}