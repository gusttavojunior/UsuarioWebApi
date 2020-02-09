using CrudUsuarios.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CrudUsuarios.Models.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
