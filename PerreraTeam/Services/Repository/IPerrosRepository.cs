using PerreraTeam.Domain;
using PerreraTeam.Domain.Models;
using PerreraTeam.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerreraTeam.Services.Repository
{
    public interface IPerrosRepository : IGenericRepository<Perros>
    {
        PerreraContext GetContext();
        Task<IEnumerable<PerrosPorRazaViewModel>> PerrosPorRaza();
    }
}
