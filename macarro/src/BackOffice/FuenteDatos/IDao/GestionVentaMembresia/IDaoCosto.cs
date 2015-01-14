using BackOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.FuenteDatos.IDao.GestionVentaMembresia
{
    public interface IDaoCosto : IDao<Entidad, Boolean, Entidad>
    {
        Entidad ConsultarCosto();
    }
}