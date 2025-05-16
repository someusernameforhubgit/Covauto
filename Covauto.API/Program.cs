using Covauto.Application.Interfaces;
using Covauto.Application.Repositories;
using Covauto.Domain;

namespace Covauto.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        ServicesConfiguration.RegisterServices(builder.Services, builder.Configuration.GetConnectionString("DefaultConnection"));
        builder.Services.AddScoped<IAdresRepository, AdresRepository>();
        builder.Services.AddScoped<IAutoRepository, AutoRepository>();
        builder.Services.AddScoped<IGebruikerRepository, GebruikerRepository>();
        builder.Services.AddScoped<IRitRepository, RitRepository>();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

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
    }
}