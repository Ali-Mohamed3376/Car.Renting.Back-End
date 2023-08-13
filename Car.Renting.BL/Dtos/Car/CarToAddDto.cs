namespace Car.Renting.BL;

public class CarToAddDto
{
    public string ModelName { get; set; } = string.Empty;
    public string ModelType { get; set; } = string.Empty;
    public int ModelYear { get; set; }
    public string BrandName { get; set; } = string.Empty;
    public int Power { get; set; }
}
