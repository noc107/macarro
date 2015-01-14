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
    public class DaoReserva : Dao , IDaoReserva
    {
        private Entidad _reserva = FabricaEntidad.ObtenerReserva();

        public bool InsertarReservaSinSecuencia(string[] data)
        {
            SqlCommand comando = new SqlCommand("InsertarReservaSinSecuencia", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("_reservaId", int.Parse(data[0])));
            comando.Parameters.Add(new SqlParameter("_fecha", data[1]));
            comando.Parameters.Add(new SqlParameter("_usu", data[2]));
            try
            {
                IniciarConexion().Open();
                comando.ExecuteNonQuery();
                return (true);
            }
            catch (Exception ex)
            {
                string hola = ex.ToString();
                Console.WriteLine(ex.ToString());
                return (false);
            }
            finally
            {
                CerrarConexion();
            }
        }

        public int ObtenerSecuencia()
        {
            List<Entidad> _listaReservaServicio = new List<Entidad>();
            SqlCommand comando = new SqlCommand("SecuenciaDeReserva", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;

            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                _lectura.Read();
                return _lectura.GetInt32(0);
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
            return 0; 
        }

        public List<Entidad> ConsultarReservasMayorANow(string _correo)
        {
            List<Entidad> _listaReservaServicio = new List<Entidad>();
            SqlCommand comando = new SqlCommand("ConsultarReservaMayorANow", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("_correo", _correo));
            Entidad _reservaServicio;

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
                        _listaReservaServicio.Add(_reservaServicio);
                    }
                }

                return _listaReservaServicio;
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

        public bool EliminarReserva(int _idReserva)
        {
            List<Entidad> _listaReservaPuesto = new List<Entidad>();
            SqlCommand comando = new SqlCommand("EliminarReservaPorID", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("_reservaID", _idReserva));
            try
            {
                IniciarConexion().Open();
                comando.ExecuteNonQuery();
                return (true);
            }
            catch (Exception ex)
            {
                string hola = ex.ToString();
                Console.WriteLine(ex.ToString());
                return (false);
            }
            finally
            {
                CerrarConexion();
            }
        }

        private Reserva ObtenerBDReader(SqlDataReader objetoBD)
        {
            Reserva _reserva = (Reserva)FabricaEntidad.ObtenerReserva();
            try
            {
                _reserva.reserva_id = objetoBD.GetInt32(0);
                _reserva.reserva_fecha = objetoBD.GetDateTime(1);
                _reserva.fK__usuario = objetoBD.GetString(3);
                _reserva.fK_estado = objetoBD.GetString(2);
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                string c = ex.ToString();

            }
            return _reserva;
        }

        public Boolean Agregar(Entidad parametro)
        {
            Reserva _r = (Reserva) parametro;

            SqlCommand _cmd;
            _cmd = new SqlCommand("Procedure_insertarReserva", IniciarConexion());
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add(new SqlParameter("@_resId", _r.reserva_id));
            _cmd.Parameters.Add(new SqlParameter("@_resFecha", _r.reserva_fecha));
            _cmd.Parameters.Add(new SqlParameter("@_fkUsuario ", _r.fK__usuario));
            _cmd.Parameters.Add(new SqlParameter("@_fkEstado ", _r.fK_estado));

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

        public Boolean ModificarStatusReserva(Entidad parametro)
        {
            try
            {
                Reserva _r = (Reserva)parametro;

                int _reservaIDQuery = _r.reserva_id;
                string _estadoReserva = _r.fK_estado;

                SqlCommand _cmd;

                IniciarConexion().Open();

                _cmd = new SqlCommand("Procedure_cambiarStatusReserva", IniciarConexion());
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Parameters.Add(new SqlParameter("@_resID", Convert.ToInt32(_reservaIDQuery)));
                _cmd.Parameters.Add(new SqlParameter("@_estadoReserva", _estadoReserva));


                _cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public Boolean Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public Entidad ConsultarXId(int _id)
        {
            SqlCommand comando = new SqlCommand("ConsultarSoloReservaPorID", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("_reservaID ", _id));


            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();

                while (_lectura.Read())
                {

                    _reserva = ObtenerBDReader(_lectura);
                }

                return _reserva;
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

    }
}