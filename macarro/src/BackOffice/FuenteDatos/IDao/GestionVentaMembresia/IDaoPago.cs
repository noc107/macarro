using BackOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.FuenteDatos.IDao.GestionVentaMembresia
{
    public interface IDaoPago : IDao<Entidad, Boolean, Entidad>
    {
        List<Entidad> ConsultarPagos(string _cadenaGenerica);
    }
}