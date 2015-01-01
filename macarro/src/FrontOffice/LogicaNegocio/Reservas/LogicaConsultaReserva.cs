using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FrontOffice.LogicaNegocio.Reservas
{
    public class LogicaConsultaReserva
    {
        string _usuarioEmail;

        public LogicaConsultaReserva (string _email)
        {
            _usuarioEmail = _email;
        }
        public void EjecutarQuerySinRetorno(string _query)
        {
            SqlConnection _cn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\jfand_000\\Documents\\ProyectoDesarrollo2\\macarro\\src\\App_Data\\MACARRO.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand command = new SqlCommand(_query, _cn);
            command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
            _cn.Open();
            SqlDataReader reader = command.ExecuteReader();
        }
        public DataTable EjecutarQuery(string _query)
        {
            SqlDataAdapter _adaptadorSql;
            SqlConnection _cn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\jfand_000\\Documents\\ProyectoDesarrollo2\\macarro\\src\\App_Data\\MACARRO.mdf;Integrated Security=True;Connect Timeout=30");
            _adaptadorSql = new SqlDataAdapter(_query, _cn);
            DataTable _tablaDatos = new DataTable();
            _adaptadorSql.Fill(_tablaDatos);
            _cn.Close();
            return (_tablaDatos);
        }
        public void EliminarReserva(int _reservaId)
        {
            string _queryString =
                "delete from Reserva_puesto where fk_reserva = " + _reservaId;
            EjecutarQuerySinRetorno(_queryString);
            _queryString = "delete from reserva where res_id=" + _reservaId;
            EjecutarQuerySinRetorno(_queryString);
        }
        public DataTable LlenarTabla()
        {
            DataTable _tabla = new DataTable();
            DataTable _auxTabla = new DataTable();
            //manueljos@hotmail.com
            string _queryString =
                "select r.RES_id as reservaid,r.RES_fecha as fecha " +
                "from RESERVA r, USUARIO u " +
                "where r.FK_usuario = u.USU_id and u.USU_correo = '" + _usuarioEmail + "' order by (fecha) asc";// and r.RES_fecha >= SYSDATETIME()";
            _auxTabla = EjecutarQuery(_queryString);

            _tabla.Columns.Add("Reserva", typeof(string));
            _tabla.Columns.Add("Fecha", typeof(string));
            _tabla.Columns.Add("Acciones", typeof(string));
            for (int i = 0; i < _auxTabla.Rows.Count; i++)
                _tabla.Rows.Add(_auxTabla.Rows[i]["reservaid"], DateTime.Parse(_auxTabla.Rows[i]["fecha"].ToString()).ToShortDateString());

            return (_tabla);
        }
    }
}