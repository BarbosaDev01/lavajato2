using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using lavajato.Models;

namespace lavajato.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<lavajato.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<lavajato.Models.Carro> Carro { get; set; } = default!;
        public DbSet<lavajato.Models.Lavagem> Lavagem { get; set; } = default!;
        public DbSet<lavajato.Models.TipoLavagem> TipoLavagem { get; set; } = default!;
    }
}