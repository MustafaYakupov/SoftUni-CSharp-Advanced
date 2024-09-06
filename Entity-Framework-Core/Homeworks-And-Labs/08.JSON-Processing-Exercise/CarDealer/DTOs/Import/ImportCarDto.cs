﻿namespace CarDealer.DTOs.Import;

public class ImportCarDto
{
    public string Make { get; set; }

    public string Model { get; set; }

    public long TravelledDistance { get; set; }
    public ICollection<int> PartsId { get; set; }
}
