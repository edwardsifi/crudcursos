using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursosCrudRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CursosCrudRazor
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        //hace una lista de todos los cursos
        public IEnumerable<Curso> Cursos { get; set; }

        //trabajar con los tempdata(datos temporales) para mensajes o notificaciones
        [TempData]
        public string Mensaje { get; set; }

        //metodo onget asincrono
        public async Task OnGet()
        {
            //pasando todos los datos a la vista
            Cursos = await _db.Curso.ToListAsync();
        }

        //metodo para borrar dela base de datos
        public async Task<IActionResult> OnPostDelete(int id) {

            var curso = await _db.Curso.FindAsync(id);
            if (curso==null) {

                return NotFound();
            
            }

            _db.Curso.Remove(curso);
            await _db.SaveChangesAsync();

            Mensaje = "curso borrado correctamente";

            return RedirectToPage("Index");
        
        }

    }
}