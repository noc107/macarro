using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.LogicaNegocio;
using BackOffice.Dominio;
using BackOffice.Dominio.Fabrica;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Dominio.Entidades;
using BackOffice.Presentacion.Contratos.GestionVentaMembresia;


namespace BackOffice.Presentacion.Presentadores.GestionVentaMembresia
{
    public class Presentador_10_gestionarCosto : PresentadorGeneral
    {
         private IContrato_10_gestionarCosto _vista;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="laVistaDefault">interfaz</param>        
         public Presentador_10_gestionarCosto(IContrato_10_gestionarCosto laVistaDefault)
            : base(laVistaDefault)
        {
            _vista = laVistaDefault;
            
        }

         /// <summary>
         /// Metodo para ejecutar y mostrar la consulta de la membresia y sus pagos
         /// </summary>
         /// <param name="idMembresia">membresia a buscar</param>        
         public void EventoBotonAceptar()
         {
             try
             {
                 Entidad _costo; 

                 Comando<Entidad, bool> _comandoModificarCosto;
                 _costo = FabricaEntidad.ObtenerCosto(float.Parse(_vista.Costo.Text));

                 _comandoModificarCosto = FabricaComando.ObtenerComandoModificarCosto();

                 _comandoModificarCosto.Ejecutar(_costo);                 
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }



    }
}