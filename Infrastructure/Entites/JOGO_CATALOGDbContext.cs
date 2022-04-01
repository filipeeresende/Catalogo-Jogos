using Infrastructure.Maper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Entites
{
    public class JOGO_CATALOGDbContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public JOGO_CATALOGDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<Jogo> Jogos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
         => options.UseSqlServer(Configuration.GetConnectionString("Jogos"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new JogoMap());
        }
    }
}
