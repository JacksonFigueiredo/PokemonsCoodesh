using PokeApi.Application.Services;
using PokeApi.Domain.Interfaces;
using PokeApi.Infrastructure.Repositories;
using PokeApi.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("DataSource=:memory:"));


builder.Services.AddScoped<IMasterRepository, MasterRepository>();
builder.Services.AddScoped<IPokeApiService, PokeApiService>();
builder.Services.AddScoped<PokemonService>();
builder.Services.AddScoped<MasterService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

