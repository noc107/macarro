using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Reservas
{
    public class LogicaReserva
    {
        const int PUESTO_OCUPADO = 2;
        const int PUESTO_ACTIVO = 1;
        const int PUESTO_INACTIVO = 0;
        public class Puesto
        {
            public int _estado;
            public float _valor;
            public Puesto()
            {
                _estado = 0;
                _valor = 0;
            }
            public Puesto(int estado,float valor)
            {
                _estado = estado;
                _valor = valor;
            }
        }
        public DateTime _fecha;
        public int _idPlaya;
        public string _usuario;
        public string NombreDeEstado(int estado)
        {
            switch (estado)
            {
                case (PUESTO_INACTIVO):
                    return ("Inactivo");
                case (PUESTO_ACTIVO):
                    return ("Disponible");
                case (PUESTO_OCUPADO):
                    return ("Ocupado");
            }
            return ("No pertenece al rango de valores");
        }
        public LogicaReserva(DateTime _f, int _idplaya , string _auxUsuario)
        {
            _fecha = _f;
            _idPlaya = _idplaya;
            _usuario = _auxUsuario;
        }
        public void EjecutarQuerySinRetorno(string _query)
        {
            SqlConnection _cn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\jfand_000\\Documents\\ProyectoDesarrollo2\\macarro\\src\\App_Data\\MACARRO.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand command = new SqlCommand(_query, _cn);
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
        public int[] DimensionPlaya()
        {
            string _queryString =
                "select p.PLA_fila as f,p.PLA_columna as c " +
                "from PLAYA p " +
                "where p.PLA_ID = " + _idPlaya;
            DataTable _tablaDatos = EjecutarQuery(_queryString);
            _tablaDatos = EjecutarQuery(_queryString);
            int[] _dimension = new int[2];
            _dimension[0] = int.Parse(_tablaDatos.Rows[0]["c"].ToString());
            _dimension[1] = int.Parse(_tablaDatos.Rows[0]["f"].ToString());
            return (_dimension);
        }
        public void EliminarPuesto(int _reservaID, int _columna, int _fila)
        {
            string _queryString =
                "delete from RESERVA_PUESTO " +
                "where fk_playa=" + _idPlaya + " and fk_reserva = " + _reservaID + " and fk_puestofila = "+
                _fila+" and fk_puestocolumna = "+_columna;
            EjecutarQuerySinRetorno(_queryString);
        }
        public void AgregarPuesto(int _reservaID, int _columna, int _fila)
        {
            string _queryString =
                "select fk_inventario i " +
                "from puesto p " +
                "where p.pue_fila = " + _fila + " and p.pue_columna = " + _columna + " and fk_playa = " + _idPlaya;
            DataTable tabla = EjecutarQuery(_queryString);
            for (int i = 0; i < tabla.Rows.Count;i++)
                EjecutarQuerySinRetorno( "insert into RESERVA_PUESTO values " +
                "(NEXT VALUE FOR RESERVA_PUESTO_SEQ,'" + _fecha.ToShortDateString() + "'," + _reservaID +
                "," + _fila + "," + _columna + "," + int.Parse(tabla.Rows[i]["i"].ToString()) + "," + _idPlaya + ")");
        }
        public bool Existe(int[] _item,List<int[]> _target)
        {
            for (int i = 0; i < _target.Count; i++)
                if (_target[i][0] == _item[0] && _target[i][1] == _item[1])
                    return (true);
            return (false);
        }
        public void ModificarReserva(int _reservaID, Puesto[,] _puestos)
        {
            List<int[]> _coordenadas = new List<int[]>();
            for (int i = 0; i < _puestos.GetLength(1); i++)
                for (int i2 = 0; i2 < _puestos.GetLength(0); i2++)
                    if (_puestos[i2, i]._estado == 3)
                        _coordenadas.Add(new int[] { i2+1, i+1 });
            string _queryString =
                    "select rp.fk_puestofila as f,rp.fk_puestocolumna as c " +
                    "from RESERVA_PUESTO rp " +
                    "where rp.fk_playa=" + _idPlaya + "  and rp.fk_reserva = " + _reservaID;
            DataTable _tablaDatos = EjecutarQuery(_queryString);
            List<int[]> _pCoordenadas = new List<int[]>();
            for (int i = 0; i < _tablaDatos.Rows.Count; i++)
                _pCoordenadas.Add(new int[] { int.Parse(_tablaDatos.Rows[i]["c"].ToString()), int.Parse(_tablaDatos.Rows[i]["f"].ToString()) });
            for (int i=0;i<_coordenadas.Count;i++)
                if (!Existe(_coordenadas[i],_pCoordenadas))
                    AgregarPuesto(_reservaID, _coordenadas[i][0], _coordenadas[i][1]);
            for (int i = 0; i < _pCoordenadas.Count; i++)
                if (!Existe(_pCoordenadas[i],_coordenadas))
                    EliminarPuesto(_reservaID,_pCoordenadas[i][0],_pCoordenadas[i][1]);
        }
        public void AgregarReserva(Puesto[,] _puestos, DateTime _fecha)
        {
            int u;
            DataTable _tabla = new DataTable();
            string _queryString =
                "select u.usu_id as u from usuario u where u.USU_correo = '" + _usuario +"'";
            _tabla = EjecutarQuery(_queryString);
            u = int.Parse(_tabla.Rows[0]["u"].ToString());
            List<int[]> _coordenadas = new List<int[]>();
            for (int i=0;i < _puestos.GetLength(1);i++)
                for (int i2=0;i2 < _puestos.GetLength(0);i2++)
                    if (_puestos[i,i2]._estado==3)
                        _coordenadas.Add(new int[] {i , i2});
            _queryString = "select NEXT VALUE FOR RESERVA_SEQ as n";
            _tabla = new DataTable();
            _tabla = EjecutarQuery(_queryString);

            _queryString = "insert into RESERVA values ("+_tabla.Rows[0]["n"].ToString()+",'"+_fecha.ToShortDateString()+"',"+u+",10)";
            EjecutarQuerySinRetorno(_queryString);
            for (int i = 0; i < _coordenadas.Count; i++)
                AgregarPuesto(int.Parse(_tabla.Rows[0]["n"].ToString()), _coordenadas[i][0]+1, _coordenadas[i][1]+1);
        }
        public Puesto[,] RetornarMatriz(int _previaReserva)
        {
            int[] dimensionplaya = DimensionPlaya();
            Puesto[,] puestoplaya = new Puesto[dimensionplaya[0], dimensionplaya[1]];

            string _queryString =
                "select p.pue_fila as f,p.pue_columna as c,p.pue_precio as prec " +
                "from puesto p " +
                "where p.fk_estado = 1 and p.fk_playa = " + _idPlaya;
            DataTable _tablaDatos = EjecutarQuery(_queryString);

            for (int x = 0; x < puestoplaya.GetLength(0); x++)
                for (int y = 0; y < puestoplaya.GetLength(1);y++)
                    puestoplaya[x, y] = new Puesto();

            for (int i = 0; i < _tablaDatos.Rows.Count; i++)
            {
                puestoplaya[int.Parse(_tablaDatos.Rows[i]["c"].ToString()) - 1, int.Parse(_tablaDatos.Rows[i]["f"].ToString()) - 1]._estado = 1;
                puestoplaya[int.Parse(_tablaDatos.Rows[i]["c"].ToString()) - 1, int.Parse(_tablaDatos.Rows[i]["f"].ToString()) - 1]._valor = float.Parse(_tablaDatos.Rows[i]["prec"].ToString());
            }

            _queryString =
                "select rp.fk_puestofila as f,rp.fk_puestocolumna as c " +
                "from RESERVA_PUESTO rp " +
                "where rp.fk_playa="+_idPlaya+" and rp.res_pue_fecha >= CAST('" + _fecha.ToString() + "' as datetime) and rp.res_pue_fecha <= CAST('" + (_fecha.AddDays(1).AddSeconds(-1)).ToString()+"' as datetime)";
            _tablaDatos = EjecutarQuery(_queryString);
            for (int i = 0; i < _tablaDatos.Rows.Count;i++)
                puestoplaya[int.Parse(_tablaDatos.Rows[i]["c"].ToString())-1, int.Parse(_tablaDatos.Rows[i]["f"].ToString())-1]._estado = 2;
            if (_previaReserva!=0)
            {
                _queryString = 
                    "select rp.fk_puestofila as f,rp.fk_puestocolumna as c " +
                    "from RESERVA_PUESTO rp " +
                    "where rp.fk_playa=" + _idPlaya + "  and rp.fk_reserva = " + _previaReserva;
                _tablaDatos = EjecutarQuery(_queryString);
                for (int i = 0; i < _tablaDatos.Rows.Count; i++)
                    puestoplaya[int.Parse(_tablaDatos.Rows[i]["c"].ToString()) - 1, int.Parse(_tablaDatos.Rows[i]["f"].ToString()) - 1]._estado = 3;
            }
            return (puestoplaya);
        }
    }
}