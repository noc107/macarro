using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using back_office.Dominio;
using System.Data.SqlClient;
using System.Data;
using back_office.Excepciones.ConfiguracionPuestosPlaya.ConfiguracionDePlaya;

namespace back_office.Datos.ConfiguracionPuestosPlaya
{
    public class PlayaBD
    {
        /// <summary>
        /// constructor de la clase PlayaBD
        /// </summary>
        public PlayaBD()
        {

        }

        #region METODOS ALEXANDER
        /// <summary>
        /// Toma la nueva configuracion de la playa y la ingresa en la base de datos
        /// </summary>
        /// <param name="configuracion">configuracion a actualizar dentro de la base dedatos</param>
        /// <returns>true en caso de exito; false en caso de error</returns>
        public bool IngresarNuevaConfiguracionDePlaya(Playa configuracion)
        {
            bool respuesta;
            OperacionesBD consultarPlaya = new OperacionesBD();
            SqlCommand comando = new SqlCommand( RecursosConfiguracionPuestosPlaya.procedimientoConfigurarPlaya, consultarPlaya._cn );
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add( new SqlParameter( RecursosConfiguracionPuestosPlaya.parametroPlayaActualizar, configuracion.Id ) );
            comando.Parameters.Add( new SqlParameter( RecursosConfiguracionPuestosPlaya.parametroFilaPlayaActualizar, configuracion.Filas ) );
            comando.Parameters.Add( new SqlParameter( RecursosConfiguracionPuestosPlaya.parametroColumnaPlayaActualizar, configuracion.Columnas ) );
            SqlDataReader lector;
            try
            {
                consultarPlaya._cn.Open();
                lector = comando.ExecuteReader();
                respuesta = true;
            }
            catch (Exception ex)
            {
                respuesta = false;
                throw new ExcepcionConfiguracionPlayaDatos(ex.Message);
            }
            finally
            {
                consultarPlaya.DesconectarBD(); 
            }
            return respuesta;
        }
        /// <summary>
        /// Toma la configuracion de la playa desde la base de datos
        /// </summary>
        /// <returns>Devuelve en forma de Objeto la configuracion actual de la playa</returns>
        public Playa ConsultarConfiguracionDePlaya()
        {
            Playa configuracionDeLaPlaya;
            configuracionDeLaPlaya = new Playa();
            OperacionesBD consultarPlaya = new OperacionesBD();
            SqlCommand comando = new SqlCommand( RecursosConfiguracionPuestosPlaya.procedimientoConsultarPlaya, consultarPlaya._cn );
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add( new SqlParameter( RecursosConfiguracionPuestosPlaya.parametroIdPlaya, DBNull.Value ) );
            SqlDataReader lector;
            try
            {
                consultarPlaya._cn.Open();
                lector = comando.ExecuteReader();
                configuracionDeLaPlaya = llenarPlayaDesdeLaBaseDeDatos(lector);
            }
            catch (Exception ex)
            {
                throw new ExcepcionConfiguracionPlayaDatos(ex.Message);
            }
            finally
            {
                consultarPlaya.DesconectarBD();
            }
            return configuracionDeLaPlaya;
        }
        /// <summary>
        /// Toma el Data Reader retornado por la base de datos y la ingresa en un objeto tipo Playa
        /// </summary>
        /// <param name="informacionDeLaPlaya">DataREader retornado por la base de datos</param>
        /// <returns>objeto del tipo Playa con la informacion de la playa</returns>
        public Playa llenarPlayaDesdeLaBaseDeDatos(SqlDataReader informacionDeLaPlaya)
        {
            Playa playa;
            playa = new Playa();
            try
            {
                if (informacionDeLaPlaya.Read())
                {
                    playa = new Playa(int.Parse(informacionDeLaPlaya[RecursosConfiguracionPuestosPlaya.id].ToString()),
                                      int.Parse(informacionDeLaPlaya[RecursosConfiguracionPuestosPlaya.filas].ToString()),
                                      int.Parse(informacionDeLaPlaya[RecursosConfiguracionPuestosPlaya.columnas].ToString()));
                }

            }
            catch (Exception ex)
            {
                throw new ExcepcionConfiguracionPlayaDatos(ex.Message);
            }
            return playa;
        }
        #endregion

    }
}