using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursosCrudRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CursosCrudRazor
{
    public class CreateModel : PageModel
    {
        //el constructor(createmodel) recive el contexto o el aplicationdbcontext que esta en la carpeta models
        //para poder usar eel constructor debemos hacer una variable privada con readonly
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db) {
            //inicializar el contexto de la base de datos en el constructor de la clase createmodel,
            //para poder usarlo en el metodo onpost para guardar en la base de datos
            _db = db;

        }
        //enlasar el modelo conn las propiedades del html
        [BindProperty]
        public Curso Curso { get; set; }

        //trabajar con los tempdata(datos temporales) para mensajes o notificaciones
        [TempData]
        public string Mensaje { get; set; }

        //metodo que trae al index todos los cursos
        public void OnGet()
        {

        }

        //metodo onpost para guardar los datos
        public async Task<IActionResult> OnPost() {

            //validamos el modelo(campos obligatorios)
            if (!ModelState.IsValid) {
                //retornamos a la pagina en la misma del formulario
                return Page();
            
            }

            _db.Add(Curso);
            await _db.SaveChangesAsync();
            Mensaje = "curso creado correctamente";
            return RedirectToPage("Index");
        }


    }
}