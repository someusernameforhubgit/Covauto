using Covauto.Shared.DTO.Reservering;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Covauto.Blazor.Pages.Reserveringen.Overzicht;

public partial class ReserveringenOverzicht : ComponentBase
{
    [Inject]
    private HttpClient HttpClient { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private IEnumerable<ReserveringListItem> reserveringen = [];
    
    protected override async Task OnInitializedAsync()
    {
        reserveringen = await HttpClient.GetFromJsonAsync<IEnumerable<ReserveringListItem>>("api/reserveringen");
    }
}