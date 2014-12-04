using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using back_office.Datos.ConfiguracionPuestosPlaya;
using back_office.Dominio;

namespace back_office.Logica.ConfiguracionPuestosPlaya
{
    public class LogicaPuesto
    {
        public PuestoBd _acceso;
        #region contructor
        public LogicaPuesto() 
        {
            _acceso = new PuestoBd();
        }

        #endregion

        #region metodos

        public Puesto[] busquedaPuesto(string fila, string columna) {

            return _acceso.ConsultarPuesto(fila, columna);
        
        }



        #endregion



    }
}