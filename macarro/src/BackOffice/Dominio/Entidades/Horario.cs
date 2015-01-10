using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class Horario : Entidad
    {
        private int _id;
        private DateTime _inicio;
        private DateTime _fin;
        private string _servicio;

        #region Constructor
        
        public Horario(DateTime inicio, DateTime fin)
        {
            this._inicio = inicio;
            this._fin = fin;
            this._servicio = "Desactivado";
        }

        #endregion

        #region Get y Set

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime Inicio
        {
            get { return _inicio; }
            set { _inicio = value; }
        }

        public DateTime Fin
        {
            get { return _fin; }
            set { _fin = value; }
        }

        public string Servicio
        {
            get { return _servicio; }
            set { _servicio = value; }
        }

        #endregion

    }
}