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
    public class AdopcionesController : Controller
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
            return View(await _repository.GetAll().ConfigureAwait(false));
        }

        // GET: Adopciones/Details/5
        public async Task<ActionResult> Details(int? idCliente, int? idEmpleado, int? idPerro, DateTime? fecha)
        {
            //if (adopciones == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var adopciones = await _repository.GetElement(idCliente, idEmpleado, idPerro, fecha).ConfigureAwait(false);
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
                _repository.Insert(adopciones);
                await _repository.Save().ConfigureAwait(false);
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(_repository.GetContext().Clientes, "Id", "NombreCompleto", adopciones.ClienteId);
            ViewBag.EmpleadoId = new SelectList(_repository.GetContext().Empleados, "Id", "NombreCompleto", adopciones.EmpleadoId);
            ViewBag.PerroId = new SelectList(_repository.GetContext().Perros, "Id", "Nombre", adopciones.PerroId);
            return View(adopciones);
        }

        // GET: Adopciones/Edit/5
        public async Task<ActionResult> Edit(int? idCliente, int? idEmpleado, int? idPerro, DateTime? fecha)
        {
            //if (item == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var adopciones = await _repository.GetElement(idCliente, idEmpleado, idPerro, fecha).ConfigureAwait(false);
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
                _repository.Update(adopciones);
                await _repository.Save().ConfigureAwait(false);
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(_repository.GetContext().Clientes, "Id", "NombreCompleto", adopciones.ClienteId);
            ViewBag.EmpleadoId = new SelectList(_repository.GetContext().Empleados, "Id", "NombreCompleto", adopciones.EmpleadoId);
            ViewBag.PerroId = new SelectList(_repository.GetContext().Perros, "Id", "Nombre", adopciones.PerroId);
            return View(adopciones);
        }

        // GET: Adopciones/Delete/5
        public async Task<ActionResult> Delete(int? idCliente, int? idEmpleado, int? idPerro, DateTime? fecha)
        {
            //if (adopciones == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var adopciones = await _repository.GetElement(idCliente, idEmpleado, idPerro, fecha).ConfigureAwait(false);
            if (adopciones == null)
            {
                return HttpNotFound();
            }
            return View(adopciones);
        }

        // POST: Adopciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? idCliente, int? idEmpleado, int? idPerro, DateTime? fecha)
        {
            var adopciones = await _repository.GetElement(idCliente, idEmpleado, idPerro, fecha).ConfigureAwait(false);
            _repository.Delete(adopciones);
            await _repository.Save().ConfigureAwait(false);
            return RedirectToAction("Index");
        }
    }
}
