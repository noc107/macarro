using BackOffice.Presentacion.Contratos.ConfiguracionServiciosPlaya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Presentacion.Presentadores.ConfiguracionServiciosPlaya
{
    public class Presentador_3_agregarServicio : PresentadorGeneral
    {
        private IContrato_3_agregarServicio _contratoAgregarServicio;

        public Presentador_3_agregarServicio(IContrato_3_agregarServicio _contratoAgregarServicio)
            : base(_contratoAgregarServicio)
        {
            this._contratoAgregarServicio = _contratoAgregarServicio;
        }

        public string CargarCategoria()
        {
            string _listacategoria = string.Empty;

            //deberia llamar algo que llame a la bd para traer todas las categorias

            return _listacategoria;
        }

    }
}