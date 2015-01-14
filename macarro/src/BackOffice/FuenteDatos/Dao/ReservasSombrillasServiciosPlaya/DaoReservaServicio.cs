using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.FuenteDatos.IDao.ReservasSombrillasServiciosPlaya;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BackOffice.FuenteDatos.Dao.ReservasSombrillasServiciosPlaya
{
    public class DaoReservaServicio : Dao, IdaoReservaServicio
    {
        private Entidad _reserva = BackOffice.Dominio.Fabrica.FabricaEntidad.ObtenerReservaServicio();

        public List<BackOffice.Dominio.Entidad> ConsultarTodos ()
        {
            return null;
        }

        private ReservaServicio ObtenerBDReader ( SqlDataReader objetoBD )
        {
            ReservaServicio _reserva = ( ReservaServicio ) BackOffice.Dominio.Fabrica.FabricaEntidad.ObtenerReservaServicio();
            try
            {

                _reserva.reservaServicio_id = ( objetoBD.GetInt32 ( 0 ) );
                _reserva.reservaServicio_Nombre = ( objetoBD.GetString ( 1 ).ToString () );
                _reserva.reservaServicio_Cantidad = ( objetoBD.GetInt32 ( 2 ) );
                _reserva.reservaServicio_HoraInicio = ( objetoBD.GetDateTime ( 3 ) );
                _reserva.reservaServicio_HoraFin = ( objetoBD.GetDateTime ( 4 ) );
               
                
                
                
            
            }
            catch ( Exception ex )
            {

            }
            return _reserva;
        }

        public Boolean Modificar ( Entidad _parametro )
        {
            return false;
        }

        public Boolean Agregar ( Entidad _parametro )
        {
            return false;
        }

        public Entidad ConsultarXId ( int _reservaid )
        {
            string _id = _reservaid.ToString ();
            string _cmd = "select (resser.RES_SER_id) as ID,(ser.SER_nombre) as Servicio, (resser.RES_SER_cantidad) as Cantidad, (resser.RES_SER_horaInicio) as Inicio, (resser.RES_SER_horaFin) as Fin " +
                          "from RESERVA res, RESERVA_SERVICIO resser, SERVICIO ser, HORARIO hor " +
                          "where  res.RES_id = " + _id + " and resser.FK_reserva = res.RES_id and resser.FK_horario = hor.HOR_id and hor.FK_servicio = ser.SER_id " +
                          "group by resser.RES_SER_id,ser.SER_nombre,resser.RES_SER_cantidad,resser.RES_SER_horaInicio,resser.RES_SER_horaFin";
            SqlCommand comando = new SqlCommand ( _cmd, IniciarConexion () );



            SqlDataReader _lectura;

            try
            {
                IniciarConexion ().Open ();
                _lectura = comando.ExecuteReader ();

                while ( _lectura.Read () )
                {
                    _reserva = ObtenerBDReader ( _lectura );
                    if ( _reserva != null )
                    {

                        return _reserva ;

                    }
                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine ( ex.ToString () );
            }
            finally
            {
                CerrarConexion ();
            }
            return null;
        }
    }
}