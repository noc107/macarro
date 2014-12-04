using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace back_office.Datos.RolesSeguridad
{
    public class Accion
    {
        private  int _id;
        private  string _nombre;
        private  string _descripcion;

        public  int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public  string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public   string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public Accion(int id, string nombre, string descripcion) 
        {
            _id = id;
            _nombre = nombre;
            _descripcion = descripcion;
        }

        public Accion()
        {
            _id = -1;
            _nombre = "";
            _descripcion = "";
        }


        public List<Accion> ConsultarAccionGeneral()
        {
            List<Accion> acciones = new List<Accion>();

            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\tecssil\\Downloads\\macarro\\src\\MACARRO.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand _comando = new SqlCommand("Procedure_ConsultarAccionGeneral", con);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            con.Open();

            SqlDataReader reader = _comando.ExecuteReader();

            int i = 0;
            while (reader.Read())
            {
                Accion acc = new Accion((int)reader[0],(string)reader[1],(string)reader[2]);
                acciones.Add(acc);
                i++;
            }

            con.Close();

            return acciones;
            
        }

        //public bool asignarAccion(Accion accion, Rol rol)
        //{
        //    //metodo para unir rol con accion
        //    return false;
        //}
    }
}