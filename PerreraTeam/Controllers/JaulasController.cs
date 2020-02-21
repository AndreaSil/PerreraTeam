using System;
using System.Data;
using System.Threading.Tasks;
using System.Web.Mvc;
using PerreraTeam.Domain.Models;
using PerreraTeam.Exceptions;
using PerreraTeam.Services.Repository;

namespace PerreraTeam.Controllers
{
    public class JaulasController : BaseController
    {
        private IGenericRepository<Jaulas> _repository = null;

        public JaulasController()
        {
            _repository = new GenericRepository<Jaulas>();
        }

        public JaulasController(IGenericRepository<Jaulas> repository)
        {
            _repository = repository;
        }


        // GET: Jaulas
        public async Task<ActionResult> Index()
        {
            try
            {
                var model = await _repository.GetAll().ConfigureAwait(false);
                return View(model);
            }
            catch (Exception ex)
            {
                throw new JaulasException("Error al obtener todas las jaulas", ex);
            }
        }

        // GET: Jaulas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var jaulas = await _repository.GetElement(id).ConfigureAwait(false);
            if (jaulas == null)
            {
                return HttpNotFound();
            }
            return View(jaulas);
        }

        // GET: Jaulas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jaulas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NombreJaula")] Jaulas jaulas)
        {
            if (!ModelState.IsValid) return View(jaulas);
            try
            {
                await _repository.Insert(jaulas).ConfigureAwait(false);
            }
            catch (DataException dex)
            {
                throw new JaulasException("Error al guardar una nueva jaula.", dex);
            }
            return RedirectToAction("Index");
        }

        // GET: Jaulas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var jaulas = await _repository.GetElement(id).ConfigureAwait(false);
            if (jaulas == null)
            {
                return HttpNotFound();
            }
            return View(jaulas);
        }

        // POST: Jaulas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NombreJaula")] Jaulas jaulas)
        {
            if (!ModelState.IsValid) return View(jaulas);
            try
            {
                await _repository.Update(jaulas).ConfigureAwait(false);
            }
            catch (DataException dex)
            {
                throw new JaulasException("Error al editar una jaula.", dex);
            }
            return RedirectToAction("Index");
        }

        // GET: Jaulas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var jaulas = await _repository.GetElement(id).ConfigureAwait(false);
            if (jaulas == null)
            {
                return HttpNotFound();
            }
            return View(jaulas);
        }

        // POST: Jaulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _repository.Delete(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new JaulasException("Error al eliminar una jaula", ex);
            }
            return RedirectToAction("Index");
        }
    }
}
