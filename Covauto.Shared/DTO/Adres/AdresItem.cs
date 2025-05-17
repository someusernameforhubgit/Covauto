using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Covauto.Shared.DTO.Adres;

public class AdresItem
{
    [Required]
    [JsonPropertyName("plaats")]
    public string Plaats { get; set; }
    
    [JsonPropertyName("ritid")]
    public int RitID { get; set; }
    
    [Required]
    [JsonPropertyName("straat")]
    public string Straat { get; set; }
    
    [Required]
    [JsonPropertyName("huisnummer")]
    public string Huisnummer { get; set; }
    
    [Required]
    [JsonPropertyName("land")]
    public string Land { get; set; }
}