using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using PerreraTeam.Domain;
using PerreraTeam.Domain.Models;
using PerreraTeam.Services;

namespace PerreraTeam.Controllers
{
    public class EmpleadosController : Controller
    {
        private IGenericRepository<Empleados> _repository = null;

        public EmpleadosController()
        {
            _repository = new GenericRepository<Empleados>();
        }

        public EmpleadosController(IGenericRepository<Empleados> repository)
        {
            _repository = repository;
        }


        // GET: Empleados
        public async Task<ActionResult> Index()
        {
            var model = await _repository.GetAll().ConfigureAwait(false);
            return View(model);
        }

        // GET: Empleados/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var empleados = await _repository.GetElement(id).ConfigureAwait(false);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NombreCompleto,Telefono,Correo,DNI")] Empleados empleados)
        {
            if (!ModelState.IsValid) return View(empleados);
            _repository.Insert(empleados);
            await _repository.Save().ConfigureAwait(false);
            return RedirectToAction("Index");

        }

        // GET: Empleados/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var empleados = await _repository.GetElement(id).ConfigureAwait(false);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NombreCompleto,Telefono,Correo,DNI")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(empleados);
                return RedirectToAction("Index");
            }
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var empleados = await _repository.GetElement(id).ConfigureAwait(false);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _repository.Delete(id).ConfigureAwait(false);
            return RedirectToAction("Index");
        }
    }
}
