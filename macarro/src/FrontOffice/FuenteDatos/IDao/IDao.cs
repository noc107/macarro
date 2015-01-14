using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontOffice.FuenteDatos.IDao
{
    public interface IDao<Parametro, Resultado, Resultado2>
    {
        Resultado Agregar(Parametro parametro);
        Resultado Modificar(Parametro parametro);
        Resultado2 ConsultarXId(int id);
        List<Resultado2> ConsultarTodos();
    }
}
