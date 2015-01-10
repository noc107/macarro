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
            Reserva _reservaPlayaPuesto = (Reserva)FabricaEntidad.ObtenerReserva();
            try
            {
                _reservaPlayaPuesto.reserva_id = objetoBD.GetInt32(0);
                _reservaPlayaPuesto.reserva_fecha = objetoBD.GetDateTime(1);
                _reservaPlayaPuesto.fK__usuario = objetoBD.GetString(2);
                _reservaPlayaPuesto.fK_estado = objetoBD.GetString(3);
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                string c = ex.ToString();

            }
            return _reservaPlayaPuesto;
        }

        public Boolean Agregar(Entidad parametro)
        {
            return true;
        }

        public Boolean Modificar(Entidad parametro)
        {
            return true;
        }

        public Entidad ConsultarXId(int _id)
        {
            return null;
        }

        public List<Dominio.Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
    }
}