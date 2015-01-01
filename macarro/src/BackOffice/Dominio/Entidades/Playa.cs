using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class Playa : Entidad
    {
        private int _id;
        private int _filas;
        private int _columnas;
        private List<InventarioPlaya> _arregloInventario;
        private List<Puesto> _arregloPuesto;

        public Playa()
        {
            this.Id = 0;
            this.Filas = 0;
            this.Columnas = 0;
            this.ArregloInventario = null;
            this.ArregloPuesto = null;
        }

        public Playa(int id, int filas, int columnas)
        {
            this.Id = id;
            this.Filas = filas;
            this.Columnas = columnas;
            this.ArregloInventario = null;
            this.ArregloPuesto = null;
        }

        #region PROPIEDADES
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int Filas
        {
            get { return _filas; }
            set { _filas = value; }
        }
        public int Columnas
        {
            get { return _columnas; }
            set { _columnas = value; }
        }
        public List<InventarioPlaya> ArregloInventario
        {
            get { return _arregloInventario; }
            set { _arregloInventario = value; }
        }
        public List<Puesto> ArregloPuesto
        {
            get { return _arregloPuesto; }
            set { _arregloPuesto = value; }
        }
        #endregion

      
    }
}