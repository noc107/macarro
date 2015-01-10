using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.FuenteDatos.IDao;
using BackOffice.FuenteDatos.IDao.VentaCierreCaja;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BackOffice.FuenteDatos.Dao.VentaCierreCaja
{
    class DaoCierreCaja : Dao, IDaoCierreCaja
    {

        private Entidad _cierreCaja = FabricaEntidad.ObtenerCierreCaja();

        /// <summary>
        /// Método implementado de la interfaz IDaoCierreCaja para consultar el cierre de caja diario
        /// </summary>
        /// <param name="parametro">Parámetros de busqueda</param>
        /// <returns>Objeto de tipo Entidad</returns>
        public Entidad consultarCierreCajaDia(string[] parametro)
        {

            SqlCommand comando = new SqlCommand("Procedure_cierreCajaDiario", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@_tipo", parametro[0]));
            comando.Parameters.Add(new SqlParameter("@_fechaChar", parametro[1]));
            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();

                _lectura.Read();
                this._cierreCaja = this.obtenerBDReaderCierreDia(_lectura, parametro);
          
                return this._cierreCaja;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                CerrarConexion();
            }

            return null;
        }

        /// <summary>
        /// Método implementado de la interfaz IDaoCierreCaja para consultar el cierre de caja mensual
        /// </summary>
        /// <param name="parametro">Parámetros de busqueda</param>
        /// <returns>Objeto de tipo Entidad</returns>
        public Entidad consultarCierreCajaMes(string[] parametro)
        {

            SqlCommand comando = new SqlCommand("Procedure_cierreCajaMensual", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@_tipo", parametro[0]));
            comando.Parameters.Add(new SqlParameter("@_mes", int.Parse(parametro[1])));
            comando.Parameters.Add(new SqlParameter("@_año", int.Parse(parametro[2])));
            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();

                _lectura.Read();
                this._cierreCaja = this.obtenerBDReaderCierreMes(_lectura, parametro);

                return this._cierreCaja;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                CerrarConexion();
            }

            return null;
        }

        /// <summary>
        /// Método privado para asignar los valores obtenidos en BD del cierre de caja diario
        /// </summary>
        /// <param name="objetoBD">Objeto SQL que contiene los datos de la consulta</param>
        /// <param name="parametro">Parámetro de busqueda para los ingresos de la semana</param>
        /// <returns>Objeto del dominio con los datos asignados</returns>
        private CierreCaja obtenerBDReaderCierreDia(SqlDataReader objetoBD, string[] parametro)
        {

            CierreCaja caja = new CierreCaja();

            caja.NumeroFacturas = int.Parse(objetoBD["cantidad"].ToString());
            caja.SaldoAnterior = float.Parse(objetoBD["saldoAnt"].ToString());
            caja.Ingresos = float.Parse(objetoBD["ingreso"].ToString());
            caja.SaldoTotal = caja.SaldoAnterior + caja.Ingresos;

            objetoBD.Close();
            caja.ValoresGrafica = this.asignarValoresGraficaSemanal(parametro);

            return caja;
        }

        /// <summary>
        /// Método privado para llenar los valores para la gráfica semanal
        /// </summary>
        /// <param name="parametro">Array de cadenas que contienen los parametros de busqueda</param>
        /// <returns>Cadena de ingresos obtenidos en BD</returns>
        private string asignarValoresGraficaSemanal(string[] parametro)
        {

            SqlCommand comando = new SqlCommand("Procedure_cierreCajaDiarioSemanal", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@_tipo", parametro[0]));
            comando.Parameters.Add(new SqlParameter("@_fechaChar", parametro[1]));
            comando.Parameters.Add(new SqlParameter("@_ingresos", SqlDbType.NVarChar, 200));

            comando.Parameters["@_ingresos"].Direction = ParameterDirection.Output;
            
            comando.ExecuteNonQuery();

            return comando.Parameters["@_ingresos"].Value.ToString();
        }

        /// <summary>
        /// Método privado para asignar los valores obtenidos en BD del cierre de caja mensual
        /// </summary>
        /// <param name="objetoBD">Objeto SQL que contiene los datos de la consulta</param>
        /// <param name="parametro">Parámetro de busqueda para los ingresos del año</param>
        /// <returns>Objeto del dominio con los datos asignados</returns>
        private CierreCaja obtenerBDReaderCierreMes(SqlDataReader objetoBD, string[] parametro)
        {

            CierreCaja caja = new CierreCaja();

            caja.NumeroFacturas = int.Parse(objetoBD["cantidad"].ToString());
            caja.SaldoAnterior = float.Parse(objetoBD["saldoAnt"].ToString());
            caja.Ingresos = float.Parse(objetoBD["ingreso"].ToString());
            caja.SaldoTotal = caja.SaldoAnterior + caja.Ingresos;

            objetoBD.Close();
            caja.ValoresGrafica = this.asignarValoresGraficaAnual(parametro);

            return caja;
        }

        /// <summary>
        /// Método privado para llenar los valores para la gráfica anual
        /// </summary>
        /// <param name="parametro">Array de cadenas que contienen los parametros de busqueda</param>
        /// <returns>Cadena de ingresos obtenidos en BD</returns>
        private string asignarValoresGraficaAnual(string[] parametro)
        {

            SqlCommand comando = new SqlCommand("Procedure_cierreCajaMensualAnual", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@_tipo", parametro[0]));
            comando.Parameters.Add(new SqlParameter("@_mes", int.Parse(parametro[1])));
            comando.Parameters.Add(new SqlParameter("@_año", int.Parse(parametro[2])));
            comando.Parameters.Add(new SqlParameter("@_ingresos", SqlDbType.NVarChar, 200));

            comando.Parameters["@_ingresos"].Direction = ParameterDirection.Output;
            
            comando.ExecuteNonQuery();

            return comando.Parameters["@_ingresos"].Value.ToString();
 
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
