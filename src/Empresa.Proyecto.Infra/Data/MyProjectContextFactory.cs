using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Empresa.Proyecto.Infra.Data
{
    public class MyProjectContextFactory : IDesignTimeDbContextFactory<MyProjectContext>
    {

        public MyProjectContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyProjectContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=testProject;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new MyProjectContext(optionsBuilder.Options);
        }
    }
}