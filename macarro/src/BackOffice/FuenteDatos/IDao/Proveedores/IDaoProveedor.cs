using BackOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.FuenteDatos.IDao.Proveedores
{
    public interface IDaoProveedor : IDao<Entidad,Boolean, Entidad> 
    {
        bool eliminarProveedor(int id);
        List<Entidad> ConsultarTodosBusq(string busqueda);
        List<string> EstadosDePais(string parametro);
        List<string> CiudadesDeEstado(string parametro);
        List<string> ConsultarTodosPaises(string parametro);
        List<string> ConsultarTodosEstados(string parametro);
        List<string> ConsultarTodasCiudades(string parametro);
    }
}
