using Car.Renting.DAL.Data;

namespace Car.Renting.DAL;
public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Nationality { get; set; } = string.Empty;
    public string DrivingLicenseNo { get; set; } = string.Empty;
    public string AdvancedPayment { get; set; } = string.Empty;
    public List<BookingCars> BookingCars { get; set; } = new();
}
