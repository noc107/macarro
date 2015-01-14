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
    public class DaoPago : Dao, IDaoPago
    {
        private  List<Pago> _pagos = new List<Pago>();
        DaoMembresia _daoMEMB = new DaoMembresia();

        /// <summary>
        /// Metodo para extraer todos los pagos de la base de datos
        /// </summary>
        /// <param name="_cadenaGenerica">cadena separada por | a buscar</param>
        /// <returns>List de pagos</returns>
        public List<Entidad> ConsultarPagos(string _cadenaGenerica)
        {
            List<Entidad> _membresias = new List<Entidad>();
            SqlCommand _comando = new SqlCommand("Procedure_consultarPagos", IniciarConexion());
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

                    _pagos = _daoMEMB.CargarPagos((int)_reader[3]);

                    //membresias con los pagos asociados
                    _membresias.Add((Membresia)FabricaEntidad.ObtenerMembresia((Persona)_persona, (int)_reader[0], _pagos));
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

        /// <summary>
        ///  Metodo para leer el detalle de un pago
        /// </summary>
        /// <param name="id">membresia asociada al pago a leer</param>
        /// <returns>la membresia completa con los pagos</returns>
        public Dominio.Entidad ConsultarXId(int _id)//membresia con todos los pagos asociados en una lista
        {
            return _daoMEMB.ConsultarXId(_id);//devuelve lo mismo que consutarxid de membresia
        }
        


        bool IDao.IDao<Entidad, bool, Entidad>.Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public List<Dominio.Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        bool IDao.IDao<Entidad, bool, Entidad>.Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }
    }
}