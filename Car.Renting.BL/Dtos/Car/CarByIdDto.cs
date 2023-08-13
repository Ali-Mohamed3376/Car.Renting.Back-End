namespace Car.Renting.BL.Dtos.Car;
public class CarByIdDto
{
    public Guid Id { get; set; }
    public string ModelName { get; set; } = string.Empty;
    public string ModelType { get; set; } = string.Empty;
    public int ModelYear { get; set; }
    public string BrandName { get; set; } = string.Empty;
    public int Power { get; set; }
    public int Counter { get; set; }
}
