using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_office.Dominio
{
    public class Puesto
    {
        private int _fila;
        private int _columna;
        private string _descripcion;
        private float _precio;

        public Puesto()
        {

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
        #endregion

        #region ConfigurarPuestoPlaya

        #endregion
    }
}