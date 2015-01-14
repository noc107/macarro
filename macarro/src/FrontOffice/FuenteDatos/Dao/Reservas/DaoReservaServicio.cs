using FrontOffice.Dominio;
using FrontOffice.Dominio.Entidades;
using FrontOffice.Dominio.Fabrica;
using FrontOffice.FuenteDatos.IDao.Reservas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FrontOffice.FuenteDatos.Dao.Reservas
{
    public class DaoReservaServicio : Dao, IDaoReservaServicio
    {
        private Entidad _reservaServicio = FabricaEntidad.ObtenerReserva();

        public List<Entidad> ConsultarTodoXCorreo(string _correo)
        {
            List<Entidad> _listaReserva = new List<Entidad>();
            SqlCommand comando = new SqlCommand("ConsultarReservaPorCorreoUsuario", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("_correo", _correo));


            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                while (_lectura.Read())
                {
                    _reservaServicio = ObtenerBDReader(_lectura);
                    if (_reservaServicio != null)
                    {
                        _listaReserva.Add(_reservaServicio);
                    }
                }

                return _listaReserva;
            }
            catch (Exception ex)
            {
                string hola = ex.ToString();
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                CerrarConexion();
            }
            return null;
        }

        private ReservaServicio ObtenerBDReader(SqlDataReader objetoBD)
        {
            ReservaServicio _reservaServicio = (ReservaServicio)FabricaEntidad.ObtenerReservaServicio();
            try
            {
                   _reservaServicio.reservaServicio_id = objetoBD.GetInt32(1);
                   _reservaServicio.reservaServicio_Nombre = objetoBD.GetString(2);
                   _reservaServicio.reservaServicio_HoraInicio = objetoBD.GetDateTime(3);
                   _reservaServicio.reservaServicio_HoraFin = objetoBD.GetDateTime(4);
                   _reservaServicio.reservaServicio_Cantidad = objetoBD.GetInt32(5);
                   _reservaServicio.reservaServicio_Total = Convert.ToInt32(objetoBD.GetDouble(6));
                   _reservaServicio.reservaServicio_FK_Horario = objetoBD.GetInt32(7);
                   _reservaServicio.reservaServicio_FK_Reserva = objetoBD.GetInt32(0);
              }

            catch (Exception ex)
            {
                string s = ex.ToString();
                string c = ex.ToString();

            }
            return _reservaServicio;
        }

        public int ConsultarCantidadServiciosDisponibles(string[] _horario)
        {
            SqlCommand _cmd;
            _cmd = new SqlCommand("CantidadDisponibleServicio", IniciarConexion());
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add(new SqlParameter("@_nombreServicio", _horario[0]));
            _cmd.Parameters.Add(new SqlParameter("@_horaInicio ", _horario[1]));
            _cmd.Parameters.Add(new SqlParameter("@_horaFin", _horario[2]));

            var returnParameter = _cmd.Parameters.Add("@_cantidad", SqlDbType.Int);

            returnParameter.Direction = ParameterDirection.ReturnValue;

            try
            {
                IniciarConexion().Open();
                _cmd.ExecuteNonQuery();
                var _result = returnParameter.Value;
                return (Convert.ToInt32(_result));
            }
            catch (Exception ex)
            {
                string hola = ex.ToString();
                Console.WriteLine(ex.ToString());
                return (-1000);
            }
            finally
            {
                CerrarConexion();
            }

        }

        public Boolean Agregar(Entidad parametro)
        {
            ReservaServicio _rs = (ReservaServicio)parametro;

            SqlCommand _cmd;
            _cmd = new SqlCommand("InsertarReservaServicio", IniciarConexion());
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add(new SqlParameter("@_nombreServicio", _rs.reservaServicio_Nombre));
            _cmd.Parameters.Add(new SqlParameter("@_resHoraInicio", _rs.reservaServicio_HoraInicio));
            _cmd.Parameters.Add(new SqlParameter("@_resHoraFin ", _rs.reservaServicio_HoraFin));
            _cmd.Parameters.Add(new SqlParameter("@_resSerCantidad", _rs.reservaServicio_Cantidad));          
            _cmd.Parameters.Add(new SqlParameter("@_fkResId", _rs.reservaServicio_FK_Reserva));

            try
            {
                IniciarConexion().Open();
                _cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string hola = ex.ToString();
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public Boolean Modificar(Entidad parametro)
        {
            ReservaServicio _rs = (ReservaServicio)parametro;

            SqlCommand _cmd;

            _cmd = new SqlCommand("ModificarReserva", IniciarConexion());
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add(new SqlParameter("@_reservaID", Convert.ToInt32(_rs.reservaServicio_FK_Reserva)));
            _cmd.Parameters.Add(new SqlParameter("@_nombreServicio", _rs.reservaServicio_Nombre));
            _cmd.Parameters.Add(new SqlParameter("@_cantidad", Convert.ToInt32(_rs.reservaServicio_Cantidad)));
            _cmd.Parameters.Add(new SqlParameter("@_horaInicio ", _rs.reservaServicio_HoraInicio));
            _cmd.Parameters.Add(new SqlParameter("@_horaFin", _rs.reservaServicio_HoraFin));

            try
            {
                IniciarConexion().Open();
                _cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string hola = ex.ToString();
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                CerrarConexion();
            }

        }

        public Entidad ConsultarXId(int _id)
        {
            List<Entidad> _listaReserva = new List<Entidad>();
            SqlCommand comando = new SqlCommand("ConsultarReservaPorIDReserva", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("_reservaID ", _id));


            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();

                while (_lectura.Read())
                {
                    _reservaServicio = ObtenerBDReader(_lectura);
                }

                return _reservaServicio;
            }
            catch (Exception ex)
            {
                string hola = ex.ToString();
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                CerrarConexion();
            }
            return null;
        }

        public List<Dominio.Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public List<string> ConsultarServicios()
        {
            List<string> _listaServicios = new List<string>();
            SqlCommand comando = new SqlCommand("ConsultarServicios", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;


            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                while (_lectura.Read())
                {
                    _reservaServicio = ObtenerBDReader(_lectura);
                    if (_reservaServicio != null)
                    {
                        _listaServicios.Add(_lectura.GetString(0));
                    }
                }

                return _listaServicios;
            }
            catch (Exception ex)
            {
                string hola = ex.ToString();
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                CerrarConexion();
            }
            return _listaServicios;
        }

        public int VerificarHorario(string[] _horario)
        {
            SqlCommand _cmd;
            _cmd = new SqlCommand("VerificarHorario", IniciarConexion());
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add(new SqlParameter("@_nombreServicio", _horario[0]));
            _cmd.Parameters.Add(new SqlParameter("@_horaInicio ", _horario[1]));
            _cmd.Parameters.Add(new SqlParameter("@_horaFin", _horario[2]));

            var returnParameter = _cmd.Parameters.Add("@_horarioFLAG", SqlDbType.Int);

            returnParameter.Direction = ParameterDirection.ReturnValue;

            try
            {
                IniciarConexion().Open();
                _cmd.ExecuteNonQuery();
                var _result = returnParameter.Value;
                return (Convert.ToInt32(_result));
            }
            catch (Exception ex)
            {
                string hola = ex.ToString();
                Console.WriteLine(ex.ToString());
                return 0;
            }
            finally
            {
                CerrarConexion();
            }

        }
    }
}