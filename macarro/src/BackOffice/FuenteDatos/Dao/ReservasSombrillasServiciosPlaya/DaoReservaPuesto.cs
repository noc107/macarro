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
    public class DaoReservaPuesto : Dao, IdaoReservaPuesto
    {
        private Entidad _reserva = BackOffice.Dominio.Fabrica.FabricaEntidad.ObtenerReservaReserva_Puesto();

        public List<List<BackOffice.Dominio.Entidad>> ConsultarTodos ()
        {
            return null;
        }

        

        public Boolean Modificar ( Entidad _parametro )
        {
            return false;
        }

        public Boolean Agregar ( Entidad _parametro )
        {
            return false;
        }

        public List<Entidad> ConsultarXId ( int _reservaid )
        {
            string _id = _reservaid.ToString ();
            List<Entidad> _reservas = new List<Entidad> ();
            string _cmd = "select (respues.RES_PUE_id) as ID, (respues.RES_PUE_fecha) as Fecha, (respues.FK_puestoFila) as Fila , (respues.FK_puestoColumna) as Columna " +
                          "from RESERVA res, RESERVA_PUESTO respues " +
                          "where  res.RES_id = " + _id + " and respues.FK_reserva = res.RES_id " +
                          "group by respues.RES_PUE_id, respues.RES_PUE_fecha, respues.FK_puestoFila, respues.FK_puestoColumna";
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

                        _reservas.Add ( _reserva );

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
            return _reservas;
        }

        private ReservaReserva_Puesto ObtenerBDReader ( SqlDataReader objetoBD )
        {
            ReservaReserva_Puesto _reserva = ( ReservaReserva_Puesto ) BackOffice.Dominio.Fabrica.FabricaEntidad.ObtenerReservaReserva_Puesto ();
            try
            {
                _reserva.reservaPuesto_id = objetoBD.GetInt32 ( 0 );
                _reserva.reservaPuesto_fecha = objetoBD.GetDateTime ( 1 );
                _reserva.reservaPuesto_FK_puestoFila = objetoBD.GetInt32 ( 2 );
                _reserva.reservaPuesto_FK_puestoColumna = objetoBD.GetInt32 ( 3 );



            }
            catch ( Exception ex )
            {
                return null;
            }
            return _reserva;
        }
    }
}