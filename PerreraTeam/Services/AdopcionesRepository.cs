using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using PerreraTeam.Domain;
using PerreraTeam.Domain.Models;

namespace PerreraTeam.Services
{
    public class AdopcionesRepository : GenericRepository<Adopciones>, IAdopcionesRepository
    {
        public override async Task<IEnumerable<Adopciones>> GetAll()
        {
            var adopciones = await Table.Include(a => a.Clientes)
                .Include(a => a.Empleados)
                .Include(a => a.Perros).ToListAsync()
                .ConfigureAwait(false);
            return adopciones.OrderByDescending(x => x.FechaEntrega);
        }

        public PerreraContext GetContext()
        {
            return DbContext;
        }
    }
}