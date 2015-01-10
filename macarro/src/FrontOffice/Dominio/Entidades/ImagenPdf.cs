using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace FrontOffice.Dominio.Entidades
{
    public class ImagenPdf : Entidad
    {
        iTextSharp.text.Image Elemento;

        public ImagenPdf(string fileName,int ancho, int alto, int x, int y)
        {
            Elemento = iTextSharp.text.Image.GetInstance(fileName);
            Elemento.ScaleToFit(ancho, alto);
            Elemento.SetAbsolutePosition(x, y);
        }

        public iTextSharp.text.Image ElementoGet
        {
            get { return Elemento; }
            set { Elemento = value; }
        }

    }
}