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


namespace BackOffice.Presentacion.Presentadores.Proveedores
{
    public class Presentador_02_agregarProveedores : PresentadorGeneral
    {
        private IContrato_02_agregarProveedores _vista;
        

        public Presentador_02_agregarProveedores(IContrato_02_agregarProveedores laVistaDefault)
            : base(laVistaDefault)
        {
            _vista = laVistaDefault;
            
        }

        public void EventoClickBotonAceptar() 
        {
            try 
            {
                Dominio.Entidad _proveedor;
                _proveedor = FabricaEntidad.ObtenerProveedor(1,_vista.Rif.Text,_vista.RazonSocial.Text,_vista.Correo.Text,_vista.PaginaWeb.Text,_vista.FechaContrato.Text,
                                                             _vista.Telefono.Text,_vista.Direccion.Text,_vista.Ciudad.Text);
                Comando<Entidad, bool> comandoAgregarProveedor;
                comandoAgregarProveedor = FabricaComando.ObtenerComandoAgregarProveedor();
                comandoAgregarProveedor.Ejecutar(_proveedor);
            }
            catch(Exception e)
            {
            
            }
        
        }

        public void EventoClickBotonVolver() 
        {
        
        }
        public void cargarPaises() 
        {
            List<string> _paises;
            Comando<string, List<string>> comandoBuscarPaisesCompletos;
            comandoBuscarPaisesCompletos = FabricaComando.ObtenerComandoPaisesTodos();
            _paises = comandoBuscarPaisesCompletos.Ejecutar("Paises");
            foreach (string pais in _paises) 
            {
                _vista.Pais.Items.Add(pais);
            }
        }

        public void cargarEstados() 
        {
            List<string> _estados;
            Comando<string, List<string>> comandoBuscarEstadosCompletos;
            comandoBuscarEstadosCompletos = FabricaComando.ObtenerComandoEstadosTodos();
            _estados = comandoBuscarEstadosCompletos.Ejecutar("Estados");
            foreach (string estado in _estados)
            {
                _vista.Estado.Items.Add(estado);
            }
        }

        public void cargarCiudades() 
        {
            List<string> _ciudades;
            Comando<string, List<string>> comandoBuscarCiudadesCompletos;
            comandoBuscarCiudadesCompletos = FabricaComando.ObtenerComandoCiudadesTodas();
            _ciudades = comandoBuscarCiudadesCompletos.Ejecutar("Ciudades");
            foreach (string ciudad in _ciudades)
            {
                _vista.Ciudad.Items.Add(ciudad);
            }
        }

        public void EventoCambioPais()
        {
            List<string> _estados;
            string _nombrePais = _vista.Pais.SelectedItem.Text;
            Comando<string, List<string>> comandoBuscarEstados;
            comandoBuscarEstados = FabricaComando.ObtenerComandoEstadosDePais();
            _estados = comandoBuscarEstados.Ejecutar(_nombrePais);
            foreach(string estado in _estados)
            {
                _vista.Estado.Items.Add(estado);
            }
        }

        public void EventoCambioEstado() 
        {
            List<string> _ciudades;
            string _nombreEstado = _vista.Estado.SelectedItem.Text;
            Comando<string, List<string>> comandoBuscarCiudades;
            comandoBuscarCiudades = FabricaComando.ObtenerComandoCiudadesDeEstado();
            _ciudades = comandoBuscarCiudades.Ejecutar(_nombreEstado);
            foreach (string ciudad in _ciudades) 
            {
                _vista.Ciudad.Items.Add(ciudad);
            }

        }
    }
}