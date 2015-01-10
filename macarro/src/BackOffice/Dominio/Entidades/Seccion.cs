using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class Seccion : Entidad
    {
        #region Atributos

        private int _id;
        private string _nombre;
        private string _descripcion;

        #endregion

        #region gets y sets

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

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        #endregion

        #region Constructores

        public Seccion(int id, string nombre, string descripcion)
        {
            _id = id;
            _nombre = nombre;
            _descripcion = descripcion;
        }

        public Seccion()
        {
            _id = -1;
            _nombre = "";
            _descripcion = "";
        }

        #endregion


    }
}