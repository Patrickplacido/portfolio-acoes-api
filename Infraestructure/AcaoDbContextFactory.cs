using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PortfolioAcoes.Infrastructure;

public class AcaoDbContextFactory : IDesignTimeDbContextFactory<AcaoDbContext>
{
    public AcaoDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AcaoDbContext>();
        optionsBuilder.UseMySql("server=localhost;user=root;database=acoes;password=udesc",
            ServerVersion.AutoDetect("server=localhost;user=root;database=acoes;password=udesc"));

        return new AcaoDbContext(optionsBuilder.Options);
    }
}