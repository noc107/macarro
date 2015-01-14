using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.FuenteDatos.IDao.ReportesFinancierosExportacion;
using BackOffice.FuenteDatos.Dao.ReportesFinancierosExportacion;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.Dao;
using System.Data;

namespace BackOffice.LogicaNegocio.Comandos.ReportesFinancierosExportacion
{
    public class ComandoReporteTablaConParametros : Comando<string[],DataTable>
    {
        IDaoReportesFinancierosExportacion _dao = FabricaDao.ObtenerDaoReportesFinancierosExportacion();
        /// <summary>
        /// El metodo funcina como intermediario para obtener los 
        /// datos de la cantidad de usuarios activos e inactivos 
        /// en la capa datos y asignarlos a un DataTable
        /// para ser utilizados en la capa de interfaz.
        /// </summary>
        /// <returns>
        /// Este metodo regresa un DataTable que contiene los datos
        /// necesarios para crear la tabla que posee el reporte.
        /// </returns>
        public override DataTable Ejecutar(string[] n)
        {
            DataTable _dataTable = new DataTable();
            int i = Convert.ToInt16(n[0]);
            switch (i)
            {
                case 1:
                    _dataTable = _dao.GetDatosIngresosMembresia(n[1],n[2]);
                    break;
                case 2:
                    _dataTable = _dao.GetDatosIngresosSombrilla(n[1], n[2]);
                    break;
                case 3:
                    _dataTable = _dao.GetDatosIngresosRestaurante(n[1], n[2]);
                    break;
                case 4:
                    _dataTable = _dao.GetDatosIngresosServicio(n[1], n[2]);
                    break;
                case 5:
                    _dataTable = _dao.GetDatosIngresosEstacionamiento(n[1], n[2]);
                    break;
                case 6:
                    _dataTable = _dao.GetDatosComidas(n[1], n[2]);
                    break;
                case 7:
                    _dataTable = _dao.GetDatosBebidas(n[1], n[2]);
                    break;
            }
            return _dataTable;
        }
    }
}