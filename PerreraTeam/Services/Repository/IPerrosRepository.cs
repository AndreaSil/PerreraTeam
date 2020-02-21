using PerreraTeam.Domain;
using PerreraTeam.Domain.Models;

namespace PerreraTeam.Services.Repository
{
    public interface IPerrosRepository : IGenericRepository<Perros>
    {
        PerreraContext GetContext();
    }
}
