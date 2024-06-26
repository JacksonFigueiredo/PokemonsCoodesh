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
    options.UseInMemoryDatabase("PokeApiDb"));


builder.Services.AddScoped<IMasterRepository, MasterRepository>();
builder.Services.AddScoped<IPokeApiService, PokeApiService>();
builder.Services.AddScoped<PokemonService>();
builder.Services.AddScoped<MasterService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

