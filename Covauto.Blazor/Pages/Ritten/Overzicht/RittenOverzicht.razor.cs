using Covauto.Shared.DTO.Rit;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Covauto.Blazor.Pages.Ritten.Overzicht;

public partial class RittenOverzicht : ComponentBase
{
    [Inject]
    private HttpClient HttpClient { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private IEnumerable<RitListItem> ritten = [];

    protected override async Task OnInitializedAsync()
    {
        ritten = await HttpClient.GetFromJsonAsync<IEnumerable<RitListItem>>("api/Rit");
    }
    
    private void RitAanmaken()
    {
        NavigationManager.NavigateTo("ritten/aanmaken");
    }
}