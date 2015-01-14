using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackOffice.Dominio;

namespace BackOffice.FuenteDatos.IDao.ConfiguracionPuestosPlaya
{
    public interface IDaoPuestoPlaya: IDao<Entidad, bool, Entidad>
    {
        
        List<Entidad> ConsultarPuesto(string filar, string columnaR);
        bool ActualizacionPuesto(string fila, string columna, string descripcion, string monto, string estado);
      //  bool IngresarNuevosPuestos(string tipo, string fila, string columna, string descripcion, string precio);
    }
}
