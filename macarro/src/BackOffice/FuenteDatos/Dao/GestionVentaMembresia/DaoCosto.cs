using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.FuenteDatos.IDao.GestionVentaMembresia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BackOffice.FuenteDatos.Dao.GestionVentaMembresia
{
    public class DaoCosto: Dao,IDaoCosto
    {
        private Entidad _costo = FabricaEntidad.ObtenerCosto();


        /// <summary>
        ///  Metodo para leer el costo actual de las membresias
        /// </summary>        
        /// <returns>el costo actual</returns>
        public Dominio.Entidad ConsultarCosto()
        {
            SqlCommand _comando = new SqlCommand("Procedure_consultarCostoMembresia", IniciarConexion());
            _comando.CommandType = CommandType.StoredProcedure;            
            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = _comando.ExecuteReader();
                while (_lectura.Read())
                {
                    _costo = FabricaEntidad.ObtenerCosto((float)_lectura[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
            return null;
        }


        /// <summary>
        ///  Metodo para modificar el costo actual de las membresias
        /// </summary>
        /// <param name="_costo">costo a modificar</param>
        /// <returns>true si se realizo la modificacion del costo</returns>
        public bool Modificar(Entidad _costo)
        {

            SqlCommand _comando = new SqlCommand("Procedure_modificarCostoMembresia", IniciarConexion());
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.Add(new SqlParameter("@_cos_mem_Costo", SqlDbType.Float));
            _comando.Parameters["@_cos_mem_Costo"].Value = ((Costo)_costo).monto;            

            try
            {
                IniciarConexion().Open();
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

        bool IDao.IDao<Entidad, bool, Entidad>.Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public Dominio.Entidad ConsultarXId(int _id)
        {
            throw new NotImplementedException();
        }
    }
}