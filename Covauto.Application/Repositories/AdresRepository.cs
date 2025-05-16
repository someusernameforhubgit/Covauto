using Covauto.Application.Interfaces;
using Covauto.Domain.Data;
using Covauto.Domain.Entities;
using Covauto.Shared.DTO.Adres;

namespace Covauto.Application.Repositories;

public class AdresRepository(CovautoContext covautoContext): IAdresRepository
{
    public Adres VoegToe(CreateAdres request)
    {
        var adres = new Adres
        {
            Plaats = request.Plaats,
            Straat = request.Straat,
            Huisnummer = request.Huisnummer,
            Land = request.Land,
            Order = request.Order,
            RitID = request.RitID
        };

        covautoContext.Adressen.Add(adres);
        covautoContext.SaveChanges();
        
        return adres;
    }
}