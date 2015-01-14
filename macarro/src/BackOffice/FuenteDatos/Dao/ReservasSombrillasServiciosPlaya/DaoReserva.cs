using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.FuenteDatos.IDao.ReservasSombrillasServiciosPlaya;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BackOffice.FuenteDatos.Dao.ReservasSombrillasServiciosPlaya
{
    public class DaoReserva:Dao,IdaoReserva
    {
        private Entidad _reserva = BackOffice.Dominio.Fabrica.FabricaEntidad.ObtenerReserva ();
        
        public List<BackOffice.Dominio.Entidad> ConsultarTodos ()
        {
            List<Entidad> _reservas = new List<Entidad>();
            string _cmd = "select (res.RES_id) as ID, (res.RES_fecha) as Fecha, (usu.USU_correo) as Usuario , (est.EST_nombre) as Estado " +
                            "from RESERVA res, ESTADO est, USUARIO usu " +
                            "where  est.EST_id = res.FK_estado and res.FK_usuario = usu.USU_id " +
                            "group by res.RES_id, res.RES_fecha, usu.USU_correo, est.EST_nombre ";
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

        private Reserva ObtenerBDReader ( SqlDataReader objetoBD )
        {
            Reserva _reserva = (Reserva) BackOffice.Dominio.Fabrica.FabricaEntidad.ObtenerReserva ();
            try
            {
                
                _reserva.reserva_id = ( objetoBD.GetInt32 ( 0 ) );
                _reserva.reserva_fecha = ( objetoBD.GetDateTime ( 1 ));
                _reserva.fK__usuario = ( objetoBD.GetString ( 2 ).ToString() );
                _reserva.fK_estado = ( objetoBD.GetString ( 3 ).ToString() );
            }
            catch ( Exception ex )
            {

            }
            return _reserva;
        }

        public Boolean Modificar (Entidad _parametro)
        {

            Reserva _reservaaux = ( Reserva ) _parametro;
            
            
            string _cmd = "update RESERVA  set FK_estado = (select est.EST_id " +
                                 "from  ESTADO est " +
                                 "where est.EST_nombre = '" + _reservaaux.fK_estado + "') " +
                                 "where RES_id = " + _reservaaux.reserva_id.ToString() + "";
            SqlDataAdapter _adp = new SqlDataAdapter ( _cmd, IniciarConexion () );
           

            try
            {
                IniciarConexion ().Open ();
                _adp.UpdateCommand = IniciarConexion().CreateCommand ();
                _adp.UpdateCommand.CommandText = _cmd;
                _adp.UpdateCommand.ExecuteNonQuery ();

                
            }
            catch ( Exception ex )
            {
                return false;
            }
            finally
            {
                CerrarConexion ();
            }
            return true;
        }

        public Boolean Agregar (Entidad _parametro)
        {
            return false;
        }

        public Entidad ConsultarXId (int _reservaid)
        {
            string _id = _reservaid.ToString ();
            
            string _cmd = "select (res.RES_id) as ID, (res.RES_fecha) as Fecha, (usu.USU_correo) as Usuario , (est.EST_nombre) as Estado " +
                            "from RESERVA res, ESTADO est, USUARIO usu " +
                            "where  est.EST_id = res.FK_estado and res.FK_usuario = usu.USU_id  and res.RES_id = "+_id+"" +
                            "group by res.RES_id, res.RES_fecha, usu.USU_correo, est.EST_nombre ";
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