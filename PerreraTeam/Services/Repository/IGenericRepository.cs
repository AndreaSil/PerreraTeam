using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerreraTeam.Services.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetElement(params object[] keys);
        Task Insert(T obj);
        Task Update(T obj);
        Task Delete(object id);
        Task Delete(T obj);
        Task Save();
    }
}
