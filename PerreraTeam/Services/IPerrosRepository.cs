using PerreraTeam.Domain;
using PerreraTeam.Domain.Models;

namespace PerreraTeam.Services
{
    public interface IPerrosRepository : IGenericRepository<Perros>
    {
        PerreraContext GetContext();
    }
}
