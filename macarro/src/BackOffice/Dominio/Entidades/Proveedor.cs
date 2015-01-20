using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class Proveedor : Entidad
    {

        #region Atributos

        private int _id;
        private string _rif;
        private string _razonSocial;
        private string _correo;
        private string _paginaWeb;
        private string _fechaContrato;
        private string _telefono;
        private string _idLugar;
        private string _status;
        private string _ciudad;
        private string _anteriorrif;

        #endregion

        #region Gets y Sets

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Ciudad
        {
            get { return _ciudad; }
            set { _ciudad = value; }
        }

        public string ARif
        {
            get { return _anteriorrif; }
            set { _anteriorrif = value; }
        }


        public string Rif
        {
            get { return _rif; }
            set { _rif = value; }
        }

        public string RazonSocial
        {
            get { return _razonSocial; }
            set { _razonSocial = value; }
        }

        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        public string PagWeb
        {
            get { return _paginaWeb; }
            set { _paginaWeb = value; }
        }

        public string FechaContrato
        {
            get { return _fechaContrato; }
            set { _fechaContrato = value; }
        }

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string IdLugar
        {
            get { return _idLugar; }
            set { _idLugar = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        #endregion

        #region Constructores

        public Proveedor(int id, string rif, string razonSocial, string correo, string pagWeb,
             string fechaContrato, string telefono, string idLugar)
        {
            _id = id;
            _rif = rif;
            _razonSocial = razonSocial;
            _correo = correo;
            _paginaWeb = pagWeb;
            _fechaContrato = fechaContrato;
            _telefono = telefono;
            _idLugar = idLugar;
        }

        public Proveedor(int id, string rif, string razonSocial, string correo, string pagWeb,
        string fechaContrato, string telefono, string idLugar, string ciudad)
        {
            _id = id;
            _rif = rif;
            _razonSocial = razonSocial;
            _correo = correo;
            _paginaWeb = pagWeb;
            _fechaContrato = fechaContrato;
            _telefono = telefono;
            _idLugar = idLugar;
            _ciudad = ciudad;
        }


        //con estado
        public Proveedor(int id, string rif, string razonSocial, string correo, string pagWeb,
             string fechaContrato, string telefono, string idLugar, string ciudad ,string status)
        {
            _id = id;
            _rif = rif;
            _razonSocial = razonSocial;
            _correo = correo;
            _paginaWeb = pagWeb;
            _fechaContrato = fechaContrato;
            _telefono = telefono;
            _idLugar = idLugar;
            _ciudad = ciudad;
            _status = status;
        }

        //con estado
        public Proveedor(int id, string rif, string razonSocial, string correo, string pagWeb,
             string fechaContrato, string telefono, string idLugar, string ciudad, string status, string anteriorRif)
        {
            _id = id;
            _rif = rif;
            _razonSocial = razonSocial;
            _correo = correo;
            _paginaWeb = pagWeb;
            _fechaContrato = fechaContrato;
            _telefono = telefono;
            _idLugar = idLugar;
            _ciudad = ciudad;
            _status = status;
            _anteriorrif = anteriorRif;
        }


        //Sin pagina web
        public Proveedor(int id, string rif, string razonSocial, string correo, string fechaContrato,
            string telefono, string idLugar)
        {
            _id = id;
            _rif = rif;
            _razonSocial = razonSocial;
            _correo = correo;
            _fechaContrato = fechaContrato;
            _telefono = telefono;
            _idLugar = idLugar;
            _paginaWeb = null;
        }


        public Proveedor()
        {

        }

        public Proveedor(int id, string rif, string razonSocial)
        {
            _id = id;
            _rif = rif;
            _razonSocial = razonSocial;
        }


        #endregion

    }
}