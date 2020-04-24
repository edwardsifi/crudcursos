using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursosCrudRazor.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NombreCurso { get; set; }
        [Display(Name = "cantidad de clases")]
        public int CantidadClases { get; set; }
        public int Precio { get; set; }

    }
}
