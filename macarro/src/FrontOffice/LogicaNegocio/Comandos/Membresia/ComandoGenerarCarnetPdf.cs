using FrontOffice.Dominio.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

namespace FrontOffice.LogicaNegocio.Comandos.Membresia
{
    public class ComandoGenerarCarnetPdf : Comando<List<Object>, Document>
    {
        iTextSharp.text.Font Titulo;
        iTextSharp.text.Font Cuerpo;

        public override Document Ejecutar(List<Object> Parametros)
        {
            try
            {

                Document PDF;

                PDF=(Document)Parametros.ElementAt(0);

                llenarPDF(PDF,(List<string>) Parametros.ElementAt(1));

                return PDF;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
                
            }
           
        }

        private Dominio.Entidades.TablaPdf Header()
        {
            List<Phrase> ListaCeldas;
            List<int> Anchos;
           
            Anchos = Dominio.Fabrica.FabricaEntidad.ObtenerAnchos();
            Anchos.Add(1);
            ListaCeldas = Dominio.Fabrica.FabricaEntidad.ObtenerListaCeldas();
            Dominio.Entidades.TablaPdf Top;
            Top = Dominio.Fabrica.FabricaEntidad.ObtenerTablaPdf(1, 0, 0, 20, 0, Anchos);
            ListaCeldas.Add(FabricaEntidad.ObtenerFrase(" ", Titulo));
            Top.LlenarTabla(ListaCeldas);

            return Top;
        }


        private Dominio.Entidades.TablaPdf Body(List<string> Datos)
        {
            List<Phrase> ListaCeldas;
            List<int> Anchos;
            
            Anchos = Dominio.Fabrica.FabricaEntidad.ObtenerAnchos();
            Anchos.Add(1);
            Anchos.Add(4);
            Dominio.Entidades.TablaPdf CuerpoC;
            ListaCeldas = Dominio.Fabrica.FabricaEntidad.ObtenerListaCeldas();

            CuerpoC = FabricaEntidad.ObtenerTablaPdf(2, 0, 50, 0, 0,Anchos );

            ListaCeldas.Add(FabricaEntidad.ObtenerFrase("Nombre :", Cuerpo));
            ListaCeldas.Add(FabricaEntidad.ObtenerFrase(Datos.ElementAt(0), Cuerpo));
            ListaCeldas.Add(FabricaEntidad.ObtenerFrase("Apellido :", Cuerpo));
            ListaCeldas.Add(FabricaEntidad.ObtenerFrase(Datos.ElementAt(1), Cuerpo));
            ListaCeldas.Add(FabricaEntidad.ObtenerFrase("F.Nacimiento:", Cuerpo));
            ListaCeldas.Add(FabricaEntidad.ObtenerFrase(Datos.ElementAt(2), Cuerpo));
            ListaCeldas.Add(FabricaEntidad.ObtenerFrase("F.Vto:", Cuerpo));
            ListaCeldas.Add(FabricaEntidad.ObtenerFrase(Datos.ElementAt(3), Cuerpo));
            ListaCeldas.Add(FabricaEntidad.ObtenerFrase(Datos.ElementAt(4), Cuerpo));
            ListaCeldas.Add(FabricaEntidad.ObtenerFrase(Datos.ElementAt(5), Cuerpo));
            ListaCeldas.Add(FabricaEntidad.ObtenerFrase("Telefono :", Cuerpo));
            ListaCeldas.Add(FabricaEntidad.ObtenerFrase(Datos.ElementAt(6), Cuerpo));

            CuerpoC.LlenarTabla(ListaCeldas);

            return CuerpoC;
           
        }

        private void Inicializar()
        {
            Titulo = FontFactory.GetFont("Open Sans", 18, iTextSharp.text.Font.NORMAL);
            Cuerpo = FontFactory.GetFont("Open Sans", 12, iTextSharp.text.Font.NORMAL);
            Titulo.Color = iTextSharp.text.BaseColor.WHITE;
            Cuerpo.Color = iTextSharp.text.BaseColor.WHITE;
            
            
        }


        private void llenarPDF(Document PDF,List<string> Datos)
        {
            Inicializar();
           

            PDF.Open();

            PDF.Add(Header().TablaP);
            PDF.Add(Dominio.Fabrica.FabricaEntidad.ObtenerParrafo("Carnet", 135, 0, 10, Titulo).ElementoGet);
            PDF.Add(Body(Datos).TablaP);
            PDF.Add(Dominio.Fabrica.FabricaEntidad.ObtenerImagenPdf(Datos.ElementAt(8),400,500,1,500).ElementoGet);
            PDF.Add(Dominio.Fabrica.FabricaEntidad.ObtenerImagenPdf(Datos.ElementAt(9), 90, 110, 280, 585).ElementoGet);
            PDF.Add(Dominio.Fabrica.FabricaEntidad.ObtenerParrafo(Datos.ElementAt(7),277 -Datos.ElementAt(7).Length *2,0,10,Cuerpo).ElementoGet);

            PDF.Close();

        }

    }
}