using Covauto.Shared.DTO.Rit;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

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

    protected override async Task OnInitializedAsync()
    {
        var result = await HttpClient.GetFromJsonAsync<RitItem>($"api/Rit/{Id}");

        rit = new RitItem
        {
            ID = result.ID,
            AutoId = result.AutoId,
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