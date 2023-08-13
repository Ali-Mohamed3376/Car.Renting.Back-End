namespace Car.Renting.DAL.Data;

public class BookingCars
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public DateTime TransactionDate { get; set; }
    public List<RentedCars> RentedCars { get; set; } = null!;

}
