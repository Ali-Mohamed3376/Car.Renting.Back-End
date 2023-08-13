using Car.Renting.DAL;

namespace Car.Renting.BL;
public class BookingToAddDto
{
    public Guid CustomerId { get; set; } = Guid.NewGuid();
    public CustomerToAddDto? Customer { get; set; }
    public DateTime TransactionDate { get; set; }
    public List<RntedCarsDto> RntedCars { get; set; }

}
