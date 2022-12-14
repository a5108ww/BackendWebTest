using BackendWebProj.Context;
using BackendWebProj.Filters;
using BackendWebProj.Models.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddControllersWithViews();

services.AddDbContext<BackendWebContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WebConnString"),
          sqlServerOptions => sqlServerOptions.CommandTimeout(300)));

services.AddScoped<EmployRepository>();
services.AddRazorPages().AddRazorRuntimeCompilation();

//?[?JFilter
services.AddMvc(options =>
{
    options.Filters.Add<ActionFilter>();

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
