using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontOffice.Presentacion.Contratos.Membresia;
using FrontOffice.LogicaNegocio.Fabrica;
using FrontOffice.LogicaNegocio;
using FrontOffice.Dominio.Entidades;
using FrontOffice.Dominio;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Presentadores.Membresia
{
    public class Presentador_12_pagos : PresentadorGeneral
    {

        #region Parametros

        private IContrato_12_pagos _vista;

        #endregion

        #region Constructor

        public Presentador_12_pagos(IContrato_12_pagos pagosMembresia)
            : base(pagosMembresia) 
        {

            _vista = pagosMembresia;
        
        }

        #endregion

        #region Metodos

        public void EventoClickDetallePago(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridView myGrid = (GridView)sender; 
            string ID = myGrid.DataKeys[rowIndex].Value.ToString();
            HttpContext.Current.Response.Redirect("/Presentacion/Vistas/Web/Membresia/web_12_detallePago.aspx" + "?id_mem=" + ObtenerId() + "&id_pag=" + ID);   
        }

        public void LiberarGrid()
        {
            _vista.gridPagosHechos.DataSource = null;
            _vista.gridPagosHechos.DataBind();
        }
        public void BusquedaClick()
        {
            List<Entidad> Resultado;
            List<Pago> convert;
            List<Object> parametros;
            LiberarGrid();
            if (!_vista.fechabusqueda.Text.Equals(""))
            {
                convert = Dominio.Fabrica.FabricaEntidad.ObtenerListaPago();
                parametros = Dominio.Fabrica.FabricaEntidad.ObtenerListaObjeto();
                System.Threading.Thread.Sleep(2000);//solo por ejemplo
                AsignarGrid(convert);
                parametros.Add(Int32.Parse(ObtenerId()));
                parametros.Add(DateTime.Parse(_vista.fechabusqueda.Text));
                Comando<List<Object>, List<Entidad>> comandoGenerarPdf;
                comandoGenerarPdf = FabricaComando.ObtenerComandoConsultarPagoConParametros();
                Resultado = comandoGenerarPdf.Ejecutar(parametros);
            }
            else
            {
                Comando<int, List<Entidad>> comandoGenerarPdf;
                comandoGenerarPdf = FabricaComando.ObtenerComandoConsultarTodosLosPagos();
                Resultado = comandoGenerarPdf.Ejecutar(Int32.Parse(ObtenerId()));
                convert = ConvertirLista(Resultado);
            }
            
            
            convert = ConvertirLista(Resultado);

            AsignarGrid(convert);
        }

        public void AsignarGrid(List<Pago> Lista)
        {
            _vista.gridPagosHechos.DataSource = Lista;
            _vista.gridPagosHechos.DataBind();
        }
        public string ObtenerId()
        {
            string[] ID; 

            ID= HttpContext.Current.Request.QueryString.GetValues(0);
            return ID.ElementAt(0);
        }
        public List<Pago> ConvertirLista(List<Entidad> Lista)
        {
            List<Pago> Resultado;

            Resultado = Dominio.Fabrica.FabricaEntidad.ObtenerListaPago();
            foreach (Entidad w in Lista)
            {
                Resultado.Add((Pago)w);
            }

            return Resultado;
        }

        public void Page_Load()
        {
            List<Entidad> Resultado;
            List<Pago> convert;

            convert = Dominio.Fabrica.FabricaEntidad.ObtenerListaPago();
            //System.Threading.Thread.Sleep(5000);//solo por ejemplo
            AsignarGrid(convert);
            
            
           Comando<int, List<Entidad>> comandoGenerarPdf;
            comandoGenerarPdf = FabricaComando.ObtenerComandoConsultarTodosLosPagos();
            Resultado = comandoGenerarPdf.Ejecutar(Int32.Parse(ObtenerId()));
            convert = ConvertirLista(Resultado);

            AsignarGrid(convert);
        }
    

        public void EventoClickVolver(string Pagina)
        {
            HttpContext.Current.Response.Redirect(Pagina);
        }


        public void _gridPagosHechos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        public void _gridPagosHechos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this._vista.gridPagosHechos.PageIndex = e.NewPageIndex;
            _vista.gridPagosHechos.DataBind();
        }



        #endregion

    }
    
}