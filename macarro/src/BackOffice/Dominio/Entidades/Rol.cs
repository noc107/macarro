using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class Rol : Entidad
    {
        #region Atributos
        private int _id;
        private string _nombre;
        private string _descripcion;
        private List<Accion> _acciones;
        #endregion

        #region Gets y Sets
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

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public List<Accion> Acciones
        {
            get { return _acciones; }
            set { _acciones = value; }
        }
        #endregion

        #region Constructores
        public Rol(int id, string nombre, string descripcion, List<Accion> acciones)
        {
            _id = id;
            _nombre = nombre;
            _descripcion = descripcion;
            _acciones = acciones;
        }

        public Rol()
        {
            _id = -1;
            _nombre = "";
            _descripcion = "";
            _acciones = null;
        }
        #endregion
    
    }
}