using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class InventarioPlaya : Entidad
    {
        private int _id;
        private float _precio;
        private string _estado;
        private string _tipo;
        private string _descripcion;
        private string _codigo;

        #region Contructores

        public InventarioPlaya()
        {
            _id = 0;
            _precio = 0;
            _estado = string.Empty;
            _tipo = string.Empty;
            _descripcion = string.Empty;
            _codigo = string.Empty;
        }

        public InventarioPlaya(int id, float precio, string estado, string tipo, string descripcion)
        {
            _id = id;
            _precio = precio;
            _estado = estado;
            _tipo = tipo;
            _descripcion = descripcion;
            _codigo = _tipo + _id;
        }

        public InventarioPlaya(float precio, string tipo)
        {
            _id = 0;
            _precio = precio;
            _estado = string.Empty;
            _tipo = tipo;
            _descripcion = string.Empty;
            _codigo = string.Empty;
        }

        #endregion

        #region PROPIEDADES
        public int Id
        {
            get { return _id; }
            set { _id = value; }
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
        
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        
        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        
        #endregion

    }
}