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
    public class Presentador_10_consultarMembresiaPagos : PresentadorGeneral
    {
        private IContrato_10_consultarMembresiaPagos _vista;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="laVistaDefault">interfaz</param>        
        public Presentador_10_consultarMembresiaPagos(IContrato_10_consultarMembresiaPagos laVistaDefault)
            : base(laVistaDefault)
        {
            _vista = laVistaDefault;
            
        }

        public void EventoClickVolver() 
        {
        
        }

        /// <summary>
        /// Metodo para ejecutar y mostrar la consulta de la membresia y sus pagos
        /// </summary>
        /// <param name="idMembresia">membresia a buscar</param>        
        public void EventoBotonConsultar(int idMembresia)
        {
            try
            {
                Dominio.Entidad _membresia;

                Comando<int, Entidad> comandoConsultarMembresia;
                _membresia = FabricaEntidad.ObtenerMembresia();
                comandoConsultarMembresia = FabricaComando.ObtenerComandoConsultarMembresia();

                _membresia = comandoConsultarMembresia.Ejecutar(idMembresia);

                if (_membresia != null)
                {                    
                    LlenarDatos((Membresia)_membresia);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Metodo para setear los labels de la ventana de consulta
        /// </summary>
        /// <param name="membr">membresia a mostrar</param>        
        public void LlenarDatos(Membresia membr)
        {
            if (membr != null)
            {
                _vista.Apellido1.Text = membr.Usuario.Apellido;
                _vista.Apellido2.Text = membr.Usuario.SegundoApellido;
                _vista.Costo.Text = membr.costo.ToString();
                _vista.Descuento.Text = membr.descAplicado.ToString();
                _vista.Documento.Text = membr.Usuario.Cedula;
                _vista.Estado.Text = membr.estado;
                _vista.FAdmision.Text = membr.fAdmision.ToString();
                _vista.FVencimiento.Text = membr.fVencimiento.ToString();                
                _vista.ID.Text = membr.id.ToString();
                _vista.Nombre1.Text = membr.Usuario.Nombre;
                _vista.Nombre2.Text = membr.Usuario.SegundoNombre;
                _vista.Telefono.Text = membr.Usuario.Telefono;
                BindGridPagos(membr.pagos);
            }
        }

        /// <summary>
        /// Metodo para llenar el gridview de los pagos asociados a la membresia
        /// </summary>
        /// <param name="pagos">lista de pagos a mostrar en el grid</param>        
        public void BindGridPagos(List<Pago> pagos)
        {
            DataTable _tablaPagos = new DataTable();
            DataColumn _tColum;            

            _tColum = new System.Data.DataColumn("Id", System.Type.GetType("System.Int32"));
            _tablaPagos.Columns.Add(_tColum);
            _tColum = new System.Data.DataColumn("Fecha", System.Type.GetType("System.DateTime"));
            _tablaPagos.Columns.Add(_tColum);
            _tColum = new System.Data.DataColumn("Monto", System.Type.GetType("System.Single"));//.single=float
            _tablaPagos.Columns.Add(_tColum);            

            foreach (Pago pago in pagos)
            {
                _tablaPagos.Rows.Add(pago.id,pago.fecha,pago.monto);
            }

            _vista.GVPagos.DataSource = _tablaPagos;
            _vista.GVPagos.DataBind();
        }
    }
}