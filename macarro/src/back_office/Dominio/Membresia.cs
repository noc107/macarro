using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_office.Dominio
{
    public class Membresia
    {
        private int _codigo;
        private DateTime _fechaAdmision;
        private DateTime _fechaVencimiento;
        private string _foto;
        private string _estado;
        private float _descAplicado;
        
      
          public int Codigo 
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
          public DateTime FechaAdmision
        {
            get { return _fechaAdmision; }
            set { _fechaAdmision = value; }
        }

        public DateTime FechaVencimiento
        {
            get { return _fechaVencimiento; }
            set { _fechaVencimiento = value; }
        }
        public string Foto
        {
            get { return _foto; }
            set { _foto = value; }
        }

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        public float DescAplicado
        {
            get { return _descAplicado; }
            set { _descAplicado = value; }
        }

    }
}