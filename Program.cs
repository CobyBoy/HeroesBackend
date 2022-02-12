using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Heroes.Data;
using Heroes.Interfaces;
using Heroes.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HeroesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HeroesContext")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IHeroeRepository, HeroeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
