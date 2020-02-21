using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using PerreraTeam.Domain.Models;
using PerreraTeam.Services;

namespace PerreraTeam.Controllers
{
    public class PerrosController : Controller
    {
        private readonly IPerrosRepository _repository = null;

        public PerrosController()
        {
            _repository = new PerrosRepository();
        }

        public PerrosController(IPerrosRepository repository)
        {
            _repository = repository;
        }

        // GET: Perros
        public async Task<ActionResult> Index()
        {
            return View(await _repository.GetAll().ConfigureAwait(false));
        }

        // GET: Perros/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var perros = await _repository.GetElement(id).ConfigureAwait(false);
            if (perros == null)
            {
                return HttpNotFound();
            }
            return View(perros);
        }

        // GET: Perros/Create
        public ActionResult Create()
        {
            ViewBag.IdJaula = new SelectList(_repository.GetContext().Jaulas, "Id", "NombreJaula");
            ViewBag.CodRazaId = new SelectList(_repository.GetContext().Razas, "Id", "Nombre");
            return View();
        }

        // POST: Perros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Nombre,Chip,FechaNacimiento,CodRazaId,IdJaula")] Perros perros)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(perros);
                return RedirectToAction("Index");
            }

            ViewBag.IdJaula = new SelectList(_repository.GetContext().Jaulas, "Id", "NombreJaula", perros.IdJaula);
            ViewBag.CodRazaId = new SelectList(_repository.GetContext().Razas, "Id", "Nombre", perros.CodRazaId);
            return View(perros);
        }

        // GET: Perros/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var perros = await _repository.GetElement(id).ConfigureAwait(false);
            if (perros == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdJaula = new SelectList(_repository.GetContext().Jaulas, "Id", "NombreJaula", perros.IdJaula);
            ViewBag.CodRazaId = new SelectList(_repository.GetContext().Razas, "Id", "Nombre", perros.CodRazaId);
            return View(perros);
        }

        // POST: Perros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Nombre,Chip,FechaNacimiento,CodRazaId,IdJaula")] Perros perros)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(perros);
                return RedirectToAction("Index");
            }
            ViewBag.IdJaula = new SelectList(_repository.GetContext().Jaulas, "Id", "NombreJaula", perros.IdJaula);
            ViewBag.CodRazaId = new SelectList(_repository.GetContext().Razas, "Id", "Nombre", perros.CodRazaId);
            return View(perros);
        }

        // GET: Perros/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var perros = await _repository.GetElement(id).ConfigureAwait(false);
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
            await _repository.Delete(id).ConfigureAwait(false);
            return RedirectToAction("Index");
        }

    }
}

