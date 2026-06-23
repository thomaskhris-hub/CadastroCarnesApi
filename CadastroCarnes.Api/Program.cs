using CadastroCarnes.Data.Context;
using CadastroCarnes.Data.Repositories;
using CadastroCarnes.Data.Repositories.Interfaces;
using CadastroCarnes.Data.Seeds;
using CadastroCarnes.Service.Interfaces;
using CadastroCarnes.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Repositories
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<ICompradorRepository, CompradorRepository>();
builder.Services.AddScoped<ICarneRepository, CarneRepository>();
builder.Services.AddScoped<ICidadeRepository, CidadeRepository>();
builder.Services.AddScoped<IEstadoRepository, EstadoRepository>();


// Services
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<ICompradorService, CompradorService>();
builder.Services.AddScoped<ICarneService, CarneService>();
builder.Services.AddScoped<ICidadeService, CidadeService>();
builder.Services.AddScoped<IEstadoService, EstadoService>();


// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();


// Banco
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(
            "DefaultConnection"
        )
    )
);


var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider
        .GetRequiredService<AppDbContext>();

    DataSeeder.Seed(context);
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ReactPolicy");
app.UseHttpsRedirection();


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool",
    "Mild", "Warm", "Balmy", "Hot",
    "Sweltering", "Scorching"
};




app.UseHttpsRedirection();

app.MapControllers();
app.Run();


record WeatherForecast(
    DateOnly Date,
    int TemperatureC,
    string? Summary)
{
    public int TemperatureF =>
        32 + (int)(TemperatureC / 0.5556);
}