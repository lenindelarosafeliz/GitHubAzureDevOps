using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<DocumentoTipo> DocumentoTipos { get; set; }
        public DbSet<Documento> Documentos { get; set; }
    }
}
