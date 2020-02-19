using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerreraTeam.Domain;

namespace PerreraTeam.Services
{
    interface IPerrosRepository
    {
        PerreraContext GetContext();
    }
}
