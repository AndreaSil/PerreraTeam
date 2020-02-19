using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using PerreraTeam.Domain;

namespace PerreraTeam.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private PerreraContext _dbContext = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            _dbContext = new PerreraContext();
            table = _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var lista = await Task.Run(() => table.ToList()
            );
            return lista;

        }
        public async Task<T> GetById(object id)
        {
            var obj = await Task.Run(() => table.Find(id));
            return obj;
        }
        public async void Insert(T obj)
        {
            await Task.Run(() => table.Add(obj));
        }

        public async void Update(T obj)
        {
            await Task.Run(() => table.Attach(obj));
            _dbContext.Entry(obj).State = EntityState.Modified;
        }

        public async void Delete(object id)
        {
            var obj = await Task.Run(() => table.Find(id));
            await Task.Run(() => table.Remove(obj));

        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}