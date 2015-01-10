using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.FuenteDatos.IDao.ConfiguracionServiciosPlaya;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BackOffice.FuenteDatos.Dao.ConfiguracionServiciosPlaya
{
    public class DaoServiciosPlaya : Dao, IDaoServiciosPlaya
    {
        /// <summary>
        /// Trae de la BD todos los datos del servicio
        /// </summary>
        /// <param name="parametro">nombre del servicio a consultar</param>
        /// <returns>El servicio completo</returns>
        public Entidad ConsultarServicioCompleto(string parametro)
        {
            Entidad _servicio = null;
            SqlDataReader _lector;
            int _idServicio = 0;
            
            try
            {
                SqlCommand _comando = new SqlCommand("Procedure_obtenerDatosServicio", IniciarConexion());
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@_nombreServicio", parametro));

                IniciarConexion().Open();
                _lector = _comando.ExecuteReader();

                while (_lector.Read())
                {
                    _servicio = LlenarServicio(_lector);
                    _idServicio = (int)_lector["SER_id"];
                                       
                }
                _lector.Close();

                _servicio = obtenerHorarios(_servicio, _idServicio);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
            return _servicio;
        }

        /// <summary>
        /// Se crea el servicio con los datos traidos de la BD
        /// </summary>
        /// <param name="objeto">Es la secuencia de filas de los datos traidos de la BD</param>
        /// <returns> El servicio pero sin la lista de horarios</returns>
        private Entidad LlenarServicio(SqlDataReader objeto)
        {
            Entidad _servicio = null;

            _servicio = FabricaEntidad.ObtenerServicio((string)objeto["SER_nombre"], (string)objeto["SER_descripcion"],
                (int)objeto["SER_capacidad"], (int)objeto["SER_cantidadDis"], float.Parse(objeto["SER_costo"].ToString()),
                (string)objeto["CAT_nombre"], (string)objeto["SER_retiro"], (string)objeto["EST_nombre"], null);
            
            return _servicio;
        }
        
        /// <summary>
        /// Trae de la BD los horarios asociados al servicio para luego agregarlos al servicio
        /// </summary>
        /// <param name="_servicio">el servicio creado</param>
        /// <param name="_idServicio">id del servicio</param>
        /// <returns>El servicio completo</returns>
        public Entidad obtenerHorarios(Entidad _servicio, int _idServicio)
        {
            Horario _horarioItem = null;
            SqlDataReader _lector;
            Servicio _elServicio = _servicio as Servicio;
            Entidad _servicioNuevo = null;
            List<Horario> _lista = new List<Horario>();

            SqlCommand _comando = new SqlCommand("Procedure_consultarHorariosServicioId", IniciarConexion());
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.Add(new SqlParameter("@_idServicio", _idServicio));
            _lector = _comando.ExecuteReader();

            while (_lector.Read())
            {
                _horarioItem = new Horario(DateTime.Parse(_lector["HOR_inicio"].ToString()),
                    DateTime.Parse(_lector["HOR_fin"].ToString()));

                _lista.Add(_horarioItem);
                
            }
            _servicioNuevo = FabricaEntidad.ObtenerServicio(_elServicio.Nombre, _elServicio.Descripcion, _elServicio.Capacidad,
                    _elServicio.Cantidad, _elServicio.Costo, _elServicio.Categoria, _elServicio.LugarRetiro, _elServicio.Estado,
                    _lista);

            _lector.Close();
            CerrarConexion();

            return _servicioNuevo;
        }

        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public Entidad ConsultarXId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
    }
}