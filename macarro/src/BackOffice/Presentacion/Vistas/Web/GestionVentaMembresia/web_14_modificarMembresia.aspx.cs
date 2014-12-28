using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using back_office.Logica.GestionVentaMembresia;
using System.IO;
//using back_office.Dominio;
//clases necesarias para generar PDF
//using iTextSharp.text;

//using iTextSharp.text.pdf;


namespace BackOffice.Presentacion.Vistas.Web.GestionVentaMembresia
{
    public partial class web_14_modificarMembresia : System.Web.UI.Page
    {
        //private Membresia _membresia;
        //private Persona _persona;


        /// <summary>
        /// Carga de informacion de una membresia particular al cargar la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    LogicaConsultarMembresia _consultaMembresia = new LogicaConsultarMembresia();
            //    LogicaConsultarMembresia _consultaPersona = new LogicaConsultarMembresia();
            //    _membresia = new Membresia();
            //    _persona = new Persona();
            //    _membresia = _consultaMembresia.solicitarMembresia(Convert.ToInt16(Request.QueryString["Membresia"]));
            //    _persona = _consultaPersona.solicitarPersona(Convert.ToInt16(Request.QueryString["Membresia"]));
            //    mostrarDatosMembresia(_membresia, _persona);

            //    btnCancelar.Attributes.Add("onclick", "history.back(); return false;");
            //}

        }
        /// <summary>
        /// Mostrar Membresia Solicitada en los componentes de la ventana
        /// </summary>
        /// <param name="_membresia">Membresia recibida</param>
        /// <param name="_persona">Persona recibida</param>
//        private void mostrarDatosMembresia(Membresia _membresia, Persona _persona)
//        {
//            //llena datos de Membresia
//            lbCarnet.Text = Convert.ToString(_membresia.Codigo);
//            telefono.Text = _membresia.Telefono;
//            cbStatus.Text = _membresia.Estado;
//            descuento1.Text = Convert.ToString(_membresia.DescAplicado);
//            tbFechaAdmision.Text = Convert.ToString(_membresia.FechaAdmision);
//            tbFechaVencimiento.Text = Convert.ToString(_membresia.FechaVencimiento);
//            descuento1.Text = Convert.ToString(_membresia.DescAplicado);
//            //lbDescuento.Font = Red;

//            //llena datos de Persona
//            tbApellido.Text = _persona.PrimerApellido;
//            tbNombre.Text = _persona.PrimerNombre;
//            tbCedula.Text = _persona.DocIdentidad;
//            FechaNacimiento.Text = Convert.ToString(_persona.FechaNacimiento);
//        }



//        /// <summary>
//        /// Modifica Datos de Membresia
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        protected void btnGuardar_Click(object sender, EventArgs e)
//        {
//            LogicaMembresia _mofificar = new LogicaMembresia();
//            bool _respuesta = _mofificar.ModificarMembresia(Convert.ToInt16(Request.QueryString["Membresia"]), cbStatus.Text, float.Parse(descuento1.Text));
//            //bool _respuesta = _mofificar.ModificarMembresia(1, cbStatus.Text, float.Parse(descuento1.Text));

//            if (_respuesta)
//            {
//                MensajeExito.Visible = true;
//            }
//            else
//            {
//                MensajeExito.Visible = true;
//                MensajeExito.Text = "Membresia no modificada";
//                MensajeExito.CssClass = "avisoMensaje MensajeError";
//                btnAceptar.Enabled = false;
//            }
//        }

//        protected void btnCarnet_Click(object sender, EventArgs e)
//        {
//            MensajeExito.Visible = true;
//            MensajeExito.Text = "No se puede Generar Carnet";
//            MensajeExito.CssClass = "avisoMensaje MensajeError";
//            btnCarnet.Enabled = false;/*

//            Document document = new Document();

//            PdfWriter.GetInstance(document,

//                          new FileStream("devjoker.pdf",

//                                 FileMode.OpenOrCreate));


//            document.Open();

//            document.Add(new Paragraph("Este es mi primer PDF al vuelo"));

//            document.Close();
//*/


//        }
    }
}


     /*    protected void btnCarnet_Click(object sender, EventArgs e){

       {

            LogicaCarnet _carnet = new LogicaCarnet();
            
            bool _respuesta = _carnet.GenerarCarnet(1, tbNombre.Text, tbApellido.Text,tbFechaAdmision.Text,tbFechaVencimiento.Text);

            if (_respuesta)
            {

                MensajeExito.Visible = true;
   //             MensajeExito.Text = "Carnet Generado";
            }
            else
            {

        //        MensajeExito.Visible = true;
          //      MensajeExito.Text = "No se puso generar carnet";
            //    MensajeExito.CssClass = "avisoMensaje MensajeError";
                //btnAceptar.Enabled = false;
           // }

            Document document = new Document();

            PdfWriter.GetInstance(document)

                          new FileStream("devjoker.pdf",

                                 FileMode.OpenOrCreate));


            document.Open();

            document.Add(new Paragraph("Este es mi primer PDF al vuelo"));

            document.Close();
           
        }
    }

}*/