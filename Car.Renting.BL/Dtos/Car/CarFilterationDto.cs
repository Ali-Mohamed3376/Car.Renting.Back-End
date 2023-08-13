namespace Car.Renting.BL.Dtos.Car;
public class CarFilterationDto
{
    public string ModelName { get; set; } = string.Empty;
    public string BrandName { get; set; } = string.Empty;
    public int ModelYear { get; set; }
    public int Counter { get; set; }
}
