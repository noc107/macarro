using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.ConfiguracionPuestosPlaya;
using BackOffice.Presentacion.Presentadores;
using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Comandos;
using BackOffice.LogicaNegocio.Fabrica;

namespace BackOffice.Presentacion.Presentadores.ConfiguracionPuestosPlaya
{
    public class Presentador_2_consultarPuesto : PresentadorGeneral
    {
        private IContrato_2_consultarPuesto _vista;

        public Presentador_2_consultarPuesto(IContrato_2_consultarPuesto vistaPrincipal)
            : base(vistaPrincipal)
        {
            _vista = vistaPrincipal;                       
        }

        public void EventoClickConsultarPuesto()
        {
            _vista.LabelMensajeExito.Visible = true;
            MostrarMensajeExito("logrado");
        }

        public void EventoEliminarPuestoSeleccionado(int idInventario)
        {

        }

        public void EventoEliminarFilaColumna()
        {

        }

        public string EventoModificar()
        {
            return RecursosPresentador.PaginaModificarPuesto;
        }
    }
}