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
    public class Presentador_05_AgregarSeccion : PresentadorGeneral
    {
        private IContrato_05_AgregarSeccion _vista;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="vistaGestionMenu">Interfaz</param>
        public Presentador_05_AgregarSeccion(IContrato_05_AgregarSeccion vistaGestionMenu)
            : base(vistaGestionMenu)
        {
            _vista = vistaGestionMenu;
        }

        public void EventoAceptar_Click()
        {
            Entidad seccion = FabricaEntidad.ObtenerSeccion();
            ((Seccion)seccion).Nombre = _vista.nombre.Text;
            ((Seccion)seccion).Descripcion = _vista.descripcion.Text;
          
            Comando<Entidad, bool> ComandoAgregarSeccion;
            ComandoAgregarSeccion = FabricaComando.ObtenerComandoAgregarSeccion();
            ComandoAgregarSeccion.Ejecutar(seccion);
        }
    }
}