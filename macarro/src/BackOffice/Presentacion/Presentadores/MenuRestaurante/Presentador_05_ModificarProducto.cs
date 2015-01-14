using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Presentacion.Contratos.MenuRestaurante;

namespace BackOffice.Presentacion.Presentadores.MenuRestaurante
{
    public class Presentador_05_ModificarProducto : PresentadorGeneral
    {
        private IContrato_05_ModificarPlato _vista;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="vistaGestionMenu">Interfaz</param>
        public Presentador_05_ModificarProducto(IContrato_05_ModificarPlato vistaGestionMenu)
            : base(vistaGestionMenu)
        {
            _vista = vistaGestionMenu;
        }


        public void EventoAceptar_Click(int id)
        {
            Entidad plato = FabricaEntidad.ObtenerPlato();
            ((Plato)plato).Id = id;
            ((Plato)plato).Nombre = _vista.nombre.Text;
            ((Plato)plato).Precio = float.Parse(_vista.precio.Text);
            ((Plato)plato).Descripcion = _vista.descripcion.Text;

            Comando<Entidad, bool> ComandoModificarPlato;
            ComandoModificarPlato = FabricaComando.ObtenerComandoModificarPlato();
            ComandoModificarPlato.Ejecutar(plato);
        }

        /// <summary>
        /// Metodo para mostrar la informacion de la seccion
        /// </summary>
        public void EventoConsultar(int _pla)
        {

            Comando<int, Entidad> ComandoConsultarPlato;
            ComandoConsultarPlato = FabricaComando.ObtenerComandoConsultarPlato();
            Entidad PlatoActual = ComandoConsultarPlato.Ejecutar(_pla);

            _vista.nombre.Text = ((Plato)PlatoActual).Nombre;
            _vista.descripcion.Text = ((Plato)PlatoActual).Descripcion;
            _vista.precio.Text = ((Plato)PlatoActual).Precio.ToString();
        }
    }
}