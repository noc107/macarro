using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontOffice.Dominio.Entidades;
using System.Web.ApplicationServices;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;
using FrontOffice.Dominio.Fabrica;

namespace FrontOffice.Dominio.Entidades
{
    public class Membresia:Entidad
    {
        private Persona _usuario; 
        private Int32 _id;
        private DateTime _fAdmision;
        private DateTime _fVencimiento;
        private string _foto;
        private float _costo;
        private float _descAplicado;
        private string _telefono;
        private bool _estado;

        public Membresia(Persona usuario, Int32 id, DateTime fAdmision, DateTime fVencimiento, string foto, float costo, float descAplicado, string telefono, bool estado)
        {
            _usuario = usuario;
            _id = id;
            _fAdmision = fAdmision;
            _fVencimiento = fVencimiento;
            _foto = this.obtenerFoto(foto);
            _costo = costo;
            _descAplicado = descAplicado;
            _telefono = telefono;
            _estado = estado;
        }

        private string obtenerFoto(string foto)
        {
            string Path;

            Path=  "/comun/resources/img/Membresia/Fotos/"+foto;

            return Path;
        }

        public string Imagen
        {
            get { return _foto; }
            set { _foto = value; }
        }

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
        public bool estado
        {
            get { return _estado; }
            set { _estado = value; }
        }


    }
}