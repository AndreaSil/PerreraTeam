using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using PerreraTeam.Domain.Models;
using PerreraTeam.Services;

namespace PerreraTeam.Controllers
{
    public class ClientesController : Controller
    {
        private IGenericRepository<Clientes> _repository = null;

        public ClientesController()
        {
            _repository = new GenericRepository<Clientes>();
        }

        public ClientesController(IGenericRepository<Clientes> repository)
        {
            _repository = repository;
        }


        // GET: Clientes
        public async Task<ActionResult> Index()
        {
            var model = await _repository.GetAll().ConfigureAwait(false);
            return View(model);
        }

        // GET: Clientes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var clientes = await _repository.GetElement(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NombreCompleto,Telefono,Correo,DNI")] Clientes clientes)
        {
            if (!ModelState.IsValid) return View(clientes);
            _repository.Insert(clientes);
            return RedirectToAction("Index");

        }

        // GET: Clientes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var clientes = await _repository.GetElement(id).ConfigureAwait(false);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NombreCompleto,Telefono,Correo,DNI")] Clientes clientes)
        {
            if (!ModelState.IsValid) return View(clientes);
            _repository.Update(clientes);
            return RedirectToAction("Index");
        }

        // GET: Clientes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var clientes = await _repository.GetElement(id).ConfigureAwait(false);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _repository.Delete(id).ConfigureAwait(false);
            return RedirectToAction("Index");
        }
    }
}
