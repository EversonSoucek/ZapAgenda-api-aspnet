using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZapAgenda_api_aspnet.models;

namespace ZapAgenda_api_aspnet.data
{
    public class CoreDBContext : DbContext
    {
        public CoreDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        public required DbSet<Empresa> Empresa { get; set; }

        /*
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Usuario>()
                .Property(u => u.UserName)
                .HasColumnName("NomeDeUsuario");
        }*/
    }
}