using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.ConfiguracionServiciosPlaya;

namespace BackOffice.Presentacion.Presentadores.ConfiguracionServiciosPlaya
{
    public class Presentador_03_consultaServicio : PresentadorGeneral
    {
        #region Parámetros

        private IContrato_03_consultaServicio _consultaServicio;

        #endregion

        #region Constructor
        
        public Presentador_03_consultaServicio(IContrato_03_consultaServicio _consultaServicio)
            : base(_consultaServicio)
        {
            this._consultaServicio = _consultaServicio;
        }

        #endregion

        #region Métodos

        public void cargarPagina()
        { 
        
        }

        public void Servicios_RowCommand()
        { 
        
        }

        public void Servicios_RowDeleting()
        { 
        
        }

        public void Servicios_RowEditing()
        { 
        
        }

        public void Servicios_SelectedIndexChanging()
        { 
        
        }

        public void Servicios_PageIndexChanging()
        { 
        
        }

        public void Servicios_RowDataBound()
        { 
        
        }

        public void imgBuscar_Click()
        { 
        
        }

        #endregion
    }
}