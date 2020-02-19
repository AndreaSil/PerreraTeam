using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PerreraTeam.Domain.Models;
using PerreraTeam.Services;

namespace PerreraTeam.Controllers
{
    public class BaseController<T> : Controller where T : class
    {
        private IGenericRepository<T> _repository = null;

        public BaseController()
        {
            _repository = new GenericRepository<T>();
        }

        public BaseController(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        //public async Task<ActionResult> Index()
        //{
        //    return View(await _repository.GetAll().ConfigureAwait(false));
        //}

        //// GET: Razas/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Razas razas = await db.Razas.FindAsync(id);
        //    if (razas == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(razas);
        //}

        //// GET: Razas/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Razas/Create
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,Nombre")] Razas razas)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Razas.Add(razas);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(razas);
        //}

        //// GET: Razas/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Razas razas = await db.Razas.FindAsync(id);
        //    if (razas == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(razas);
        //}

        //// POST: Razas/Edit/5
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre")] Razas razas)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(razas).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(razas);
        //}

        //// GET: Razas/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Razas razas = await db.Razas.FindAsync(id);
        //    if (razas == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(razas);
        //}

        //// POST: Razas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Razas razas = await db.Razas.FindAsync(id);
        //    db.Razas.Remove(razas);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}