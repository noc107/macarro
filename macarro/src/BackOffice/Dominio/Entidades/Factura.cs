using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class Factura : Entidad
    {

        #region Atributos
        private int _idFactura;        
        private bool _facturada;
        private DateTime _fecha;
        private float _subTotal;
        private float _total;
        private int _codigo;
        private List<LineaFactura> _lineas;
        //private Usuario _usuario;
        private string _fkUsuario;
        #endregion

        #region Constructor
        public Factura()
        {
            _lineas = new List<LineaFactura>();
        }

        public Factura(int _idFactura, DateTime _fecha, float _subtotal, float _total)
        {
            this._idFactura = _idFactura;
            this._fecha = _fecha;
            this._subTotal = _subtotal;
            this._total = _total;

        }

        public Factura(int _idFactura, float _subtotal, float _total)
        {
            this._idFactura = _idFactura;
             this._subTotal = _subtotal;
            this._total = _total;

        }

        #endregion

        #region Propiedades

        public int IdFactura
        {
            get { return _idFactura; }
            set { _idFactura = value; }
        }

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
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


        public string FkUsuario
        {
            get { return _fkUsuario; }
            set { _fkUsuario = value; }
        }

        public bool Facturada
        {
            get { return _facturada; }
            set { _facturada = value; }
        }

        #endregion     

        #region Métodos

        private void AgregarLinea(LineaFactura _linea)
        {
            this._lineas.Add(_linea);
        }

        private void EliminarLinea(LineaFactura _linea)
        {
            while (this._lineas.GetEnumerator().MoveNext())
            {
                LineaFactura _lineaActual = this._lineas.GetEnumerator().Current;
                if (_linea.IdLineaFactura == this._lineas.GetEnumerator().Current.IdLineaFactura)
                {
                    this._lineas.Remove(this._lineas.GetEnumerator().Current);
                    break;
                }
            }
            this._lineas.Remove(_linea);
        }

        private IEnumerator<LineaFactura> IteradorLineaFactura()
        {
            return this._lineas.GetEnumerator();
        }

        #endregion
    }
}