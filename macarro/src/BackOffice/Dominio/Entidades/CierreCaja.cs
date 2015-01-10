using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class CierreCaja : Entidad
    {

        private int _numeroFacturas;
        private float _saldoAnterior;
        private float _ingresos;
        private float _saldoTotal;
        private string _valoresGrafica;

        public CierreCaja()
        {

        }

        #region PROPIEDADES
        public int NumeroFacturas
        {
            get { return _numeroFacturas; }
            set { _numeroFacturas = value; }
        }
        public float SaldoAnterior
        {
            get { return _saldoAnterior; }
            set { _saldoAnterior = value; }
        }
        public float Ingresos
        {
            get { return _ingresos; }
            set { _ingresos = value; }
        }
        public float SaldoTotal
        {
            get { return _saldoTotal; }
            set { _saldoTotal = value; }
        }
        public string ValoresGrafica
        {
            get { return _valoresGrafica; }
            set { _valoresGrafica = value; }
        }
        #endregion

    }
}