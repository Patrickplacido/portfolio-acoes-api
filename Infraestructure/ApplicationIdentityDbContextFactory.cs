using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PortfolioAcoes.Infrastructure
{
    public class ApplicationIdentityDbContextFactory : IDesignTimeDbContextFactory<ApplicationIdentityDbContext>
    {
        public ApplicationIdentityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationIdentityDbContext>();
            optionsBuilder.UseMySql("server=localhost;user=root;database=acoes;password=udesc",
                ServerVersion.AutoDetect("server=localhost;user=root;database=acoes;password=udesc"));

            return new ApplicationIdentityDbContext(optionsBuilder.Options);
        }
    }
}