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
            optionsBuilder.UseSqlServer("Server=DESKTOP-G9OVET8\\SQLEXPRESS;Database=testProject;MultipleActiveResultSets=true;User Id=sa;Password=123;");

            return new MyProjectContext(optionsBuilder.Options);
        }
    }
}