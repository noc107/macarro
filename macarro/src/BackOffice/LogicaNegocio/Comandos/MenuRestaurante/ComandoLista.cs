using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Excepciones;
using BackOffice.Excepciones.ExcepcionesDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BackOffice.LogicaNegocio.Comandos.MenuRestaurante
{
    public class ComandoLista : Comando<List<Entidad>, List<string>>
    {

        /// <summary>
        ///  Metodo para ejecutar el comando para a una lista
        /// </summary>
        /// <param name="parametro">lista de entidad</param>
        /// <returns>la lista de string</returns>
        public override List<string> Ejecutar(List<Entidad> parametro)
        {
            try
            {
                List<string> lista = new List<string>();

                foreach (Seccion s in parametro)
                {
                    lista.Add(s.Nombre);
                }

                return lista;
            }
            
            catch (ExcepcionDao e)
            {
                return null;
            }

        }

    }
}