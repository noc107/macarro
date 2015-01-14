using BackOffice.Dominio;
using BackOffice.Dominio.Fabrica;
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
    public class DaoImprimirFactura : Dao, IDaoImprimirFactura
    {

        /// <summary>
        /// Realiza la consulta de la factura dada
        /// </summary>
        /// <param name="parametro">Nro de la Factura a consultar</param>
        /// <returns>Entidad factura</returns>
        public Entidad obtenerDatosBasicosFactura(int _parametro)
        {

            Entidad _factura = FabricaEntidad.ObtenerFactura();

            try
            {
                SqlCommand comando = new SqlCommand(RecursosDaoCierreCaja.ProcedimientoDatosBasicosFactura, IniciarConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter(RecursosDaoCierreCaja.ParametroNroFactura, _parametro));

                SqlDataReader lector;

                IniciarConexion().Open();
                lector = comando.ExecuteReader();
 
                lector.Read();
                _factura = FabricaEntidad.ObtenerDetalleFactura(_parametro, DateTime.Parse(lector["Fecha"].ToString()), float.Parse(lector["SubTotal"].ToString()), float.Parse(lector["Total"].ToString()));
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }

            return _factura;

        }


        /// <summary>
        /// Obtiene los datos basicos del cliente al que esta asociada la factura
        /// </summary>
        /// <param name="parametro">Nro de la Factura a consultar</param>
        /// <returns>Entidad Persona</returns>
        public Entidad obtenerDatosClienteFactura(int _parametro)
        {

            Entidad _cliente;

            try
            {
                SqlCommand comando = new SqlCommand(RecursosDaoCierreCaja.ProcedimientoDatosCliente, IniciarConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter(RecursosDaoCierreCaja.ParametroNroFactura, _parametro));

                SqlDataReader lector;

                IniciarConexion().Open();
                lector = comando.ExecuteReader();

                lector.Read();
                _cliente = FabricaEntidad.ObtenerPersona((string)lector["Nombre"], (string)lector["Apellido"], (string)lector["DocIdentidad"]);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }

            return _cliente;

        }


        /// <summary>
        /// Obtiene las lineas facturas
        /// </summary>
        /// <param name="parametro">Nro de la Factura a consultar</param>
        /// <returns>DataTable con las lineas factura a</returns>
        public DataTable obtenerLineasFactura(int _parametro)
        {

            DataTable _dt;
            SqlDataAdapter _da;

            try
            {
                SqlCommand comando = new SqlCommand(RecursosDaoCierreCaja.ProcedimientoLineasFacturas, IniciarConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter(RecursosDaoCierreCaja.ParametroNroFactura, _parametro));

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