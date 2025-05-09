using Covauto.Application.Interfaces;
using Covauto.Domain.Data;
using Covauto.Shared.DTO.Gebruiker;

namespace Covauto.Application.Repositories;

public class GebruikerRepository(CovautoContext covautoContext): IGebruikerRepository
{
    public IEnumerable<GebruikerListItem> GeefAlleGebruikers()
    {
        var returnGebruikers = new List<GebruikerListItem>();
        var gebruikers = covautoContext.Gebruikers.Select(n => n);
        foreach (var item in gebruikers)
            returnGebruikers.Add(new GebruikerListItem
            {
                ID = item.ID,
                Voornaam = item.Voornaam,
                Achternaam = item.Achternaam
            });
        return returnGebruikers;
    }
    
    public GebruikerItem GeefGebruiker(int id)
    {
        var gebruiker = covautoContext.Gebruikers.FirstOrDefault(g => g.ID == id);
        
            if (gebruiker == null)
            return null;
       

        return new GebruikerItem
        {
            ID = gebruiker.ID,
            Voornaam = gebruiker.Voornaam,
            Achternaam = gebruiker.Achternaam,
            Admin = gebruiker.Admin
        };
    }
}