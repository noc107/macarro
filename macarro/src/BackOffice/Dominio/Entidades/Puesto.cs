using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class Puesto : Entidad
    {
        private int _fila;
        private int _columna;
        private string _descripcion;
        private float _precio;
        private string _estado;

       
        public Puesto()
        {

        }

        public Puesto(int fila,int columna, string descripcion, float precio, string estado)
        {
            _fila = fila;
            _columna = columna;
            _descripcion = descripcion;
            _precio = precio;
            _estado = estado;
        }

        public Puesto(int fila, int columna, string descripcion, float precio)
        {
            _fila = fila;
            _columna = columna;
            _descripcion = descripcion;
            _precio = precio;
            
        }

        #region PROPIEDADES
        public int Fila
        {
            get { return _fila; }
            set { _fila = value; }
        }
        public int Columna
        {
            get { return _columna; }
            set { _columna = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public float Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        #endregion
        
    }
}