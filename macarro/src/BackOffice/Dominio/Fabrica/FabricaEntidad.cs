using BackOffice.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Fabrica
{
    public class FabricaEntidad
    {
        #region Ejemplo

        public static Entidad ObtenerPersona(string nombre, string apellido)
        {
            return new Persona(nombre, apellido);
        }

        #endregion

        public static Entidad ObtenerEstado()
        {
            return new Estado();
        }

        public static Entidad ObtenerEstado(int id, string titulo)
        {
            return new Estado( id,  titulo);
        }

        public static Entidad ObtenerItem(int codigo, string descripcion, int cantidad, string nombre, float precioCompra, float precioVenta, DateTime fechaCompra, int cantidadMinima)
        {
            return new Item(codigo, descripcion, cantidad, nombre, precioCompra, precioVenta, fechaCompra, cantidadMinima);
        }        
		
		#region RolesSeguridad

        public static Entidad ObtenerAccion(int id, string nombre, string descripcion)
        {
            return new Accion(id, nombre, descripcion);
        }

        public static Entidad ObtenerAccionVacio()
        {
            return new Accion();
        }

        public static Entidad ObtenerRol(int id, string nombre, string descripcion, List<Accion> acciones)
        {
            return new Rol(id, nombre, descripcion, acciones);
        }

        public static Entidad ObtenerRolVacio()
        {
            return new Rol();
        }

        #endregion

        #region ConfiguracionPuestosPlaya
        public static Entidad ObtenerInventarioPlaya()
        {
            return new InventarioPlaya();
        }
        
        public static Entidad ObtenerInventarioPlaya(int id, float precio, string estado, string tipo, string descripcion, string codigo)
        {
            return new InventarioPlaya(id, precio, estado, tipo, descripcion, codigo);
        }

        public static Entidad ObtenerInventarioPlaya(float precio, string tipo)
        {
            return new InventarioPlaya(precio,tipo);
        }
        #endregion
    }
}