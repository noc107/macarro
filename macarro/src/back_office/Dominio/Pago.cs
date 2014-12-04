using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_office.Dominio
{
    public class Pago
    {
        private float _monto;
        private float _descuento;
        private DateTime _fecha;

        public Pago()
        {

        }
 
        public float Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }

        public float Descuento
        {
            get { return _descuento; }
            set { _descuento = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
    }
}