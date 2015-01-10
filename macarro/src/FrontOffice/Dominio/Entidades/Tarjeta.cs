using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Dominio.Entidades
{
    public class Tarjeta : Entidad
    {
        private bool tipoTarjeta;
        private string numeroG;
        private string _nombreImpreso;
        private string _imgURL;

        public Tarjeta(Int32 numero)
        {
            int count;

            this.numeroG = numero.ToString();
            count = this.numeroG.Count();
            if (this.numeroG.ElementAt(0).Equals(4))
            {
                tipoTarjeta = true; //VISA
            }
            else
            {
                tipoTarjeta = false; //MASTER
            }
             this.numeroG = numeroG.Substring(numeroG.Length - 4); ;
        }
        public Tarjeta(Int32 numero, string nombre)
        {
            int count;
            this._nombreImpreso = nombre;
            this.numeroG = numero.ToString();
            count = this.numeroG.Count();
            if (this.numeroG.ElementAt(0).Equals(4))
            {
                tipoTarjeta = true; //VISA
                this._imgURL = "/comun/resources/img/Membresia/Visa_Logo.png";
            }
            else
            {
                tipoTarjeta = false; //MASTER
                this._imgURL = "/comun/resources/img/Membresia/MasterCard_Logo.png";
            }
            this.numeroG = numeroG.Substring(numeroG.Length - 4); ;
        }

        public string numero
        {
            get { return numeroG; }
            set { numeroG = value; }
        }
        public bool tipoTarjetaGet
        {
            get { return tipoTarjeta; }
            set { tipoTarjeta = value; }
        }
        public string NombreEnTarjeta
        {
            get { return _nombreImpreso; }
            set { _nombreImpreso = value; }
        }
        public string ImagenURL
        {
            get { return _imgURL; }
            set { _imgURL = value; }
        }


    }
}