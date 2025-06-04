using System.Net.Http.Json;
using Covauto.Shared.DTO.Auto;
using Covauto.Shared.DTO.Reservering;
using Covauto.Shared.DTO.Gebruiker;
using Microsoft.AspNetCore.Components;

namespace Covauto.Blazor.Pages.Reserveringen.Aanmaken;

public partial class ReserveringenAanmaken
{
    [Inject] 
    private HttpClient Http { get; set; } = null!;
    
    [Inject] 
    private NavigationManager NavigationManager { get; set; } = null!;

    private ReserveringMaakItem reservering = new();
    private List<AutoListItem> autos = new();
    private List<GebruikerListItem> gebruikers = new();
    private DateTime beginDatum = DateTime.Today;
    private DateTime eindDatum = DateTime.Today;
    private string? errorMessage;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            autos = await Http.GetFromJsonAsync<List<AutoListItem>>("api/Auto") ?? new List<AutoListItem>();
            gebruikers = await Http.GetFromJsonAsync<List<GebruikerListItem>>("api/Gebruiker") ?? new List<GebruikerListItem>();
        }
        catch (Exception ex)
        {
            errorMessage = $"Error: {ex.Message}";
        }
    }

    public async Task Submit()
    {
        try
        {
            reservering.Begin = beginDatum;
            reservering.End = eindDatum;
            if (reservering.GebruikerID == 0)
            {
                errorMessage = "Selecteer een gebruiker";
                return;
            }

            var response = await Http.PostAsJsonAsync("api/Reservering", reservering);
            
            if (response.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/reserveringen");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                errorMessage = $"Error: {errorContent}";
            }
        }
        catch (Exception ex)
        {
            errorMessage = $"Error: {ex.Message}";
        }
    }

    public void Annuleren()
    {
        NavigationManager.NavigateTo("/reserveringen");
    }
}
