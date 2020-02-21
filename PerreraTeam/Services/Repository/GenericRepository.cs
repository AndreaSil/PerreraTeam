using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PerreraTeam.Domain;

namespace PerreraTeam.Services.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public PerreraContext DbContext = null;
        public DbSet<T> Table = null;

        public GenericRepository()
        {
            DbContext = new PerreraContext();
            Table = DbContext.Set<T>();
        }

        public GenericRepository(PerreraContext context)
        {
            DbContext = context;
            Table = DbContext.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await Table.ToListAsync().ConfigureAwait(false);
        }

        public async Task<T> GetElement(params object[] keys)
        {
            if (keys.All(id => id == null))
            {
                //log with HttpStatusCode.BadRequest
                //ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return null;
            }
            return await Table.FindAsync(keys);
        }

        public async Task Insert(T obj)
        {
            Table.Add(obj);
            await Save().ConfigureAwait(false);
        }

        public async Task Update(T obj)
        {
            Table.Attach(obj);
            DbContext.Entry(obj).State = EntityState.Modified;
            await Save().ConfigureAwait(false);
        }

        public async Task Delete(object id)
        {
            var obj = await Table.FindAsync(id).ConfigureAwait(false);
            if (obj != null)
                await Task.Run(() => Table.Remove(obj));
            await Save().ConfigureAwait(false);
        }

        public async Task Delete(T item)
        {
            Table.Remove(item);
            await Save().ConfigureAwait(false);
        }

        public async Task Save()
        {
            await DbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}