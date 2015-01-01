using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.FuenteDatos.IDao
{
    public interface IDao<Parametro, Resultado>
    {
        Resultado Agregar(Parametro parametro);
        Resultado Modificar(Parametro parametro);
        Resultado ConsultarXId(int id);
        List<Resultado> ConsultarTodos();
    }
}
