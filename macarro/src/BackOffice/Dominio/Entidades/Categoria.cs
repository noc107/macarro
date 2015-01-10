using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class Categoria : Entidad
    {
        private int _id;
        private string _nombre;

        #region Constructor

        public Categoria()
        {
            _id = 0;
            _nombre = string.Empty;
        }

        public Categoria(int id, string nombre)
        {
            _id = id;
            _nombre = nombre;
        }

        public Categoria(string nombre)
        {
            _id = 0;
            _nombre = nombre;
        }

        #endregion

        #region Get y Set

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        #endregion
    }
}