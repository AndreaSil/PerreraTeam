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
    public class PerrosController : Controller
    {
        private PerreraContext db = new PerreraContext();

        // GET: Perros
        public async Task<ActionResult> Index()
        {
            var perros = db.Perros.Include(p => p.Jaulas).Include(p => p.Razas);
            return View(await perros.ToListAsync());
        }

        // GET: Perros/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perros perros = await db.Perros.FindAsync(id);
            if (perros == null)
            {
                return HttpNotFound();
            }
            return View(perros);
        }

        // GET: Perros/Create
        public ActionResult Create()
        {
            ViewBag.IdJaula = new SelectList(db.Jaulas, "Id", "NombreJaula");
            ViewBag.CodRazaId = new SelectList(db.Razas, "Id", "Nombre");
            return View();
        }

        // POST: Perros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre,Chip,FechaNacimiento,CodRazaId,IdJaula")] Perros perros)
        {
            if (ModelState.IsValid)
            {
                db.Perros.Add(perros);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdJaula = new SelectList(db.Jaulas, "Id", "NombreJaula", perros.IdJaula);
            ViewBag.CodRazaId = new SelectList(db.Razas, "Id", "Nombre", perros.CodRazaId);
            return View(perros);
        }

        // GET: Perros/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perros perros = await db.Perros.FindAsync(id);
            if (perros == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdJaula = new SelectList(db.Jaulas, "Id", "NombreJaula", perros.IdJaula);
            ViewBag.CodRazaId = new SelectList(db.Razas, "Id", "Nombre", perros.CodRazaId);
            return View(perros);
        }

        // POST: Perros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,Chip,FechaNacimiento,CodRazaId,IdJaula")] Perros perros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perros).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdJaula = new SelectList(db.Jaulas, "Id", "NombreJaula", perros.IdJaula);
            ViewBag.CodRazaId = new SelectList(db.Razas, "Id", "Nombre", perros.CodRazaId);
            return View(perros);
        }

        // GET: Perros/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perros perros = await db.Perros.FindAsync(id);
            if (perros == null)
            {
                return HttpNotFound();
            }
            return View(perros);
        }

        // POST: Perros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Perros perros = await db.Perros.FindAsync(id);
            db.Perros.Remove(perros);
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
