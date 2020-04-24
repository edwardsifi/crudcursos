using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursosCrudRazor.Models
{
    //cualquier tabla de la base de datos sepuede invocar como un contexto con todo y relaciones
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        }

        public DbSet<Curso> Curso{ get; set; }
    }
}
