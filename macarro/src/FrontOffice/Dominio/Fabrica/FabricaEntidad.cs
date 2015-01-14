using FrontOffice.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace FrontOffice.Dominio.Fabrica
{
    public class FabricaEntidad
    {
        #region Ejemplo

        public static Entidad ObtenerPersona(string nombre, string apellido)
        {
            return new Persona(nombre, apellido);
        }

        #endregion

        #region Reserva

        public static Entidad ObtenerReserva()
        {
            return new Reserva();
        }

        public static Entidad ObtenerReserva(int _id, DateTime _fecha, string _usuario, string _estado, ReservaServicio _reservaServicio)
        {
            return new Reserva(_id, _fecha, _usuario, _estado,_reservaServicio);
        }

        public static Entidad ObtenerReservaServicio()
        {
            return new ReservaServicio();
        }

        public static Entidad ObtenerReservaServicio(int _reservaServicioId, DateTime _reservaHoraInicio, DateTime _reservaHoraFin, int _cantidad, int _total, int _fkHorario, int _fkReserva)
        {
            return new ReservaServicio(_reservaServicioId,_reservaHoraInicio, _reservaHoraFin,_cantidad, _total, _fkHorario, _fkReserva);
        }

        public static Entidad ObtenerReservaPuesto(int _reservaPuesto_Precio,int _reservaPuesto_Reserva,int _reservaPuesto_PuestoFila,int _reservaPuesto_PuestoColumna,int _reservaPuesto_FK_Inventario,
            int _reservaPuesto_FK_Playa,string _reservaPuesto_Descripcion)
        {
            return new ReservaPuesto(_reservaPuesto_Precio, _reservaPuesto_Reserva, _reservaPuesto_PuestoFila, _reservaPuesto_PuestoColumna, _reservaPuesto_FK_Inventario,
                _reservaPuesto_FK_Playa, _reservaPuesto_Descripcion);
        }
        public static Entidad ObtenerReservaPuesto()
        {
            return new ReservaPuesto();
        }

        public static Entidad ObtenerReservaPlaya()
        {
            return new ReservaPlaya();
        }
        public static Entidad ObtenerReservaPlaya(int _reservaPlaya_Id,int _reservaPlaya_Fila, int _reservaPlaya_Columna)
        {
            return new ReservaPlaya(_reservaPlaya_Id, _reservaPlaya_Fila, _reservaPlaya_Columna);
        }

        public static Entidad ObtenerReservaReserva_Puesto()
        {
            return new ReservaReserva_Puesto();
        }
        
        #endregion

        #region Membresia
        public static Membresia ObtenerMembresia(Persona _usuario, int _id, DateTime _fAdmision, DateTime _fVencimiento, string _foto, float _costo, float _descAplicado, string _telefono, bool _estado)
        {
            return new Membresia(_usuario, _id, _fAdmision, _fVencimiento, _foto, _costo, _descAplicado, _telefono, _estado);
        }

        public static Document ObtenerDocumentoMembresia()
        {
            return new Document();
        }

        public static PdfPTable ObtenerTablaPdf(int cantColumnas)
        {
            return new PdfPTable(cantColumnas);
        }
        public static TablaPdf ObtenerTablaPdf(int CantidadColumnas, int AlineadoHorizontal, int EspaciadoAnterior, int EspaciadoPosterior, int GruesoBorde, List<int> GruesoCeldas)
        {
            return new TablaPdf(CantidadColumnas, AlineadoHorizontal, EspaciadoAnterior, EspaciadoPosterior, GruesoBorde, GruesoCeldas);
        }

        public static List<int> ObtenerAnchos()
        {
            return new List<int>();
        }

        public static Paragraph ObtenerParrafo(string Texto, Font Fuente)
        {
            return new Paragraph(Texto, Fuente);
        }
        public static ParrafoPdf ObtenerParrafo(string Texto, int indentacion, int EspaciadoAntes, int EspaciadoDespues, Font fuente)
        {
            return new ParrafoPdf(Texto, indentacion, EspaciadoAntes, EspaciadoDespues, fuente);
        }

        public static ImagenPdf ObtenerImagenPdf(string fileName, int ancho, int alto, int x, int y)
        {
            return new ImagenPdf(fileName, ancho, alto, x, y);
        }

        public static List<Object> ObtenerListaMembresia()
        {
            return new List<Object>();
        }
        public static List<Phrase> ObtenerListaCeldas()
        {
            return new List<Phrase>();
        }
        public static Phrase ObtenerFrase(string Texto, Font font)
        {
            return new Phrase(Texto, font);
        }
        public static List<string> ObtenerListaParametrosPdfMembresia()
        {
            return new List<string>();
        }
        public static Pago ObtenerPagoMembresia(Tarjeta tarjeta, DateTime fechaPago, float monto, int id)
        {
            return new Pago(tarjeta, fechaPago, monto, id);
        }
        public static Tarjeta ObtenerTarjetaMembresia(Int32 numero)
        {
            return new Tarjeta(numero);
        }
        public static Tarjeta ObtenerTarjetaMembresia(Int32 numero, string nombre)
        {
            return new Tarjeta(numero, nombre);
        }
        public static Tarjeta ObtenerTarjetaMembresia(Int32 numero, string nombre,string FechaVencimiento, int id)
        {
            return new Tarjeta(numero, nombre,FechaVencimiento, id);
        }
        public static List<Entidad> ObtenerListaEntidad()
        {
            return new List<Entidad>();
        }
        public static List<Pago> ObtenerListaPago()
        {
            return new List<Pago>();
        }
        public static List<Tarjeta> ObtenerListaTarjeta()
        {
            return new List<Tarjeta>();
        }
        public static List<Object> ObtenerListaObjeto()
        {
            return new List<Object>();
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

        #region ConfiguracionEstacionamiento

        public static Entidad ObtenerEstacionamiento()
        {
            return new Estacionamiento();

        }

        public static Entidad ObtenerEstacionamiento(int id, string nombre, int capacidad, float tarifa, float ticketPerdido, int estado, int disponible, string nombreEstado)
        {
            return new Estacionamiento(id, nombre, capacidad, tarifa, ticketPerdido, estado, disponible, nombreEstado);

        }
        public static Entidad ObtenerTicket()
        {
            return new Ticket();

        }

        public static Entidad ObtenerTicket(int id, DateTime entrada, DateTime salida, string placa, int fkEstacionamiento, string estado)
        {
            return new Ticket(id, entrada, salida, placa, fkEstacionamiento, estado);
        }

        public static Entidad ObtenerTicket(int id, DateTime entrada, string placa, int fkEstacionamiento, string estado)
        {
            return new Ticket(id, entrada, placa, fkEstacionamiento, estado);
        }
        public static Entidad ObtenerTicket(string placa)
        {
            return new Ticket(placa);
        }

        public static Entidad ObtenerTicket(string placa, int fkEstado)
        {
            return new Ticket(placa, fkEstado);
        }


        #endregion
    }
}