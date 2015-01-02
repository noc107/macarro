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
        private int _idLugar;

        #endregion

        #region Gets y Sets

        public int Id
        {
            get { return _id; }
            set { _id = value; }
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

        public int IdLugar
        {
            get { return _idLugar; }
            set { _idLugar = value; }
        }
        #endregion

        #region Constructores

        public Proveedor(int id, string rif, string razonSocial, string correo, string pagWeb,
             string fechaContrato, string telefono, int idLugar)
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

        //Sin pagina web
        public Proveedor(int id, string rif, string razonSocial, string correo, string fechaContrato,
            string telefono, int idLugar)
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

        //Sin Telefono
        //public Proveedor(int id, string rif, string razonSocial, string correo, string pagWeb,
        //    string fechaContrato, int idLugar)
        //{
        //    _id = id;
        //    _rif = rif;
        //    _razonSocial = razonSocial;
        //    _correo = correo;
        //    _paginaWeb = pagWeb;
        //    _fechaContrato = fechaContrato;
        //    _idLugar = idLugar;
        //    _telefono = null;
        //}

        public Proveedor()
        {

        }


        #endregion

    }
}