using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PerreraTeam.Domain;
using PerreraTeam.Domain.Models;

namespace PerreraTeam.Services.Repository
{
    public class PerrosRepository : GenericRepository<Perros>, IPerrosRepository
    {
        public override async Task<IEnumerable<Perros>> GetAll()
        {
            var perros = await Table.Include(a => a.Raza)
                .Include(a => a.Jaula).ToListAsync()
                .ConfigureAwait(false);
            return perros.OrderBy(x => x.Nombre);
        }

        public PerreraContext GetContext()
        {
            return DbContext;
        }
    }
}