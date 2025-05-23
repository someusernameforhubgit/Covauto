using System.Net.Http.Json;
using Covauto.Shared.DTO.Auto;
using Covauto.Shared.DTO.Reservering;
using Microsoft.AspNetCore.Components;

namespace Covauto.Blazor.Pages.Reserveringen.Bewerken;

public partial class ReserveringenBewerken : ComponentBase
{
    [Parameter]
    public int Id { get; set; }

    [Inject]
    private HttpClient Http { get; set; } = null!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    private ReserveringUpdateItem reservering = new();
    private List<AutoListItem> autos = new();
    private DateTime beginDatum = DateTime.Today;
    private DateTime eindDatum = DateTime.Today;

    protected override async Task OnInitializedAsync()
    {
        autos = await Http.GetFromJsonAsync<List<AutoListItem>>("api/Auto");

        if (Id > 0 && Http is not null)
        {
            var result = await Http.GetFromJsonAsync<ReserveringItem>($"api/Reservering/{Id}");
            if (result is not null)
            {
                reservering = new ReserveringUpdateItem
                {
                    ID = result.ID,
                    AutoID = result.AutoID,
                    Begin = result.Begin,
                    End = result.End
                };
                
                beginDatum = reservering.Begin.HasValue ? reservering.Begin.Value.Date : DateTime.Today;
                eindDatum = reservering.End.HasValue ? reservering.End.Value.Date : DateTime.Today;
            }
        }
    }

    private async Task Save()
    {
        if (reservering is null || Http is null || NavigationManager is null) return;

        reservering.Begin = beginDatum;
        reservering.End = eindDatum;

        var response = await Http.PutAsJsonAsync($"api/Reservering/{Id}", reservering);
        if (response.IsSuccessStatusCode)
        {
            NavigationManager.NavigateTo("/reserveringen");
        }
    }

    private async Task Delete()
    {
        if (Http is null || NavigationManager is null) return;
        
        var response = await Http.DeleteAsync($"api/Reservering/{Id}");
        if (response.IsSuccessStatusCode)
        {
            NavigationManager.NavigateTo("/reserveringen");
        }
    }

    private void Cancel()
    {
        NavigationManager.NavigateTo("/reserveringen");
    }
}