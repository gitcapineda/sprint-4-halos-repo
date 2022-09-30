using Microsoft.EntityFrameworkCore;
using Proyecto.App.Dominio;

namespace Proyecto.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fase> Fases { get; set; }
        public DbSet<Programa> Programas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog= PROYECTO_CICLO_3");
            }
        }
    }
}