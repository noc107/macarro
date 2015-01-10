using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class LineaFactura : Entidad
    {
        #region Atributos
        /*private Ticket _ticket;
        private Plato _plato;
        private Servicio _servicio;*/
        private int _idLineaFactura;        
        private string _nombreItem;
        private string _tipo;
        private int _cantidad;
        private float _precio;
        private string _servicioFactura;
        
        #endregion

        #region Constructor
        public LineaFactura()
        {
            
        }

        public LineaFactura(int _idLineaFactura, float _precio, string _servicioFactura, string _tipo)
        {
            this._idLineaFactura = _idLineaFactura;
            this._precio = _precio;
            this._servicioFactura = _servicioFactura;
            this._tipo = _tipo;
        }

        public LineaFactura(float _precio, int _cantidad, string _servicioFactura, string _tipo)
        {
            this._cantidad = _cantidad;
            this._precio = _precio;
            this._servicioFactura = _servicioFactura;
            this._tipo = _tipo;
        }
        #endregion

        #region Servicios
        /*public Ticket Ticket
        {
            get { return _ticket; }
            set { _ticket = value; }
        }

        public Plato Plato
        {
            get { return _plato; }
            set { _plato = value; }
        }

        public Servicio Servicio
        {
            get { return _servicio; }
            set { _servicio = value; }
        }*/
        #endregion

        #region Propiedades
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public float Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public string NombreItem
        {
            get { return _nombreItem; }
            set { _nombreItem = value; }
        }

        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public int IdLineaFactura
        {
            get { return _idLineaFactura; }
            set { _idLineaFactura = value; }
        }
        public string ServicioFactura
        {
            get { return _servicioFactura; }
            set { _servicioFactura = value; }
        }
        #endregion
    }
}