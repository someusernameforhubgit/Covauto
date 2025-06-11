using Covauto.Shared.DTO.Reservering;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Covauto.Shared.DTO.Auto;

namespace Covauto.Blazor.Pages.Reserveringen.Overzicht;

public partial class ReserveringenOverzicht : ComponentBase
{
    [Inject]
    private HttpClient HttpClient { get; set; } = null!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    private IEnumerable<ReserveringListItem> reserveringen = new List<ReserveringListItem>();
    
    private Dictionary<int, AutoListItem> autos;
    
    protected override async Task OnInitializedAsync()
    {
        if (HttpClient is not null)
        {
            var autoResponse = await HttpClient.GetFromJsonAsync<IEnumerable<AutoListItem>>("api/Auto");
            autos = autoResponse.ToDictionary(auto => auto.ID, auto => auto);
            
            var result = await HttpClient.GetFromJsonAsync<IEnumerable<ReserveringListItem>>("api/Reservering");
            if (result is not null)
            {
                reserveringen = result;
            }
        }
    }
    
    private void ReserveringAanmaken()
    {
        if (NavigationManager is not null)
        {
            NavigationManager.NavigateTo("reserveringen/aanmaken");
        }
    }

    private void ReserveringBewerken(int id)
    {
        if (NavigationManager is not null)
        {
            NavigationManager.NavigateTo($"reserveringen/bewerken/{id}");
        }
    }
}