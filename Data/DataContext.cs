using Microsoft.EntityFrameworkCore;
using simple_crud.Models;

namespace simple_crud.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Etudiant> Etudiants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Etudiant>().HasData(
                DataInitializer.SeedEtudiantData()
            );
        }
    }
}