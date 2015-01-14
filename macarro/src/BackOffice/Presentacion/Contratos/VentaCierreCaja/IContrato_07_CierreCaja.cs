using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.VentaCierreCaja
{
    public interface IContrato_07_CierreCaja : IContratoGeneral
    {
        // Por día
        DropDownList tipoIngresoDia { get; }

        DateTime textBoxDiaSeleccionado { get; }

        bool contenedorConsultaDiaVisibilidad { get; }

        bool contenedorConsultaDiaVisibilidadAsignar { set; }

        string hiddenValoresDiasGrafica { set; }

        string hiddenFechaDiaGrafica { set; }

        string labelTituloReporteDia { set; }

        string labelInformacionFechaDia { set; }

        string labelInformacionFacturasDia { set; }

        string labelInformacionSaldoAnteriorDia { set; }

        string labelInformacionIngresoDia { set; }

        string labelInformacionTotalDia { set; }

        void generarGraficaSemanal();
        
        // Por mes
        DropDownList tipoIngresoMes { get; }

        DropDownList cierreCajaMes { get; }

        string dropDownListAñoSeleccionado { get; }

        bool contenedorConsultaMesVisibilidad { get; }

        bool contenedorConsultaMesVisibilidadAsignar { set; }

        string hiddenValoresMesGrafica { set; }

        string hiddenFechaMesGrafica { set; }

        string labelTituloReporteMes { set; }

        string labelInformacionFechaMes { set; }

        string labelInformacionFacturasMes { set; }

        string labelInformacionSaldoAnteriorMes { set; }

        string labelInformacionIngresoMes { set; }

        string labelInformacionTotalMes { set; }

        void generarGraficaMensual();
        
    }
}