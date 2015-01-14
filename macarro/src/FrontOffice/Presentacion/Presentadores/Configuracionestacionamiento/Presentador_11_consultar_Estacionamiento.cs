using FrontOffice.Dominio;
using FrontOffice.Dominio.Entidades;
using FrontOffice.Dominio.Fabrica;
using FrontOffice.LogicaNegocio;
using FrontOffice.LogicaNegocio.Fabrica;
using FrontOffice.Presentacion.Contratos.Configuracionestacionamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Presentadores.Configuracionestacionamiento
{
    public class Presentador_11_consultar_Estacionamiento : PresentadorGeneral
    {
        private IContrato_11_consultar_Estacionamiento _vista;
        private Estacionamiento est;

        public Presentador_11_consultar_Estacionamiento(IContrato_11_consultar_Estacionamiento vistaEstacionamiento)
            : base(vistaEstacionamiento) 
        {

            _vista = vistaEstacionamiento;
        
        }
        //boton volver
        public void EventoClickVolver()
        {
            throw new NotImplementedException();
        }

        public Estacionamiento ConsultarEstacionamiento() 
        {
            try
            {
                Dominio.Entidad _estacionamiento;

                Comando<int, Entidad> comandoConsultarEstacionamiento;
                _estacionamiento = FabricaEntidad.ObtenerEstacionamiento();
                comandoConsultarEstacionamiento = FabricaComando.ObtenerComandoConsultarEstacionamiento();

                _estacionamiento = comandoConsultarEstacionamiento.Ejecutar(1);

                if (_estacionamiento != null)
                {
                    est = (Estacionamiento)_estacionamiento;
                    LlenarDatos(est);
                
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return est;
        }


        public void LlenarDatos(Estacionamiento est)
        {
            if (est != null)
            {
                Console.WriteLine(est.Nombre.ToString());
                _vista.LabelNombreEstacionamienot.Text = est.Nombre.ToString();
                _vista.LabelCapacidad.Text = est.Capacidad.ToString();
                _vista.LabelTarifa.Text = est.Tarifa.ToString();
                _vista.LabelPerdido.Text = est.TicketPerdido.ToString();
                _vista.LabelEstado.Text = est.NombreEstado.ToString();
                _vista.LabelDisponible.Text = est.Disponible.ToString();
                
            }
        }  
        
    }
}