using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Presentacion.Contratos.Proveedores;

namespace BackOffice.Presentacion.Presentadores.Proveedores
{
    public class Presentador_02_modificarProveedor : PresentadorGeneral
    {
        private IContrato_02_modificarProveedor _vista;
        private Proveedor p;
       
        public Presentador_02_modificarProveedor(IContrato_02_modificarProveedor laVistaDefault)
            : base(laVistaDefault)
        {
            _vista = laVistaDefault;
            
        }

        public void EventoClickBotonAceptar() 
        {
            try
            {
                Dominio.Entidad _proveedor;
                _proveedor = FabricaEntidad.ObtenerProveedor(1, _vista.Rif.Text, _vista.RazonS.Text, _vista.Correo.Text, _vista.PaginaWeb.Text, _vista.FechaContrato.Text,
                                                             _vista.Telefono.Text, _vista.Direccion.Text,_vista.Ciudad.Text,_vista.Status.Text);
                Comando<Entidad, bool> comandoModificarProveedor;
                comandoModificarProveedor = FabricaComando.ObtenerComandoModificarProveedor();
                comandoModificarProveedor.Ejecutar(_proveedor);
                _vista.LabelMensajeExito.Visible = true;
                _vista.LabelMensajeError.Text = "Exito";
            }
            catch (Exception e)
            {

            }
        }

        public void EventoBotonConsultar(int idProveedor)
        {
            try
            {
                Dominio.Entidad _proveedor;

                Comando<int, Entidad> comandoConsultarProveedor;
                _proveedor = FabricaEntidad.ObtenerProveedor();
                comandoConsultarProveedor = FabricaComando.ObtenerComandoConsultarProveedor();

                _proveedor = comandoConsultarProveedor.Ejecutar(idProveedor);

                if (_proveedor != null)
                {
                    p = (Proveedor)_proveedor;
                    LlenarDatos(p);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void LlenarDatos(Proveedor p)
        {
            if (p != null)
            {

                _vista.Rif.Text = p.Rif;
                _vista.RazonS.Text = p.RazonSocial;
                _vista.Pais.Text = p.IdLugar.ToString();
                _vista.Telefono.Text = p.Telefono;
                _vista.PaginaWeb.Text = p.PagWeb;
                DateTime dt = Convert.ToDateTime(p.FechaContrato);
                _vista.FechaContrato.Text = dt.ToString("yyyy/MM/dd");
                _vista.Correo.Text = p.Correo;

                string[]  split = p.IdLugar.Split(':');
                string[] split2 = split[1].Split(';');
                _vista.Direccion.Text = split2[0] + '.';

            
                _vista.Status.Items.Add("Activado");
                _vista.Status.Items.Add("Desactivado");
                //_vista.Estado.Text = p.Status;
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


        //public void EventoCambioPais()
        //{
        //    List<string> _estados;
        //    string _nombrePais = _vista.Pais.SelectedItem.Text;
        //    Comando<string, List<string>> comandoBuscarEstados;
        //    comandoBuscarEstados = FabricaComando.ObtenerComandoEstadosDePais();
        //    _estados = comandoBuscarEstados.Ejecutar(_nombrePais);
        //    foreach (string estado in _estados)
        //    {
        //        _vista.Estado.Items.Add(estado);
        //    }
        //}

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


        //public void EventoCambioEstado()
        //{
        //    List<string> _ciudades;
        //    string _nombreEstado = _vista.Estado.SelectedItem.Text;
        //    Comando<string, List<string>> comandoBuscarCiudades;
        //    comandoBuscarCiudades = FabricaComando.ObtenerComandoCiudadesDeEstado();
        //    _ciudades = comandoBuscarCiudades.Ejecutar(_nombreEstado);
        //    foreach (string ciudad in _ciudades)
        //    {
        //        _vista.Ciudad.Items.Add(ciudad);
        //    }

        //}


    }
}