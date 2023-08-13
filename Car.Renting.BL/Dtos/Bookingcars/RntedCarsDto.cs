namespace Car.Renting.BL;
public class RntedCarsDto
{
    public Guid CarId { get; set; } = Guid.NewGuid();
    public string? CarName { get; set; } 
    public int QuantityOfCars { get; set; }
    public DateTime RentDuration { get; set; }

}
