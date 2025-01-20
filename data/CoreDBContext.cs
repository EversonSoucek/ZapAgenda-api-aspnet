using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZapAgenda_api_aspnet.models;

namespace ZapAgenda_api_aspnet.data
{
    public class CoreDBContext : IdentityDbContext<Usuario>
    {
        public CoreDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        public required DbSet<Empresa> Empresa { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = [
                new IdentityRole{
                    Id = "d31bd8fe-e02c-4a9b-ad7b-41761e44db2c",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole{
                    Id = "5041cc22-0870-44c7-81c1-657d0cf1b781",
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole {
                    Id = "5beb1da9-824c-42c9-8cd1-5f7ff2b32913",
                    Name = "MaxAdmin",
                    NormalizedName = "MAXADMIN"
                }
            ];
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}