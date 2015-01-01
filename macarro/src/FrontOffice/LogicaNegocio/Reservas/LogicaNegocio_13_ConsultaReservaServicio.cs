using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Reservas
{
    public class LogicaNegocio_13_ConsultaReservaServicio
    {
        public static DataTable ConsultarReservaServicioBD(string _correo)
        {
            DataTable _tablaDatos = new DataTable();
            SqlConnection  _cn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\jfand_000\\Documents\\ProyectoDesarrollo2\\macarro\\src\\App_Data\\MACARRO.mdf;Integrated Security=True;Connect Timeout=30");

            SqlDataAdapter _adaptadorSql;

            string _correoQuery = _correo;

            _adaptadorSql = new SqlDataAdapter("EXEC ConsultarReservaPorCorreoUsuario '" + _correoQuery + "'", _cn);
            _adaptadorSql.Fill(_tablaDatos);

            return _tablaDatos;


        }
        //CAMBIAR ESTADO DE RESERVA A CANCELADO
        public static DataTable EliminarServicioBD(string _reservaID)
        {
            DataTable _tablaDatos = new DataTable();
            SqlConnection _cn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\jfand_000\\Documents\\ProyectoDesarrollo2\\macarro\\src\\App_Data\\MACARRO.mdf;Integrated Security=True;Connect Timeout=30");

            SqlDataAdapter _adaptadorSql;

            int _reservaIDQuery = Convert.ToInt32(_reservaID);

            _adaptadorSql = new SqlDataAdapter("EXEC ModificarEstadoReserva '" + _reservaIDQuery + "'," + "'Cancelado'", _cn);
            _adaptadorSql.Fill(_tablaDatos);

            return _tablaDatos;


        }
    }
}