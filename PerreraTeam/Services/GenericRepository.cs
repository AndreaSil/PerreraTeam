using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using PerreraTeam.Domain;

namespace PerreraTeam.Services
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
            if (keys.Any(id => id == null))
            {
                //log with HttpStatusCode.BadRequest
                //ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return null;
            }
            return await Table.FindAsync(keys);
        }

        public void Insert(T obj)
        {
            Table.Add(obj);
        }

        public void Update(T obj)
        {
            Table.Attach(obj);
            DbContext.Entry(obj).State = EntityState.Modified;
        }

        public async void Delete(object id)
        {
            var obj = await Task.Run(() => Table.Find(id)).ConfigureAwait(false);
            await Task.Run(() => Table.Remove(obj));
        }

        public void Delete(T item)
        {
            Table.Remove(item);
        }

        public async Task Save()
        {
            await DbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}