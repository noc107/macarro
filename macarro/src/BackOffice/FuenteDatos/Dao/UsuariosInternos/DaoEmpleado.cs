using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient; 
using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.FuenteDatos.IDao.UsuariosInternos;
using BackOffice.FuenteDatos.Dao.UsuariosInternos.Recursos;

namespace BackOffice.FuenteDatos.Dao.UsuariosInternos
{
    public class DaoEmpleado:Dao, IDaoEmpleado
    {
        private Entidad _persona = FabricaEntidad.ObtenerPersona();



        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }


        public bool Agregar(Entidad parametro) 
        {
            throw new NotImplementedException(); 
        }


        /// <summary>
        /// Actualiza los datos del Empleado en la BD
        /// </summary>
        /// <param name="parametro">La entidad a actualizar en la BD</param>
        /// <returns>retorna true si la actualización fue éxitosa
        /// false en caso de error.</returns>
        public bool Modificar(Entidad parametro) 
        {
            
            bool _respuesta = false;
            SqlDataReader _lector;
            Persona _persona = parametro as Persona;

            try
            {
            SqlCommand _comando = new SqlCommand(RecursosDaoUsuariosInternos.ProcedimientoModificarEmpleado, IniciarConexion());
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.Add(new SqlParameter(RecursosDaoUsuariosInternos.ParametroDocIdentidad, _persona.Cedula));
            _comando.Parameters.Add(new SqlParameter(RecursosDaoUsuariosInternos.ParametroPrimerNombre, _persona.Nombre));
            _comando.Parameters.Add(new SqlParameter(RecursosDaoUsuariosInternos.ParametroSegundoNombre, _persona.SegundoNombre));
            _comando.Parameters.Add(new SqlParameter(RecursosDaoUsuariosInternos.ParametroPrimerApellido, _persona.Apellido));
            _comando.Parameters.Add(new SqlParameter(RecursosDaoUsuariosInternos.ParametroSegundoApellido, _persona.SegundoApellido));
            _comando.Parameters.Add(new SqlParameter(RecursosDaoUsuariosInternos.ParametroFechaNacimiento, _persona.FechaNacimiento));
            _comando.Parameters.Add(new SqlParameter(RecursosDaoUsuariosInternos.ParametroTelefono, _persona.Telefono));
            _comando.Parameters.Add(new SqlParameter(RecursosDaoUsuariosInternos.ParametroTipoDocIdentidad, _persona.TipoDocumento));
            _comando.Parameters.Add(new SqlParameter(RecursosDaoUsuariosInternos.ParametroIdCiudad, _persona.FkLugar));
            _comando.Parameters.Add(new SqlParameter(RecursosDaoUsuariosInternos.ParametroCorreo, _persona.UsuarioAsociado.Correo));
            _comando.Parameters.Add(new SqlParameter(RecursosDaoUsuariosInternos.ParametroContrasena, _persona.UsuarioAsociado.Contrasena));
            _comando.Parameters.Add(new SqlParameter(RecursosDaoUsuariosInternos.ParametroEstatus, _persona.UsuarioAsociado.Estatus));
            _comando.Parameters.Add(new SqlParameter(RecursosDaoUsuariosInternos.ParametroFechaEgreso, _persona.UsuarioAsociado.FechaEgreso));
            _comando.Parameters.Add(new SqlParameter(RecursosDaoUsuariosInternos.ParametroNombreLugar, _persona.NombreLugar));
            
                                
                IniciarConexion().Open();
                _lector = _comando.ExecuteReader();
                _respuesta = true;
             }

            catch (Exception ex) 
            {
                
                throw ex; 
            }

            finally
            {
                 CerrarConexion();
            }

            return _respuesta;
        }
        
