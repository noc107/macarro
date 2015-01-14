using System;
using System.Collections.Generic;
using System.Data;
using BackOffice.Presentacion.Contratos.RolesSeguridad;
using BackOffice.Dominio;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Dominio.Entidades;
using BackOffice.Excepciones.ExcepcionesComando.RolesSeguridad;
using BackOffice.Excepciones.ExcepcionesComando;
using BackOffice.Excepciones;

namespace BackOffice.Presentacion.Presentadores.RolesSeguridad
{
    public class Presentador_08_ConsultarAcciones : PresentadorGeneral
    {

        private IContrato_08_ConsultarAcciones _vista;
        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="laVistaRolesSeguridad">Interfaz</param>
        public Presentador_08_ConsultarAcciones(IContrato_08_ConsultarAcciones laVistaRolesSeguridad)
            : base(laVistaRolesSeguridad)
        {
            _vista = laVistaRolesSeguridad;
        }

        /// <summary>
        /// Metodo para la presentacion de los datos del GridView 
        /// </summary>
        public void BindGridAcciones()
        {

            DataTable mytable = new DataTable();
            DataColumn tColumn;

            try
            {
                Comando<bool, List<Entidad>> ComandoLlenarGridAcciones;
                ComandoLlenarGridAcciones = FabricaComando.ObtenerComandoLlenarGridAcciones();
                List<Entidad> listAcc = ComandoLlenarGridAcciones.Ejecutar(true);

                tColumn = new DataColumn("Acción", Type.GetType("System.String"));
                mytable.Columns.Add(tColumn);
                tColumn = new DataColumn("Descripción", Type.GetType("System.String"));
                mytable.Columns.Add(tColumn);

                foreach (Accion a in listAcc)
                {
                    mytable.Rows.Add(a.Nombre, a.Descripcion);
                }

                _vista.GVAcciones.DataSource = mytable;
                _vista.GVAcciones.DataBind();
            }
            catch (ExcepcionComandoLlenarGridAcciones e)
            {
                _vista.LabelMensajeError.Visible = true;
                MostrarMensajeError(e.Mensaje);
                Logger.EscribirEnLogger(e);
            }
            catch (ExcepcionComando e)
            {
                _vista.LabelMensajeError.Visible = true;
                MostrarMensajeError(e.Mensaje);
                Logger.EscribirEnLogger(e);
            }
        }
    
    }
}