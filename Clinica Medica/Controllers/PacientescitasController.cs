using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica_Medica.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace pruebaClinica.Controllers
{
    [Authorize]
    public class PacientescitasController : Controller
    {
        private readonly clinicamedicadbContext _context;

        public PacientescitasController(clinicamedicadbContext context)
        {
            _context = context;
        }

        // GET: Pacientescitas
        [HttpGet]
        [Route("PacientesCitas/Index")]
        public async Task<IActionResult> Index(string searchString)
        {
            var citas = from c in _context.Pacientescitas
                        select c;

            // Si hay una cadena de búsqueda, filtra los resultados
            if (!String.IsNullOrEmpty(searchString))
            {
                citas = citas.Where(c => c.NombrePaciente.Contains(searchString)
                                      || c.DoctorNombre.Contains(searchString)
                                      || c.FechaCita.ToString().Contains(searchString));
            }

            return View(await citas.ToListAsync());
        }

        // GET: Pacientescitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pacientescitas == null)
            {
                return NotFound();
            }

            var pacientescita = await _context.Pacientescitas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacientescita == null)
            {
                return NotFound();
            }

            return View(pacientescita);
        }

        // GET: Pacientescitas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacientescitas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombrePaciente,Correo,Telefono,FechaCita,MotivoCita,DoctorNombre")] Pacientescita pacientescita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacientescita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacientescita);
        }

        // GET: Pacientescitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pacientescitas == null)
            {
                return NotFound();
            }

            var pacientescita = await _context.Pacientescitas.FindAsync(id);
            if (pacientescita == null)
            {
                return NotFound();
            }
            return View(pacientescita);
        }

        // POST: Pacientescitas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombrePaciente,Correo,Telefono,FechaCita,MotivoCita,DoctorNombre")] Pacientescita pacientescita)
        {
            if (id != pacientescita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacientescita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacientescitaExists(pacientescita.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pacientescita);
        }

        // GET: Pacientescitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pacientescitas == null)
            {
                return NotFound();
            }

            var pacientescita = await _context.Pacientescitas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacientescita == null)
            {
                return NotFound();
            }

            return View(pacientescita);
        }

        // POST: Pacientescitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pacientescitas == null)
            {
                return Problem("Entity set 'clinicamedicaContext.Pacientescitas'  is null.");
            }
            var pacientescita = await _context.Pacientescitas.FindAsync(id);
            if (pacientescita != null)
            {
                _context.Pacientescitas.Remove(pacientescita);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacientescitaExists(int id)
        {
            return (_context.Pacientescitas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
