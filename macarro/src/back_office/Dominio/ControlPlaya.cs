using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace back_office.Dominio
{
    interface ControlPlaya
    {
        #region ConfigurarPuestoPlaya
        /// <summary>
        /// Obtener las dimensiones de la playa
        /// </summary>
        void ObtenerDimensiones();
        /// <summary>
        /// Agregar puesto en playa
        /// </summary>
        /// <param name="puesto"> puesto para gregar </param>
        /// <returns>true = exito - false = error</returns>  
        bool AgregarPuesto( Puesto puesto );
        /// <summary>
        /// modifica el precio indicado en el puesto asignado
        /// </summary>
        /// <param name="precio">nuevo valor del precio</param>
        /// <param name="puesto">puesto a asignar el nuevo precio</param>
        /// <returns>true = exito - false = error</returns>
        bool ModificarPuesto( int precio, Puesto puesto );
        /// <summary>
        /// desactiva el puesto dentro del inventario
        /// </summary>
        /// <param name="puesto">puesto a descartivar</param>
        /// <returns>true = exito - false = error</returns>
        bool EliminarPuesto(Puesto puesto);
        /// <summary>
        /// consulta los puestos
        /// </summary>
        /// <param name="id">id de la playa a consultar</param>
        /// <returns>true = exito - false = error</returns>
        Puesto ConsultarPuesto(int id);
        /// <summary>
        /// Lista todos los puestos
        /// </summary>
        /// <returns>lista de puestos</returns>
        List<Puesto> ListarPuestos();
        /// <summary>
        /// Agrega un item nuevo al inventario
        /// </summary>
        /// <param name="inventario">item a agregar</param>
        /// <returns>true = exito - false = error</returns>
        bool AgregarInventario(Inventario inventario);
        /// <summary>
        /// Modifica el item de inventario a un nuevo precio
        /// </summary>
        /// <param name="precio">nuevo precio</param>
        /// <param name="inventario">item a modificar</param>
        /// <returns>true = exito - false = error</returns>
        bool ModificarInventario(int precio, Inventario inventario);
        /// <summary>
        /// Desactiva el item de inventario a 
        /// </summary>
        /// <param name="inventario"></param>
        /// <returns>true = exito - false = error</returns>
        bool EliminarInventario(Inventario inventario);
        /// <summary>
        /// consulta el item de inventario segun si ID
        /// </summary>
        /// <param name="id">id a consultar</param>
        /// <returns>inventario consultado</returns>
        Puesto ConsultarInventario(int id);
        /// <summary>
        /// lista el inventario completo
        /// </summary>
        /// <returns>inventario completo</returns>
        List<Inventario> ListarInventario();
        /// <summary>
        /// indica el total de sillas segun su estado
        /// </summary>
        /// <param name="tipo">estado de las sillas</param>
        /// <returns>total de sillas</returns>
        int TotalSilla(string tipo);
        /// <summary>
        /// indica el total de misas segun su estado
        /// </summary>
        /// <param name="tipo">estado de las mesas</param>
        /// <returns>total de mesas</returns>
        int TotalMesa(string tipo);
        /// <summary>
        /// indica el total de sombrillas segun su estado
        /// </summary>
        /// <param name="tipo">estado de las sombrillas</param>
        /// <returns>total de sombrillas</returns>
        int TotalSombrilla(string tipo);
        #endregion
    }
}
