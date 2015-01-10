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
    public class DaoReservaReserva_Puesto : Dao, IDaoReservaReserva_Puesto
    {

        public bool EliminarReservaReserva_PuestoXIdReserva(int _idReserva)
        {
            List<Entidad> _listaReservaPuesto = new List<Entidad>();
            SqlCommand comando = new SqlCommand("EliminarReserva_ReservaPuesto", IniciarConexion());
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

        public bool EliminarReservaReserva_PuestoXIdReservaXFilaXColumna(int[] data)
        {
            List<Entidad> _listaReservaPuesto = new List<Entidad>();
            SqlCommand comando = new SqlCommand("EliminarReserva_ReservaPuestoPorFactores", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("_reservaID", data[0]));
            comando.Parameters.Add(new SqlParameter("_fila", data[2]));
            comando.Parameters.Add(new SqlParameter("_columna", data[1]));
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

        public bool InsertarReservaReserva_PuestoSinInventario(ReservaReserva_Puesto origen)
        {
            List<Entidad> _listaReservaPuesto = new List<Entidad>();
            SqlCommand comando = new SqlCommand("Procedure_insertarTablaReservaPuesto", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("_resFecha", origen.reservaPuesto_fecha.ToShortDateString()));
            comando.Parameters.Add(new SqlParameter("_resId", origen.reservaPuesto_FK_reserva));
            comando.Parameters.Add(new SqlParameter("_fila", origen.reservaPuesto_FK_puestoFila));
            comando.Parameters.Add(new SqlParameter("_columna", origen.reservaPuesto_FK_puestoColumna));
            comando.Parameters.Add(new SqlParameter("_playa", origen.reservaPuesto_FK_playa));
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
        public List<Entidad> ConsultarReservaReserva_PuestoXidplayaXidreserva(int[] data)
        {
            List<Entidad> _listaPuesto = new List<Entidad>();
            SqlCommand comando;
            comando = new SqlCommand("ConsultarReserva_ReservaPuesto", IniciarConexion());
            comando.Parameters.Add(new SqlParameter("_playaid", data[0]));
            comando.Parameters.Add(new SqlParameter("_previaReserva", data[1]));
            comando.CommandType = CommandType.StoredProcedure;

            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                while (_lectura.Read())
                {
                    ReservaReserva_Puesto _reservaPuestoPlaya = ObtenerBDReader(_lectura);
                    if (_reservaPuestoPlaya != null)
                    {
                        _listaPuesto.Add(_reservaPuestoPlaya);
                    }
                }

                return _listaPuesto;
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
        public List<Entidad> ConsultarReservaReserva_PuestoXidplayaXinicioXfin(string[] data)
        {
            List<Entidad> _listaPuesto = new List<Entidad>();
            SqlCommand comando;
            comando = new SqlCommand("ConsultarReserva_Reserva_Puesto_Fecha", IniciarConexion());
            comando.Parameters.Add(new SqlParameter("_playaid", int.Parse(data[0])));
            comando.Parameters.Add(new SqlParameter("_fechai", DateTime.Parse(data[1])));
            comando.Parameters.Add(new SqlParameter("_fechaf", DateTime.Parse(data[2])));
            comando.CommandType = CommandType.StoredProcedure;

            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                while (_lectura.Read())
                {
                    ReservaReserva_Puesto _reservaPuestoPlaya = ObtenerBDReader(_lectura);
                    if (_reservaPuestoPlaya != null)
                    {
                        _listaPuesto.Add(_reservaPuestoPlaya);
                    }
                }

                return _listaPuesto;
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
        private ReservaReserva_Puesto ObtenerBDReader(SqlDataReader objetoBD)
        {
            ReservaReserva_Puesto _reservaReser_Puesto = (ReservaReserva_Puesto)FabricaEntidad.ObtenerReservaReserva_Puesto();
            try
            {
                _reservaReser_Puesto.reservaPuesto_id = objetoBD.GetInt32(0);
                _reservaReser_Puesto.reservaPuesto_fecha = objetoBD.GetDateTime(1);
                _reservaReser_Puesto.reservaPuesto_FK_reserva = objetoBD.GetInt32(2);
                _reservaReser_Puesto.reservaPuesto_FK_puestoFila = objetoBD.GetInt32(3);
                _reservaReser_Puesto.reservaPuesto_FK_puestoColumna = objetoBD.GetInt32(4);
                _reservaReser_Puesto.reservaPuesto_FK_inventario = objetoBD.GetInt32(5);
                _reservaReser_Puesto.reservaPuesto_FK_playa = objetoBD.GetInt32(6);
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                string c = ex.ToString();

            }
            return _reservaReser_Puesto;
        }

        public Boolean Agregar(Entidad parametro)
        {
            return true;
        }

        public Boolean Modificar(Entidad parametro)
        {
            return true;
            /*            string _queryString =
                "select fk_inventario i " +
                "from puesto p " +
                "where p.pue_fila = " + _fila + " and p.pue_columna = " + _columna + " and fk_playa = " + _idPlaya;
            DataTable tabla = EjecutarQuery(_queryString);
            for (int i = 0; i < tabla.Rows.Count;i++)
                EjecutarQuerySinRetorno( "insert into RESERVA_PUESTO values " +
                "(NEXT VALUE FOR RESERVA_PUESTO_SEQ,'" + _fecha.ToShortDateString() + "'," + _reservaID +
                "," + _fila + "," + _columna + "," + int.Parse(tabla.Rows[i]["i"].ToString()) + "," + _idPlaya + ")");*/
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