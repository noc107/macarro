using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class Pago : Entidad
    {
        #region Atributos
        private int _id;
        private float _monto;
        private DateTime _fecha;
        #endregion


        #region Constructores

        public Pago()
        {
            this._id = -1;
            this._monto = -1;
            this._fecha = DateTime.Now;
        }

        public Pago(int _id, float _monto, DateTime _fecha)
        {
            this._id = _id;
            this._monto = _monto;
            this._fecha = _fecha;
        }

        #endregion

        #region Gets y sets
        
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public float monto
        {
            get { return _monto; }
            set { _monto = value; }
        }

        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        #endregion
    }
}