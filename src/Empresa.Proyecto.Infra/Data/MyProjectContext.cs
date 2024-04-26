using Microsoft.EntityFrameworkCore;
using Empresa.Proyecto.Core.Entities;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore.Design;
using Empresa.Proyecto.Infra.Data.Configuration;


namespace Empresa.Proyecto.Infra.Data
{
    public class MyProjectContext : DbContext
    {
        //public MyProjectContext() { }

        /// <summary>
        /// Constructor para DI
        /// </summary>
        /// <param name="options"></param>
        public MyProjectContext(DbContextOptions<MyProjectContext> options) : base(options)
        {

        }

        public virtual DbSet<SimpleEntity> SimpleEntity { get; set; }
        public virtual DbSet<ComplexEntity> ComplexEntity { get; set; }
        public virtual DbSet<CompleteEntity> CompleteEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            builder.Entity<SimpleEntity>().HasData(
                new SimpleEntity
                {
                    Id = 1,
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    Name = "Nuevo",
                    Value = "Nuevo",
                },
                new SimpleEntity
                {
                    Id = 2,
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    Name = "Existente",
                    Value = "Existente",
                },
                new SimpleEntity
                {
                    Id = 3,
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    Name = "Reconstruido",
                    Value = "Reconstruido",
                }
            );
        }
    }

    /*
    public class YourDbContextFactory : IDesignTimeDbContextFactory<MyProjectContext>
    {
        public MyProjectContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyProjectContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-G9OVET8\\SQLEXPRESS;Database=testProject;MultipleActiveResultSets=true;User Id=sa;Password=123;");

            return new MyProjectContext(optionsBuilder.Options);
        }
    }
    */
}