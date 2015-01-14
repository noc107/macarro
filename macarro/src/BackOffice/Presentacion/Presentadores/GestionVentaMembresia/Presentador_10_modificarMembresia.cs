using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.LogicaNegocio;
using BackOffice.Dominio;
using BackOffice.Dominio.Fabrica;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Dominio.Entidades;
using BackOffice.Presentacion.Contratos.GestionVentaMembresia;


namespace BackOffice.Presentacion.Presentadores.GestionVentaMembresia
{
    public class Presentador_10_modificarMembresia : PresentadorGeneral
    {
        private IContrato_10_modificarMembresia _vista;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="laVistaDefault">interfaz</param>        
        public Presentador_10_modificarMembresia(IContrato_10_modificarMembresia laVistaDefault)
            : base(laVistaDefault)
        {
            _vista = laVistaDefault;
            
        }


        /// <summary>
        /// Metodo para la modificacion del descuento y del estado de la membresia
        /// </summary>                
        public void EventoAceptar_Click()
        {
            try
            {
                Entidad _membresia = FabricaEntidad.ObtenerMembresia();

                ((Membresia)_membresia).id = int.Parse(_vista.ID.Text);
                ((Membresia)_membresia).descAplicado = float.Parse(_vista.Descuento.Text);
                ((Membresia)_membresia).estado = _vista.Estado.SelectedValue;

                Comando<Entidad, bool> _comandoModificarMembresia;
                _comandoModificarMembresia = FabricaComando.ObtenerComandoModificarMembresia();
                _comandoModificarMembresia.Ejecutar(_membresia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}