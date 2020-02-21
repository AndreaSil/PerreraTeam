using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PerreraTeam.Domain;
using PerreraTeam.Domain.Models;

namespace PerreraTeam.Services.Repository
{
    public class AdopcionesRepository : GenericRepository<Adopciones>, IAdopcionesRepository
    {
        public override async Task<IEnumerable<Adopciones>> GetAll()
        {
            var adopciones = await Table.Include(a => a.Cliente)
                .Include(a => a.Empleado)
                .Include(a => a.Perro).ToListAsync()
                .ConfigureAwait(false);
            return adopciones.OrderByDescending(x => x.FechaEntrega);
        }

        public PerreraContext GetContext()
        {
            return DbContext;
        }
    }
}