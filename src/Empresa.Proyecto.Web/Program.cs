using System.Globalization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Empresa.Proyecto.Core.Interfaces;
using Empresa.Proyecto.Core.Entities;
using Empresa.Proyecto.Infra.Data;
using Empresa.Proyecto.Infra.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MyProjectContext>(db =>
    db.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"))
    );

builder.Services.AddScoped<IAsyncRepository<SimpleEntity>, EFRepository<SimpleEntity>>();
builder.Services.AddScoped<IAsyncRepository<ComplexEntity>, EFRepository<ComplexEntity>>();
builder.Services.AddScoped<IAsyncRepository<CompleteEntity>, EFRepository<CompleteEntity>>();


//builder.Services.AddDbContexts(builder.Configuration);// Conexion a BD
//builder.Services.AddServices();// dependencias


//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//Configuracion de JSON para que no cambie el case al hacer parse, y funcione los controles de Kendo
builder.Services.AddRazorPages()
    .AddJsonOptions(options=>
    options.JsonSerializerOptions.PropertyNamingPolicy = null);

var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MyProjectContext>();
    context.Database.Migrate();
}



/*
using (var db = new MyProjectContext())
{
    var nuevo = new SimpleEntity();
    nuevo.Id = 1;
    nuevo.Created = DateTime.Now;
    nuevo.Modified = DateTime.Now;
    nuevo.Name = "Nuevo";
    nuevo.Value = "Nuevo";
    db.SimpleEntity.Add(nuevo);
    db.SaveChanges();
}
*/


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Poruqe no esta configurada la autorizacion :D
//app.UseAuthentication();
//app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

/*
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}");
*/

app.Run();
