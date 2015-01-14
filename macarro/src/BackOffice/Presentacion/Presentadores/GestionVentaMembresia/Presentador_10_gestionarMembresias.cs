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
    public class Presentador_10_gestionarMembresias : PresentadorGeneral
    {
        private IContrato_10_gestionarMembresias _vista;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="laVistaDefault">interfaz</param>        
        public Presentador_10_gestionarMembresias(IContrato_10_gestionarMembresias laVistaDefault)
            : base(laVistaDefault)
        {
            _vista = laVistaDefault;
            
        }

        public string Splitear(string cadena)
        {
            string[] _arregloAux = null;
            string _cadenaAux  = string.Empty;

            _arregloAux = cadena.Split(' ');

            for (int i = 0; i < _cadenaAux.Length; i++)
            {
                if (_arregloAux[i]!=" ")
                    _cadenaAux += _arregloAux[i] + "|";
            }

            return _cadenaAux;
        }

        /// <summary>
        /// Metodo para llenar el gridview de las membresias
        /// </summary>
        /// <param name="_generica">cadena generica para buscar</param>
        public void BindGridMembresias(string _generica)
        {
            DataTable _tablaMembresias = new DataTable();
            DataColumn tColumn;

            Comando<string, List<Entidad>> ComandoLlenarGridMembresias;
            ComandoLlenarGridMembresias = FabricaComando.ObtenerComandoConsultarGVMembresias();
            List<Entidad> _listaMembresias = ComandoLlenarGridMembresias.Ejecutar(Splitear(_generica));

            tColumn = new System.Data.DataColumn("Id", System.Type.GetType("System.Int32"));
            _tablaMembresias.Columns.Add(tColumn);
            tColumn = new System.Data.DataColumn("Fecha de admision", System.Type.GetType("System.DateTime"));
            _tablaMembresias.Columns.Add(tColumn);
            tColumn = new System.Data.DataColumn("Fecha de vencimiento", System.Type.GetType("System.DateTime"));
            _tablaMembresias.Columns.Add(tColumn);
            tColumn = new System.Data.DataColumn("Estado", System.Type.GetType("System.String"));
            _tablaMembresias.Columns.Add(tColumn);
            tColumn = new System.Data.DataColumn("Datos del miembro", System.Type.GetType("System.String"));
            _tablaMembresias.Columns.Add(tColumn);
            tColumn = new System.Data.DataColumn("Acciones", System.Type.GetType("System.String"));
            _tablaMembresias.Columns.Add(tColumn);

            foreach (Membresia membr in _listaMembresias)
            {
                _tablaMembresias.Rows.Add(membr.id,membr.fAdmision,membr.fVencimiento,membr.estado,
                    membr.Usuario.Apellido + membr.Usuario.SegundoApellido + "," + membr.Usuario.Nombre
                    + membr.Usuario.SegundoNombre + ". Cédula: " + membr.Usuario.Cedula);
            }

            _vista.GVMembresias.DataSource = _tablaMembresias;
            _vista.GVMembresias.DataBind();
        }
    }
}