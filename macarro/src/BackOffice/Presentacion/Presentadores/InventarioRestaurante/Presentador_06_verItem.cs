﻿using BackOffice.Dominio.Entidades;
using BackOffice.Presentacion.Contratos.InventarioRestaurante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BackOffice.Presentacion.Presentadores.InventarioRestaurante
{
    public class Presentador_06_verItem : PresentadorGeneral
    {
        private IContrato_06_verItem _contrato;
        private Item _item;

        public Presentador_06_verItem(IContrato_06_verItem _contrato)
            : base(_contrato)
        {
            this._contrato = _contrato;
            this._item = new Item();
        }

        public void EventoVerItem()
        {

        }

    }

}
