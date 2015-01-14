using BackOffice.Presentacion.Contratos.ConfiguracionServiciosPlaya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Presentacion.Presentadores.ConfiguracionServiciosPlaya
{
    public class Presentador_3_modificarServiciosPlaya : PresentadorGeneral
    {
        private IContrato_3_modificarServiciosPlaya _contratoModificarServicio;

        #region Contructor

        public Presentador_3_modificarServiciosPlaya(IContrato_3_modificarServiciosPlaya _contratoModificarServicio)
            : base(_contratoModificarServicio)
        {
            this._contratoModificarServicio = _contratoModificarServicio;
        }

        #endregion

        #region Metodos

        public void CargarPagina()
        {

        }

        public void inicializarMensajes()
        {

        }

        public void inicializarCampos()
        {

        }

        public void agregarHorarioListBox()
        {

        }

        public void obtenerHoraString()
        {

        }

        public void llenarCategorias()
        {

        }

        public void validarHorario()
        {

        }

        public void aceptarBoton()
        {

        }

        public void agregarHorarioListbox()
        {

        }

        public void removerHorarioListbox()
        {

        }

        #endregion

    }
}