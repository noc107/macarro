using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class Membresia : Entidad
    {
        private Persona _usuario;
        private Int32 _id;
        private DateTime _fAdmision;
        private DateTime _fVencimiento;
        private string _foto;
        private float _costo;
        private float _descAplicado;
        private string _telefono;
        private string _estado;
        private List<Pago> _pagos;

        #region Constructores
        public Membresia(Persona usuario, Int32 id, DateTime fAdmision, DateTime fVencimiento, float costo, float descAplicado, string telefono, string estado, List<Pago> pagos)
        {
            _usuario = usuario;
            _id = id;
            _fAdmision = fAdmision;
            _fVencimiento = fVencimiento;
            _costo = costo;
            _descAplicado = descAplicado;
            _telefono = telefono;
            _estado = estado;
            _pagos = pagos;
        }

        public Membresia()
        {
            _usuario = null;
            _id = 0;
            _fAdmision = DateTime.Now;
            _fVencimiento = DateTime.Now;
            _costo = 0;
            _descAplicado = 0;
            _telefono = string.Empty;
            _estado = string.Empty;
            _pagos = null;
        }

        #endregion

        public Persona Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public Int32 id
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime fAdmision
        {
            get { return _fAdmision; }
            set { _fAdmision = value; }
        }
        public DateTime fVencimiento
        {
            get { return _fVencimiento; }
            set { _fVencimiento = value; }
        }
        public float costo
        {
            get { return _costo; }
            set { _costo = value; }
        }
        public float descAplicado
        {
            get { return _descAplicado; }
            set { _descAplicado = value; }
        }
        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        public string estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        public List<Pago> pagos
        {
            get { return _pagos; }
            set { _pagos = value; }
        }

    }
}