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

namespace PerreraTeam.Controllers
{
    public class JaulasController : Controller
    {
        private PerreraContext db = new PerreraContext();

        // GET: Jaulas
        public async Task<ActionResult> Index()
        {
            return View(await db.Jaulas.ToListAsync());
        }

        // GET: Jaulas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jaulas jaulas = await db.Jaulas.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "Id,NombreJaula")] Jaulas jaulas)
        {
            if (ModelState.IsValid)
            {
                db.Jaulas.Add(jaulas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(jaulas);
        }

        // GET: Jaulas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jaulas jaulas = await db.Jaulas.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,NombreJaula")] Jaulas jaulas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jaulas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jaulas);
        }

        // GET: Jaulas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jaulas jaulas = await db.Jaulas.FindAsync(id);
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
            Jaulas jaulas = await db.Jaulas.FindAsync(id);
            db.Jaulas.Remove(jaulas);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
