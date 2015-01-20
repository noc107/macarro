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
using BackOffice.Excepciones.ExcepcionesComando.Proveedores;
using BackOffice.Excepciones.ExcepcionesPresentacion.Proveedores;
using BackOffice.Excepciones;
using BackOffice.Presentacion.Presentadores.Proveedores.Recursos;

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
                                                             _vista.Telefono.Text, _vista.Direccion.Text, _vista.Ciudad.Text, _vista.Status.Text);
                Comando<Entidad, bool> comandoModificarProveedor;
                comandoModificarProveedor = FabricaComando.ObtenerComandoModificarProveedor();
                comandoModificarProveedor.Ejecutar(_proveedor);
                _vista.LabelMensajeExito.Visible = true;
                _vista.LabelMensajeError.Text = RecursosPresentadorProveedor.ItemModificado;
            }
            catch (ExcepcionComandoModificarProveedor e)
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionModificarProveedor Ex = new ExcepcionPresentacionModificarProveedor
                    (RecursosPresentadorProveedor.rs19,
                     RecursosPresentadorProveedor.PresentadorModificar,
                     RecursosPresentadorProveedor.Modificar,
                     RecursosPresentadorProveedor.ex19,
                     e); 
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje;

            }
            catch (Exception e) 
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionModificarProveedor Ex = new ExcepcionPresentacionModificarProveedor
                    (RecursosPresentadorProveedor.rs19,
                     RecursosPresentadorProveedor.PresentadorModificar,
                     RecursosPresentadorProveedor.Modificar,
                     RecursosPresentadorProveedor.ex199,
                     e);
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje;
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
            catch (ExcepcionComandoConsultarProveedor e)
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionModificarProveedor Ex = new ExcepcionPresentacionModificarProveedor
                    (RecursosPresentadorProveedor.rs19,
                     RecursosPresentadorProveedor.PresentadorModificar,
                     RecursosPresentadorProveedor.Modificar,
                     RecursosPresentadorProveedor.ex19,
                     e); Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje;
            }
            catch (Exception e) 
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionModificarProveedor Ex = new ExcepcionPresentacionModificarProveedor
                    (RecursosPresentadorProveedor.rs19,
                     RecursosPresentadorProveedor.PresentadorModificar,
                     RecursosPresentadorProveedor.Modificar,
                     RecursosPresentadorProveedor.ex199,
                     e); Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje;
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
                _vista.FechaContrato.Text = dt.ToString(RecursosPresentadorProveedor.yyymmdd);
                _vista.Correo.Text = p.Correo;

                string[]  split = p.IdLugar.Split(RecursosPresentadorProveedor.dospuntos.ToCharArray());
                string[] split2 = split[1].Split(RecursosPresentadorProveedor.puntoycoma.ToCharArray());
                _vista.Direccion.Text = split2[0];

                if (p.Status == RecursosPresentadorProveedor.Activado)
                {
                    _vista.Status.Items.Add(RecursosPresentadorProveedor.Activado);
                    _vista.Status.Items.Add(RecursosPresentadorProveedor.Desactivado);
                }
                else
                {
                    _vista.Status.Items.Add(RecursosPresentadorProveedor.Desactivado);
                    _vista.Status.Items.Add(RecursosPresentadorProveedor.Activado);                   
                }   
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
            try
            {
                _paises = comandoBuscarPaisesCompletos.Ejecutar(RecursosPresentadorProveedor.Paises);
                foreach (string pais in _paises)
                {
                    _vista.Pais.Items.Add(pais);
                }
            }
            catch (ExcepcionComandoObtenerPaisesTodos e)
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionModificarProveedor Ex = new ExcepcionPresentacionModificarProveedor
                    (RecursosPresentadorProveedor.rs19,
                     RecursosPresentadorProveedor.PresentadorModificar,
                     RecursosPresentadorProveedor.Modificar,
                     RecursosPresentadorProveedor.ex19,
                     e);                
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje;
            }
            catch (Exception e) 
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionModificarProveedor Ex = new ExcepcionPresentacionModificarProveedor
                    (RecursosPresentadorProveedor.rs19,
                     RecursosPresentadorProveedor.PresentadorModificar,
                     RecursosPresentadorProveedor.Modificar,
                     RecursosPresentadorProveedor.ex199,
                     e); 
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje;
            }
        }


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
            catch (ExcepcionComandoObtenerTodasLasCiudades e)
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionModificarProveedor Ex = new ExcepcionPresentacionModificarProveedor
                    (RecursosPresentadorProveedor.rs19,
                     RecursosPresentadorProveedor.PresentadorModificar,
                     RecursosPresentadorProveedor.Modificar,
                     RecursosPresentadorProveedor.ex19,
                     e);                
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje;
            }
            catch (Exception e)
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionModificarProveedor Ex = new ExcepcionPresentacionModificarProveedor
                    (RecursosPresentadorProveedor.rs19,
                     RecursosPresentadorProveedor.PresentadorModificar,
                     RecursosPresentadorProveedor.Modificar,
                     RecursosPresentadorProveedor.ex199,
                     e);                
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje;
            }
        }


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
            catch (ExcepcionComandoObtenerTodosLosEstados e)
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionModificarProveedor Ex = new ExcepcionPresentacionModificarProveedor
                    (RecursosPresentadorProveedor.rs19,
                     RecursosPresentadorProveedor.PresentadorModificar,
                     RecursosPresentadorProveedor.Modificar,
                     RecursosPresentadorProveedor.ex19,
                     e);                
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje;
            }
            catch (Exception e)
            {
                _vista.LabelMensajeError.Visible = true;
                ExcepcionPresentacionModificarProveedor Ex = new ExcepcionPresentacionModificarProveedor(RecursosPresentadorProveedor.rs19,
                     RecursosPresentadorProveedor.PresentadorModificar,
                     RecursosPresentadorProveedor.Modificar,
                     RecursosPresentadorProveedor.ex199,
                     e); 
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeError.Text = Ex.Mensaje;
            }
        }

    }
}