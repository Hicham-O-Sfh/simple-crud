using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using simple_crud.Data;
using simple_crud.Interfaces;
using simple_crud.Repositories;
using simple_crud.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// dependencie injection
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddScoped<IEtudiantRepository, EtudiantRepository>();
builder.Services.AddScoped<IEtudiantService, EtudiantService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Etudiant/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var cultureInfo = new CultureInfo("fr-FR");
cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Etudiant}/{action=Index}/{id?}");

app.Run();
