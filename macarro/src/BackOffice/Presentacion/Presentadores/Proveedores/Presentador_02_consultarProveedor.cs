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
using BackOffice.Excepciones.ExcepcionesPresentacion.Proveedores;
using BackOffice.Excepciones.ExcepcionesComando.Proveedores;
using BackOffice.Excepciones;
using BackOffice.Presentacion.Presentadores.Proveedores.Recursos;

namespace BackOffice.Presentacion.Presentadores.Proveedores
{
    public class Presentador_02_consultarProveedor : PresentadorGeneral
    {
        private IContrato_02_consultarProveedor _vista;
        private Proveedor p;
        /// <summary>
        /// Constructor de la clase 
        /// </summary>
        /// <param name="laVistaDefault">Contrato que contiene la vista</param>
        public Presentador_02_consultarProveedor(IContrato_02_consultarProveedor laVistaDefault)
            : base(laVistaDefault)
        {
            _vista = laVistaDefault;
            
        }

        public void EventoClickVolver() 
        {
        
        }
        /// <summary>
        /// Metodo que se usa para consultar un proveedor
        /// </summary>
        /// <param name="idProveedor">Integer que contiene el id del proveedor</param>
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
            catch (ExcepcionComandoConsultarProveedor ex)
            {
                _vista.LabelMensajeExito.CssClass = RecursosPresentadorProveedor.AvMenErr;
                _vista.LabelMensajeExito.Visible = true;
                 
                ExcepcionPresentacionConsultarProveedor Ex = new ExcepcionPresentacionConsultarProveedor
                    (RecursosPresentadorProveedor.rs19,
                     RecursosPresentadorProveedor.PresentadorConsultar,
                     RecursosPresentadorProveedor.Consultar,
                     RecursosPresentadorProveedor.ex19,
                     ex); 
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeExito.Text = Ex.Mensaje;
            }
            catch (Exception e) 
            {
                _vista.LabelMensajeExito.CssClass = RecursosPresentadorProveedor.AvMenErr;
                _vista.LabelMensajeExito.Visible = true;
                 
                ExcepcionPresentacionConsultarProveedor Ex = new ExcepcionPresentacionConsultarProveedor
                    (RecursosPresentadorProveedor.rs19,
                     RecursosPresentadorProveedor.PresentadorConsultar,
                     RecursosPresentadorProveedor.Consultar,
                     RecursosPresentadorProveedor.ex199,
                     e);
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeExito.Text = Ex.Mensaje;
            }
            
        }
        /// <summary>
        /// Metodo que carga los datos en la vista
        /// </summary>
        /// <param name="p">Proveedor con la informacion a mostrar</param>
        public void LlenarDatos(Proveedor p)
        {
            if (p != null)
            {

                _vista.Rif.Text = p.Rif;
                _vista.RazonSocial.Text = p.RazonSocial;
                _vista.Pais.Text = p.IdLugar.ToString();
                _vista.Telefono.Text = p.Telefono;
                _vista.PaginaWeb.Text = p.PagWeb;
                _vista.FechaContrato.Text = p.FechaContrato;
                _vista.Correo.Text = p.Correo;
                _vista.Estado.Text = p.Status;
            }
        }

        /// <summary>
        /// Metodo que se utiliza para cargar los items del proveedor
        /// </summary>
        /// <param name="idProveedor">Integer con el id del proveedor</param>
        public void cargarItems(int idProveedor)
        {            
            List<string> items;
            Comando<int, List<string>> comandoCargar;
            comandoCargar = FabricaComando.ObtenerComandoCargarItem();
            try
            {
                items = comandoCargar.Ejecutar(idProveedor);
                foreach (string itemproveedor in items)
                {
                    _vista.Items.Items.Add(itemproveedor);
                }
            }
            catch (Exception e)
            {
                _vista.LabelMensajeExito.CssClass = RecursosPresentadorProveedor.AvMenErr;
                _vista.LabelMensajeExito.Visible = true;
                 
                ExcepcionPresentacionConsultarProveedor Ex = new ExcepcionPresentacionConsultarProveedor
                    (RecursosPresentadorProveedor.rs19,
                     RecursosPresentadorProveedor.PresentadorConsultar,
                     RecursosPresentadorProveedor.Consultar,
                     RecursosPresentadorProveedor.ex19,
                     e);
                Logger.EscribirEnLogger(Ex);
                _vista.LabelMensajeExito.Text = Ex.Mensaje;
            }
        }

    }
}