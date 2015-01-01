using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Reservas
{
    public class LogicaNegocio_13_ReservaServicio
    {
        public DataTable ConsultarServicios()
        {
            DataTable _tablaDatos = new DataTable();
            SqlConnection _cn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\jfand_000\\Documents\\ProyectoDesarrollo2\\macarro\\src\\App_Data\\MACARRO.mdf;Integrated Security=True;Connect Timeout=30");

            SqlDataAdapter _adaptadorSql;

            _adaptadorSql = new SqlDataAdapter("EXEC ConsultarServicios", _cn);
            _adaptadorSql.Fill(_tablaDatos);

            return _tablaDatos;


        }

        public  int ConsultarCantidadServicios(string _nombreServicio, string _horaInicio, string _horaFin)
        {
            DataTable _tablaDatos = new DataTable();
            SqlConnection _cn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\jfand_000\\Documents\\ProyectoDesarrollo2\\macarro\\src\\App_Data\\MACARRO.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand _cmd;
            _cn.Open();
            _cmd = new SqlCommand("CantidadDisponibleServicio", _cn);
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add(new SqlParameter("@_nombreServicio", _nombreServicio));
            _cmd.Parameters.Add(new SqlParameter("@_horaInicio ",_horaInicio));
            _cmd.Parameters.Add(new SqlParameter("@_horaFin", _horaFin));
            var returnParameter = _cmd.Parameters.Add("@_cantidad", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            _cmd.ExecuteNonQuery();

            _cmd.ExecuteNonQuery();
            var _result = returnParameter.Value;
            _cn.Close();

            return Convert.ToInt32(_result);

        }

        public  void InsertarReservaServicio(string _correo, string _estado, string _nombreServicio, string _horaInicio, string _horaFin, string _cantidad)
        {

            SqlConnection _cn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\jfand_000\\Documents\\ProyectoDesarrollo2\\macarro\\src\\App_Data\\MACARRO.mdf;Integrated Security=True;Connect Timeout=30");

            SqlCommand _cmd;
            _cn.Open();
            _cmd = new SqlCommand("InsertarReservaServicio", _cn);
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add(new SqlParameter("@_correo", _correo));
            _cmd.Parameters.Add(new SqlParameter("@_Estado", _estado));
            _cmd.Parameters.Add(new SqlParameter("@_nombreServicio",_nombreServicio));
            _cmd.Parameters.Add(new SqlParameter("@_reshoraInicio ",_horaInicio));
            _cmd.Parameters.Add(new SqlParameter("@_reshoraFin ",_horaFin));
            _cmd.Parameters.Add(new SqlParameter("@_resSerCantidad ",Convert.ToInt32(_cantidad)));


            _cmd.ExecuteNonQuery();

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

    }
}