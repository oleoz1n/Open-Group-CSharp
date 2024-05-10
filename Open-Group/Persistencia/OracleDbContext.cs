using Microsoft.EntityFrameworkCore;
using Open_Group.Models;

namespace Open_Group.Persistencia
{
    public class OracleDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<DadosCliente> DadosClientes { get; set; }
        public DbSet<Arquivo> Arquivos { get; set; }
        public DbSet<Insight> Insights { get; set; }    

        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
    }
}
