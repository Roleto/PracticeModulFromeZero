using Microsoft.EntityFrameworkCore;
using PracticeModul.Data.Classes;
using PracticeModul.Data.Interfaces;
using PracticeModul.Helpers;
using PracticeModul.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOutputCaching();
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRepository<Hero>, HeroRepository>();
builder.Services.AddTransient<TableBuilder>();
builder.Services.AddDbContext<HeroDbContext>(opt =>
{
    //opt.UseInMemoryDatabase("db");
    opt.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HeroDb;Trusted_Connection=True;MultipleActiveResultSets=true");

});

var app = builder.Build();
app.UseOutputCaching();
app.UseExceptionHandler("/Hero/Error");
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Hero}/{action=Index}/{id?}");

app.Run();
