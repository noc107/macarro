using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.FuenteDatos.IDao.IngresoRecuperacionClave;

namespace BackOffice.FuenteDatos.Dao.IngresoRecuperacionClave
{
    public class DaoInicio : Dao, IDaoIniciarSesion
    {
      //  private Entidad _usuario = FabricaEntidad.ObtenerUsuarioInicio();

        public Entidad verificarDatos(Entidad parametro)
        {
            // Implementación de verificación de datos (inicio con bd)
            Usuario usuarioRetornado = (Usuario)FabricaEntidad.ObtenerUsuarioInicio();

            SqlCommand _comando = new SqlCommand("Procedure_consultarEmpleadoClave", IniciarConexion());
            _comando.CommandType = CommandType.StoredProcedure;
            SqlParameter _parametro1 = new SqlParameter("@usuario", ((Usuario)parametro).Correo);
            SqlParameter _parametro2 = new SqlParameter("@clave", ((Usuario)parametro).Contrasena);
            _comando.Parameters.Add(_parametro1);
            _comando.Parameters.Add(_parametro2);
            SqlDataReader reader;
            try
            {
                IniciarConexion().Open();
                reader = _comando.ExecuteReader();
                if (reader.Read())
                {
                    usuarioRetornado.Correo = reader["USU_correo"].ToString();
                    usuarioRetornado.Id = int.Parse(reader["USU_id"].ToString());       
                }

                return usuarioRetornado;
            }
            catch (Exception e)
            {
                return usuarioRetornado;
            }
            finally
            {
                CerrarConexion(); 
            }

        }

        public Entidad verificarDatosPersona(Entidad parametro)
        {
            // Implementación de verificación de datos (inicio con bd)
            Persona personaRetornado = (Persona)FabricaEntidad.ObtenerPersonaInicio();

            SqlCommand _comando = new SqlCommand("Procedure_consultarEmpleadoClave", IniciarConexion());
            _comando.CommandType = CommandType.StoredProcedure;
            SqlParameter _parametro1 = new SqlParameter("@usuario", ((Usuario)parametro).Correo);
            SqlParameter _parametro2 = new SqlParameter("@clave", ((Usuario)parametro).Contrasena);
            _comando.Parameters.Add(_parametro1);
            _comando.Parameters.Add(_parametro2);
            SqlDataReader reader;
            try
            {
                IniciarConexion().Open();
                reader = _comando.ExecuteReader();
                if (reader.Read())
                {
                    personaRetornado.Cedula = reader["PER_docIdentidad"].ToString();
                    personaRetornado.Nombre = reader["PER_primerNombre"].ToString();
                    personaRetornado.Apellido = reader["PER_primerApellido"].ToString();
                    personaRetornado.Id = int.Parse(reader["PER_id"].ToString());
                }

                return personaRetornado;
            }
            catch (Exception e)
            {
                return personaRetornado;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public Entidad ConsultarXId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
    }
}