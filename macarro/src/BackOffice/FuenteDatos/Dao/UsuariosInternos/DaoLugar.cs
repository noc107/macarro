using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient; 
using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.FuenteDatos.IDao.UsuariosInternos;
using BackOffice.FuenteDatos.Dao.UsuariosInternos.Recursos;

namespace BackOffice.FuenteDatos.Dao.UsuariosInternos
{
    public class DaoLugar : Dao, IDaoLugar
    {

        private List<Entidad> _listaLugar;
        private List<int> _direccionCompleta; 
        private Lugar _lugar; 

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }


        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public  Entidad ConsultarXId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Entidad parametro) 
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Método que retorna la lista de paises 
        /// </summary>
        /// <returns>Lista de Paises</returns>
        public List<Entidad> LlenarCBPaisesBD() 
        {
            _listaLugar = new List<Entidad>();

            SqlCommand comando = new SqlCommand(RecursosDaoUsuariosInternos.ProcedimientoLlenarCBPais, IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                while (_lectura.Read())
                {
                    _lugar = AsignarLugar(_lectura);
                    if (_lugar != null)
                    {
                        _listaLugar.Add(_lugar);
                    }
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
            return _listaLugar;
        }


        /// <summary>
        /// Método que retorna una lista de estados dado el id de un país
        /// </summary>
        /// <param name="pais">Id del país</param>
        /// <returns>Lista de Estados</returns>
        public List<Entidad> LlenarCBEstadoBD(int pais) 
        {
            _listaLugar = new List<Entidad>();

            SqlCommand comando = new SqlCommand(RecursosDaoUsuariosInternos.ProcedimientoLlenarCBEstado, IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter(RecursosDaoUsuariosInternos.ParametroIdPais, pais));
            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                while (_lectura.Read())
                {
                    _lugar = AsignarLugar(_lectura);
                    if (_lugar != null)
                    {
                        _listaLugar.Add(_lugar);
                    }
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
            return _listaLugar;
        }


        /// <summary>
        /// Método que retorna la lista de Ciudades dado un estado
        /// </summary>
        /// <param name="estado">Id del estado</param>
        /// <returns>Lista de Ciudades</returns>
        public List<Entidad> LlenarCBCiudadBD(int estado) 
        {
            _listaLugar = new List<Entidad>();

            SqlCommand comando = new SqlCommand(RecursosDaoUsuariosInternos.ProcedimientoLlenarCBCiudad, IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter(RecursosDaoUsuariosInternos.ParametroIdEstado, estado));
            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                while (_lectura.Read())
                {
                    _lugar = AsignarLugar(_lectura);
                    if (_lugar != null)
                    {
                        _listaLugar.Add(_lugar);
                    }
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
            return _listaLugar;
        }

        public string ObtenerDireccionBD(int direccion) 
        {
            string _direccion = string.Empty;
            SqlCommand comando = new SqlCommand("Procedure_obtenerDireccion", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter(RecursosDaoUsuariosInternos.ParametroIdDireccion, direccion));
            SqlDataReader _lectura;
            
            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();

                while (_lectura.Read())
                {
                    _direccion = _lectura.GetString(0);
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

            return _direccion; 
        } 

        public List<int> ConsultarDireccionCompleta(int direccion) 
        {
            _direccionCompleta = new List<int>();

            SqlCommand comando = new SqlCommand(RecursosDaoUsuariosInternos.ProcedimientoConsultarDireccionCompleta, IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter(RecursosDaoUsuariosInternos.ParametroIdDireccion, direccion));

            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                while (_lectura.Read())
                {
                    _direccionCompleta.Add(_lectura.GetInt32(0));
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

            return _direccionCompleta;
        }


        /// <summary>
        /// Método que lee directamente desde la BD la información de un lugar
        /// </summary>
        /// <param name="objeto">Objeto de la BD</param>
        /// <returns>Retorna el lugar obtenido</returns>
        private Lugar AsignarLugar(SqlDataReader objeto) 
        {
            Lugar _lugar = (Lugar)FabricaEntidad.ObtenerLugar();

            try
            {
                _lugar.IdLugar = objeto.GetInt32(0);
                _lugar.NombreLugar = objeto.GetString(1);
            }
            catch (Exception ex) 
            {
                throw ex; 
            }

            return _lugar; 
        }
    }
}