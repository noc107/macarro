using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class Servicio : Entidad
    {
        private string _nombre;
        private string _descripcion;
        private string _categoria;
        private string _lugarRetiro;
        private int _capacidad;
        private int _cantidad;
        private float _costo;
        private string _estado;
        private List<Horario> _listaHorarios;

        #region Constructor

        public Servicio(string _nombre, string _descripcion, int _capacidad, int _cantidad, float _costo, string _categoria,
            string _lugarRetiro, string _estado, List<Horario> _listaHorarios)
        {
            this._nombre = _nombre;
            this._descripcion = _descripcion;
            this._capacidad = _capacidad;
            this._cantidad = _cantidad;
            this._costo = _costo;
            this._categoria = _categoria;
            this._lugarRetiro = _lugarRetiro;
            this._estado = _estado;
            this._listaHorarios = _listaHorarios;
        }

        #endregion

        #region Get y Set

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

        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        public string LugarRetiro
        {
            get { return _lugarRetiro; }
            set { _lugarRetiro = value; }
        }

        public int Capacidad
        {
            get { return _capacidad; }
            set { _capacidad = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public float Costo
        {
            get { return _costo; }
            set { _costo = value; }
        }

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public List<Horario> obtenerListaHorario()
        {
            return this._listaHorarios;
        }
        
        #endregion
    }
}