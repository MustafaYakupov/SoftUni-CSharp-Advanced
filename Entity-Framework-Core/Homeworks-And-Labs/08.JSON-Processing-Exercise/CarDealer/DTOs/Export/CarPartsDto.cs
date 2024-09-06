using Newtonsoft.Json;

namespace CarDealer.DTOs.Export;

public class CarPartsDto
{
    [JsonProperty("car")]
    public ExportCarDto Car { get; set; }

    [JsonProperty("parts")]
    public ICollection<ExportPartDto> Parts { get; set; }
}
