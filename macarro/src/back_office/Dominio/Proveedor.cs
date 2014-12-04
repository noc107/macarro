using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_office.Dominio
{
    public class Proveedor
    {
        //Declaracion de los atributos de la clase proveedor
        private string _rif;
        private string _nombre;
        private string _razonSocial;
        private string _correo;
        private string _paginaWeb;
        private DateTime _fechaContrato;
        private string _telefono;
        private string _direccion;
        private List<int> _items = new List<int>(); 

        //Agregacion de item
        //Item _item;

        //Declaracion de los getters y setter de los atributos de la clase proveedor
        public string Rif
        {
            get { return _rif; }
            set { this._rif = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { this._nombre = value; }
        }
        public string RazonSocial
        {
            get { return _razonSocial; }
            set { this._razonSocial = value; }
        }
        public string Correo
        {
            get { return _correo; }
            set { this._correo = value; }
        }
        public string PaginaWeb
        {
            get { return _paginaWeb; }
            set { this._paginaWeb = value; }
        }
        public DateTime FechaContrato
        {
            get { return _fechaContrato ; }
            set { this._fechaContrato = value; }
        }
        public string Telefono
        {
            get { return _telefono ; }
            set { this._telefono = value; }
        }
        public string Direccion
        {
            get { return _direccion; }
            set { this._direccion = value; }
        }
        public List<int> Items
        {
            get { return _items; }
            set { this._items = value; }
        }
    }
}