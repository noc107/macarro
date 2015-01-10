using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Dominio.Entidades
{
    public class ReservaPlaya : Entidad
    {
        private int ReservaPlaya_id;
        private int ReservaPlaya_fila;
        private int ReservaPlaya_columna;

        public int reservaPlaya_Id
        {
            get { return ReservaPlaya_id; }
            set { ReservaPlaya_id = value; }
        }
        public int reservaPlaya_Fila
        {
            get { return ReservaPlaya_fila; }
            set { ReservaPlaya_fila = value; }
        }
        public int reservaPlaya_Columna
        {
            get { return ReservaPlaya_columna; }
            set { ReservaPlaya_columna = value; }
        }

        public ReservaPlaya()
        {
            reservaPlaya_Id = 0;
            reservaPlaya_Columna = 0;
            reservaPlaya_Fila = 0;
        }

        public ReservaPlaya(int _reservaPlaya_Id,int _reservaPlaya_Fila, int _reservaPlaya_Columna)
        {
            reservaPlaya_Id = _reservaPlaya_Id;
            reservaPlaya_Columna = _reservaPlaya_Columna;
            reservaPlaya_Fila = _reservaPlaya_Fila;
        }
    }
}