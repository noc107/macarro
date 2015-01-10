using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Presentacion.Contratos.MenuRestaurante;

namespace BackOffice.Presentacion.Presentadores.MenuRestaurante
{
    public class Presentador_05_AgregarProducto : PresentadorGeneral
    {
        private IContrato_05_AgregarPlato _vista;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="vistaGestionMenu">Interfaz</param>
        public Presentador_05_AgregarProducto(IContrato_05_AgregarPlato vistaGestionMenu)
            : base(vistaGestionMenu)
        {
            _vista = vistaGestionMenu;
        }

        public void EventoAceptar_Click()
        {
            Entidad plato = FabricaEntidad.ObtenerPlato();
            ((Plato)plato).Nombre = _vista.nombre.Text;
            ((Plato)plato).Descripcion = _vista.descripcion.Text;
            ((Plato)plato).Precio = float.Parse(_vista.precio.Text);

            Comando<Entidad, bool> ComandoAgregarPlato;
            ComandoAgregarPlato = FabricaComando.ObtenerComandoAgregarPlato();
            ComandoAgregarPlato.Ejecutar(plato);
        }
    }
}