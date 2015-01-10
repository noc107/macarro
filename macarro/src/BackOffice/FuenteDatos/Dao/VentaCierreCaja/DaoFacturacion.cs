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
using System.Globalization;
using System.Linq;
using System.Web;

namespace BackOffice.FuenteDatos.Dao.VentaCierreCaja
{
    public class DaoFacturacion:Dao,IDaoFacturacion
    {
        public string ConsultarCorreos()
        {
            string _listaCorreos = String.Empty;

            try
            {
                SqlCommand comando = new SqlCommand(RecursosDaoCierreCaja.ProcedimientoConsultarCorreosClientes, IniciarConexion());
                comando.CommandType = CommandType.StoredProcedure;

                SqlDataReader lector;

                IniciarConexion().Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    _listaCorreos += (string)lector["USU_correo"];
                    _listaCorreos += " ";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally{
                CerrarConexion();
            }

            return _listaCorreos;
        }

        public bool Agregar(Dominio.Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Dominio.Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public Dominio.Entidad ConsultarXId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Dominio.Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }


        public Entidad VerificarCorreo(string _correoUsuario)
        {

            Entidad _usuario = null;
            try
            {
                SqlCommand comando = new SqlCommand(RecursosDaoCierreCaja.ProcedimientoVerificarCorreo, IniciarConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter(RecursosDaoCierreCaja.ParametroCorreo, _correoUsuario));

                SqlDataReader lector;

                IniciarConexion().Open();
                lector = comando.ExecuteReader();

                if (!lector.HasRows)
                    throw new UserNotFoundExcepcion(RecursosMensajesExcepciones.MensajeUsuarioNoEncontrado);
                else
                {
                    while (lector.Read())
                        _usuario = FabricaEntidad.ObtenerPersona((string)lector["PER_primerNombre"], (string)lector["PER_primerApellido"], (string)lector["PER_docIdentidad"]);
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

            return _usuario;
        }


        public List<Entidad> ConsultarDetalleServicio(string _correoUsuario)
        {
            Entidad _servicio = null;
            List<Entidad> _listaServicios = new List<Entidad>();
            try
            {
                SqlCommand comando = new SqlCommand(RecursosDaoCierreCaja.ProcedimientoGridServicios, IniciarConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter(RecursosDaoCierreCaja.ParametroCorreo, _correoUsuario));

                SqlDataReader lector;

                IniciarConexion().Open();
                lector = comando.ExecuteReader();

                if (!lector.HasRows)
                    throw new DataNoDisponibleExcepcion(RecursosMensajesExcepciones.MensajeBaseDatosVacia);
                else
                {
                    while (lector.Read())
                    {
              
                        string _precio = lector["Precio"].ToString();
                        float _precioSer = float.Parse(_precio, CultureInfo.InvariantCulture.NumberFormat);


                        _servicio = FabricaEntidad.ObtenerLineaFacturaServicio(lector["Servicio"].ToString(), _precioSer, (int)lector["ID"], (string)lector["Tipo"].ToString());
                        _listaServicios.Add(_servicio);
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

            return _listaServicios;
        }
    }
}