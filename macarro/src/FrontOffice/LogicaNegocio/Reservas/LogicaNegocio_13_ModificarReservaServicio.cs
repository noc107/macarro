using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Reservas
{
    public class LogicaNegocio_13_ModificarReservaServicio
    {
        
        public  DataTable ConsultarReservaPorIdBD(string _reservaID)
        {
            DataTable _tablaDatos = new DataTable();
            SqlConnection _cn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\jfand_000\\Documents\\ProyectoDesarrollo2\\macarro\\src\\App_Data\\MACARRO.mdf;Integrated Security=True;Connect Timeout=30");

            SqlDataAdapter _adaptadorSql;

            int _reservaIDQuery = Convert.ToInt32(_reservaID);

            _adaptadorSql = new SqlDataAdapter("EXEC ConsultarReservaPorIDReserva '" + _reservaIDQuery + "'", _cn);
            _adaptadorSql.Fill(_tablaDatos);

            return _tablaDatos;


        }

        public void ModificarReserva(string _reservaID, string _horaInicio, string _horaFin, string _nombreServicio, string _cantidad, string _fecha)
        {
            //DataTable _tablaDatos = new DataTable();
            SqlConnection _cn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\jfand_000\\Documents\\ProyectoDesarrollo2\\macarro\\src\\App_Data\\MACARRO.mdf;Integrated Security=True;Connect Timeout=30");

            SqlCommand _cmd;
            _cn.Open();
            _cmd = new SqlCommand("ModificarReserva", _cn);
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add(new SqlParameter("@_reservaID", Convert.ToInt32(_reservaID)));
            _cmd.Parameters.Add(new SqlParameter("@_nombreServicio", _nombreServicio));
            _cmd.Parameters.Add(new SqlParameter("@_cantidad", Convert.ToInt32(_cantidad)));
            _cmd.Parameters.Add(new SqlParameter("@_horaInicio ", _fecha +" "+_horaInicio));
            _cmd.Parameters.Add(new SqlParameter("@_horaFin", _fecha + " " + _horaFin));


           _cmd.ExecuteNonQuery();


        }

        public DataTable ConsultarServicios()
        {
            DataTable _tablaDatos = new DataTable();
            SqlConnection _cn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\jfand_000\\Documents\\ProyectoDesarrollo2\\macarro\\src\\App_Data\\MACARRO.mdf;Integrated Security=True;Connect Timeout=30");

            SqlDataAdapter _adaptadorSql;

            _adaptadorSql = new SqlDataAdapter("EXEC ConsultarServicios", _cn);
            _adaptadorSql.Fill(_tablaDatos);

            return _tablaDatos;


        }

        public int ConsultarHorarioServicios(string _nombreServicio, string _horaInicio, string _horaFin)
        {
            DataTable _tablaDatos = new DataTable();
            SqlConnection _cn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\jfand_000\\Documents\\ProyectoDesarrollo2\\macarro\\src\\App_Data\\MACARRO.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand _cmd;
            _cn.Open();
            _cmd = new SqlCommand("VerificarHorario", _cn);
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add(new SqlParameter("@_horaInicio ", _horaInicio));
            _cmd.Parameters.Add(new SqlParameter("@_horaFin", _horaFin));
            _cmd.Parameters.Add(new SqlParameter("@_nombreServicio", _nombreServicio));
            var returnParameter = _cmd.Parameters.Add("@_flag", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            _cmd.ExecuteNonQuery();

            _cmd.ExecuteNonQuery();
            var _result = returnParameter.Value;
            _cn.Close();

            return Convert.ToInt32(_result);

        }

        public int ConsultarCantidadServicios(string _nombreServicio, string _horaInicio, string _horaFin)
        {
            DataTable _tablaDatos = new DataTable();
            SqlConnection _cn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\jfand_000\\Documents\\ProyectoDesarrollo2\\macarro\\src\\App_Data\\MACARRO.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand _cmd;
            _cn.Open();
            _cmd = new SqlCommand("CantidadDisponibleServicio", _cn);
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add(new SqlParameter("@_nombreServicio", _nombreServicio));
            _cmd.Parameters.Add(new SqlParameter("@_horaInicio ", _horaInicio));
            _cmd.Parameters.Add(new SqlParameter("@_horaFin", _horaFin));
            var returnParameter = _cmd.Parameters.Add("@_cantidad", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            _cmd.ExecuteNonQuery();

            _cmd.ExecuteNonQuery();
            var _result = returnParameter.Value;
            _cn.Close();

            return Convert.ToInt32(_result);

        }
    }
}