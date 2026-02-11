using System;
using System.Diagnostics;
using GestiondeCursos.Data;
using GestiondeCursos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestiondeCursos.Controllers
{
    public class HomeController : Controller
    {
        private readonly GestiondeCursosContext _context;

        public HomeController(GestiondeCursosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Lógica de Inteligencia de Negocios (BI)

            // 1. Conteo total
            ViewBag.TotalEstudiantes = await _context.Estudiante.CountAsync();
            ViewBag.TotalCursos = await _context.Curso.CountAsync();
            ViewBag.TotalInscripciones = await _context.Inscripcion.CountAsync();

            // 2. Cursos con más inscritos (Top 3)
            var cursosPopulares = await _context.Inscripcion
                .Include(i => i.Curso)
                .GroupBy(i => i.Curso.Titulo)
                .Select(g => new { Curso = g.Key, Cantidad = g.Count() })
                .OrderByDescending(x => x.Cantidad)
                .Take(3)
                .ToListAsync();

            ViewBag.CursosPopulares = cursosPopulares;

            return View();
        }
    }
}
