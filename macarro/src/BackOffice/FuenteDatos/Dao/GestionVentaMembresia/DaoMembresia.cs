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
    public class DaoMembresia : Dao, IDaoMembresia
    {
        private Entidad _membresia = FabricaEntidad.ObtenerMembresia();

        /// <summary>
        ///  Metodo para leer el detalle de una membresia
        /// </summary>
        /// <param name="id">membresia a leer</param>
        /// <returns>la membresia completa</returns>
        public Dominio.Entidad ConsultarXId(int _id)//membresia con todos los pagos asociados en una lista
        {
            SqlCommand _comando = new SqlCommand("Procedure_consultarDetalleMembresia", IniciarConexion());
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.Add(new SqlParameter("@_memId", SqlDbType.Int));
            _comando.Parameters["@_memID"].Value = _id;
            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = _comando.ExecuteReader();
                while (_lectura.Read())
                {
                    _membresia = LeerTupla(_lectura);
                    if (_membresia != null)
                    {
                        return _membresia;
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
            return null;
        }



        /// <summary>
        ///  Metodo para realizar la lectura de la tupla
        /// </summary>
        /// <param name="objetoBD">el objeto a leer</param>
        /// <returns>La membresia si se leyo correctamente</returns>
        public Membresia LeerTupla(SqlDataReader objetoBD)
        {
            Entidad _membresia = FabricaEntidad.ObtenerMembresia();            
            try
            {
                ((Membresia)_membresia).id = objetoBD.GetInt32(0);                
                ((Membresia)_membresia).descAplicado = objetoBD.GetFloat(2);
                ((Membresia)_membresia).fAdmision = objetoBD.GetDateTime(3);
                ((Membresia)_membresia).fVencimiento = objetoBD.GetDateTime(4);
                ((Membresia)_membresia).estado = objetoBD.GetString(5).ToString();
                ((Membresia)_membresia).Usuario.UsuarioAsociado.Correo = objetoBD.GetString(6).ToString();
                ((Membresia)_membresia).Usuario.Nombre = objetoBD.GetString(7).ToString();
                ((Membresia)_membresia).Usuario.SegundoNombre = objetoBD.GetString(8).ToString();
                ((Membresia)_membresia).Usuario.Apellido = objetoBD.GetString(9).ToString();
                ((Membresia)_membresia).Usuario.SegundoApellido = objetoBD.GetString(10).ToString();
                ((Membresia)_membresia).Usuario.Cedula = objetoBD.GetString(11).ToString();
                ((Membresia)_membresia).Usuario.FechaNacimiento = objetoBD.GetDateTime(12);
                ((Membresia)_membresia).Usuario.TipoDocumento = objetoBD.GetString(13).ToString();
                ((Membresia)_membresia).pagos = CargarPagos(objetoBD.GetInt32(0));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ((Membresia)_membresia);
        }


        /// <summary>
        ///  Metodo para realizar la carga de pagos asociados a membresia
        /// </summary>
        /// <param name="_idMembresia">id de la membresia a buscar pagos</param>
        /// <returns>Los pagos asociados a la membresia</returns>
        public List<Pago> CargarPagos(int _idMembresia)
        {
            SqlCommand _comando = new SqlCommand("Procedure_membresiaPagos", IniciarConexion());
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.Add(new SqlParameter("@_memId", SqlDbType.Int));
            _comando.Parameters["@_memID"].Value = _idMembresia;
            SqlDataReader _lectura;
            List<Pago> _pagos = null;

            try
            {
                IniciarConexion().Open();
                _lectura = _comando.ExecuteReader();
                while (_lectura.Read())
                {
                    _pagos.Add((Pago)FabricaEntidad.ObtenerPago(_lectura.GetInt32(0), _lectura.GetFloat(2), _lectura.GetDateTime(1)));
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
            return _pagos;
        }


        /// <summary>
        ///  Metodo para modficar una membresia
        /// </summary>
        /// <param name="_membresia">membresia a modificar</param>
        /// <returns>true si se realizo la modificacion de la membresia</returns>
        public bool Modificar(Entidad _membresia)
        {

            SqlCommand _comando = new SqlCommand("Procedure_modificarMembresia", IniciarConexion());
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.Add(new SqlParameter("@_memId", SqlDbType.Int));
            _comando.Parameters.Add(new SqlParameter("@_memStatus", SqlDbType.VarChar));
            _comando.Parameters.Add(new SqlParameter("@_memDescuento", SqlDbType.Float));
            _comando.Parameters["@_memId"].Value = ((Membresia)_membresia).id;
            _comando.Parameters["@_memStatus"].Value = ((Membresia)_membresia).estado;
            _comando.Parameters["@_memDescuento"].Value = ((Membresia)_membresia).descAplicado;

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

        /// <summary>
        /// Metodo para extraer todos las membresias de la base de datos
        /// </summary>
        /// <param name="_cadenaGenerica">cadena separada por | a buscar</param>
        /// <returns>List de membresias</returns>
        public List<Entidad> ConsultarMembresias(string _cadenaGenerica)
        {
            List<Entidad> _membresias = new List<Entidad>();
            SqlCommand _comando = new SqlCommand("Procedure_consultarMembresias", IniciarConexion());
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.Add(new SqlParameter("@generico", SqlDbType.VarChar));
            _comando.Parameters["@generico"].Value = _cadenaGenerica;
            SqlDataReader _reader;
            Entidad _persona = FabricaEntidad.ObtenerPersona();
            try
            {
                IniciarConexion().Open();
                _reader = _comando.ExecuteReader();
                
                while (_reader.Read())
                {
                    //unicamente los datos que vienen de la base de datos
                    _persona = FabricaEntidad.ObtenerPersona(0, _reader["PER_docIdentidad"].ToString(), _reader["tipoDocumento"].ToString(),
                        _reader["PER_primerNombre"].ToString(), _reader["PER_segundoNombre"].ToString(), _reader["PER_primerApellido"].ToString(),
                        _reader["PER_segundoApellido"].ToString(), DateTime.Now, "04129229123", "cualquiera", null);

                    //membresias sin los pagos asociados
                    _membresias.Add((Membresia)FabricaEntidad.ObtenerMembresia((Persona)_persona, (int)_reader[0], (DateTime)_reader[1], (DateTime)_reader[2],
                        (float)_reader[4], (float)_reader[3], _reader["estadoMembresia"].ToString(), null));

                }
                return _membresias;
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

        public List<Dominio.Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

    }
}