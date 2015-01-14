using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class Plato : Entidad
    {
        #region Atributos

        private int _id;
        private string _nombre;
        private float _precio;
        private string _descripcion;
        private string _seccion;

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

        public float Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public string Seccion
        {
            get { return _seccion; }
            set { _seccion = value; }
        }

        

        #endregion

        #region Constructores

        public Plato(int id, string nombre, float precio, string descripcion)
        {
            _id = id;
            _nombre = nombre;
            _precio = precio;
            _descripcion = descripcion;
        }

        public Plato(int id, string nombre, float precio, string descripcion, string seccion)
        {
            _id = id;
            _nombre = nombre;
            _precio = precio;
            _descripcion = descripcion;
            _seccion = seccion;
        }

        public Plato()
        {
            _id = -1;
            _nombre = "";
            _precio = -1;
            _descripcion = "";
        }

        #endregion


    }
}