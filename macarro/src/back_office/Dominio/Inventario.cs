using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_office.Dominio
{
    public class Inventario 
    {
        private int _id;
        private int _precio;
        private string _estado;
        private string _tipo;

        public Inventario()
        {

        }

        #region PROPIEDADES
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int Precio
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
        #endregion

        #region ConfigurarPuestoPlaya

        #endregion
    }
}