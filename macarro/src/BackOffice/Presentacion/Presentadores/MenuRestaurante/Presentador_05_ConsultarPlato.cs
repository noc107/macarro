using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.MenuRestaurante;
using BackOffice.LogicaNegocio;
using BackOffice.Dominio;
using BackOffice.Dominio.Fabrica;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Dominio.Entidades;


namespace BackOffice.Presentacion.Presentadores.MenuRestaurante
{
    public class Presentador_05_ConsultarPlato : PresentadorGeneral
    {
        private IContrato_05_ConsultarPlato _vista;
        private Plato _p;

        public Presentador_05_ConsultarPlato(IContrato_05_ConsultarPlato VistaDefault)
            : base(VistaDefault)
        {
            _vista = VistaDefault;
        }

        public void EventoConsultar()
        {
            try
            {
                Dominio.Entidad _plato;

                Comando<int, Entidad> ComandoConsultarPlato;
                _plato = FabricaEntidad.ObtenerPlato();
                ComandoConsultarPlato = FabricaComando.ObtenerComandoConsultarPlato();

                _plato = ComandoConsultarPlato.Ejecutar(1);

                if (_plato != null)
                {
                    _p = (Plato)_plato;
                    LlenarDatos(_p);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void LlenarDatos(Plato p)
        {
            if (p != null)
            {
                _vista.nombre.Text = p.Nombre;
                _vista.precio.Text = p.Precio.ToString();
                _vista.descripcion.Text = p.Descripcion;
            }
        }

    }
}