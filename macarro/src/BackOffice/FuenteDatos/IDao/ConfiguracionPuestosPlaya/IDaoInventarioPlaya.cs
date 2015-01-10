using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackOffice.Dominio;

namespace BackOffice.FuenteDatos.IDao.ConfiguracionPuestosPlaya
{
    public interface IDaoInventarioPlaya : IDao<Entidad,bool,Entidad>
    {
        List<Entidad> ConsultarInventarioTipo(string parametro);
        bool EliminarItemSeleccionado(int parametro);
        List<Entidad> ConsultarEstadosInventario();
    }
}
