using BackOffice.Presentacion.Contratos.VentaCierreCaja;
using BackOffice.Presentacion.Presentadores.VentaCierreCaja;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace back_office.Interfaz.web.VentaCierreCaja
{
    public partial class web_07_cierreCaja : System.Web.UI.Page, IContrato_07_CierreCaja
    {

        private Presentador_07_CierreCaja _presentador;

        public web_07_cierreCaja()
        {
            this._presentador = new Presentador_07_CierreCaja(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGenerarDia_Click(object sender, EventArgs e)
        {
            this._presentador.EventoButtonGenerarDia_Click();
        }

        protected void ButtonGenerarMes_Click(object sender, EventArgs e)
        {
            this._presentador.EventoButtonGenerarMes_Click();
        }

        public Label LabelMensajeExito
        {
            get
            {
                return this.MensajeExito;
            }
            set
            {
                this.MensajeExito = value;
            }
        }

        public Label LabelMensajeError
        {
            get
            {
                return this.MensajeError;
            }
            set
            {
                this.MensajeError = value;
            }
        }

        // Por día
        #region Implementación de metodos del contrato (Dia)

        public DropDownList tipoIngresoDia
        {
            get { return this.DropDownListTipoDias; }
        }

        public DateTime textBoxDiaSeleccionado 
        {
            get { return DateTime.ParseExact(this.TextBoxDia.Text, "yyyy-mm-dd", CultureInfo.InvariantCulture); } 
        }

        public bool contenedorConsultaDiaVisibilidad 
        {
            get { return this.contenedorConsultaDia.Visible; }
        }

        public bool contenedorConsultaDiaVisibilidadAsignar
        {
            set { this.contenedorConsultaDia.Visible = value; }
        }

        public string hiddenValoresDiasGrafica 
        {
            set { this.hiddenValoresDias.Value = value; }
        }

        public string hiddenFechaDiaGrafica
        {
            set { this.hiddenFechaDia.Value = value; } 
        }

        public string labelTituloReporteDia
        {
            set { this.tituloReporteDia.InnerText = value; }
        }

        public string labelInformacionFechaDia 
        {
            set { this.informacionFechaDia.Text = value; }
        }

        public string labelInformacionFacturasDia 
        {
            set { this.informacionFacturasDia.Text = value; }
        }

        public string labelInformacionSaldoAnteriorDia 
        {
            set { this.informacionSaldoAnteriorDia.Text = value; }
        }

        public string labelInformacionIngresoDia 
        {
            set { this.informacionIngresoDia.Text = value; }
        }

        public string labelInformacionTotalDia 
        {
            set { this.informacionTotalDia.Text = value; }
        }

        public void generarGraficaSemanal() 
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "generarGrafica", "generarGrafica();", true);        
        }
        #endregion

        // Por Mes
        #region Implementación de metodos del contrato (Mes)

        public DropDownList tipoIngresoMes 
        {
            get { return this.DropDownListTipoMes; }
        }

        public DropDownList cierreCajaMes
        {
            get { return this.DropDownListMes; } 
        }

        public string dropDownListAñoSeleccionado 
        {
            get { return this.DropDownListAño.SelectedValue; }
        }

        public bool contenedorConsultaMesVisibilidad 
        {
            get { return this.contenedorConsultaMes.Visible; }
        }

        public bool contenedorConsultaMesVisibilidadAsignar 
        {
            set { this.contenedorConsultaMes.Visible = value; }
        }

        public string hiddenValoresMesGrafica 
        {
            set { this.hiddenValoresMes.Value = value; }
        }

        public string hiddenFechaMesGrafica 
        {
            set { this.hiddenFechaMes.Value = value; }
        }

        public string labelTituloReporteMes
        {
            set { this.tituloReporteMes.InnerText = value; }
        }

        public string labelInformacionFechaMes 
        {
            set { this.informacionFechaMes.Text = value; }
        }

        public string labelInformacionFacturasMes 
        {
            set { this.informacionFacturasMes.Text = value; }
        }

        public string labelInformacionSaldoAnteriorMes 
        {
            set { this.informacionSaldoAnteriorMes.Text = value; }
        }

        public string labelInformacionIngresoMes 
        {
            set { this.informacionIngresoMes.Text = value; }
        }

        public string labelInformacionTotalMes 
        {
            set { this.informacionTotalMes.Text = value; }
        }

        public void generarGraficaMensual()
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "generarGraficaMes", "generarGraficaMes();", true);
        }

        #endregion
    }
}