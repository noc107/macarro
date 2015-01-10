using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.FuenteDatos.IDao.MenuRestaurante;

namespace BackOffice.FuenteDatos.Dao.MenuRestaurante
{
    public class DaoSeccion : Dao, IDaoSeccion
    {
        /// <summary>
        /// Metodo para obtener una seccion particular de la base de datos
        /// </summary>
        /// <returns>plato</returns>
        public Entidad ConsultarSeccion(int id)
        {
            Entidad seccion = new Seccion();
            SqlDataReader reader;
            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand("Procedure_ConsultarSeccion", _cn);
                _comando.Parameters.Add(new SqlParameter("@_secId", SqlDbType.Int));
                _comando.Parameters["@_secId"].Value = id;
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    seccion = (Seccion)FabricaEntidad.ObtenerSeccion((int)reader[0], (string)reader[1], (string)reader[2]);
                }

                return seccion;
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
        /// Metodo para agregar una seccion a la base de datos
        /// </summary>
        /// <param name="seccion">seccion a agregar</param>
        /// <returns>bool true o false dependiendo del exito de la operacion</returns>
        public bool Agregar(Entidad seccion)
        {
            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();

                SqlCommand _comando = new SqlCommand("Procedure_agregarSeccion", _cn);
                _comando.Parameters.Add(new SqlParameter("@_secNombre", SqlDbType.VarChar));
                _comando.Parameters.Add(new SqlParameter("@_secDescripcion", SqlDbType.VarChar));

                _comando.Parameters["@_secNombre"].Value = ((Seccion)seccion).Nombre;
                _comando.Parameters["@_secDescripcion"].Value = ((Seccion)seccion).Descripcion;           

                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.ExecuteNonQuery();

                return true;
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
        /// Metodo para Modificar una seccion a la base de datos
        /// </summary>
        /// <param name="seccion">seccion modificar </param>
        /// <returns>bool true o false dependiendo del exito de la operacion</returns>
        public bool Modificar(Entidad seccion)
        {
            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();

                SqlCommand _comando = new SqlCommand("Procedure_modificarSeccion", _cn);
                _comando.Parameters.Add(new SqlParameter("@_secId", SqlDbType.Int));
                _comando.Parameters.Add(new SqlParameter("@_secNombre", SqlDbType.VarChar));
                _comando.Parameters.Add(new SqlParameter("@_secDescripcion", SqlDbType.VarChar));

                _comando.Parameters["@_secId"].Value = ((Seccion)seccion).Id;
                _comando.Parameters["@_secNombre"].Value = ((Seccion)seccion).Nombre;
                _comando.Parameters["@_secDescripcion"].Value = ((Seccion)seccion).Descripcion;

                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.ExecuteNonQuery();

                return true;
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


        public Entidad ConsultarXId(int id)
        {
            throw new NotImplementedException();
        }
       
       /* public bool Modificar(Entidad seccion)
        {
            throw new NotImplementedException();
        }*/
        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
    }
}