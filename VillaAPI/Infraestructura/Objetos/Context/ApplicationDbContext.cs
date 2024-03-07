using Microsoft.EntityFrameworkCore;
using VillaAPI.Infraestructura.Objetos.Models;

namespace VillaAPI.Infraestructura.Objetos.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<VillaEntity>Villas {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
