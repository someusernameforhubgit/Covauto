using Covauto.Application.Interfaces;
using Covauto.Application.Repositories;
using Covauto.Application.Services;
using Covauto.Domain;
using Covauto.Shared.DTO.Adres;
using Covauto.Shared.DTO.Auto;
using Covauto.Shared.DTO.Gebruiker;
using Covauto.Shared.DTO.Reservering;
using Covauto.Shared.DTO.Rit;
using NuGet.Configuration;

namespace Covauto.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        ServicesConfiguration.RegisterServices(builder.Services, builder.Configuration.GetConnectionString("DefaultConnection"));

        var _ = typeof(object);
        var mappings = new List<(Type listType, Type itemType, Type addType, Type updateType, Type repositoryType)>
        {
            (_, _, typeof(AdresMakeItem), _, typeof(AdresRepository)),
            (typeof(AutoListItem), typeof(AutoItem), _, _, typeof(AutoRepository)),
            (typeof(GebruikerListItem), typeof(GebruikerItem), _, _, typeof(GebruikerRepository)),
            (typeof(RitListItem), typeof(RitItem), typeof(RitMaakItem), _, typeof(RitRepository))
        };

        foreach (var (listType, itemType, addType, updateType, repositoryType) in mappings)
        {
            var baseService = typeof(AbstractService<,,,>).MakeGenericType(listType, itemType, addType, updateType);
            var serviceType = typeof(BaseService<,,,>).MakeGenericType(listType, itemType, addType, updateType);
            builder.Services.AddScoped(baseService, serviceType);
            
            var baseRepository = typeof(AbstractRepository<,,,>).MakeGenericType(listType, itemType, addType, updateType);
            builder.Services.AddScoped(baseRepository, repositoryType);
        }

        builder.Services.AddScoped<AbstractService<ReserveringListItem, ReserveringItem, ReserveringMaakItem, ReserveringUpdateItem>, ReserveringService<ReserveringItem>>();
        builder.Services.AddScoped<AbstractRepository<ReserveringListItem, ReserveringItem, ReserveringMaakItem, ReserveringUpdateItem>, ReserveringRepository>();
        
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