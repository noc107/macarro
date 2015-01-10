using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using FrontOffice.Presentacion.Contratos.Membresia;
using FrontOffice.LogicaNegocio.Fabrica;
using FrontOffice.LogicaNegocio;
using FrontOffice.Dominio;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;



namespace FrontOffice.Presentacion.Presentadores.Membresia
{
    public class Presentador_12_consultarMembresia : PresentadorGeneral
    {

        #region Parametros

        private IContrato_12_consultarMembresia _vista;
        private Dominio.Entidad _Entidad;
        

        #endregion

        #region Constructor

        public Presentador_12_consultarMembresia(IContrato_12_consultarMembresia consultarMembresia)
            : base(consultarMembresia) 
        {

            _vista = consultarMembresia;
        
        }

        #endregion

        #region Metodos

        public void Page_Load()
        {
            Comando<int , Dominio.Entidad> comandoConsultaMembresia;
            comandoConsultaMembresia = FabricaComando.ObtenerComandoConsultarMembresia();
            _Entidad = comandoConsultaMembresia.Ejecutar(1);
            if (_Entidad != null)
            {
                this.llenarCampos( (Dominio.Entidades.Membresia)_Entidad);
            }
        }
        private List<string> LlenarListaParametrosPdf()
        {
            List<string> Parametros;
            string Nombre;
            string Apellido;
            string Fnacimiento;
            string Fvencimiento;
            string Tipodoc;
            string Cedula;
            string Telefono;
            string Numerocarnet;
            string Logo;
            string Foto;
            string fileName;

            fileName = "Carnet" + DateTime.Now.Ticks + ".pdf";
            Nombre = this._vista.nombre.Text;
            Apellido = this._vista.apellido.Text;
            Fnacimiento = this._vista.fechaNacimiento.Text;
            Fvencimiento = this._vista.fechaVencimiento.Text;
            Tipodoc = this._vista.tipoDocumentoIdentidad.Text;
            Cedula = this._vista.numeroDocumentoIdentidad.Text;
            Telefono = this._vista.numeroTelefono.Text;
            Numerocarnet = this._vista.numeroCarnet.Text;
            Logo = this._vista.logo.ImageUrl;
            Foto = this._vista.foto.ImageUrl;

            Parametros = Dominio.Fabrica.FabricaEntidad.ObtenerListaParametrosPdfMembresia();

            Parametros.Add(Nombre);
            Parametros.Add(Apellido);
            Parametros.Add(Fnacimiento);
            Parametros.Add(Fvencimiento);
            Parametros.Add(Tipodoc);
            Parametros.Add(Cedula);
            Parametros.Add(Telefono);
            Parametros.Add(Numerocarnet);
            Parametros.Add(HttpContext.Current.Server.MapPath("/comun/resources/img/Membresia/Carnet.jpg"));
            Parametros.Add(HttpContext.Current.Server.MapPath(Foto));
            Parametros.Add(fileName);

            return Parametros;
        }

        public void GeneratePDF()
        {
            Comando<List<Object>, Document> comandoGenerarPdf;
            List<string> Parametros;
            List<Object> Aux;
            Document PDF;

            Aux = new List<Object>();
            Parametros = LlenarListaParametrosPdf();

            PDF = Dominio.Fabrica.FabricaEntidad.ObtenerDocumentoMembresia();
            Aux.Add(PDF);
            Aux.Add(Parametros);
            HttpContext.Current.Response.ContentType = "image/pdf";
            string headerValue = string.Format("attachment; filename={0}", Parametros.ElementAt(10));
            HttpContext.Current.Response.AppendHeader("Content-Disposition", headerValue);
            PdfWriter.GetInstance(PDF, HttpContext.Current.Response.OutputStream);
            
            
            comandoGenerarPdf = FabricaComando.ObtenerComandoGenerarPdfMembresia();
            PDF = comandoGenerarPdf.Ejecutar(Aux);

        }

        public void EventoClickDescargarPDF()
        {
            GeneratePDF();
        }

        public void EventoClickVerPagos(string Pagina)
        {
            HttpContext.Current.Response.Redirect(Pagina+"?id_mem="+this._vista.numeroCarnet.Text.Remove(0,1));
        }

        public void llenarCampos(Dominio.Entidades.Membresia entidad)
        {
            this._vista.nombre.Text = entidad.Usuario.nombre;
            this._vista.foto.ImageUrl = entidad.Imagen;
            this._vista.apellido.Text = entidad.Usuario.apellido;
            this._vista.fechaNacimiento.Text = entidad.fAdmision.Day.ToString() + "/" + entidad.fAdmision.Month.ToString() + "/" + entidad.fAdmision.Year.ToString();
            this._vista.fechaVencimiento.Text = entidad.fVencimiento.Day.ToString() + "/" + entidad.fVencimiento.Month.ToString() + "/" + entidad.fVencimiento.Year.ToString();
            this._vista.numeroTelefono.Text = entidad.telefono;
            this._vista.numeroCarnet.Text = "# " + entidad.id;
            this._vista.tipoDocumentoIdentidad.Text = entidad.Usuario.TipoDocumento+ " :";
            this._vista.numeroDocumentoIdentidad.Text = entidad.Usuario.Cedula;
        }

        //puede que falten metodos

        #endregion

    }
    
}