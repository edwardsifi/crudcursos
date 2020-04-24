using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursosCrudRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CursosCrudRazor
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        //cargar todos el curso en la vista edit, binculando el modelo curso al onget
        //y nos carga el modelo curso a la vista html
        [BindProperty]
        public Curso Curso { get; set; }

        //trabajar con los tempdata(datos temporales) para mensajes o notificaciones
        [TempData]
        public string Mensaje { get; set; }

        //busca el curso con el id
        public async Task OnGet(int id)
        {
            Curso = await _db.Curso.FindAsync(id);
        }

        //cuando precionamos el boton editar en la vista llama al metodo onpost
        //el metodo verifica si el modelo es valido ingresa los datos en la base de datos y redireje al index
        // sino es valido no  hace nada nos deja en la misma pagina
        public async Task<IActionResult> OnPost() {

            if (ModelState.IsValid) {

                var CursoDesdeDb = await _db.Curso.FindAsync(Curso.Id);
                CursoDesdeDb.NombreCurso = Curso.NombreCurso;
                CursoDesdeDb.CantidadClases = Curso.CantidadClases;
                CursoDesdeDb.Precio = Curso.Precio;

                await _db.SaveChangesAsync();
                Mensaje = "Curso Editado correctamente";
                return RedirectToPage("Index");
            
            }

            return RedirectToPage();
        
        }

    }
}