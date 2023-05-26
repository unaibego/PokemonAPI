using Microsoft.EntityFrameworkCore;
using PokemonAPI.Data;
using PokemonAPI.Interface;
using PokemonAPI.Repository;
using PokemonReviewApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<Seed>(); //taulak betetzeko seed fitxategia erabili dugu
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(builderSQL =>
{
    builderSQL.UseSqlServer(builder.Configuration.GetConnectionString("Connection1")); //Hemos guardado el string de conexion en el fitxero de configuración de appsettings
});

var app = builder.Build();

//hau ere gure taulak automatikoki betetzeko
if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
