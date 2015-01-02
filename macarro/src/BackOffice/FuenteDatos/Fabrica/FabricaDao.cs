using BackOffice.FuenteDatos.Dao.Proveedores;
using BackOffice.FuenteDatos.IDao.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.FuenteDatos.Fabrica
{
    public class FabricaDao
    {
        #region ConfiguracionEstacionamiento

        #endregion

        #region ConfiguracionPuestosPlaya

        #endregion

        #region ConfiguracionServiciosPlaya

        #endregion

        #region GestionVentaMembresia

        #endregion

        #region IngresoRecuperacionClave

        #endregion

        #region InventarioRestaurante

        #endregion

        #region MenuRestaurante

        #endregion

        #region Proveedores

        public static IDaoProveedor ObtenerDaoProveedor()
        {
            return new DaoProveedor();
        }

        #endregion

        #region ReportesFinancierosExportacion

        #endregion

        #region ReservasSombrillasServiciosPlaya

        #endregion

        #region RolesSeguridad

        #endregion

        #region UsuariosInternos

        #endregion

        #region VentaCierreCaja

        #endregion
    }
}