        /// <summary>
        /// Método para Consultar un empleado por su id 
        /// </summary>
        /// <param name="id">Id de la persona en la BD</param>
        /// <returns>Un objeto de tipo entidad que es persona o el registro de la persona</returns>
        public Entidad ConsultarXId(int id)
        {
            SqlCommand _comando = new SqlCommand(RecursosDaoUsuariosInternos.ProcedimientoConsultarEmpleadoUnico, IniciarConexion());
            _comando.CommandType = CommandType.StoredProcedure; 
            _comando.Parameters.Add(new SqlParameter(RecursosDaoUsuariosInternos.ParametroIdPersona,id));

            SqlDataReader _lectura;

            try
            {
                IniciarConexion().Open();
                _lectura = _comando.ExecuteReader();

                while ( _lectura.HasRows &&   _lectura.Read())
                {
                    _persona = AsignarEmpleado(_lectura); 

                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            finally 
            {
                CerrarConexion(); 
            }

            return _persona;  
        }

        /// <summary>
        /// Método para consultar el nombre los roles o cargo de un empleado dado su ID
        /// </summary>
        /// <param name="id">Id de la persona en la BD</param>
        /// <returns>Nombres de los cargos que desempeña la persona</returns>

        public List<string> ConsultarRolesEmpleado(int parametro) 
        {
            List<string> _listaCargos = new List<string>(); 
             try
            {
                SqlCommand _comando = new SqlCommand(RecursosDaoUsuariosInternos.ProcedimientoConsultarRolesEmpleado, IniciarConexion());

                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter(RecursosDaoUsuariosInternos.ParametroIdPersona, parametro));
                
          
                SqlDataReader lector;
            
                    IniciarConexion().Open();
                    lector = _comando.ExecuteReader();
                    while (lector.Read())
                    {
                        string rol = AsignarRol(lector);
                        if (rol != null)
                        {
                            _listaCargos.Add(rol);
                        }
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
             return _listaCargos;
        
        }
      

           
    
        /// <summary>
        /// Asigna un objeto de la BD a un objeto de tipo Persona según las posiciones especificadas en la columna
        /// de la consulta Procedure_consultarEmpleadoUnico. 
        /// </summary>
        /// <param name="objetoBD">Objeto leído de la BD de tipo SqlDataReader</param>
        /// <returns>Retorna un objeto de tipo Persona</returns>
        private Persona  AsignarEmpleado(SqlDataReader objetoBD)
        
        {
            Usuario _personaUsuario = (Usuario)FabricaEntidad.ObtenerUsuario(); 
            Persona _personaEmpleado = (Persona)FabricaEntidad.ObtenerPersona();
            _personaEmpleado.UsuarioAsociado = _personaUsuario;

            /* Asigno las columnas de objeto de BD con sus respectivos atributos de los objetos*/
             _personaEmpleado.Id = objetoBD.GetInt32(0);
             _personaEmpleado.TipoDocumento = objetoBD.GetString(1);
             _personaEmpleado.Cedula = objetoBD.GetString(2);                
             _personaEmpleado.Nombre = objetoBD.GetString(3);
             string vacio = objetoBD.GetString(4); 
             if (vacio == "") 
             {
                 _personaEmpleado.SegundoNombre = string.Empty; 
             }
             else
                _personaEmpleado.SegundoNombre = objetoBD.GetString(4); 

             _personaEmpleado.Apellido = objetoBD.GetString(5);
             _personaEmpleado.SegundoApellido = objetoBD.GetString(6);
             _personaEmpleado.FechaNacimiento = objetoBD.GetDateTime(7);
             _personaEmpleado.Telefono = objetoBD.GetString(8);
             _personaEmpleado.UsuarioAsociado.Correo = objetoBD.GetString(9);
             _personaEmpleado.UsuarioAsociado.Estatus = objetoBD.GetString(10);
             _personaEmpleado.UsuarioAsociado.FechaIngreso = objetoBD.GetDateTime(11);
             _personaEmpleado.UsuarioAsociado.FechaEgreso = objetoBD.GetDateTime(12);
             _personaEmpleado.NombreLugar = objetoBD.GetString(13);
             _personaEmpleado.FkLugar = objetoBD.GetInt32(14); 

            
            return _personaEmpleado; 
            
        }


        /// <summary>
        /// Asigna un objeto de la BD a un nombre de un rol según las posiciones especificadas en la columna
        /// de la consulta Procedure_consultarRolesEmpleado. 
        /// </summary>
        /// <param name="objetoBD">Objeto leído de la BD de tipo SqlDataReader</param>
        /// <returns>Retorna el nombre de los roles obtenidos</returns>
        private string AsignarRol(SqlDataReader objeto) 
        {
            Rol _rolEmpleado = (Rol)FabricaEntidad.ObtenerRol();

            _rolEmpleado.Nombre = objeto.GetString(0);

            return _rolEmpleado.Nombre ; 
            
        }
        

    }
}