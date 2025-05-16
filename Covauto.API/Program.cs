using Covauto.Application.Interfaces;
using Covauto.Application.Repositories;
using Covauto.Application.Services;
using Covauto.Domain;
using Covauto.Shared.DTO.Adres;
using Covauto.Shared.DTO.Auto;
using Covauto.Shared.DTO.Gebruiker;
using Covauto.Shared.DTO.Reservering;
using Covauto.Shared.DTO.Rit;

namespace Covauto.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        ServicesConfiguration.RegisterServices(builder.Services, builder.Configuration.GetConnectionString("DefaultConnection"));
        
        builder.Services.AddScoped<AbstractRepository<AdresListItem, AdresItem>, AdresRepository>();
        builder.Services.AddScoped<AbstractService<AutoListItem, AutoItem>, BaseService<AutoListItem, AutoItem>>();
        builder.Services.AddScoped<AbstractService<GebruikerListItem, GebruikerItem>, BaseService<GebruikerListItem, GebruikerItem>>();
        builder.Services.AddScoped<AbstractService<ReserveringListItem, ReserveringItem>, BaseService<ReserveringListItem, ReserveringItem>>();
        builder.Services.AddScoped<AbstractService<RitListItem, RitItem>, BaseService<RitListItem, RitItem>>();
        
        builder.Services.AddScoped<AbstractRepository<AutoListItem, AutoItem>, AutoRepository>();
        builder.Services.AddScoped<AbstractRepository<GebruikerListItem, GebruikerItem>, GebruikerRepository>();
        builder.Services.AddScoped<AbstractRepository<ReserveringListItem, ReserveringItem>, ReserveringRepository>();
        builder.Services.AddScoped<AbstractRepository<RitListItem, RitItem>, RitRepository>();
        
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