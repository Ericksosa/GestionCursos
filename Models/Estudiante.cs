using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GestiondeCursos.Models
{
    public class Estudiante
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string Email { get; set; }

        // Relación: un estudiante puede tener muchas inscripciones
        public ICollection<Inscripcion>? Inscripciones { get; set; }
    }
}
