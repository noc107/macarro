using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.ConfiguracionPuestosPlaya;
using BackOffice.Presentacion.Presentadores.ConfiguracionPuestosPlaya;


namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya
{
    public partial class web_2_modificarInventario : System.Web.UI.Page , IContrato_2_modificarInventario
    {
        private object _parametroId;
        private object _parametroTipo;

        #region Presentador
        private Presentador_2_modificarInventario _presentador;
        #endregion

        #region Implementación de Contrato
        public TextBox CampoPrecio
        {
	        get { return formularioModificarInventario.txt_Precio; }
        }

        public DropDownList DropEstado
        {
	        get { return formularioModificarInventario.Estado; }
        }

        public TextBox CampoDescripcion
        {
	        get { return formularioModificarInventario.txt_Descripcion; }
        }

        public Button BtnAceptar
        {
	        get { return botonAceptar; }
        }

        public Button BtnCancelar
        {
	        get { return botonCancelar; }
        }

        public Label LabelMensajeExito 
        {
            get { return mensajeDeEstado.mensajeExito;}
            set { mensajeDeEstado.mensajeExito = value;}
        }

        public Label LabelMensajeError
        {
            get { return mensajeDeEstado.mensajeError; }
            set { mensajeDeEstado.mensajeError = value; }
        }
        
        #endregion

        #region constructor
        public web_2_modificarInventario()
        {
            _presentador = new Presentador_2_modificarInventario(this);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            _parametroId = Session[RecursosInterfaz.IdInventario];
            _parametroTipo = Session[RecursosInterfaz.InvTipo];
            
            if (_parametroId != null || _parametroTipo != null)
            {
                if (DropEstado.Items.Count == 1)
                {
                    _presentador.CargarDropEstados();
                }
                _presentador.Inicio(_parametroId);
                
            }
            else
            {
                Response.Redirect(RecursosInterfaz.PaginaConsultarInventario);
            }
        }

        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickAceptar(_parametroId,_parametroTipo);
        }

        protected void botonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(_presentador.EventoClickCancelar());
        }

    }
}