using System.Data;
using BackOffice.Presentacion.Contratos.VentaCierreCaja;

namespace BackOffice.Presentacion.Presentadores.VentaCierreCaja
{
    public class Presentador_07_ImprimirFactura : PresentadorGeneral
    {
        private IContrato_07_ImprimirFactura _contratoImprimirFactura;

        public Presentador_07_ImprimirFactura(IContrato_07_ImprimirFactura _contrato) 
            : base(_contrato)
        {
            this._contratoImprimirFactura = _contrato;
        }

    }
}