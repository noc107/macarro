using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.MenuRestaurante;
using BackOffice.LogicaNegocio;
using BackOffice.Dominio;
using BackOffice.Dominio.Fabrica;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Dominio.Entidades;

namespace BackOffice.Presentacion.Presentadores.MenuRestaurante
{
    public class Presentador_05_ConsultarSeccion : PresentadorGeneral
    {
        private IContrato_05_ConsultarSeccion _vista;
        //private Seccion _s;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="vistaDefault"></param>
        public Presentador_05_ConsultarSeccion(IContrato_05_ConsultarSeccion VistaDefault)
            : base(VistaDefault)
        {
            _vista = VistaDefault;
        }

        /// <summary>
        /// Metodo para mostrar la informacion de la seccion
        /// </summary>
        public void EventoConsultar()
        {

            Comando<int, Entidad> ComandoConsultarSeccion;
            ComandoConsultarSeccion = FabricaComando.ObtenerComandoConsultarSeccion();
            Entidad SeccionActual = ComandoConsultarSeccion.Ejecutar(1);

            _vista.nombre.Text = ((Seccion)SeccionActual).Nombre;
            _vista.descripcion.Text = ((Seccion)SeccionActual).Descripcion;
        }
    }
}