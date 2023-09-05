using APIRest_Terminales.Models;
using Microsoft.EntityFrameworkCore;

namespace APIRest_Terminales.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Fabricantes> Fabricantes { get; set; }
        public DbSet<Terminales> Terminales { get; set; }
    }
}
