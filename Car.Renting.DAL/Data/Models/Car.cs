using Car.Renting.DAL.Data;

namespace Car.Renting.DAL;
public class Car
{
    public Guid Id { get; set; }
    public string ModelName { get; set; } = string.Empty;
    public string ModelType { get; set; } = string.Empty;
    public int ModelYear { get; set; }
    public string BrandName { get; set; } = string.Empty;
    public int Power { get; set; }
    public int Counter { get; set; }
    public List<BookingCars> BookingCars { get; set; } = new();
}
