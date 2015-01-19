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

        public static Entidad ObtenerPersona(string nombre, string apellido, string documento)
        {
            return new Persona(nombre, apellido,documento);
        }

        #endregion
		
		#region Estado

        public static Entidad ObtenerEstado()
        {
            return new Estado();
        }

        public static Entidad ObtenerEstado(int id, string titulo)
        {
            return new Estado( id,  titulo);
        }
		#endregion

        #region IngresoRecuperacionClave

        public static Entidad ObtenerUsuarioInicio(string correo, string contrasena)
        {
            return new Usuario(correo, contrasena);
        }

        public static Entidad ObtenerUsuarioInicio()
        {
            return new Usuario();
        }

        public static Entidad ObtenerPersonaInicio()
        {
            return new Persona();
        }

        #endregion

        #region InventarioRestaurante
        public static Entidad ObtenerItem()
        {
            return new Item();
        }

        public static Entidad ObtenerItem(int codigo, string descripcion, int cantidad, string nombre, float precioCompra, float precioVenta, DateTime fechaCompra, int cantidadMinima, Proveedor proveedor)
        {
            return new Item(codigo, descripcion, cantidad, nombre, precioCompra, precioVenta, fechaCompra, cantidadMinima, proveedor);
        }
        #endregion

        #region RolesSeguridad

        /// <summary>
        /// Metodo para la fabrica del ObtenerAccion 
        /// </summary>
        /// <param name="id">id de la accion</param>
        /// <param name="nombre">nombre de la accion</param>
        /// <param name="descripcion">descripcion de la accion</param>
        /// <returns>la accion</returns>
        public static Entidad ObtenerAccion(int id, string nombre, string descripcion)
        {
            return new Accion(id, nombre, descripcion);
        }

        /// <summary>
        /// Metodo para la fabrica del ObtenerAccion vacia
        /// </summary>
        /// <returns>la accion</returns>
        public static Entidad ObtenerAccion()
        {
            return new Accion();
        }

        /// <summary>
        /// Metodo para la fabrica del ObtenerRol 
        /// </summary>
        /// <param name="id">id del rol</param>
        /// <param name="nombre">nombre del rol</param>
        /// <param name="descripcion">descripcion del rol</param>
        /// <param name="acciones">acciones del rol</param>
        /// <returns>el rol</returns>
        public static Entidad ObtenerRol(int id, string nombre, string descripcion, List<Accion> acciones)
        {
            return new Rol(id, nombre, descripcion, acciones);
        }

        /// <summary>
        /// Metodo para la fabrica del ObtenerRol vacio
        /// </summary>
        /// <returns>el rol</returns>
        public static Entidad ObtenerRol()
        {
            return new Rol();
        }

        #endregion

        #region ConfiguracionPuestosPlaya
        public static Entidad ObtenerInventarioPlaya()
        {
            return new InventarioPlaya();
        }
        
        public static Entidad ObtenerInventarioPlaya(int id, float precio, string estado, string tipo, string descripcion)
        {
            return new InventarioPlaya(id, precio, estado, tipo, descripcion);
        }

        public static Entidad ObtenerInventarioPlaya(float precio, string tipo)
        {
            return new InventarioPlaya(precio,tipo);
        }

        public static Entidad ObtenerPuestoPlaya()
        {
            return new Puesto();
        }

        public static Entidad ObtenerPuestoPlaya(int fila, int columna, string descripcion, float precio, string estado)
        {
            return new Puesto(fila, columna, descripcion, precio, estado);
        }

        public static Entidad ObtenerPuestoPlaya(int fila, int columna, string descripcion, float precio)
        {
            return new Puesto(fila, columna, descripcion, precio);
        }



        #endregion

        #region ConfiguracionServiciosPlaya

        public static Entidad ObtenerCategoria()
        {
            return new Categoria();
        }

        public static Entidad ObtenerCategoria(int id, string nombre)
        {
            return new Categoria(id, nombre);
        }

        public static Entidad ObtenerCategoria(string nombre)
        {
            return new Categoria(nombre);
        }

        public static Entidad ObtenerHorario(DateTime inicio, DateTime fin)
        {
            return new Horario(inicio, fin);
        }

        public static Entidad ObtenerServicio(string _nombre, string _descripcion, int _capacidad, int _cantidad, float _costo, string _categoria,
            string _lugarRetiro, string _estado, List<Horario> _listaHorarios)
        {
            return new Servicio(_nombre, _descripcion, _capacidad, _cantidad, _costo, _categoria, _lugarRetiro, _estado, _listaHorarios);
        }

        public static Entidad ObtenerServicio()
        {
            return new Servicio();
        }

        public static Entidad ObtenerServicio(string nombre, string descripcion, string estado)
        {
            return new Servicio(nombre, descripcion, estado);
        }

        public static Entidad ObtenerServicio(string nombre, string estado)
        {
            return new Servicio(nombre, estado);
        }

        #endregion

        #region VentaCierreCaja

        public static Entidad ObtenerLineaFacturaServicio(string _servicio, float _precio, int _idServicio, string _tipo)
        {
            return new LineaFactura(_idServicio, _precio, _servicio, _tipo);  
        }
        
        public static Entidad ObtenerLineaFacturaServicioCant(string _servicio, float _precio, int _cantidad, string _tipo)
        {
            return new LineaFactura(_precio,_cantidad, _servicio, _tipo);
        }

        public static Entidad ObtenerCierreCaja()
        {
            return new CierreCaja();
        }

        public static Entidad ObtenerDetalleFactura(int _nroFactura, DateTime _fecha, float _subtotal, float _total)
        {
            return new Factura(_nroFactura, _fecha, _subtotal, _total);
        }

        public static Entidad ObtenerDetalleFactura2(int _nroFactura, float _subtotal, float _total)
        {
            return new Factura(_nroFactura, _subtotal, _total);
        }

        public static Entidad ObtenerFactura()
        {
            return new Factura();
        }

        #endregion

        #region Proveedores

        public static Entidad ObtenerProveedor()
        {
            return new Proveedor();
        }

        public static Entidad ObtenerProveedor(int id, string rif, string razonSocial,string correo, string paginaweb, string fechaContrato, string telefono,
                                               string idLugar, string ciudad ) 
        {
            return new Proveedor(id,rif,razonSocial,correo,paginaweb,fechaContrato,telefono,idLugar,ciudad);
        }

        public static Entidad ObtenerProveedor(int id, string rif, string razonSocial, string correo, string paginaweb, string fechaContrato, string telefono,
                                       string idLugar, string ciudad, string status)
        {
            return new Proveedor(id, rif, razonSocial, correo, paginaweb, fechaContrato, telefono, idLugar, ciudad,status);
        }

        public static Entidad ObtenerProveedor(int id, string rif, string nombre)
        {
            return new Proveedor(id, rif, nombre);
        }

        #endregion
		
		#region Usuarios Internos
        public static Entidad ObtenerLugar() 
        {
            return new Lugar();
        }

        public static Entidad ObtenerLugar(int idLugar, string nombreLugar, string tipoLugar, int fkLugar) 
        {
            return new Lugar(idLugar, nombreLugar, tipoLugar, fkLugar);
        }

        public static Entidad ObtenerPersona() 
        {
            return new Persona(); 
        }

        public static Entidad ObtenerPersona(int id, string cedula, string tipoDoc, string nombre, string segNombre, string apellido, string segApellido, DateTime fechaNac, string telefono, string nombreLugar, Usuario usuario) 
        {
            return new Persona(id, cedula, tipoDoc,nombre,segNombre,apellido,segApellido,fechaNac,telefono,nombreLugar,usuario); 
        }

        public static Entidad ObtenerUsuario() 
        {
            return new Usuario(); 
        }

        public static Entidad ObtenerUsuario(string estatus, string correo, DateTime fechaIngreso, DateTime fechaEgreso) 
        {
            return new Usuario(estatus,correo,fechaIngreso,fechaEgreso); 
        }

        public static Entidad ObtenerUsuario(int id, string correo, string contrasena, DateTime fechaIngreso, DateTime fechaEgreso,string tipoUsuario, string estatus, List <Rol> cargos) 
        {
            return new Usuario(id,correo,contrasena,fechaIngreso,fechaEgreso,tipoUsuario,estatus,cargos);
        }

        public static Entidad ObtenerHash() 
        {
            return new Hash(); 
        }
        #endregion

        #region MenuRestaurante

        /// <summary>
        /// Metodo para la fabrica del ObtenerSeccion vacia
        /// </summary>
        /// <returns>seccion</returns>
        public static Entidad ObtenerSeccion()
        {
            return new Seccion();
        }
        
        /// <summary>
        /// Metodo para la fabrica del ObtenerSeccion 
        /// </summary>
        /// <param name="id">id de la seccion</param>
        /// <param name="nombre">nombre de la seccion</param>
        /// <param name="descripcion">descripcion de la seccion</param>
        /// <returns>seccion</returns>
        public static Entidad ObtenerSeccion(int id, string nombre, string descripcion)
        {
            return new Seccion(id, nombre, descripcion);
        }

        /// <summary>
        /// Metodo para la fabrica del ObtenerPlato vacia
        /// </summary>
        /// <returns>plato</returns>
        public static Entidad ObtenerPlato()
        {
            return new Plato();
        }

        /// <summary>
        /// Metodo para la fabrica del ObtenerPlato 
        /// </summary>
        /// <param name="id">id del plato</param>
        /// <param name="nombre">nombre del plato</param>
        /// <param name="precio">precio del plato</param>
        /// <param name="descripcion">descripcion del plato</param>
        /// <returns>plato</returns>
        public static Entidad ObtenerPlato(int id, string nombre, float precio, string descripcion, string seccion)
        {
            return new Plato(id, nombre, precio, descripcion, seccion);
        }

        public static Entidad ObtenerPlato(int id, string nombre, float precio, string descripcion)
        {
            return new Plato(id, nombre, precio, descripcion);
        }  

        #endregion

        #region Membresia
        /// <summary>
        /// Metodo para la fabrica del ObtenerMembresia 
        /// </summary>        
        /// <returns>la membresia</returns>
        public static Entidad ObtenerMembresia()
        {
            return new Membresia();
        }
        /// <summary>
        /// Metodo para la fabrica del ObtenerMembresia 
        /// </summary>
        /// <param name="_usuario">usuario de la membresia</param>
        /// <param name="_id">id de la membresia</param>
        /// <param name="_fAdmision">fecha de expedicion de la membresia</param>
        /// <param name="_fVencimiento">fecha de vencimiento de la membresia</param>
        /// <param name="_costo">descripcion de la membresia</param>
        /// <param name="_descAplicado">descuento de la membresia</param>
        /// <param name="_telefono">telefono de la membresia</param>
        /// <param name="_estado">estado de la membresia</param>
        /// <param name="_pagos">lista de pagos asociados a la membresia</param>
        /// <returns>la membresia</returns>
        public static Entidad ObtenerMembresia(Persona _usuario, int _id, DateTime _fAdmision, DateTime _fVencimiento, float _costo, float _descAplicado, string _estado, List<Pago> _pagos)
        {
            return new Membresia(_usuario, _id, _fAdmision, _fVencimiento, _costo, _descAplicado, _estado, _pagos);
        }

        /// <summary>
        /// Metodo para la fabrica del ObtenerMembresia para pagos
        /// </summary>
        /// <param name="_usuario">usuario de la membresia</param>
        /// <param name="_id">id de la membresia</param>        
        /// <param name="_pagos">lista de pagos asociados a la membresia</param>
        /// <returns>la membresia</returns>
        public static Entidad ObtenerMembresia(Persona usuario, Int32 id, List<Pago> pagos)
        {
            return new Membresia(usuario, id, pagos);
        }

        /// <summary>
        /// Metodo para la fabrica del ObtenerPago
        /// </summary>        
        /// <returns>el pago</returns>
        public static Entidad ObtenerPago()
        {
            return new Pago();
        }

        /// <summary>
        /// Metodo para la fabrica del ObtenerPago 
        /// </summary>
        /// <param name="_id">id del pago</param>
        /// <param name="_monto">monto del pago</param>
        /// <param name="_fecha">fecha del pago</param>
        /// <returns>el pago</returns>
        public static Entidad ObtenerPago(int _id, float _monto, DateTime _fecha)
        {
            return new Pago(_id, _monto, _fecha);
        }

        /// <summary>
        /// Metodo para la fabrica del ObtenerCosto 
        /// </summary>        
        /// <returns>el costo actual de las membresias</returns>
        public static Entidad ObtenerCosto()
        {
            return new Costo();
        }

        /// <summary>
        /// Metodo para la fabrica del ObtenerCosto 
        /// </summary>        
        /// <param name="costo">cost de la membresia</param>
        /// <returns>el costo actual de las membresias</returns>
        public static Entidad ObtenerCosto(float costo)
        {
            return new Costo(costo);
        }

        #endregion

        #region Reserva
        public static Entidad ObtenerReserva()
        {
            return new Reserva();
        }

        public static Entidad ObtenerReserva(int _id, DateTime _fecha, string _usuario, string _estado, ReservaServicio _reservaServicio)
        {
            return new Reserva(_id, _fecha, _usuario, _estado, _reservaServicio);
        }

        public static Entidad ObtenerReservaServicio()
        {
            return new ReservaServicio();
        }

        public static Entidad ObtenerReservaServicio(int _reservaServicioId, DateTime _reservaHoraInicio, DateTime _reservaHoraFin, int _cantidad, int _total, int _fkHorario, int _fkReserva)
        {
            return new ReservaServicio(_reservaServicioId, _reservaHoraInicio, _reservaHoraFin, _cantidad, _total, _fkHorario, _fkReserva);
        }

        public static Entidad ObtenerReservaPuesto(int _reservaPuesto_Precio, int _reservaPuesto_Reserva, int _reservaPuesto_PuestoFila, int _reservaPuesto_PuestoColumna, int _reservaPuesto_FK_Inventario,
            int _reservaPuesto_FK_Playa, string _reservaPuesto_Descripcion)
        {
            return new ReservaPuesto(_reservaPuesto_Precio, _reservaPuesto_Reserva, _reservaPuesto_PuestoFila, _reservaPuesto_PuestoColumna, _reservaPuesto_FK_Inventario,
                _reservaPuesto_FK_Playa, _reservaPuesto_Descripcion);
        }
        public static Entidad ObtenerReservaPuesto()
        {
            return new ReservaPuesto();
        }

        public static Entidad ObtenerReservaReserva_Puesto()
        {
            return new ReservaReserva_Puesto();
        }
        #endregion
    }
}