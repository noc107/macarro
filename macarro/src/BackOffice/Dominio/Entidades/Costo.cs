using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class Costo : Entidad
    {
        #region atributos
        private float _costo;
        #endregion

        #region constructores
        public Costo()
        {
            _costo = 0;
        }

        public Costo(float costo)
        {
            _costo = costo;
        }
        #endregion

        #region gets y sets
        public float monto
        {
            get { return _costo; }
            set { _costo = value; }
        }
        #endregion
    }
}