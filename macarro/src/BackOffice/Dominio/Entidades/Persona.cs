using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class Persona:Entidad
    {
        private string _nombre;
        private string _apellido;

        public Persona(string nombre, string apellido)
        {
            _nombre = nombre;
            _apellido = apellido;
        }
    }
}