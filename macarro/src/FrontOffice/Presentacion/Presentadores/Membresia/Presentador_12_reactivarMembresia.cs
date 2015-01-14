using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using FrontOffice.Presentacion.Contratos.Membresia;
using FrontOffice.Dominio.Entidades;
using FrontOffice.Dominio.Fabrica;
using FrontOffice.LogicaNegocio;
using FrontOffice.LogicaNegocio.Comandos;
using FrontOffice.LogicaNegocio.Fabrica;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Presentadores.Membresia
{
    public class Presentador_12_reactivarMembresia : PresentadorGeneral
    {

        #region Parametros

        private IContrato_12_reactivarMembresia _vista;
        private Dominio.Entidad _Entidad;

        #endregion

        #region Constructor

        public Presentador_12_reactivarMembresia(IContrato_12_reactivarMembresia reactivarMembresia)
            : base(reactivarMembresia) 
        {

            _vista = reactivarMembresia;
        
        }

        #endregion

        #region Metodos

        public void EventoClickCambiarFoto()
        {
            throw new NotImplementedException();
        }
        public void ConsultarMembresia()
        {
            Comando<int, Dominio.Entidad> comandoConsultaMembresia;
            comandoConsultaMembresia = FabricaComando.ObtenerComandoConsultarMembresia();
            _Entidad = comandoConsultaMembresia.Ejecutar(1);
            if (_Entidad != null)
            {
                this.llenarCampos((Dominio.Entidades.Membresia)_Entidad);
            }
        }
        public void ConsultarTarjetas()
        {
            List<Dominio.Entidad> Result;
            List<Tarjeta> Convert;
            LiberarGrid();
            Comando<int, List<Dominio.Entidad>> ComandoConsultarTarjetas;
            ComandoConsultarTarjetas = FabricaComando.ObtenerComandoConsultaTarjeta();
            Result = ComandoConsultarTarjetas.Ejecutar(1);
            Convert=ConvertirLista(Result);
            AsignarGrid(Convert);
        }
        public void LiberarGrid()
        {
            _vista.gridTarjetasUsadas.DataSource = null;
            _vista.gridTarjetasUsadas.DataBind();
        }
        public void AsignarGrid(List<Tarjeta> Lista)
        {
            _vista.gridTarjetasUsadas.DataSource = Lista;
            _vista.gridTarjetasUsadas.DataBind();
        }
        public List<Tarjeta> ConvertirLista(List<Dominio.Entidad> Lista)
        {
            List<Tarjeta> Resultado;

            Resultado = Dominio.Fabrica.FabricaEntidad.ObtenerListaTarjeta();
            foreach (Dominio.Entidad w in Lista)
            {
                Resultado.Add((Tarjeta)w);
            }

            return Resultado;
        }

        public void Page_Load()
        {
            
                ConsultarMembresia();
                ConsultarTarjetas();
            
        }

        public void EventoClickAgregarTarjeta()
        {
            if (!this._vista.formulariosM.Visible)
            {
                this._vista.agregarTarjeta.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundImage, "url(/comun/resources/img/menos.png)");
                this._vista.agregarTarjeta.Text = "Ocultar";
            }
            else
            {
                this._vista.agregarTarjeta.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundImage, "url(/comun/resources/img/agregar.png)");
                this._vista.agregarTarjeta.Text = "Usar otra tarjeta";
            }

            this._vista.formulariosM.Visible = !this._vista.formulariosM.Visible;
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
            this._vista.tipoDocumentoIdentidad.Text = entidad.Usuario.TipoDocumento + " :";
            this._vista.numeroDocumentoIdentidad.Text = entidad.Usuario.Cedula;
        }

        public void EventoClickAceptar()
        {
            throw new NotImplementedException();
        }

        public void EventoClickCancelar()
        {
            throw new NotImplementedException();
        }

        public void QuitarCheckALosDemas(object sender, System.EventArgs e)
        {
            //Clear the existing selected row 
            foreach (GridViewRow oldrow in _vista.gridTarjetasUsadas.Rows)
            {
                ((RadioButton)oldrow.FindControl("_tarjetaElegidaEnGrid")).Checked = false;
            }


            //Set the new selected row
            RadioButton rb = (RadioButton)sender;
            GridViewRow row = (GridViewRow)rb.NamingContainer;
            ((RadioButton)row.FindControl("_tarjetaElegidaEnGrid")).Checked = true;
        }

        public void _gridTarjetasUsadas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            this._vista.gridTarjetasUsadas.PageIndex = e.NewPageIndex;
            ConsultarTarjetas();
            _vista.gridTarjetasUsadas.DataBind();
        }
        //puede que falten metodos

        #endregion

    }
    
}