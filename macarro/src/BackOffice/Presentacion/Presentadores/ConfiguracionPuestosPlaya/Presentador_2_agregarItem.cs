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
    public class Presentador_2_agregarItem : PresentadorGeneral
    {
        private IContrato_2_agregarItem _vista;


        public Presentador_2_agregarItem(IContrato_2_agregarItem vistaPrincipal)
            : base(vistaPrincipal)
        {
            _vista = vistaPrincipal;                       
        }


        public void EventoClickAceptar()
        {
            
        }

    }
}