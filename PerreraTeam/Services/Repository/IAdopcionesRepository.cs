using PerreraTeam.Domain;
using PerreraTeam.Domain.Models;

namespace PerreraTeam.Services.Repository
{
    public interface IAdopcionesRepository : IGenericRepository<Adopciones>
    {
        PerreraContext GetContext();
    }
}
