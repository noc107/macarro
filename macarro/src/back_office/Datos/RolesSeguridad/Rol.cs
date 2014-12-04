using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace back_office.Datos.RolesSeguridad
{
    public class Rol
    {
        private int _id;
        private string _nombre;
        private string _descripcion;
        private List<Accion> _acciones;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public List<Accion> Acciones
        {
            get { return _acciones; }
            set { _acciones = value; }
        }

        public Rol(int id, string nombre, string descripcion, List<Accion> acciones)
        {
            _id = id;
            _nombre = nombre;
            _descripcion = descripcion;
            _acciones = acciones;
        }

        public Rol()
        {
            _id = -1;
            _nombre = "";
            _descripcion = "";
            _acciones = null;
        }

        /// <summary>
        /// Metodo para agregar un rol en la base de datos
        /// </summary>
        /// <returns></returns>
        public bool agregarRol()
        {
            int i;
            SqlConnection con;
            SqlCommand _comando;
            try
            {
                con = new SqlConnection();
                con.Open();

                _comando = new SqlCommand("Procedure_AgregarRol " + this.Nombre + " " + this.Descripcion, con);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.ExecuteNonQuery();

                for (i = 0; i < this.Acciones.Count; i++)
                {
                    _comando = new SqlCommand("Procedure_AgregarRol_Accion " + this.Id + " " + this.Acciones[i].Id, con);
                    _comando.CommandType = System.Data.CommandType.StoredProcedure;
                    _comando.ExecuteNonQuery();
                }
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                //mandar excepcion
            }
            return false;
        }

        /// <summary>
        /// Metodo para extraer todos los roles en la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Rol> ConsultarRolesGeneral()
        {
            List<Rol> roles = new List<Rol>();
            SqlConnection con;
            SqlCommand _comando;
            SqlDataReader reader;
            int i = 0;
            try
            {
                con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\tecssil\\Downloads\\macarro\\src\\MACARRO.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();

                _comando = new SqlCommand("Procedure_ConsultarRolGeneral", con);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    roles.Add(new Rol((int)reader[0], (string)reader[1], (string)reader[2], null));
                    i++;
                }
                con.Close();
                return roles;
            }
            catch (Exception e)
            {
                //mandar excepcion
            }

            return roles;
        }

        /// <summary>
        /// Metodo para consultar un rol en detalle
        /// </summary>
        /// <returns></returns>
        public List<Accion> ConsultarRol()
        {
            List<Accion> acciones = new List<Accion>();
            SqlConnection con;
            SqlCommand _comando;
            SqlDataReader reader;
            int i = 0;
            try
            {
                con = new SqlConnection();
                con.Open();

                _comando = new SqlCommand("Procedure_ConsultarRol " + this.Id, con);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                reader = _comando.ExecuteReader();

                while (reader.Read())
                {
                    acciones.Add(new Accion((int)reader[0], (string)reader[1], (string)reader[2]));
                    i++;
                }
                con.Close();
                return acciones;
            }
            catch (Exception e)
            {
                //mandar excepcion
            }

            return acciones;
        }

        /// <summary>
        /// Metodo para modficar las caracteristicas de un rol en especifico
        /// </summary>
        /// <returns></returns>
        public bool modificarRol()
        {

            int i;
            SqlConnection con;
            SqlCommand _comando;
            try
            {
                con = new SqlConnection();
                con.Open();

                _comando = new SqlCommand("Procedure_ModificarRol " + this.Id + " " + this.Nombre + " " + this.Descripcion, con);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.ExecuteNonQuery();

                _comando = new SqlCommand("EXEC Procedure_EliminarAccionRol " + this.Id, con);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.ExecuteNonQuery();

                for (i = 0; i < this.Acciones.Count; i++)
                {
                    _comando = new SqlCommand("EXEC Procedure_AgregarRol_Accion " + this.Id + " " + this.Acciones[i].Id);
                    _comando.CommandType = System.Data.CommandType.StoredProcedure;
                    _comando.ExecuteNonQuery();
                }
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                //mandar excepcion
            }
            return false;
        }

        /// <summary>
        /// Metodo para eliminar un rol de la base de datos junto con las n a n de la tabla ROL_ACCION y USUARIO_ROL
        /// </summary>
        /// <returns></returns>
        public bool eliminarRol()
        {
            int i;
            SqlConnection con;
            SqlCommand _comando;
            try
            {
                con = new SqlConnection();
                con.Open();

                _comando = new SqlCommand("Procedure_EliminarRol " + this.Id, con);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.ExecuteNonQuery();

                con.Close();
                return true;
            }
            catch (Exception e)
            {
                //mandar excepcion
            }
            return false;
        }

    }
}