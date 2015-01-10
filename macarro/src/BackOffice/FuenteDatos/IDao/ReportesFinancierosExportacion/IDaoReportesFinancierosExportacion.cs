using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackOffice.Dominio;
using System.Data;

namespace BackOffice.FuenteDatos.IDao.ReportesFinancierosExportacion
{
    public interface IDaoReportesFinancierosExportacion 
    {
        DataTable GetDatosActivos();
        DataTable GetDatosRoles();
        DataTable GetDatosProveedores();
        DataTable GetDatosProductos();
        DataTable GetDatosIngresosMembresia(string _fechaini, string _fechafin);
        DataTable GetDatosIngresosSombrilla(string _fechaini, string _fechafin);
        DataTable GetDatosIngresosRestaurante(string _fechaini, string _fechafin);
        DataTable GetDatosIngresosServicio(string _fechaini, string _fechafin);
        DataTable GetDatosIngresosEstacionamiento(string _fechaini, string _fechafin);
        DataTable GetDatosComidas(string _fechaini, string _fechafin);
        DataTable GetDatosBebidas(string _fechaini, string _fechafin);
    }
}
