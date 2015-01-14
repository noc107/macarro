using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class Estado : Entidad
    {
        private int _id;
        private string _titulo;

        #region Contructores

        public Estado()
        {
            _id = 0;
            _titulo = string.Empty;           
        }

        public Estado(int id, string titulo)
        {
            _id = id;
            _titulo = titulo; 
        }        

        #endregion

        #region PROPIEDADES
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }
        #endregion
    }
}