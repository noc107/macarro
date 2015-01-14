using BackOffice.Dominio;
using BackOffice.Dominio.Fabrica;
using BackOffice.Excepciones;
using BackOffice.Excepciones.VentaCierreCaja;
using BackOffice.Excepciones.VentaCierreCaja.Recursos;
using BackOffice.FuenteDatos.Dao.VentaCierreCaja.Recursos;
using BackOffice.FuenteDatos.IDao.VentaCierreCaja;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BackOffice.FuenteDatos.Dao.VentaCierreCaja
{
    public class DaoGestionarVenta : Dao, IDaoGestionarVenta
    {

        /// <summary>
        /// Realiza la consulta de la facturas
        /// </summary>
        /// <param name="parametro">parametros de la busqueda de facturas</param>
        /// <returns>DataTable con las coicidencias de facturas</returns>
        public DataTable ConsultarFacturas(string[] parametro)
        {
            DataTable _dt;
            SqlDataAdapter _da;
          

            try
            {
                SqlCommand comando = new SqlCommand(RecursosDaoCierreCaja.ProcedimientoConsultarFacturas, IniciarConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter(RecursosDaoCierreCaja.ParametroBusqueda, parametro[0]));
                comando.Parameters.Add(new SqlParameter(RecursosDaoCierreCaja.ParametroEstado, parametro[1]));

                _dt = new DataTable();

                IniciarConexion().Open();
                
                 _da = new SqlDataAdapter(comando);
                 _da.Fill(_dt);
    
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }

            return _dt;
        }


        /// <summary>
        /// Realiza la eliminacion de la facturas
        /// </summary>
        /// <param name="parametro">Nro de la factura a eliminar</param>
        /// <returns>Boolean indicando si se realizo satisfactoriamente la eliminacion de la factura </returns>
        public int EliminarFacturas(string parametro)
        {
            SqlDataReader _consulta;
            SqlParameter _parametroRetorno;

            try
            {

                IniciarConexion().Open();
            
                SqlCommand comando = new SqlCommand(RecursosDaoCierreCaja.ProcedimientoEliminarFacturas, IniciarConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter(RecursosDaoCierreCaja.ParametroNroFactura, Convert.ToInt32(parametro)));

                _parametroRetorno = comando.Parameters.Add(RecursosDaoCierreCaja.ParametroRetorno, SqlDbType.Int);
                _parametroRetorno.Direction = ParameterDirection.ReturnValue;

                _consulta = comando.ExecuteReader();

                return (int)_parametroRetorno.Value;
                
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



        #region SinImplementacion
        public Entidad ConsultarXId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}