using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.ConfiguracionPuestosPlaya
{
    public interface IContrato_2_consultarInventario : IContratoGeneral
    {       
        DropDownList DropTipoItem { get; }
        Button BtnAceptar { get; }
        GridView GridTablaInventario { get; }
        Button BtnModificarTodo { get; }
    }
}




