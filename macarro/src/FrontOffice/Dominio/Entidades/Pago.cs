using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontOffice.Dominio.Entidades;

namespace FrontOffice.Dominio.Entidades
{
    public class Pago : Entidad
    {
        int _id;
        Tarjeta tarjeta;
        DateTime fechaPagoG;
        float montoG;

        public Pago(Tarjeta tarjeta, DateTime fechaPago, float monto,int id)
        {
            this.tarjeta = tarjeta;
            this.fechaPagoG = fechaPago;
            this.montoG = monto;
            _id = id;
        }

        public Tarjeta tarjetaGet
        {
            get { return tarjeta; }
            set { tarjeta = value; }
        }
        public DateTime fechaPago
        {
            get { return fechaPagoG; }
            set { fechaPagoG = value; }
        }
        public float monto
        {
            get { return montoG; }
            set { montoG = value; }
        }
        public string numeroTarjeta
        {
            get { return tarjetaGet.numero; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

    }
}