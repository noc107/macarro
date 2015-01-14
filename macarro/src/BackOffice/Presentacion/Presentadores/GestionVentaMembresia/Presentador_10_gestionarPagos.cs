using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BackOffice.LogicaNegocio;
using BackOffice.Dominio;
using BackOffice.Dominio.Fabrica;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Dominio.Entidades;
using BackOffice.Presentacion.Contratos.GestionVentaMembresia;


namespace BackOffice.Presentacion.Presentadores.GestionVentaMembresia
{
    public class Presentador_10_gestionarPagos : PresentadorGeneral
    {
        private IContrato_10_gestionarPagos _vista;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="laVistaDefault">interfaz</param>        
        public Presentador_10_gestionarPagos(IContrato_10_gestionarPagos laVistaDefault)
            : base(laVistaDefault)
        {
            _vista = laVistaDefault;            
        }

        /// <summary>
        /// Metodo para llenar el gridview de los pagos
        /// </summary>
        /// <param name="_generica">cadena generica para buscar</param>
        public void BindGridPagos(string _generica)
        {
            DataTable _tablaMembresias = new DataTable();
            DataColumn tColumn;
            Presentador_10_gestionarMembresias obj = new Presentador_10_gestionarMembresias(null);

            Comando<string, List<Entidad>> ComandoLlenarGridPagos;
            ComandoLlenarGridPagos = FabricaComando.ObtenerComandoConsultarGVPagos();
            List<Entidad> _listaMembresias = ComandoLlenarGridPagos.Ejecutar(obj.Splitear(_generica));

            tColumn = new System.Data.DataColumn("Id", System.Type.GetType("System.Int32"));
            _tablaMembresias.Columns.Add(tColumn);
            tColumn = new System.Data.DataColumn("Monto", System.Type.GetType("System.Single"));//.Single=float
            _tablaMembresias.Columns.Add(tColumn);
            tColumn = new System.Data.DataColumn("Fecha", System.Type.GetType("System.DateTime"));
            _tablaMembresias.Columns.Add(tColumn);
            tColumn = new System.Data.DataColumn("Id Membresia", System.Type.GetType("System.Int32"));
            _tablaMembresias.Columns.Add(tColumn);
            tColumn = new System.Data.DataColumn("Datos del miembro", System.Type.GetType("System.String"));
            _tablaMembresias.Columns.Add(tColumn);
            tColumn = new System.Data.DataColumn("Accion", System.Type.GetType("System.String"));//SOLO PUEDE VER
            _tablaMembresias.Columns.Add(tColumn);

            foreach (Membresia membr in _listaMembresias)
            {
                foreach (Pago pag in membr.pagos)
                {
                    _tablaMembresias.Rows.Add(pag.id, pag.monto, pag.fecha, membr.id,
                        membr.Usuario.Apellido + membr.Usuario.SegundoApellido + "," + membr.Usuario.Nombre
                        + membr.Usuario.SegundoNombre + ". Cédula: " + membr.Usuario.Cedula);
                }
            }
            _vista.GVPagos.DataSource = _tablaMembresias;
            _vista.GVPagos.DataBind();
        }
    }
}