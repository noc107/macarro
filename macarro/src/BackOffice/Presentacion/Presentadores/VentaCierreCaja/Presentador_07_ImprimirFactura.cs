using System.Data;
using BackOffice.Presentacion.Contratos.VentaCierreCaja;
using BackOffice.Dominio;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.LogicaNegocio;
using BackOffice.Dominio.Entidades;
using System;
using BackOffice.Presentacion.Presentadores.VentaCierreCaja.Recursos;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Presentadores.VentaCierreCaja
{
    public class Presentador_07_ImprimirFactura : PresentadorGeneral
    {
        private IContrato_07_ImprimirFactura _contratoImprimirFactura;
        private DataTable _dt;

        public Presentador_07_ImprimirFactura(IContrato_07_ImprimirFactura _contrato) 
            : base(_contrato)
        {
            this._contratoImprimirFactura = _contrato;
        }

        /// <summary>
        /// Metodo de paginacion del GridView
        /// </summary>
        /// <param name="e">Evento de paginacion GridView</param>
        public void gridFactura_PageIndexChanging(GridViewPageEventArgs e)
        {
            this._contratoImprimirFactura.GridFactura.PageIndex = e.NewPageIndex;
            this._contratoImprimirFactura.GridFactura.DataSource = this._dt;
            this._contratoImprimirFactura.GridFactura.DataBind();
        }


        /// <summary>
        /// Metodo de obtencion de los datos basicos de la factura seleccionada, para ser mostrados a al usuario
        /// </summary>
        /// <param name="_nroFactura">Nro de la factura a consultar e imprimir</param>
        public void mostrarDatosBasicosFactura(int _nroFactura)
        {
            Entidad _factura;
            Factura _facturaImprimir;
            Persona _cliente;

            Comando<int, Entidad> _comandoDatosFactura = FabricaComando.ObtenerComandoConsultarDatosBasicosFactura();
            Comando<int, Entidad> _comandoClienteFactura = FabricaComando.ObtenerComandoConsultarClienteFactura();
            Comando<int, DataTable> _comandoLineaFactura = FabricaComando.ObtenerComandoConsultarLineaFactura();

            this._dt = new DataTable();

            try
            {

                _factura = _comandoDatosFactura.Ejecutar(_nroFactura);
                _facturaImprimir = (Factura)_factura;

                _factura = _comandoClienteFactura.Ejecutar(_nroFactura);
                _cliente = (Persona)_factura;

                this._dt = _comandoLineaFactura.Ejecutar(_nroFactura);

                this.llenarDatosFactura(_facturaImprimir, _cliente, this._dt);
                              
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void llenarDatosFactura(Factura _datosFactura, Persona _datosCliente, DataTable _lineaFactura)
        {

            float _impuesto;
            float _descuento;

            _impuesto = _datosFactura.SubTotal * float.Parse(RecursoVentaCierreCaja.Impuesto);
            _descuento = (_datosFactura.SubTotal + _impuesto) - _datosFactura.Total;

            this._contratoImprimirFactura.LabelDocIdentidadCliente = _datosCliente.Documento;
            this._contratoImprimirFactura.LabelNombreCliente = _datosCliente.Nombre;
            this._contratoImprimirFactura.LabelApellidoCliente = _datosCliente.Apellido;
           
            this._contratoImprimirFactura.GridFactura.DataSource = _lineaFactura;
            this._contratoImprimirFactura.GridFactura.DataBind();

            this._contratoImprimirFactura.LabelFechaFactura = Convert.ToDateTime(_datosFactura.Fecha).ToString("dd/MM/yyyy");
            this._contratoImprimirFactura.LabelSubTotal = _datosFactura.SubTotal.ToString();       
            this._contratoImprimirFactura.LabelMontoIVA = _impuesto.ToString();
            this._contratoImprimirFactura.LabelTotal = _datosFactura.Total.ToString() + RecursoVentaCierreCaja.UnidadMonetaria;

           this._contratoImprimirFactura.LabelDescuento = RecursoVentaCierreCaja.Negativo + Math.Round((double)_descuento, 2).ToString();

        }

    }
}