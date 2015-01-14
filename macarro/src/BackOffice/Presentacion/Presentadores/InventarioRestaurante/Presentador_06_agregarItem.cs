using BackOffice.Dominio;
using BackOffice.Dominio.Entidades;
using BackOffice.Dominio.Fabrica;
using BackOffice.LogicaNegocio;
using BackOffice.LogicaNegocio.Fabrica;
using BackOffice.Presentacion.Contratos.InventarioRestaurante;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace BackOffice.Presentacion.Presentadores.InventarioRestaurante
{
    public class Presentador_06_agregarItem : PresentadorGeneral
    {
        private IContrato_06_agregarItem _vista;

        public Presentador_06_agregarItem(IContrato_06_agregarItem _vista)
            : base(_vista)
        {
            this._vista = _vista;
        }

        public bool EventoAceptar(int _index)
        {
            _vista.LabelMensajeError.Text = _index.ToString();
            _vista.LabelMensajeError.Visible = true;
            bool _exito;
            try
            {
                Entidad _item = FabricaEntidad.ObtenerItem();
                ((Item)_item).Nombre = _vista.Nombre.Text;
                ((Item)_item).Cantidad = Convert.ToInt32(_vista.Cantidad.Text);
                ((Item)_item).CantidadMinima = Convert.ToInt32(_vista.CantidadMinima.Text);
                ((Item)_item).Descripcion = _vista.Descripcion.Text;
                ((Item)_item).PrecioVenta = float.Parse(_vista.PrecioVenta.Text);
                ((Item)_item).PrecioCompra = float.Parse(_vista.PrecioCompra.Text);
                ((Item)_item).Proveedor.RazonSocial = _vista.Proveedor.Items[_index].Text;

                Comando<Entidad, bool> comandoAgregarItem;
                comandoAgregarItem = FabricaComando.ObtenerComandoAgregarItem();

                _exito = comandoAgregarItem.Ejecutar(_item);

            }
            catch (Exception ex)
            {
                _exito = false;
                Console.WriteLine(ex.ToString());
            }

            return _exito;
        }

        public void llenarListaRazonSocial()
        {
            try
            {
                DataTable _prov;
                Comando<int, DataTable> comandoConsultarRazonSocial;
                comandoConsultarRazonSocial = FabricaComando.ObtenerListaRazonSocial();

                _prov = comandoConsultarRazonSocial.Ejecutar(0);

                if (_prov != null)
                {
                    _vista.Proveedor.DataSource = _prov;
                    _vista.Proveedor.DataTextField = "PRO_razonSocial";
                    _vista.Proveedor.DataValueField = "PRO_id";
                    _vista.Proveedor.DataBind();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}