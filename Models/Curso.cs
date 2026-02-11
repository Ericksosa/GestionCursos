using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GestiondeCursos.Models
{
    public class Curso
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Range(1, 100, ErrorMessage = "Los créditos deben ser entre 1 y 100")]
        public int Creditos { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        // Relación: un curso tiene muchas inscripciones
        public ICollection<Inscripcion>? Inscripciones { get; set; }
    } 
}
