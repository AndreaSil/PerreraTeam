using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PerreraTeam.Domain;
using PerreraTeam.Domain.Models;
using PerreraTeam.ViewModels;

namespace PerreraTeam.Services.Repository
{
    public class PerrosRepository : GenericRepository<Perros>, IPerrosRepository
    {
        private readonly PerreraContext _dbContext;
        public override async Task<IEnumerable<Perros>> GetAll()
        {
            var perros = await Table.Include(a => a.Raza)
                .Include(a => a.Jaula).ToListAsync()
                .ConfigureAwait(false);
            return perros.OrderBy(x => x.Nombre);
        }

        public PerreraContext GetContext()
        {
            return DbContext;
        }

        public async Task<IEnumerable<PerrosPorRazaViewModel>> PerrosPorRaza()
        {
            //var consulta = from p in _dbContext.Perros
            //           join r in _dbContext.Razas on p.RazaId equals r.Id
            //          group p by new { r.Id, r.Nombre } into raza
            //          select raza;


            //var consulta = from p in _dbContext.Perros
            //               group p by new { p.RazaId, p.Raza.Nombre }
            //               into raza​
            //               select raza;

            var consulta = (from p in _dbContext.Perros
                           join r in _dbContext.Razas on p.RazaId equals r.Id
                           //group p by new { r.Id, r.Nombre } into raza
                           select new PerrosPorRazaViewModel
                           {
                               ID=p.Id,
                               NombreRaza = r.Nombre,
                               NombrePerro= p.Nombre

                     }).ToListAsync();



            //List<PerrosPorRazaViewModel> lista = new List<PerrosPorRazaViewModel>();
            //PerrosPorRazaViewModel perros = new PerrosPorRazaViewModel();


            //foreach (var item in consulta)
            //{
            //    perros.NombreRaza = item.Key.Nombre;
            //    foreach (var objetoAgrupado in item)
            //    {
            //        perros.NombrePerro = objetoAgrupado.Nombre;
            //        perros.ID = objetoAgrupado.Id;
            //        lista.Add(perros);
            //    }
            //}

            return await consulta;


        }
    }
}