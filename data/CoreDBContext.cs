using Microsoft.EntityFrameworkCore;
using ZapAgenda_api_aspnet.models;

namespace ZapAgenda_api_aspnet.data
{
    public class CoreDBContext : DbContext
    {
        public CoreDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {}

        public required DbSet<Empresa> Empresa { get; set; }
    }
}