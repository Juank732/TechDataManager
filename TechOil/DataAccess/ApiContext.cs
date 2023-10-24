using Microsoft.EntityFrameworkCore;
using TechOil.Models;

namespace TechOil.DataAccess
{
    public class ApiContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Trabajo> Trabajos { get; set; }

        public DbSet<Proyecto> Proyectos { get; set; }

        public DbSet<Servicio> Servicios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\SERVERTEST;Initial Catalog=TechOil;Integrated Security=True");
        }
    }
}
