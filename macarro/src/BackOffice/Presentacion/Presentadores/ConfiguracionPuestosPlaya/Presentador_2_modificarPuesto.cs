using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.ConfiguracionPuestosPlaya;
using BackOffice.Presentacion.Presentadores;
using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Comandos;
using BackOffice.LogicaNegocio.Fabrica;

namespace BackOffice.Presentacion.Presentadores.ConfiguracionPuestosPlaya
{
    public class Presentador_2_modificarPuesto : PresentadorGeneral
    {
        private IContrato_2_modificarPuesto _vista;

        public Presentador_2_modificarPuesto(IContrato_2_modificarPuesto vistaPrincipal)
            : base(vistaPrincipal)
        {
            _vista = vistaPrincipal;                       
        }

        public void EventoClickAceptar()
        {
               string estado=string.Empty;
               string filax = _vista.CampoFila.Text.ToString();
               string columnax= _vista.CampoColumna.Text.ToString();
               string descripcionx=_vista.CampoDescripcion.Text.ToString();
               string montox= _vista.CampoPrecio.Text.ToString();

               if (filax.Equals(string.Empty))
                   filax = "0";

               if (columnax.Equals(string.Empty))
                   columnax = "0";

               if (montox.Equals(string.Empty))
                   montox = "0";

               Entidad Puesto = FabricaEntidad.ObtenerPuestoPlaya(Convert.ToInt32(filax), Convert.ToInt32(columnax), descripcionx, Convert.ToSingle(montox), estado);
               Comando<Entidad, bool> ComandoActualizarPuesto = FabricaComando.ObtenerComandoActualizarPuesto();
               bool flag = ComandoActualizarPuesto.Ejecutar(Puesto);
             if (flag)
           {

               _vista.LabelMensajeExito.Visible = true;
               MostrarMensajeExito(RecursosPresentador.mensajeDeExitoModificarPuesto);
          }
           
        }

        public string EventoClickCancelar()
        {
            return RecursosPresentador.PaginaConsultarPuesto;
        }

        public void SetearContratoModificar(String fila,String Columna,String descripcion,String Monto)
        {
            _vista.CampoFila.Text = fila;
            _vista.CampoColumna.Text = Columna;
            _vista.CampoDescripcion.Text = descripcion;
            _vista.CampoPrecio.Text = Monto;
        
        }
    }
}