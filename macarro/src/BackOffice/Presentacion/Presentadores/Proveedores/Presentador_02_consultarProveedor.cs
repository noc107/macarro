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
    public class Presentador_02_consultarProveedor : PresentadorGeneral
    {
        private IContrato_02_consultarProveedor _vista;
        private Proveedor p;

        public Presentador_02_consultarProveedor(IContrato_02_consultarProveedor laVistaDefault)
            : base(laVistaDefault)
        {
            _vista = laVistaDefault;
            
        }

        public void EventoClickVolver() 
        {
        
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
                _vista.RazonSocial.Text = p.RazonSocial;
                _vista.Pais.Text = p.IdLugar.ToString();
                _vista.Telefono.Text = p.Telefono;
                _vista.PaginaWeb.Text = p.PagWeb;
                _vista.FechaContrato.Text = p.FechaContrato;
                _vista.Correo.Text = p.Correo;
                _vista.Estado.Text = p.Status;
            }
        }
    }
}