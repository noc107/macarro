using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_office.Dominio
{
    public class Factura
    {
        private string _codigo;
        private DateTime _fecha;
        private List<LineaFactura> _lineas;
        private float _subTotal;
        private float _total;

        public Factura()
        {
            _codigo = null;
            _fecha = new DateTime();
            _lineas = new List<LineaFactura>();
            _subTotal = 0;
            _total = 0;
        }

        #region PROPIEDADES
        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public List<LineaFactura> Lineas
        {
            get { return _lineas; }
            set { _lineas = value; }
        }

        public float SubTotal
        {
            get { return _subTotal; }
            set { _subTotal = value; }
        }

        public float Total
        {
            get { return _total; }
            set { _total = value; }
        }
        #endregion       
    }
}