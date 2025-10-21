using System.Text.Json.Serialization;

namespace api.Models.DTOs;

public class AddressDTO
{
    [JsonPropertyName("street")]
    public string? Street { get; set; }

    [JsonPropertyName("number")]
    public string? Number { get; set; }

    [JsonPropertyName("floor")]
    public string? Floor { get; set; }

    [JsonPropertyName("door")]
    public string? Door { get; set; }

    [JsonPropertyName("postal_code")]
    public string? PostalCode { get; set; }

    [JsonPropertyName("town_name")]
    public string? TownName { get; set; }

    public void SetFloor(int? floor)
    {
        Floor = floor != null ? floor.ToString() : nameof(FloorType.St);
    }
}
