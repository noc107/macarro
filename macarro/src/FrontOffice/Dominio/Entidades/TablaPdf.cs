using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace FrontOffice.Dominio.Entidades
{
    public class TablaPdf : Entidad
    {
        PdfPTable Tabla;

        public TablaPdf(int CantidadColumnas, int AlineadoHorizontal, int EspaciadoAnterior, int EspaciadoPosterior, int GruesoBorde, List<int> GruesoCeldas)
        {

            Tabla = Dominio.Fabrica.FabricaEntidad.ObtenerTablaPdf(CantidadColumnas);
            Tabla.HorizontalAlignment = AlineadoHorizontal;
            Tabla.SpacingBefore = EspaciadoAnterior;
            Tabla.SpacingAfter = EspaciadoPosterior;
            Tabla.DefaultCell.Border = GruesoBorde;
            Tabla.SetWidths((int[])GruesoCeldas.ToArray());

        }


        public void LlenarTabla(List<Phrase> Elementos)
        {
            foreach (Phrase Celda in Elementos)
            {
                Tabla.AddCell(Celda);
            }

        }

        public PdfPTable TablaP
        {
            get { return Tabla; }
            set { Tabla = value; }
        }

    }
}