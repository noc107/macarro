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
    public class DaoReservaPuesto : Dao , IDaoReservaPuesto
    {

        public bool EliminarReservaPuesto(int _id)
        {
            return (false);
        }
        public List<Entidad> ConsultarReservaPlayaPuestoXidPlaya(int _idplaya)
        {
            List<Entidad> _listaReservaPuesto = new List<Entidad>();
            SqlCommand comando = new SqlCommand("ConsultarReserva_PlayaPuesto", IniciarConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("_playaid", _idplaya));


            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = comando.ExecuteReader();
                while (_lectura.Read())
                {
                    ReservaPuesto _reservaPuestoPlaya = ObtenerBDReader(_lectura);
                    if (_reservaPuestoPlaya != null)
                    {
                        _listaReservaPuesto.Add(_reservaPuestoPlaya);
                    }
                }

                return _listaReservaPuesto;
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

        private ReservaPuesto ObtenerBDReader(SqlDataReader objetoBD)
        {
            ReservaPuesto _reservaPlayaPuesto = (ReservaPuesto)FabricaEntidad.ObtenerReservaPuesto();
            try
            {
                _reservaPlayaPuesto.reservaPuesto_puestoFila = objetoBD.GetInt32(0);
                _reservaPlayaPuesto.reservaPuesto_puestoColumna = objetoBD.GetInt32(1);
                _reservaPlayaPuesto.reservaPuesto_Descripcion = objetoBD.GetString(2);
                _reservaPlayaPuesto.reservaPuesto_precio = (float)objetoBD.GetDouble(3);
                _reservaPlayaPuesto.reservaPuesto_FK_estado = objetoBD.GetInt32(4);
                _reservaPlayaPuesto.reservaPuesto_FK_inventario = objetoBD.GetInt32(5);
                _reservaPlayaPuesto.reservaPuesto_FK_playa = objetoBD.GetInt32(6);
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