using Car.Renting.DAL.Data;

namespace Car.Renting.DAL;

public class RentedCars
{
    public Guid BookingCarsId { get; set; }
    public BookingCars? Booking { get; set; }
    public Guid CarId { get; set; }
    public DateTime RentDuration { get; set; }
    public int Quantity { get; set; }
}
