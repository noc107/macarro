using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.ReservasSombrillasServiciosPlaya
{
    public class logica_13_consultar
    {

        public logica_13_consultar ()
        {

        }



        SqlConnection _conn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\jfand_000\\Documents\\ProyectoDesarrollo2\\macarro\\src\\App_Data\\MACARRO.mdf;Integrated Security=True;Connect Timeout=30");

        public DataTable GetReservas ()
        {


            DataTable _dt = new DataTable ();
            string _cmd = "select (res.RES_id) as ID, (res.RES_fecha) as Fecha, (usu.USU_correo) as Usuario , (est.EST_nombre) as Estado " +
                            "from RESERVA res, ESTADO est, USUARIO usu " +
                            "where  est.EST_id = res.FK_estado and res.FK_usuario = usu.USU_id " +
                            "group by res.RES_id, res.RES_fecha, usu.USU_correo, est.EST_nombre ";
            SqlDataAdapter _adp = new SqlDataAdapter ( _cmd, _conn );
            _adp.Fill ( _dt );

         
                return _dt;
           
        }

        public DataTable GetReservasPuesto ( string _id )
        {


            DataTable _dt = new DataTable ();
            string _cmd = "select (respues.RES_PUE_id) as ID, (respues.RES_PUE_fecha) as Fecha, (respues.FK_puestoFila) as Fila , (respues.FK_puestoColumna) as Columna " +
                          "from RESERVA res, RESERVA_PUESTO respues " +
                          "where  res.RES_id = " + _id + " and respues.FK_reserva = res.RES_id " +
                          "group by respues.RES_PUE_id, respues.RES_PUE_fecha, respues.FK_puestoFila, respues.FK_puestoColumna";
            SqlDataAdapter _adp = new SqlDataAdapter ( _cmd, _conn );
            _adp.Fill ( _dt );

            if ( _dt.Rows.Count > 0 )
                return _dt;
            else return null;
        }

        public DataTable GetReservasServicio ( string _id )
        {


            DataTable _dt = new DataTable ();
            string _cmd = "select (resser.RES_SER_id) as ID,(ser.SER_nombre) as Servicio, (resser.RES_SER_cantidad) as Cantidad, (resser.RES_SER_horaInicio) as Inicio, (resser.RES_SER_horaFin) as Fin " +
                          "from RESERVA res, RESERVA_SERVICIO resser, SERVICIO ser, HORARIO hor " +
                          "where  res.RES_id = " + _id + " and resser.FK_reserva = res.RES_id and resser.FK_horario = hor.HOR_id and hor.FK_servicio = ser.SER_id " +
                          "group by resser.RES_SER_id,ser.SER_nombre,resser.RES_SER_cantidad,resser.RES_SER_horaInicio,resser.RES_SER_horaFin";
            SqlDataAdapter _adp = new SqlDataAdapter ( _cmd, _conn );
            _adp.Fill ( _dt );

            if ( _dt.Rows.Count > 0 )
                return _dt;
            else return null;
        }

        public DataTable  GetReserva ( string _id )
        {
            DataTable _dt = new DataTable ();
            string _cmd = "select est.EST_nombre "+
                          "from RESERVA res, ESTADO est "+
                          "where  res.RES_id = "+_id+" and res.FK_estado = est.EST_id "+
                          "group by est.EST_nombre ";
            SqlDataAdapter _adp = new SqlDataAdapter ( _cmd, _conn );
            _adp.Fill ( _dt );
            return _dt;
       }

        public DataTable GetReservaFecha ( string _id )
        {
            DataTable _dt = new DataTable ();
            string _cmd = "select distinct Fecha = "+ 
                          "case "+
                          "when respues.FK_reserva = res.RES_id then (respues.RES_PUE_fecha) "+
                          "when resser.FK_reserva = res.RES_id then (resser.RES_SER_horaInicio) "+
                          "end "+
                          "from RESERVA res, ESTADO est , RESERVA_PUESTO respues, RESERVA_SERVICIO resser "+
                          "where  res.RES_id = "+_id+" and (respues.FK_reserva = res.RES_id or resser.FK_reserva = res.RES_id)  ";
            SqlDataAdapter _adp = new SqlDataAdapter ( _cmd, _conn );
            _adp.Fill ( _dt );
            return _dt;
        }

        public bool EstadoReserva (string _id, string _estado)
        {
            string _cmd =        "update RESERVA  set FK_estado = (select est.EST_id "+
                                 "from  ESTADO est "+
								 "where est.EST_nombre = '"+_estado+"') "+
                                 "where RES_id = "+_id+"" ;
            SqlDataAdapter _adp = new SqlDataAdapter ( _cmd, _conn );
            _conn.Open ();
            _adp.UpdateCommand = _conn.CreateCommand ();
            _adp.UpdateCommand.CommandText = _cmd;
            _adp.UpdateCommand.ExecuteNonQuery ();

            return true;
        }
    }
}