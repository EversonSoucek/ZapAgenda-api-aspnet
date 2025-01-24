using Microsoft.EntityFrameworkCore;
using ZapAgenda_api_aspnet.models;

namespace ZapAgenda_api_aspnet.data
{
    public class CoreDBContext : DbContext
    {
        public CoreDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        public required DbSet<Empresa> Empresa { get; set; }
        public required DbSet<Usuario> Usuario { get; set; }
        public required DbSet<Cargo> Cargo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<Cargo> cargos = [
                new Cargo {
                    IdCargo = 1,
                    NomeCargo = "Admin"
                },
                new Cargo {
                    IdCargo = 2,
                    NomeCargo = "User"
                },
                new Cargo {
                    IdCargo = 3,
                    NomeCargo = "MaxAdmin"
                },
            ];

            modelBuilder.Entity<Cargo>().HasData(cargos);
        }
    }
}