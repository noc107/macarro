using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.Proveedores;
using BackOffice.LogicaNegocio;
using BackOffice.Dominio;
using BackOffice.Dominio.Fabrica;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Dominio.Entidades;
using BackOffice.Excepciones.ExcepcionesComando.Proveedores;
using BackOffice.Excepciones.ExcepcionesPresentacion.Proveedores;
using BackOffice.Excepciones;
using BackOffice.Presentacion.Presentadores.Proveedores.Recursos;

namespace BackOffice.Presentacion.Presentadores.Proveedores
{
    public class Presentador_02_agregarProveedores : PresentadorGeneral
    {
        private IContrato_02_agregarProveedores _vista;
        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="laVistaDefault">Contrato que contiene la vista</param>
        public Presentador_02_agregarProveedores(IContrato_02_agregarProveedores laVistaDefault)
            : base(laVistaDefault)
        {
            _vista = laVistaDefault;
            
        }
        /// <summary>
        /// Metodo que se utiliza para agregar un proveedor
        /// </summary>
        public void EventoClickBotonAceptar() 
        {
            try
            {
                Dominio.Entidad _proveedor;
                _proveedor = FabricaEntidad.ObtenerProveedor(1, _vista.Rif.Text, _vista.RazonSocial.Text, _vista.Correo.Text,
                                                                _vista.PaginaWeb.Text, _vista.FechaContrato.Text,_vista.Telefono.Text,
                                                                _vista.Direccion.Text, _vista.Ciudad.Text);
                Comando<Entidad, bool> comandoAgregarProveedor;
                comandoAgregarProveedor = FabricaComando.ObtenerComandoAgregarProveedor();
                comandoAgregarProveedor.Ejecutar(_proveedor);
                _vista.LabelMensajeExito.Visible = true;
                _vista.LabelMensajeExito.Text = RecursosPresentadorProveedor.ProvExito;
            }
            catch (ExcepcionComandoAgregarProveedor e)
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionAgregarProveedor Ex = new ExcepcionPresentacionAgregarProveedor
                    (RecursosPresentadorProveedor.rs19,
                     RecursosPresentadorProveedor.PresentadorAgregar,
                     RecursosPresentadorProveedor.Agregar,
                     RecursosPresentadorProveedor.ex19,
                     e);
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje;
            }
            catch (Exception e) 
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionAgregarProveedor Ex = new ExcepcionPresentacionAgregarProveedor
                    (RecursosPresentadorProveedor.rs19,
                     RecursosPresentadorProveedor.PresentadorAgregar,
                     RecursosPresentadorProveedor.Agregar,
                     RecursosPresentadorProveedor.ex199,
                     e); 
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje;
            }
        
        }

        public void EventoClickBotonVolver() 
        {
        
        }
        /// <summary>
        /// Metodo que se usa para cargar los paises
        /// </summary>
        public void cargarPaises() 
        {
            List<string> _paises;
            Comando<string, List<string>> comandoBuscarPaisesCompletos;
            comandoBuscarPaisesCompletos = FabricaComando.ObtenerComandoPaisesTodos();
            try
            {
                _paises = comandoBuscarPaisesCompletos.Ejecutar(RecursosPresentadorProveedor.Paises);
                foreach (string pais in _paises)
                {
                    _vista.Pais.Items.Add(pais);
                }
            }
            catch (Exception e) 
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionAgregarProveedor Ex = new ExcepcionPresentacionAgregarProveedor
                    (RecursosPresentadorProveedor.rs19,
                     RecursosPresentadorProveedor.PresentadorAgregar,
                     RecursosPresentadorProveedor.Agregar,
                     RecursosPresentadorProveedor.ex199,
                     e); 
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje; 
            }
        }
        /// <summary>
        /// Metodo que se usa para cargar los estados
        /// </summary>
        public void cargarEstados() 
        {
            List<string> _estados;
            Comando<string, List<string>> comandoBuscarEstadosCompletos;
            comandoBuscarEstadosCompletos = FabricaComando.ObtenerComandoEstadosTodos();
            try
            {
                _estados = comandoBuscarEstadosCompletos.Ejecutar(RecursosPresentadorProveedor.Estados);
                foreach (string estado in _estados)
                {
                    _vista.Estado.Items.Add(estado);
                }
            }
            catch (Exception e)
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionAgregarProveedor Ex = new ExcepcionPresentacionAgregarProveedor
                    (RecursosPresentadorProveedor.rs19,
                     RecursosPresentadorProveedor.PresentadorAgregar,
                     RecursosPresentadorProveedor.Agregar,
                     RecursosPresentadorProveedor.ex19,
                     e);
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje;
            }
        }
        /// <summary>
        /// Metodo que se usa para cargar las ciudades
        /// </summary>
        public void cargarCiudades() 
        {
            List<string> _ciudades;
            Comando<string, List<string>> comandoBuscarCiudadesCompletos;
            comandoBuscarCiudadesCompletos = FabricaComando.ObtenerComandoCiudadesTodas();
            try
            {
                _ciudades = comandoBuscarCiudadesCompletos.Ejecutar(RecursosPresentadorProveedor.Ciudades);
                foreach (string ciudad in _ciudades)
                {
                    _vista.Ciudad.Items.Add(ciudad);
                }
            }
            catch (Exception e)
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionAgregarProveedor Ex = new ExcepcionPresentacionAgregarProveedor
                    (RecursosPresentadorProveedor.rs19,
                     RecursosPresentadorProveedor.PresentadorAgregar,
                     RecursosPresentadorProveedor.Agregar,
                     RecursosPresentadorProveedor.ex19,
                     e); 
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje;
            }
        }

        /// <summary>
        /// Metodo que se utiliza para cargar los estados de un pais
        /// </summary>
        public void EventoCambioPais()
        {
            List<string> _estados;
            string _nombrePais = _vista.Pais.SelectedItem.Text;
            Comando<string, List<string>> comandoBuscarEstados;
            comandoBuscarEstados = FabricaComando.ObtenerComandoEstadosDePais();
            try
            {
                _estados = comandoBuscarEstados.Ejecutar(_nombrePais);
                foreach (string estado in _estados)
                {
                    _vista.Estado.Items.Add(estado);
                }
            }
            catch (Exception e)
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionAgregarProveedor Ex = new ExcepcionPresentacionAgregarProveedor
                    (RecursosPresentadorProveedor.rs19,
                     RecursosPresentadorProveedor.PresentadorAgregar,
                     RecursosPresentadorProveedor.Agregar,
                     RecursosPresentadorProveedor.ex19,
                     e); 
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje;
            }
        }

        /// <summary>
        /// Metodo que se utiliza para obtener las ciudades de un estado
        /// </summary>
        public void EventoCambioEstado() 
        {
            List<string> _ciudades;
            string _nombreEstado = _vista.Estado.SelectedItem.Text;
            Comando<string, List<string>> comandoBuscarCiudades;
            comandoBuscarCiudades = FabricaComando.ObtenerComandoCiudadesDeEstado();
            try
            {
                _ciudades = comandoBuscarCiudades.Ejecutar(_nombreEstado);
                foreach (string ciudad in _ciudades)
                {
                    _vista.Ciudad.Items.Add(ciudad);
                }
            }
            catch (Exception e)
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionAgregarProveedor Ex = new ExcepcionPresentacionAgregarProveedor
                    (RecursosPresentadorProveedor.rs19,
                     RecursosPresentadorProveedor.PresentadorAgregar,
                     RecursosPresentadorProveedor.Agregar,
                     RecursosPresentadorProveedor.ex19,
                     e); 
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje;
            }
        }
    }
}