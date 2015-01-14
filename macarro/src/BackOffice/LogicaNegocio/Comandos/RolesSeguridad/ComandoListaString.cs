using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Excepciones;
using BackOffice.Excepciones.ExcepcionesComando.RolesSeguridad;
using BackOffice.Excepciones.ExcepcionesDao;
using BackOffice.Excepciones.ExcepcionesDao.RolesSeguridad;
using BackOffice.LogicaNegocio.Comandos.RolesSeguridad.Recursos;
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
            catch (NullReferenceException e)
            {
                ExcepcionComandoListaString exComandoListaString = new ExcepcionComandoListaString
                    (RecursosComandoRolesSeguridad.CodigoNullReferenceException,
                    RecursosComandoRolesSeguridad.ClaseComandoListaString,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeNullReferenceException,
                    e);
                Logger.EscribirEnLogger(exComandoListaString);

                throw exComandoListaString;
            }
            catch (ExcepcionDaoMenu e)
            {
                ExcepcionComandoListaString exComandoListaString = new ExcepcionComandoListaString
                    (e.Codigo, e.Clase, e.Metodo, e.Mensaje, e);
                Logger.EscribirEnLogger(exComandoListaString);

                throw exComandoListaString;
            }
            catch (ExcepcionDao e)
            {
                ExcepcionComandoListaString exComandoListaString = new ExcepcionComandoListaString
                    (RecursosComandoRolesSeguridad.CodigoGeneralError,
                    RecursosComandoRolesSeguridad.ClaseComandoListaString,
                    RecursosComandoRolesSeguridad.MetodoEjecutar,
                    RecursosComandoRolesSeguridad.MensajeGeneralError,
                    e);
                Logger.EscribirEnLogger(exComandoListaString);

                throw exComandoListaString;
            }

        }

    }
}