using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CatalogoDeDiscos.Data;
using CatalogoDeDiscos.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CatalogoDeDiscosContext>(options =>
options.UseMySql(builder.Configuration.GetConnectionString("CatalogoDeDiscosContext"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("CatalogoDeDiscosContext")),
    builder => builder.MigrationsAssembly("CatalogoDeDiscos")));


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<ArtistBandService>();
builder.Services.AddScoped<AlbumService>();
builder.Services.AddScoped<MusicGenreService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    using (var scope = app.Services.CreateScope())
    {
        var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
        seedingService.Seed();
    }
}
else
{
    app.UseExceptionHandler("/Home/Error");
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
