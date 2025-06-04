using Covauto.Shared.DTO.Rit;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Covauto.Shared.DTO.Adres;

namespace Covauto.Blazor.Pages.Ritten.Bekijken;

public partial class RitBekijken : ComponentBase
{
    [Parameter]
    public int Id { get; set; }
    
    [Inject]
    private HttpClient HttpClient { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private RitItem rit;
    private IEnumerable<AdresListItem> adressen = [];

    protected override async Task OnInitializedAsync()
    {
        var result = await HttpClient.GetFromJsonAsync<RitItem>($"api/Rit/{Id}");

        rit = new RitItem
        {
            ID = result.ID,
            AutoId = result.AutoId,
            Kilometers = result.Kilometers,
            GebruikerId = result.GebruikerId,
            Adressen = result.Adressen,
        };
    }
    
    private void RitAanmaken()
    {
        NavigationManager.NavigateTo("ritten/aanmaken");
    }
    
    private void Cancel()
    {
        NavigationManager.NavigateTo("/ritten");
    }
}