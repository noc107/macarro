using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.FuenteDatos.IDao.RolesSeguridad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BackOffice.FuenteDatos.Dao.RolesSeguridad
{
    public class DaoAccion : Dao, IDaoAccion
    {
        /// <summary>
        /// Metodo para obtener todas las acciones del sistema
        /// </summary>
        /// <returns>List de accion</returns>
        public List<Entidad> ConsultarTodos()
        {
            List<Entidad> acciones = new List<Entidad>();
            SqlDataReader reader;

            try
            {

                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand("Procedure_ConsultarAccionGeneral", _cn);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    acciones.Add((Accion)FabricaEntidad.ObtenerAccion((int)reader[0], (string)reader[1], (string)reader[2]));
                }

                return acciones;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }

        /// <summary>
        /// Metodo para agregar una accion en la base de datos. No implementado
        /// </summary>
        /// <param name="rol">accion a agregar</param>
        /// <returns>bool si agrego la accion</returns>
        public bool Agregar(Entidad rol)
        {
            throw new NotImplementedException();

        }

        /// <summary>
        ///  Metodo para modficar las caracteristicas de una accion en especifica. No implementado
        /// </summary>
        /// <param name="rol">rol a modificar</param>
        /// <returns>bool si se realizo la modificacion de la accion</returns>
        public bool Modificar(Entidad accion)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para consultar rol por id. No implementado
        /// </summary>
        /// <param name="id">id de la accion</param>
        /// <returns>accion consultada</returns>
        public Entidad ConsultarXId(int id)
        {
            throw new NotImplementedException();
        }
    
    }
}