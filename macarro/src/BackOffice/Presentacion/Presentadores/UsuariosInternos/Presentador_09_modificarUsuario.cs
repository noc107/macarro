using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
    public class Presentador_09_modificarUsuario : PresentadorGeneral
    {
        private IContrato_09_modificarUsuario _vistaModificarEmpleado;
        private Persona _empleado; 
        
        
        public Presentador_09_modificarUsuario(IContrato_09_modificarUsuario _vistaModificarEmpleado)
            : base(_vistaModificarEmpleado)
        {
            this._vistaModificarEmpleado = _vistaModificarEmpleado; 
        }


        /// <summary>
        /// Método que se ejecuta al cargar el inicio de la ventana
        /// </summary>
        public void PageLoad() 
        {

            LlenarDatosEmpleado(ConsultarEmpleadoXID(7)); 
        }

        /// <summary>
        /// Método que se ejecuta cuando se presiona el botón Siguiente de la ventana
        /// </summary>
        public void Siguiente()
        {
            
        }

        /// <summary>
        /// Método que se activa cuando el usuario presiona volver. 
        /// Lo envía de nuevo a la ventana del Grid
        /// </summary>
        /// <returns>Retorna el nombre de la pagina gestión usuario</returns>
        public string BotonRegresar() 
        {
            return RecursosPresentadorUsuariosInternos.PaginaGestionUsuario;
        }


        # region Métodos para carga de datos del Empleado
        /// <summary>
        /// Método que se ejecuta cuando se selecciona un valor
        /// del Combo Box de Estado. 
        /// </summary>
        public void cbEstado_SelectionChangeCommitted ()
        {
            _vistaModificarEmpleado.Estado.Items.Clear();
            _vistaModificarEmpleado.Ciudad.Items.Clear();
            _vistaModificarEmpleado.Direccion.Text = "";
            int idPais = Convert.ToInt32(_vistaModificarEmpleado.Pais.SelectedValue);
            llenadoComboBoxEstado(idPais);

        }

        /// <summary>
        /// Método que se ejecuta cuando se selecciona un valor 
        /// del Combo Box de Ciudad. 
        /// </summary>

        public void cbCiudad_SelectionChangeCommitted() 
        {
            int _idEstado = Convert.ToInt32(_vistaModificarEmpleado.Estado.SelectedValue);
            llenadoComboBoxCiudad(_idEstado);
        }

        /// <summary>
        /// Método que carga el ComboBox de Estados
        /// </summary>
        /// <param name="idPais">Id del País</param>
        private void llenadoComboBoxEstado(int idPais) 
        {
            try
            {
                List<Lugar> _estados = CBEstado(idPais);
                ListItem _itemEstado;

                _vistaModificarEmpleado.Estado.Items.Clear();

                _itemEstado = new ListItem();
                _itemEstado.Text = "Seleccione un Estado";
                _itemEstado.Value = "0";
                _vistaModificarEmpleado.Estado.Items.Add(_itemEstado);

                foreach (Lugar _itemEstados in _estados)
                {
                    _itemEstado = new ListItem();
                    _itemEstado.Text = _itemEstados.NombreLugar;
                    _itemEstado.Value = _itemEstados.IdLugar.ToString();
                    _vistaModificarEmpleado.Estado.Items.Add(_itemEstado);
                }
            }
            catch (Exception ex) 
            {
                throw ex; 
            }

        }

        /// <summary>
        /// Método que carga el Combo Box de Ciudades
        /// </summary>
        /// <param name="idEstado">Id del Estado</param>
        private void llenadoComboBoxCiudad(int idEstado) 
        {
            try
            {
                List<Lugar> _ciudades = CBCiudad(idEstado);
                ListItem _itemCiudad;

                _vistaModificarEmpleado.Ciudad.Items.Clear();

                _itemCiudad = new ListItem();
                _itemCiudad.Text = "Seleccione una Ciudad";
                _itemCiudad.Value = "0";
                _vistaModificarEmpleado.Ciudad.Items.Add(_itemCiudad);

                foreach (Lugar _itemCiudades in _ciudades)
                {
                    _itemCiudad = new ListItem();
                    _itemCiudad.Text = _itemCiudades.NombreLugar;
                    _itemCiudad.Value = _itemCiudades.IdLugar.ToString();
                    _vistaModificarEmpleado.Ciudad.Items.Add(_itemCiudad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método que llama al Comando Consultar Empleado por ID y retorna
        /// un objeto de tipo Persona
        /// </summary>
        /// <param name="parametro">Id del Empleado</param>
        /// <returns>EL objeto de tipo Persona</returns>
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
        /// Método que recibe una Lista de tipo Entidad y la transforma en una tipo Lugar
        /// </summary>
        /// <param name="lista">La lista de tipo Entidad</param>
        /// <returns>Retorna la lista de tipo Lugar</returns>
        private List<Lugar> ConvertirListaLugar(List<Entidad> lista)
        {
            List<Lugar> _listaLugar = new List<Lugar>();
            foreach (Lugar entidad in lista)
            {
                _listaLugar.Add(entidad as Lugar);
            }
            return _listaLugar;
        }

        private List<Estado> ConvertirListaEstatus(List<Entidad> lista) 
        {
            List<Estado> _listaEstado = new List<Estado>();
            foreach (Estado entidad in lista)
            {
                _listaEstado.Add(entidad as Estado);
            }
            return _listaEstado;
        }


        /// <summary>
        /// Llama al comando de Llenar CB Paises y retorna la lista de paises para ser llenados en el DropDownList de Paises
        /// </summary>
        /// <param name="parametro">Recibe un parámetro bool de ejecución</param>
        /// <returns>Lista de Paises</returns>
        private List<Lugar> CBPais(bool parametro)
        {
            Comando<bool, List<Entidad>> ComandoLlenarCBPais = FabricaComando.ObtenerComandoLlenarCBPais();
            List<Entidad> _listaDesdeComando = ComandoLlenarCBPais.Ejecutar(parametro);

            return ConvertirListaLugar(_listaDesdeComando);
        }


        /// <summary>
        /// Llama al comando LLenarCBEstado y retorna la lista de estados para ser llenados en el 
        /// DropDownList de Estados 
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        private List<Lugar> CBEstado(int parametro) 
        {
            Comando<int, List<Entidad>> ComandoLlenarCBEstado = FabricaComando.ObtenerComandoLlenarCBEstado();
            List<Entidad> _listaDesdeComando = ComandoLlenarCBEstado.Ejecutar(parametro);

            return ConvertirListaLugar(_listaDesdeComando);
        }


        /// <summary>
        /// Llama al comando LLenarCBCiudad y retorna la lista de ciudades
        /// para ser llenados en el DropDownList de Estados 
        /// </summary>
        /// <param name="parametro">Id del Estado </param>
        /// <returns>Lista de Ciudades</returns>
        private List<Lugar> CBCiudad(int parametro) 
        {
            Comando<int, List<Entidad>> ComandoLlenarCBCiudad = FabricaComando.ObtenerComandoLlenarCBCiudad();
            List<Entidad> _listaDesdeComando = ComandoLlenarCBCiudad.Ejecutar(parametro);

            return ConvertirListaLugar(_listaDesdeComando);
        }

        
        private List<int> ConsultaDireccionCompleta(int direccion) 
        {
            Comando<int, List<int>> ComandoDirCompleta = FabricaComando.ObtenerComandoConsultarDireccionCompleta();
            List<int> _listaComando = ComandoDirCompleta.Ejecutar(direccion);

            return _listaComando; 
        }

        private List<Estado> CBEstatus(bool parametro) 
        {
            Comando<bool, List<Entidad>> ComandoLlenarCBEstatus = FabricaComando.ObtenerComandoLlenarCBEstatusUsuario();
            List<Entidad> _listaComando = ComandoLlenarCBEstatus.Ejecutar(parametro);

            return ConvertirListaEstatus(_listaComando);
 
        }


        /// <summary>
        /// Método que llama al Comando ObtenerDirección, y retorna una 
        /// cadena de caracteres con una dirección específica del Empleado
        /// </summary>
        /// <param name="direccion">Id del Lugar asociado al Empleado</param>
        /// <returns>Nombre de la dirección</returns>
        private string ObtenerDireccion(int direccion) 
        {
            Comando<int, string> ComandoObtenerDireccion = FabricaComando.ObtenerComandoObtenerDireccion();
            string _comando = ComandoObtenerDireccion.Ejecutar(direccion);

            return _comando; 

        }

        private void CargarEstatusUsuario() 
        {
            _vistaModificarEmpleado.Estatus.DataSource = CBEstatus(true);
            _vistaModificarEmpleado.Estatus.DataTextField = "Titulo";
            _vistaModificarEmpleado.Estatus.DataValueField = "Id";
            _vistaModificarEmpleado.Estatus.DataBind();

            _vistaModificarEmpleado.Estatus.Items.Insert(0, new ListItem("Seleccione...", "Seleccione..."));
        }
        /// <summary>
        /// Método encargado de cargar las direcciones 
        /// que posee un empleado.
        /// </summary>
        /// <param name="persona">Objeto de tipo Persona</param>
        private void CargarDireccion(Persona persona) 
        {
            _vistaModificarEmpleado.Pais.DataSource = CBPais(true);
            _vistaModificarEmpleado.Pais.DataTextField = "NombreLugar";
            _vistaModificarEmpleado.Pais.DataValueField = "IdLugar";
            _vistaModificarEmpleado.Pais.DataBind();

            _vistaModificarEmpleado.Pais.Items.FindByValue(ConsultaDireccionCompleta(persona.FkLugar).ElementAt(0).ToString()).Selected = true;

            _vistaModificarEmpleado.Estado.DataSource = CBEstado(ConsultaDireccionCompleta(persona.FkLugar).ElementAt(0));
            _vistaModificarEmpleado.Estado.DataTextField = "NombreLugar";
            _vistaModificarEmpleado.Estado.DataValueField = "IdLugar";
            _vistaModificarEmpleado.Estado.DataBind();

            _vistaModificarEmpleado.Estado.Items.FindByValue(ConsultaDireccionCompleta(persona.FkLugar).ElementAt(1).ToString()).Selected=true;

            _vistaModificarEmpleado.Ciudad.DataSource = CBCiudad(ConsultaDireccionCompleta(persona.FkLugar).ElementAt(1));
            _vistaModificarEmpleado.Ciudad.DataTextField = "NombreLugar";
            _vistaModificarEmpleado.Ciudad.DataValueField = "IdLugar";
            _vistaModificarEmpleado.Ciudad.DataBind();

            _vistaModificarEmpleado.Ciudad.Items.FindByValue(ConsultaDireccionCompleta(persona.FkLugar).ElementAt(2).ToString()).Selected = true;

            _vistaModificarEmpleado.Direccion.Text = ObtenerDireccion(persona.FkLugar); 

        }



        /// <summary>
        /// Carga los datos del Empleado al principio de cargar la página.
        /// </summary>
        /// <param name="persona">El objeto de tipo Persona</param>
        private void LlenarDatosEmpleado(Persona persona) 
        {
            if (persona != null)
            {
                _vistaModificarEmpleado.Nombre.Text = persona.Nombre;
                _vistaModificarEmpleado.SegundoNombre.Text = persona.SegundoNombre;
                _vistaModificarEmpleado.Apellido.Text = persona.Apellido;
                _vistaModificarEmpleado.SegundoApellido.Text = persona.SegundoApellido;
                _vistaModificarEmpleado.TipoDocumento.Items.FindByValue(persona.TipoDocumento).Selected = true; 
                _vistaModificarEmpleado.Cedula.Text = persona.Cedula;
                _vistaModificarEmpleado.FechaNacimiento.Text = persona.FechaNacimiento.ToString();
              /*  _vistaModificarEmpleado.Estatus.Text = persona.UsuarioAsociado.Estatus;*/
                _vistaModificarEmpleado.Telefono.Text = persona.Telefono;
                _vistaModificarEmpleado.Correo.Text = persona.UsuarioAsociado.Correo;
                CargarEstatusUsuario(); 
                CargarDireccion(persona); 
                
            }

            else
            {
                _vistaModificarEmpleado.LabelMensajeError.Visible = true;
                _vistaModificarEmpleado.LabelMensajeError.Text = RecursosPresentadorUsuariosInternos.RegistrosVacios;
            }
        }
        #endregion

        /* Falta pasarle el id para que modifique la persona*/

        /// <summary>
        /// Método que crea una clase de tipo Persona 
        /// para asignarle los datos editados y enviárselos a 
        /// la BD.
        /// </summary>
        /// <param name="id">Id de la Persona o Empleado</param>
        /// <returns>Objeto de tipo Persona</returns>
        private Persona EditarEmpleado(int id) 
        {
            Entidad _entidadPersona = FabricaEntidad.ObtenerPersona();
            Entidad _entidadHash = FabricaEntidad.ObtenerHash();
            Hash _hash = (Hash)_entidadHash; 
            
             _empleado = (Persona)_entidadPersona;
             _empleado.Id = id; 
            _empleado.Cedula = _vistaModificarEmpleado.Cedula.Text;  
            _empleado.Nombre = _vistaModificarEmpleado.Nombre.Text;
            _empleado.SegundoNombre = _vistaModificarEmpleado.SegundoNombre.Text;
            _empleado.Apellido = _vistaModificarEmpleado.Apellido.Text;
            _empleado.SegundoApellido = _vistaModificarEmpleado.SegundoApellido.Text;
            _empleado.TipoDocumento = _vistaModificarEmpleado.TipoDocumento.SelectedItem.ToString();
            _empleado.Documento = _vistaModificarEmpleado.Cedula.Text;
            _empleado.FechaNacimiento = DateTime.Parse(_vistaModificarEmpleado.FechaNacimiento.Text);
            _empleado.Telefono = _vistaModificarEmpleado.Telefono.Text; 
            _empleado.UsuarioAsociado.Correo = _vistaModificarEmpleado.Correo.Text;
            _empleado.UsuarioAsociado.Contrasena = _hash.ObtenerMd5Hash(_vistaModificarEmpleado.Contrasena.Text);
            _empleado.UsuarioAsociado.FechaIngreso = DateTime.MaxValue;
            _empleado.UsuarioAsociado.FechaEgreso = DateTime.Now;
            _empleado.UsuarioAsociado.Estatus = _vistaModificarEmpleado.Estatus.Text;
            _empleado.FkLugar = Convert.ToInt16(_vistaModificarEmpleado.Ciudad.SelectedItem.Value);
            _empleado.NombreLugar = _vistaModificarEmpleado.Direccion.Text; 
                       

            return _empleado; 

        }

       
        /// <summary>
        /// Método que llama al método que llama al comando 
        /// de Modificar Empleado, para ser llamado
        /// al presionar Botón Siguiente
        /// </summary>
        /// <returns>Retorna true si 
        /// la operación de modificar fue éxitosa, sino
        /// retorna false</returns>

        public bool ModificarEmpleado() 
        {
            bool _resultado = false;
           

            if (ComandoModificarEmpleado(EditarEmpleado(7)))
                _resultado = true;

            return _resultado; 
        }



        /// <summary>
        /// Método que llama al comando Modificar Empleado
        /// </summary>
        /// <param name="parametro">Objeto de tipo Persona</param>
        /// <returns>true si realizó la actualización correctamente,
        /// false si no se pudo realizar</returns>
        private bool ComandoModificarEmpleado(Entidad parametro)
        {
            Comando<Entidad, bool> comandoModificarEmpleado = FabricaComando.ObtenerComandoModificarEmpleado();

            bool respuesta = comandoModificarEmpleado.Ejecutar(parametro);

            return respuesta; 
        }

       





    }
}