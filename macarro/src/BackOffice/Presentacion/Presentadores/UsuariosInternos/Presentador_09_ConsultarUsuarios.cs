using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BackOffice.Presentacion.Contratos.UsuariosInternos;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.LogicaNegocio; 
using BackOffice.Dominio.Fabrica;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio; 

namespace BackOffice.Presentacion.Presentadores.UsuariosInternos
{
    public class Presentador_09_ConsultarUsuarios : PresentadorGeneral
    {
        private IContrato_09_ConsultarUsuarios _contratoPerfilUsuario;
        
        


        public Presentador_09_ConsultarUsuarios(IContrato_09_ConsultarUsuarios _contratoPerfilUsuario)
            : base(_contratoPerfilUsuario)
        {
            this._contratoPerfilUsuario = _contratoPerfilUsuario;
        }

        public void PageLoad()
        {
            try
            {
                _contratoPerfilUsuario.LabelMensajeExito.Visible = false;
                _contratoPerfilUsuario.LabelMensajeError.Visible = false;
                BuscadorID();
                BuscadorCargos();
            }
            catch (Exception ex)
            {
                _contratoPerfilUsuario.LabelMensajeError.Visible = true;
                MostrarMensajeError(ex.Message);
            }
        }

        public void EventoBotonConsultar() 
        {
           
        }

        public string EventoBotonVolver() 
        {
            return RecursosPresentadorUsuariosInternos.PaginaGestionUsuario; 
        }


        private void BuscadorID() 
        {
            
            LlenarDatosEmpleadoID(ConsultarEmpleadoXID(8)); 

        }

        private void BuscadorCargos()
        {
            
            LlenarListBoxRoles(ConsultarRoles(8));
        }


        /// <summary>
        /// Método que llama a la fábrica de comandos para ejecutar la petición de Consultar Empleados por ID
        /// </summary>
        /// <param name="parametro">ID del Empleado en la BD</param>
        /// <returns>el objeto de Tipo Persona, o los datos del Empleado</returns>
        private Persona ConsultarEmpleadoXID(int parametro) 
        {
            Comando<int, Entidad> comandoConsultarEmpleado;
            Entidad _persona = FabricaEntidad.ObtenerPersona();
            comandoConsultarEmpleado = FabricaComando.ObtenerComandoConsultarEmpleadoXId();
            _persona = comandoConsultarEmpleado.Ejecutar(parametro);
            Persona _laPersona = (Persona)_persona;

            return _laPersona; 

        }


        /// <summary>
        /// Método encargado de instanciar los objetos de la clase Persona en 
        /// los elementos de la ventana.
        /// </summary>
        /// <param name="persona">Recibe un objeto de tipo Persona</param>
        private void LlenarDatosEmpleadoID(Persona persona) 
        {
            if (persona != null)
            {
                _contratoPerfilUsuario.Nombre.Text = persona.Nombre;
                _contratoPerfilUsuario.SegundoNombre.Text = persona.SegundoNombre;
                _contratoPerfilUsuario.Apellido.Text = persona.Apellido;
                _contratoPerfilUsuario.SegundoApellido.Text = persona.SegundoApellido;
                _contratoPerfilUsuario.TipoDocumento.Text = persona.TipoDocumento;
                _contratoPerfilUsuario.Cedula.Text = persona.Cedula;
                _contratoPerfilUsuario.FechaNacimiento.Text = persona.FechaNacimiento.ToString("dd/MM/yyyy");
                _contratoPerfilUsuario.Estatus.Text = persona.UsuarioAsociado.Estatus;
                _contratoPerfilUsuario.Telefono.Text = persona.Telefono;
                _contratoPerfilUsuario.Correo.Text = persona.UsuarioAsociado.Correo;
                _contratoPerfilUsuario.FechaIngreso.Text = persona.UsuarioAsociado.FechaIngreso.ToString();
                if (persona.UsuarioAsociado.FechaEgreso.ToString("dd/MM/yyyy") == "01/01/1900")
                    _contratoPerfilUsuario.FechaEgreso.Text = "";
                else
                    _contratoPerfilUsuario.FechaEgreso.Text = persona.UsuarioAsociado.FechaEgreso.ToString("dd/MM/yyyy"); 

                _contratoPerfilUsuario.Direccion.Text = persona.NombreLugar;                

            }
            else 
            {
                _contratoPerfilUsuario.LabelMensajeError.Visible = true; 
                _contratoPerfilUsuario.LabelMensajeError.Text = RecursosPresentadorUsuariosInternos.RegistrosVacios; 
            }
        }


        /// <summary>
        /// Busqueda del nombre de un rol según el id específico de un empleado
        /// </summary>
        /// <param name="parametro">Id del empleado a buscar</param>
        /// <returns>Lista de los nombres de los cargos o roles que desempeña el empleado</returns>
        private List<string> ConsultarRoles(int parametro)
        {
            Comando<int, List<string>> ComandoConsultarRolesEmpleado = FabricaComando.ObtenerComandoConsultarRolesEmpleado();
            List<string> _listaDesdeComando = ComandoConsultarRolesEmpleado.Ejecutar(parametro);

            return _listaDesdeComando;
        }


        /*
            /// <summary>
        /// Transforma una lista obtenida en el comando en una lista de Tipo Rol para usarse en el ListBox 
        /// de cargos de la persona
        /// </summary>
        /// <param name="lista">Lista del tipo Rol</param>
        /// <returns>Lista de roles </returns>
        private List<Rol> CovertirListaRol(List<Entidad> _lista) 
        {
            List<Rol> _listaRoles = new List<Rol>();
            
            foreach (Rol _entidad in _lista) 
            {
                _listaRoles.Add(_entidad as Rol);    
            }

           
            return _listaRoles; 
        }*/


        /// <summary>
        /// Método que llena el list box con los roles obtenidos dado un Id del Empleado
        /// </summary>
        /// <param name="roles">Lista de Roles o cargos desempeñados por el Empleado</param>
        private void LlenarListBoxRoles(List<string> lista) 
        {
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    _contratoPerfilUsuario.ListaCargos.DataSource = lista;
                    _contratoPerfilUsuario.ListaCargos.DataBind(); 
                }
                else
                {
                    _contratoPerfilUsuario.LabelMensajeError.Visible = true;
                    _contratoPerfilUsuario.LabelMensajeError.Text = "Registro Vacío";
                }
            }
            else 
            {
                _contratoPerfilUsuario.LabelMensajeError.Visible = true;
                _contratoPerfilUsuario.LabelMensajeError.Text = "Registro Vacío";
            }
        }


            
        }


    }
