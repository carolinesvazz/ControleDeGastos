using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ControleGastos.API.Data;

// Classe utilizada pelo Entity Framework para criar o DbContext 
// durante as migrations.
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseSqlite("Data Source=ControleGastos.db");

        return new AppDbContext(optionsBuilder.Options);
    }
}