using Microsoft.AspNetCore.Components;
using Covauto.Shared.DTO.Rit;
using Covauto.Shared.DTO.Adres;
using System.Net.Http.Json;

namespace Covauto.Blazor.Pages.Ritten.Aanmaken;

public partial class RitAanmaken : ComponentBase
{
    [Inject]
    private HttpClient HttpClient { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private RitMaakItem rit = new RitMaakItem();

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
    }
    
    private void AddAdres()
    {
        rit.Adressen.Add(new AdresMaakItem());
    }
}