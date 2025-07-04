using Microsoft.AspNetCore.Components;
using Covauto.Shared.DTO.Rit;
using Covauto.Shared.DTO.Adres;
using System.Net.Http.Json;
using Covauto.Shared.DTO.Auto;
using Covauto.Shared.DTO.Gebruiker;

namespace Covauto.Blazor.Pages.Ritten.Aanmaken;

public partial class RitAanmaken : ComponentBase
{
    [Inject]
    private HttpClient HttpClient { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private RitMaakItem rit = new RitMaakItem
    {
        Begin= DateTime.Now,
        End = DateTime.Now
    };
    private List<AutoListItem> autos = new();
    private List<GebruikerListItem> gebruikers = new();
    
    protected override async Task OnInitializedAsync()
    {
        autos = await HttpClient.GetFromJsonAsync<List<AutoListItem>>("/api/Auto");
        gebruikers = await HttpClient.GetFromJsonAsync<List<GebruikerListItem>>("/api/Gebruiker");
    }

    private async Task Submit()
    {
        var result = await HttpClient.PostAsJsonAsync<RitMaakItem>("/api/Rit", rit);
        if (result.IsSuccessStatusCode)
        {
            NavigationManager.NavigateTo("/ritten");
            // Succesmelding tonen
        }
        else
        {
            Console.WriteLine("Failed to create rit: " + result.StatusCode);
            // Foutmelding tonen
        }
        
        var index = 0;
        foreach (var adres in rit.Adressen)
        {
            adres.RitID = int.Parse(await result.Content.ReadAsStringAsync());
            adres.Order = index;
            Console.WriteLine(adres);
            var adresResult = await HttpClient.PostAsJsonAsync<AdresMaakItem>("/api/Adres", adres);
            if (!adresResult.IsSuccessStatusCode)
            {
                Console.WriteLine("Failed to create adres: " + adresResult.StatusCode);
            }

            index++;
        }
    }
    
    private void AddAdres()
    {
        rit.Adressen.Add(new AdresMaakItem());
    }
    
    private void Cancel()
    {
        NavigationManager.NavigateTo("/ritten");
    }
}