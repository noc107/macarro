using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using back_office.Dominio;
using System.Data.SqlClient;
using System.Data;

namespace back_office.Datos.ConfiguracionPuestosPlaya
{
    public class PuestoBd
    {
        #region parametro
        private OperacionesBD _bd;
        private int _filaI;
        private int _columnaI;
        //parametros de  funcionamiento
        private readonly string _funcionConsultarPuesto = "Procedure_consultarPuesto";
        private readonly string _Resultado = "Resultado";
        // parametros de campo de bd
        private readonly string _fila = "PUE_fila";
        private readonly string _Columna = "PUE_columna";
        private readonly string _descripcion = "PUE_descripcion";
        private readonly string _precio = "PUE_precio";
        private readonly string _filaparametro = "@_pueFila";
        private readonly string _columnaparametro = "@_pueColumna";
        #endregion


        #region constructor
        public PuestoBd()
        {
            _bd = new OperacionesBD();
        }
        #endregion

        #region metodos fernando

        /// <summary>
        /// Metodo que crea un objeto de tipo de dato puesto
        /// </summary>
        /// <param name="dr">Es un registro en donde estan contenido los valores de fila,columna,precio y descripcion</param>
        /// <returns>Un Objeto de tipo puesto</returns>
        public Puesto CrearPuesto(DataRow dr)
        {
            Puesto _puesto = new Puesto();

            try
            {
                _puesto.Fila = int.Parse(dr[_fila].ToString());
                _puesto.Columna = int.Parse(dr[_Columna].ToString());
                _puesto.Descripcion = dr[_descripcion].ToString();
                _puesto.Precio = float.Parse(dr[_precio].ToString());

            }
            catch (NullReferenceException e)
            {
                // throw new CargoBDExcepcion(_codigoErrorExcepcionNullObject, _mensajeExcepcionNullObject, e);
            }
            catch (Exception e)
            {
                // throw new CargoBDExcepcion(_codigoErrorExcepcionGeneral, _mensajeExcepcionGeneral, e);
            }
            return _puesto;
        }

        /// <summary>
        /// Metodo que crea un arreglo de objetos de tipo puesto
        /// </summary>
        /// <param name="drc">Es un registro en donde estan contenido los valores de fila,columna,descripcion,precio</param>
        /// <returns>Un arreglo de objetos de tipo Puesto</returns>
        public Puesto[] CrearArregloPuesto(DataRowCollection drc)
        {
            Puesto[] _arregloPuesto = null;
            try
            {
                _arregloPuesto = new Puesto[drc.Count];
                int _iterador = 0;
                foreach (DataRow row in drc)
                {
                    _arregloPuesto[_iterador] = CrearPuesto(row);
                    _iterador++;
                }

            }
            catch (NullReferenceException e)
            {
                // throw new CargoBDExcepcion(_codigoErrorExcepcionNullObject, _mensajeExcepcionNullObject, e);
            }
            catch (Exception e)
            {
                // throw new CargoBDExcepcion(_codigoErrorExcepcionGeneral, _mensajeExcepcionGeneral, e);

            }
            return _arregloPuesto;
        }





        /// <summary>
        /// Metodo que realiza la busqueda de los puesto por fila,columna  bien sea activo o inactivo.
        /// </summary>
        /// <param name="estado">Si es true=activo y false=inactivo</param>
        /// <returns>Un arreglo de objetos de tipo Puesto</returns>
        public Puesto[] ConsultarPuesto(string filar, string columnaR)
        {

            


            Puesto[] _arregloPuesto = null;
            try
            {
                SqlDataAdapter _datos = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(_funcionConsultarPuesto, _bd._cn);
                if (filar.Equals(""))
                {
                    command.Parameters.Add(new SqlParameter(_filaparametro, SqlDbType.Int)).Value = DBNull.Value;
                }
                else
                {
                    _filaI = int.Parse(filar);
                    command.Parameters.Add(new SqlParameter(_filaparametro, SqlDbType.Int)).Value = _filaI;
                
                }
                if (columnaR.Equals(""))
                {
                    command.Parameters.Add(new SqlParameter(_columnaparametro, SqlDbType.Int)).Value = DBNull.Value;
                }
                else
                {
                    _columnaI = int.Parse(columnaR);
                    command.Parameters.Add(new SqlParameter(_filaparametro, SqlDbType.Int)).Value = _columnaI;

                }

                
                _datos.SelectCommand = command;
                _datos.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet dt = new DataSet();
                _datos.Fill(dt, _Resultado);

                _arregloPuesto = CrearArregloPuesto(dt.Tables[_Resultado].Rows);
            }
            catch (SqlException e)
            {
                // throw new CargoBDExcepcion(_codigoErrorSQLExcepcion, _mensajeSQLExcepcion, e);
            }
            catch (NullReferenceException e)
            {
                // throw new CargoBDExcepcion(_codigoErrorExcepcionNullObject, _mensajeExcepcionNullObject, e);
            }
            catch (Exception e)
            {
                // throw new CargoBDExcepcion(_codigoErrorExcepcionGeneral, _mensajeExcepcionGeneral, e);
            }

            return _arregloPuesto;

        }


        #endregion

    }
}