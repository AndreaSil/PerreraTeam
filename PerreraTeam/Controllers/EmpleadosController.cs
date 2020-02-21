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
    public class EmpleadosController : BaseController
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
            try
            {
                var model = await _repository.GetAll().ConfigureAwait(false);
                return View(model);
            }
            catch (Exception ex)
            {
                throw new EmpleadosException("Error al obtener todos los empleados", ex);
            }
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
            try
            {
                await _repository.Insert(empleados).ConfigureAwait(false);
            }
            catch (DataException dex)
            {
                throw new EmpleadosException("Error al guardar un nuevo cliente.", dex);
            }
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
            if (!ModelState.IsValid) return View(empleados);
            try
            {
                await _repository.Update(empleados).ConfigureAwait(false);
            }
            catch (DataException dex)
            {
                throw new EmpleadosException("Error al editar un nuevo cliente.", dex);
            }
            return RedirectToAction("Index");
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
            try
            {
                await _repository.Delete(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new EmpleadosException("Error al eliminar un empleado", ex);
            }
            return RedirectToAction("Index");
        }
    }
}
