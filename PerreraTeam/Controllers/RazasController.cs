using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PerreraTeam.Domain;
using PerreraTeam.Domain.Models;
using PerreraTeam.Services;

namespace PerreraTeam.Controllers
{
    public class RazasController : Controller
    {
        private readonly IGenericRepository<Razas> _repository = null;

        public RazasController()
        {
            _repository = new GenericRepository<Razas>();
        }

        public RazasController(IGenericRepository<Razas> repository)
        {
            _repository = repository;
        }


        // GET: Razas
        public async Task<ActionResult> Index()
        {
            var model = await _repository.GetAll().ConfigureAwait(false);
            return View(model);
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
            if (ModelState.IsValid)
            {
                _repository.Insert(razas);
                await _repository.Save().ConfigureAwait(false);
                return RedirectToAction("Index");
            }

            return View(razas);
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
        public async Task<ActionResult> Edit([Bind(Include = "Nombre")] Razas razas)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(razas);
                await _repository.Save().ConfigureAwait(false);
                return RedirectToAction("Index");
            }
            return View(razas);
        }

        // GET: Razas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var razas = await _repository.GetElement(id);
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
            _repository.Delete(id);
            await _repository.Save().ConfigureAwait(false);
            return RedirectToAction("Index");
        }

    }
}
