using System;
using System.ComponentModel.DataAnnotations;

namespace GestiondeCursos.Models
{
    public class Inscripcion
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Curso")]
        public int CursoId { get; set; }
        public Curso? Curso { get; set; }

        [Required]
        [Display(Name = "Estudiante")]
        public int EstudianteId { get; set; }
        public Estudiante? Estudiante { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Inscripción")]
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
