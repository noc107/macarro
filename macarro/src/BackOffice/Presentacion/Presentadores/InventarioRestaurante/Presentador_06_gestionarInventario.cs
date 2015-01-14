using BackOffice.Dominio.Entidades;
using BackOffice.Presentacion.Contratos.InventarioRestaurante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BackOffice.Presentacion.Presentadores.InventarioRestaurante
{
    public class Presentador_06_gestionarInventario : PresentadorGeneral
    {
        private IContrato_06_gestionarInventario _contrato;
        private List<Item> _list;

        public Presentador_06_gestionarInventario(IContrato_06_gestionarInventario _contrato)
            : base(_contrato)
        {
            this._contrato = _contrato;
            this._list = new List<Item>();

        }
        public void EventoEliminar()
        { 
        
        }

        public void EventoModificar()
        {

        }

        public void EventoConsultar()
        {

        }

        public void EventoBuscar()
        {

        }

        public void EventoCancelar()
        {

        }

    }
}