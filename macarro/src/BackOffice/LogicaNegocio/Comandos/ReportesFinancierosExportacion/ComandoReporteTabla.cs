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
    public class ComandoReporteTabla : Comando<int, DataTable>
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
        public override DataTable Ejecutar(int i)
        {
            DataTable _dataTable = new DataTable();
            switch (i)
            {
                case 1:
                    _dataTable = _dao.GetDatosActivos();
                    break;
                case 2:
                    _dataTable = _dao.GetDatosRoles();
                    break;
                case 3:
                    _dataTable = _dao.GetDatosProveedores();
                    break;
                case 4:
                    _dataTable = _dao.GetDatosProductos();
                    break;
            }
            return _dataTable;
        }
    }
}