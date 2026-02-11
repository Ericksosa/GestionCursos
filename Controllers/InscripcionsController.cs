using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestiondeCursos.Data;
using GestiondeCursos.Models;

namespace GestiondeCursos.Controllers
{
    public class InscripcionsController : Controller
    {
        private readonly GestiondeCursosContext _context;

        public InscripcionsController(GestiondeCursosContext context)
        {
            _context = context;
        }

        // GET: Inscripcions
        public async Task<IActionResult> Index()
        {
            var gestiondeCursosContext = _context.Inscripcion.Include(i => i.Curso).Include(i => i.Estudiante);
            return View(await gestiondeCursosContext.ToListAsync());
        }

        // GET: Inscripcions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripcion
                .Include(i => i.Curso)
                .Include(i => i.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscripcion == null)
            {
                return NotFound();
            }

            return View(inscripcion);
        }

        // GET: Inscripcions/Create
        public IActionResult Create()
        {
            // Buscamos los estudiantes y creamos un campo combinado "NombreCompleto"
            var listaEstudiantes = _context.Estudiante
                .Select(e => new {
                    Id = e.Id,
                    NombreCompleto = e.Nombre + " " + e.Apellido
                });
            ViewData["CursoId"] = new SelectList(_context.Curso, "Id", "Titulo");                   

            // Ahora usamos "NombreCompleto" como el texto a mostrar
            ViewData["EstudianteId"] = new SelectList(listaEstudiantes, "Id", "NombreCompleto");
            return View();
        }

        // POST: Inscripcions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CursoId,EstudianteId,Fecha")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscripcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Curso, "Id", "Titulo", inscripcion.CursoId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiante, "Id", "Apellido", inscripcion.EstudianteId);
            return View(inscripcion);
        }

        // GET: Inscripcions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripcion.FindAsync(id);
            if (inscripcion == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Curso, "Id", "Titulo", inscripcion.CursoId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiante, "Id", "Apellido", inscripcion.EstudianteId);
            return View(inscripcion);
        }

        // POST: Inscripcions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CursoId,EstudianteId,Fecha")] Inscripcion inscripcion)
        {
            if (id != inscripcion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscripcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscripcionExists(inscripcion.Id))
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
            ViewData["CursoId"] = new SelectList(_context.Curso, "Id", "Titulo", inscripcion.CursoId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiante, "Id", "Apellido", inscripcion.EstudianteId);
            return View(inscripcion);
        }

        // GET: Inscripcions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripcion
                .Include(i => i.Curso)
                .Include(i => i.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscripcion == null)
            {
                return NotFound();
            }

            return View(inscripcion);
        }

        // POST: Inscripcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscripcion = await _context.Inscripcion.FindAsync(id);
            if (inscripcion != null)
            {
                _context.Inscripcion.Remove(inscripcion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscripcionExists(int id)
        {
            return _context.Inscripcion.Any(e => e.Id == id);
        }
    }
}
