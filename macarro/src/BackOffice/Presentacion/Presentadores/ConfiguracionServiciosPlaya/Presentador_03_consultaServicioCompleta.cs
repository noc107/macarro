using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.ConfiguracionServiciosPlaya;

namespace BackOffice.Presentacion.Presentadores.ConfiguracionServiciosPlaya
{
    public class Presentador_03_consultaServicioCompleta : PresentadorGeneral
    {
        #region Párametros

        private IContrato_03_consultaServicioCompleta _consultaServicioCompleta;

        #endregion

        #region Constructor

        public Presentador_03_consultaServicioCompleta(IContrato_03_consultaServicioCompleta _consultaServicioCompleta)
            : base(_consultaServicioCompleta)
        {
            this._consultaServicioCompleta = _consultaServicioCompleta;
        }

        #endregion 

        #region Métodos

        public void cargarPagina()
        {
        
        }

        // Este método recibe (Servicio _servicio)
        public void mostrarDatosServicio()
        { 
        
        }
        
        // Este método recibe (Servicio _servicio)
        public void mostrarHorarioServicio()
        { 
        
        }

        // Este método recibe (DateTime _itemHora)
        public void obtenerHoraString()
        { 
        
        }

        #endregion
    }
}