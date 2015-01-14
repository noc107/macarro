using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using BackOffice.Presentacion.Presentadores.ConfiguracionServiciosPlaya;
using BackOffice.Presentacion.Contratos.ConfiguracionServiciosPlaya;

namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionServiciosPlaya
{
    public partial class web_03_consultaServicioCompleta : System.Web.UI.Page, IContrato_03_consultaServicioCompleta
    {

        #region Párametros

        private Presentador_03_consultaServicioCompleta _presentador;

        #endregion 

        #region Constructor

        public web_03_consultaServicioCompleta()
        {
            _presentador = new Presentador_03_consultaServicioCompleta(this);
        }

        #endregion

        #region Implementación de IContrato_03_consultaServicioCompleta

        public Label nombreServicio
        {
            set { NombreServcio = value; }
            get { return NombreServcio; }
        }

        public Label descripcionServicio
        {
            set { Descripcion = value; }
            get { return Descripcion; }
        }

        public Label categoriaServicio
        {
            set { Categoria = value; }
            get { return Categoria; }
        }

        public Label lugarRetiroServicio
        {
            set { LugarRetiro = value; }
            get { return LugarRetiro; }
        }

        public Label cantidadServicio
        {
            set { Cantidad = value; }
            get { return Cantidad; }
        }

        public Label capacidadServicio
        {
            set { Capacidad = value; }
            get { return Capacidad; }
        }

        public Label costoServicio
        {
            set { Costo = value; }
            get { return Costo; }
        }

        public Label horarioServicio
        {
            set { Horario = value; }
            get { return Horario; }
        }

        public Label estadoServicio
        {            
            set { Estado = value; }
            get { return Estado; }
        }

        public Button volver
        {
            get { return VolverConsulta; }
        }

        public Label LabelMensajeExito
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Label LabelMensajeError
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Carga de datos de un servicio particular al cargar la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            String _nombre = "Tabla de Surf";
            //String _nombre = Request.QueryString["Servicio"];             
            _presentador.mostrarDatosServicio(_nombre);

        }

        /// <summary>
        /// Evento asociado al boton que permite volver a la consulta general
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void VolverConsulta_Click(object sender, EventArgs e)
        {
            Response.Redirect(RecursosVistasServiciosPlaya.VistaConsultaServicio);
        }

        #endregion

    }
}