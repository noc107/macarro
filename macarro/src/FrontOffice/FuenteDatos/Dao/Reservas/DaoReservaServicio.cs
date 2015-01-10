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


        public List<Entidad> ConsultarReservaServicioXCorreo(string _correo)
        {
            List<Entidad> _listaReservaServicio = new List<Entidad>();
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

        private Reserva ObtenerBDReader(SqlDataReader objetoBD)
        {
            Reserva _reservaServicio = (Reserva)FabricaEntidad.ObtenerReserva();
            try
            {
                if (objetoBD.GetInt32(0) != 0)
                {
                    _reservaServicio.reserva_id = objetoBD.GetInt32(0);
                }
                else
                {
                    _reservaServicio.reserva_id = 0;
                }


                if (objetoBD.GetString(1) != null)
                {
                    _reservaServicio.reserva_Servicio.reservaServicio_Nombre = objetoBD.GetString(1);
                }
                else
                {
                    _reservaServicio.reserva_Servicio.reservaServicio_Nombre = string.Empty;
                }


                if (objetoBD.GetDateTime(2) != null)
                {
                    _reservaServicio.reserva_Servicio.reservaServicio_HoraInicio = objetoBD.GetDateTime(2);
                }
                else
                {
                    _reservaServicio.reserva_Servicio.reservaServicio_HoraInicio = System.DateTime.Now;
                }


                if (objetoBD.GetDateTime(3) != null)
                {
                    _reservaServicio.reserva_Servicio.reservaServicio_HoraFin = objetoBD.GetDateTime(3);
                }
                else
                {
                    _reservaServicio.reserva_Servicio.reservaServicio_HoraFin = System.DateTime.Now;
                }

                if (objetoBD.GetInt32(4) != 0)
                {
                    _reservaServicio.reserva_Servicio.reservaServicio_Cantidad = objetoBD.GetInt32(4);
                }
                else
                {
                    _reservaServicio.reserva_Servicio.reservaServicio_Cantidad = 0;
                }


                if (objetoBD.GetDouble(5)!= null)
                {
                    _reservaServicio.reserva_Servicio.reservaServicio_Total = Convert.ToInt32(objetoBD.GetDouble(5));
                }
                else
                {
                    _reservaServicio.reserva_Servicio.reservaServicio_Total = 0;
                }


                if (objetoBD.GetString(6) != null)
                {
                    _reservaServicio.fK_estado = objetoBD.GetString(6);
                }
                else
                {
                    _reservaServicio.fK_estado = string.Empty;
                }


            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                string c = ex.ToString();

            }
            return _reservaServicio;
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