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
    public class DaoPlato : Dao,IDaoPlato
    {
        /// <summary>
        /// Metodo para obtener un plato particular de la base de datos
        /// </summary>
        /// <returns>plato</returns>
        public Entidad ConsultarPlato(int id)
        {

            Entidad plato = new Plato();
            SqlDataReader reader;
            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();
                SqlCommand _comando = new SqlCommand("Procedure_ConsultarPlato", _cn);
                _comando.Parameters.Add(new SqlParameter("@_PlaId", SqlDbType.Int));
                _comando.Parameters["@_plaId"].Value = id;
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    plato = (Plato)FabricaEntidad.ObtenerPlato((int)reader[0], (string)reader[1], (float)reader[2], (string)reader[3], (string)reader[4]);
                }

                return plato;
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
        /// Metodo para agregar un plato a la base de datos
        /// </summary>
        /// <param name="plato">plato a agregar</param>
        /// <returns>bool true o false dependiendo del exito de la operacion</returns>
        public bool Agregar(Entidad plato)
        {
            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();

                SqlCommand _comando = new SqlCommand("Procedure_agregarPlato", _cn);
                _comando.Parameters.Add(new SqlParameter("@_plaNombre", SqlDbType.VarChar));
                _comando.Parameters.Add(new SqlParameter("@_plaPrecio", SqlDbType.Float));
                _comando.Parameters.Add(new SqlParameter("@_plaDescripcion", SqlDbType.VarChar));
                _comando.Parameters.Add(new SqlParameter("@_seccionNombre", SqlDbType.VarChar));
                _comando.Parameters.Add(new SqlParameter("@_seccionId", SqlDbType.Int));

                _comando.Parameters["@_plaNombre"].Value = ((Plato)plato).Nombre;
                _comando.Parameters["@_plaPrecio"].Value = ((Plato)plato).Precio;
                _comando.Parameters["@_plaDescripcion"].Value = ((Plato)plato).Descripcion;
                _comando.Parameters["@_seccionNombre"].Value = "x";
                _comando.Parameters["@_seccionId"].Value = 1;

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
        /// Metodo para Modificar un Plato a la base de datos
        /// </summary>
        /// <param name="seccion">plato modificar </param>
        /// <returns>bool true o false dependiendo del exito de la operacion</returns>
        public bool Modificar(Entidad plato)
        {
            try
            {
                SqlConnection _cn = IniciarConexion();
                _cn.Open();

                SqlCommand _comando = new SqlCommand("Procedure_modificarPlato", _cn);
                _comando.Parameters.Add(new SqlParameter("@_plaId", SqlDbType.Int));
                _comando.Parameters.Add(new SqlParameter("@_plaNombre", SqlDbType.VarChar));
                _comando.Parameters.Add(new SqlParameter("@_plaPrecio", SqlDbType.Float));
                _comando.Parameters.Add(new SqlParameter("@_plaDescripcion", SqlDbType.VarChar));
                _comando.Parameters.Add(new SqlParameter("@_plaEstado", SqlDbType.Int));
                _comando.Parameters.Add(new SqlParameter("@_plaSeccion", SqlDbType.Int));

                _comando.Parameters["@_plaId"].Value = ((Plato)plato).Id;
                _comando.Parameters["@_plaNombre"].Value = ((Plato)plato).Nombre;
                _comando.Parameters["@_plaPrecio"].Value = ((Plato)plato).Precio;
                _comando.Parameters["@_plaDescripcion"].Value = ((Plato)plato).Descripcion;
                _comando.Parameters["@_plaEstado"].Value = 19;
                _comando.Parameters["@_seccionId"].Value = 1;//Cambiar metodo de recepcion

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
        
       /* public bool Modificar(Entidad plato)
        {
            throw new NotImplementedException();
        }*/
        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
    }
}