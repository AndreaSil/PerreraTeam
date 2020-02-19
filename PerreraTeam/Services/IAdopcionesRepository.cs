using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerreraTeam.Domain;
using PerreraTeam.Domain.Models;

namespace PerreraTeam.Services
{
    public interface IAdopcionesRepository : IGenericRepository<Adopciones>
    {
        PerreraContext GetContext();
    }
}
