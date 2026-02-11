using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestiondeCursos.Models;

namespace GestiondeCursos.Data
{
    public class GestiondeCursosContext : DbContext
    {
        public GestiondeCursosContext (DbContextOptions<GestiondeCursosContext> options)
            : base(options)
        {
        }

        public DbSet<GestiondeCursos.Models.Curso> Curso { get; set; } = default!;
        public DbSet<GestiondeCursos.Models.Estudiante> Estudiante { get; set; } = default!;
        public DbSet<GestiondeCursos.Models.Inscripcion> Inscripcion { get; set; } = default!;
    }
}
