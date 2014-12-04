using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_office.Dominio
{
    public class Caja
    {
        private float _saldoInicial;
        private float _saldoActual;
        private DateTime _fecha;
        private List<Factura> _factura;

        public Caja()
        {
            _saldoInicial = 0;
            _saldoActual = 0;
            _fecha = new DateTime();
            _factura = new List<Factura>();
        }

        #region PROPIEDADES
        public float SaldoInicial
        {
            get { return _saldoInicial; }
            set { _saldoInicial = value; }
        }

        public float SaldoActual
        {
            get { return _saldoActual; }
            set { _saldoActual = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public List<Factura> Factura
        {
            get { return _factura; }
            set { _factura = value; }
        }
        #endregion
    }
}