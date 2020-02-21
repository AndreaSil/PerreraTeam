using System;
using System.Data;
using System.Threading.Tasks;
using System.Web.Mvc;
using PerreraTeam.Domain.Models;
using PerreraTeam.Exceptions;
using PerreraTeam.Services;

namespace PerreraTeam.Controllers
{
    public class AdopcionesController : BaseController
    {
        private IAdopcionesRepository _repository = null;

        public AdopcionesController()
        {
            _repository = new AdopcionesRepository();
        }

        public AdopcionesController(IAdopcionesRepository repository)
        {
            _repository = repository;
        }

        // GET: Adopciones
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await _repository.GetAll().ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                throw new AdopcionesException("Error al recuperar los registros", ex);
            }
        }

        // GET: Adopciones/Details/5
        public async Task<ActionResult> Details(int? clienteId, int? empleadoId, int? perroId, DateTime? fechaEntrega)
        {
            //if (adopciones == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var adopciones = await _repository.GetElement(clienteId, empleadoId, perroId, fechaEntrega).ConfigureAwait(false);
            if (adopciones == null)
            {
                return HttpNotFound();
            }
            return View(adopciones);
        }

        // GET: Adopciones/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_repository.GetContext().Clientes, "Id", "NombreCompleto");
            ViewBag.EmpleadoId = new SelectList(_repository.GetContext().Empleados, "Id", "NombreCompleto");
            ViewBag.PerroId = new SelectList(_repository.GetContext().Perros, "Id", "Nombre");
            return View();
        }

        // POST: Adopciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PerroId,ClienteId,EmpleadoId,FechaEntrega")] Adopciones adopciones)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Insert(adopciones);
                }
                catch (DataException dex)
                {
                    throw new AdopcionesException("Error al guardar un nuevo elemento", dex);
                }
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(_repository.GetContext().Clientes, "Id", "NombreCompleto", adopciones.ClienteId);
            ViewBag.EmpleadoId = new SelectList(_repository.GetContext().Empleados, "Id", "NombreCompleto", adopciones.EmpleadoId);
            ViewBag.PerroId = new SelectList(_repository.GetContext().Perros, "Id", "Nombre", adopciones.PerroId);
            return View(adopciones);
        }

        // GET: Adopciones/Edit/5
        public async Task<ActionResult> Edit(int? clienteId, int? empleadoId, int? perroId, DateTime? fechaEntrega)
        {
            //if (item == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var adopciones = await _repository.GetElement(clienteId, empleadoId, perroId, fechaEntrega).ConfigureAwait(false);
            if (adopciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(_repository.GetContext().Clientes, "Id", "NombreCompleto", adopciones.ClienteId);
            ViewBag.EmpleadoId = new SelectList(_repository.GetContext().Empleados, "Id", "NombreCompleto", adopciones.EmpleadoId);
            ViewBag.PerroId = new SelectList(_repository.GetContext().Perros, "Id", "Nombre", adopciones.PerroId);
            return View(adopciones);
        }

        // POST: Adopciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PerroId,EmpleadoId,ClienteId,FechaEntrega")] Adopciones adopciones)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(adopciones);
                }
                catch (DataException dex)
                {
                    throw new AdopcionesException("Error al actualizar los datos", dex);
                }
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(_repository.GetContext().Clientes, "Id", "NombreCompleto", adopciones.ClienteId);
            ViewBag.EmpleadoId = new SelectList(_repository.GetContext().Empleados, "Id", "NombreCompleto", adopciones.EmpleadoId);
            ViewBag.PerroId = new SelectList(_repository.GetContext().Perros, "Id", "Nombre", adopciones.PerroId);
            return View(adopciones);
        }

        // GET: Adopciones/Delete/5
        public async Task<ActionResult> Delete(int? clienteId, int? empleadoId, int? perroId, DateTime? fechaEntrega)
        {
            //if (adopciones == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var adopciones = await _repository.GetElement(clienteId, empleadoId, perroId, fechaEntrega).ConfigureAwait(false);
            if (adopciones == null)
            {
                return HttpNotFound();
            }
            return View(adopciones);
        }

        // POST: Adopciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? clienteId, int? empleadoId, int? perroId, DateTime? fechaEntrega)
        {
            var adopciones = await _repository.GetElement(clienteId, empleadoId, perroId, fechaEntrega).ConfigureAwait(false);
            try
            {
                _repository.Delete(adopciones);
            }
            catch (Exception ex)
            {
                throw new AdopcionesException("Error al borrar el registro", ex);
            }

            return RedirectToAction("Index");
        }
    }
}
