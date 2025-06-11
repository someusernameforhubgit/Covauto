using Covauto.Shared.DTO.Rit;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Covauto.Shared.DTO.Gebruiker;

namespace Covauto.Blazor.Pages.Ritten.Overzicht;

public partial class RittenOverzicht : ComponentBase
{
    [Inject]
    private HttpClient HttpClient { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private IEnumerable<RitListItem> ritten = [];
    
    private Dictionary<int, GebruikerListItem> gebruikers;

    protected override async Task OnInitializedAsync()
    {
        var gebruikerResponse = await HttpClient.GetFromJsonAsync<IEnumerable<GebruikerListItem>>("api/Gebruiker");
        gebruikers = gebruikerResponse.ToDictionary(gebruiker => gebruiker.ID, gebruiker => gebruiker);
        
        ritten = await HttpClient.GetFromJsonAsync<IEnumerable<RitListItem>>("api/Rit");
    }
    
    private void RitAanmaken()
    {
        NavigationManager.NavigateTo("ritten/aanmaken");
    }
    
    private void RitBekijken(int id)
    {
        NavigationManager.NavigateTo($"ritten/bekijken/{id}");
    }
}