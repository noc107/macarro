using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontOffice.Presentacion.Contratos.Membresia;
using FrontOffice.Dominio.Fabrica;
using FrontOffice.LogicaNegocio.Fabrica;
using FrontOffice.LogicaNegocio.Comandos;
using FrontOffice.Dominio.Entidades;
using FrontOffice.Dominio;
using FrontOffice.LogicaNegocio;

namespace FrontOffice.Presentacion.Presentadores.Membresia
{
    public class Presentador_12_detallePago : PresentadorGeneral
    {

        #region Parametros

        private IContrato_12_detallePago _vista;

        #endregion

        #region Constructor

        public Presentador_12_detallePago(IContrato_12_detallePago detallePagoMembresia)
            : base(detallePagoMembresia) 
        {

            _vista = detallePagoMembresia;
        
        }

        #endregion

        #region Metodos

        public void CargarDatos()
        {
            List<Object> Lista;
            Entidad Resultado;
            Lista = FabricaEntidad.ObtenerListaObjeto();
            Lista.Add(ObtenerId());
            Lista.Add(ObtenerIdPago());
            Comando<List<Object>, Entidad> comandoDetallePago;
            comandoDetallePago = FabricaComando.ObtenerComandoConsultaDetallePago();
            Resultado = comandoDetallePago.Ejecutar(Lista);
            LlenarCampos(Resultado);
        }

        public string ObtenerId()
        {
            string[] ID;

            ID = HttpContext.Current.Request.QueryString.GetValues(0);
            return ID.ElementAt(0);
        }
        public string ObtenerIdPago()
        {
            string[] ID;

            ID = HttpContext.Current.Request.QueryString.GetValues(1);
            return ID.ElementAt(0);
        }

        public void EventoClickVolver(string Pagina)
        {
            HttpContext.Current.Response.Redirect(Pagina + "?id_mem=" + ObtenerId());
        }
        //puede que falten metodos

        public void LlenarCampos(Entidad Parametros)
        {
            Pago Resultado=(Pago)Parametros;
            _vista.tipoTarjeta.ImageUrl = Resultado.tarjetaGet.ImagenURL;
            _vista.numeroTarjeta.Text = Resultado.numeroTarjeta;
            _vista.nombreImpresoEnTarjeta.Text = Resultado.tarjetaGet.NombreEnTarjeta;
            _vista.fechaPago.Text = Resultado.fechaPago.Day.ToString() + "/" + Resultado.fechaPago.Month.ToString() + "/"+Resultado.fechaPago.Year.ToString();
            _vista.montoTotal.Text = Resultado.monto.ToString();
        }

        #endregion

    }
    
}