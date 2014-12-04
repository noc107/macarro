using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_office.Dominio
{
    public class LineaFactura
    {
        /// private Ticket _ticket;
        /// private Plato _plato;
        /// private Servicio _servicio;
        private int _cantidad;
        private float _precio;

        public LineaFactura()
        {
            ///  _ticket = null;
            /// _plato = null;
            /// _servicio = null;
            _cantidad = 0;
            _precio = 0;
        }

        #region PROPIEDADES
        /// public Ticket Ticket
        /// {
        ///     get { return _ticket; }
        ///     set { _ticket = value; }
        /// }

        /// public Plato Plato
        /// {
        ///     get { return _plato; }
        ///     set { _plato = value; }
        /// }

        /// public Servicio Servicio
        /// {
        ///     get { return _servicio; }
        ///     set { _servicio = value; }
        /// }

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
        #endregion
    }
}