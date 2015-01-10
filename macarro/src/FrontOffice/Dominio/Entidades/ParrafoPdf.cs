using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using FrontOffice.Dominio.Fabrica;

namespace FrontOffice.Dominio.Entidades
{
    public class ParrafoPdf : Entidad
    {
        Paragraph Elemento;

        public ParrafoPdf(string Texto, int indentacion, int EspaciadoAntes, int EspaciadoDespues, Font fuente)
        {
            Elemento = FabricaEntidad.ObtenerParrafo(Texto, fuente);
            Elemento.IndentationLeft = indentacion;
            Elemento.SpacingBefore = EspaciadoAntes;
            Elemento.SpacingAfter = EspaciadoDespues;
        }

        public Paragraph ElementoGet
        {
            get { return Elemento; }
            set { Elemento = value; }
        }
    }
}