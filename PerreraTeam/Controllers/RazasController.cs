using System;
using System.Data;
using System.Threading.Tasks;
using System.Web.Mvc;
using PerreraTeam.Domain.Models;
using PerreraTeam.Exceptions;
using PerreraTeam.Services;
using PerreraTeam.Services.Repository;

namespace PerreraTeam.Controllers
{
    public class RazasController : BaseController
    {
        private readonly IGenericRepository<Razas> _repository = null;

        //public RazasController()
        //{
        //    _repository = new GenericRepository<Razas>();
        //}

        public RazasController(IGenericRepository<Razas> repository)
        {
            _repository = repository;
        }


        // GET: Razas
        public async Task<ActionResult> Index()
        {
            try
            {
                var model = await _repository.GetAll().ConfigureAwait(false);
                return View(model);
            }
            catch (Exception ex)
            {
                throw new JaulasException("Error al obtener todas las razas", ex);
            }
        }

        // GET: Razas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var razas = await _repository.GetElement(id).ConfigureAwait(false);
            if (razas == null)
            {
                return HttpNotFound();
            }
            return View(razas);
        }

        // GET: Razas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Razas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Nombre")] Razas razas)
        {
            if (!ModelState.IsValid) return View(razas);
            try
            {
                await _repository.Insert(razas).ConfigureAwait(false);
            }
            catch (DataException dex)
            {
                throw new RazasException("Error al crear una raza", dex);
            }
            return RedirectToAction("Index");
        }

        // GET: Razas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var razas = await _repository.GetElement(id).ConfigureAwait(false);
            if (razas == null)
            {
                return HttpNotFound();
            }
            return View(razas);
        }

        // POST: Razas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id, Nombre")] Razas razas)
        {
            if (!ModelState.IsValid) return View(razas);
            try
            {
                await _repository.Update(razas).ConfigureAwait(false);
            }
            catch (DataException dex)
            {
                throw new RazasException("Error al editar una raza", dex);
            }

            return RedirectToAction("Index");
        }

        // GET: Razas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var razas = await _repository.GetElement(id).ConfigureAwait(false);
            if (razas == null)
            {
                return HttpNotFound();
            }
            return View(razas);
        }

        // POST: Razas/Delete/5
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
                throw new RazasException("Error al eliminar una raza", ex);
            }
            return RedirectToAction("Index");
        }

    }
}
